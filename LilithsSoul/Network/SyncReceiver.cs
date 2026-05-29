using System.Text.Json;
using LilithsSoul.Config;
using LilithsSoul.Foundation;
using LilithsSoul.Services;
using LilithsMind.Network;

// ============================================================
//  SyncReceiver — LilithsSoul
//
//  Intercepts system chat messages from Heart and reassembles
//  the chunked ServerSyncPayload.
//
//  Chunk protocol:
//  ───────────────
//  Heart sends N messages of the form [[LG:N]]<content>,
//  followed by a final [[LG:end]] sentinel.
//  SyncReceiver accumulates content strings in order and
//  processes the full JSON when end is received.
//
//  Integration point:
//  ──────────────────
//  ClientChatSystemPatch calls TryHandleMessage(string) for
//  every incoming system message. Returns true if the message
//  was a LilithsGarden chunk (consumed), false otherwise.
//
//  [CHANGED] ApplyPayload now calls IconPatcher.ClearPrevious()
//            and IconPatcher.Apply() alongside the existing
//            LocalizationInjector and RecipePatcher calls.
//            IconPatcher must run after LocalizationInjector
//            as it is independent but benefits from world being
//            confirmed ready.
//
//  [CHANGED] NotifyWorldReady now calls IconPatcher.BuildSpriteMaps()
//            in addition to LocalizationInjector.BuildLookupTable()
//            and RecipePatcher.BuildNameMap().
//
//  Client Payload Application Order (FIXED — DO NOT REORDER):
//  ────────────────────────────────────────────────────────────
//  1. LocalizationInjector.Inject()         — text into _LocalizedStrings
//  2. IconPatcher.Apply()                   — sprites into ManagedItemData
//  3. RecipePatcher.Apply()                 — recipe ECS data
//  4. RecipePatcher.ApplyStationRecipes()   — station buffer patches
//  5. RecipePatcher.ApplyPlayerRecipes()    — player buffer patches
//
//  [PERFORMANCE] Per-message check is a string.StartsWith on the
//                hot chat path — effectively free outside connect.
//                Deserialization and disk I/O run once per connect.
// ============================================================

namespace LilithsSoul.Network;

public static class SyncReceiver
{
    private const string LOG_SOURCE   = "LilithsSoul.SyncReceiver";
    private const string CHUNK_PREFIX = "[[LG:";
    private const string CHUNK_END    = "[[LG:end]]";

    static readonly List<string> _chunks = [];

    static bool _clientWorldReady;
    static ServerSyncPayload? _pendingPayload;
    static string _connectionString = string.Empty;

    // ── Called from ClientChatSystemPatch ────────────────────

    /// <summary>
    /// Inspects an incoming system message. If it is a LilithsGarden
    /// chunk, accumulates it and returns true (consumed).
    /// Returns false for unrelated messages.
    /// </summary>
    public static bool TryHandleMessage(string message)
    {
        if (string.IsNullOrEmpty(message)) return false;

        if (message == CHUNK_END)
        {
            ProcessAccumulatedChunks();
            return true;
        }

        if (message.StartsWith(CHUNK_PREFIX))
        {
            int closeBracket = message.IndexOf("]]", CHUNK_PREFIX.Length,
                StringComparison.Ordinal);

            if (closeBracket >= 0)
            {
                _chunks.Add(message[(closeBracket + 2)..]);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Called by ClientInitPatch when the client ECS world is ready.
    /// Builds all lookup tables, pre-applies cached sync, and applies
    /// any payload that arrived before world was ready.
    ///
    /// [CHANGED] Now calls IconPatcher.BuildSpriteMaps() alongside
    ///           LocalizationInjector.BuildLookupTable() and
    ///           RecipePatcher.BuildNameMap().
    /// </summary>
    public static void NotifyWorldReady(string connectionString)
    {
        _clientWorldReady = true;
        _connectionString = connectionString;

        // Build all lookup tables now that game data is available.
        LocalizationInjector.BuildLookupTable();
        RecipePatcher.BuildNameMap();

        // [CHANGED] Build sprite maps for IconPatcher.
        // Resources.FindObjectsOfTypeAll<Sprite>() requires world ready.
        IconPatcher.BuildSpriteMaps();

        TryPreApplyCachedSync(connectionString);

        if (_pendingPayload != null)
        {
            SoulLogger.Info(LOG_SOURCE,
                "Client world now ready — applying queued sync payload.");
            ApplyPayload(_pendingPayload);
            _pendingPayload = null;
        }
    }

    // ── Internal ─────────────────────────────────────────────

    static void TryPreApplyCachedSync(string connectionString)
    {
        ServerRegistry.Load();

        if (string.IsNullOrEmpty(connectionString))
        {
            SoulLogger.Debug(LOG_SOURCE,
                "No connection string — cannot pre-apply cached sync.");
            return;
        }

        if (!ServerRegistry.TryGetFolderName(connectionString, out var folderName))
        {
            SoulLogger.Info(LOG_SOURCE,
                $"No cached sync for '{connectionString}' — " +
                "waiting for server payload.");
            return;
        }

        var syncFile = SoulPathIndex.SyncFile(folderName);
        if (!File.Exists(syncFile))
        {
            SoulLogger.Info(LOG_SOURCE,
                $"Sync file not found for '{folderName}' — " +
                "waiting for server payload.");
            return;
        }

        try
        {
            var json    = File.ReadAllText(syncFile);
            var payload = JsonSerializer.Deserialize<ServerSyncPayload>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (payload == null)
            {
                SoulLogger.Warning(LOG_SOURCE,
                    $"Cached sync.json for '{folderName}' deserialized to null.");
                return;
            }

            SoulLogger.Info(LOG_SOURCE,
                $"Pre-applying cached sync for '{folderName}' " +
                $"(hash: {payload.PayloadHash}) before UI builds.");

            ApplyPayload(payload);
        }
        catch (Exception ex)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Failed to pre-apply cached sync for '{folderName}': {ex.Message}");
        }
    }

    static void ProcessAccumulatedChunks()
    {
        if (_chunks.Count == 0)
        {
            SoulLogger.Warning(LOG_SOURCE,
                "Received [[LG:end]] but chunk list is empty — ignoring.");
            return;
        }

        var json = string.Concat(_chunks);
        _chunks.Clear();

        try
        {
            var payload = JsonSerializer.Deserialize<ServerSyncPayload>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (payload == null)
            {
                SoulLogger.Warning(LOG_SOURCE,
                    "Deserialized payload is null — ignoring.");
                return;
            }

            SoulLogger.Info(LOG_SOURCE,
                $"Sync payload received from '{payload.ServerIdentity}' " +
                $"(hash: {payload.PayloadHash}, " +
                $"appearances: {payload.ItemAppearanceOverrides.Count}, " +
                $"recipes: {payload.RecipeOverrides.Count}).");

            if (!string.IsNullOrEmpty(_connectionString))
                ServerRegistry.Register(_connectionString, payload.ServerIdentity);

            WriteToDiskIfChanged(payload);

            if (_clientWorldReady)
                ApplyPayload(payload);
            else
                _pendingPayload = payload;
        }
        catch (Exception ex)
        {
            SoulLogger.Error(LOG_SOURCE,
                $"Failed to process sync payload: {ex.Message}");
            _chunks.Clear();
        }
    }

    static void ApplyPayload(ServerSyncPayload payload)
    {
        // 1. Localization — display names and tooltips into _LocalizedStrings.
        LocalizationInjector.Inject(payload);

        // 2. Icons — sprites into ManagedItemData.Icon.
        // [CHANGED] ClearPrevious restores original icons before applying new ones.
        IconPatcher.ClearPrevious();
        IconPatcher.Apply(payload);

        // 3. Recipe patching — ingredients, outputs, craft duration.
        RecipePatcher.Apply(payload.RecipeOverrides);

        // 4. Station recipe patching — WorkstationRecipesBuffer on placed stations.
        RecipePatcher.ApplyStationRecipes(payload.StationRecipeOverrides);

        // 5. Player recipe patching — add/remove from client player entity buffer.
        RecipePatcher.ApplyPlayerRecipes(
            payload.PlayerRecipesToAdd,
            payload.PlayerRecipesToRemove);
    }

    static void WriteToDiskIfChanged(ServerSyncPayload payload)
    {
        var syncFile = SoulPathIndex.SyncFile(payload.ServerIdentity);

        if (File.Exists(syncFile))
        {
            try
            {
                var existing = JsonSerializer.Deserialize<ServerSyncPayload>(
                    File.ReadAllText(syncFile),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (existing?.PayloadHash == payload.PayloadHash)
                {
                    SoulLogger.Debug(LOG_SOURCE,
                        $"Payload hash unchanged ({payload.PayloadHash}) " +
                        "— skipping disk write.");
                    return;
                }
            }
            catch
            {
                // Malformed cache — overwrite below.
            }
        }

        try
        {
            Directory.CreateDirectory(SoulPathIndex.ServerDir(payload.ServerIdentity));
            File.WriteAllText(syncFile,
                JsonSerializer.Serialize(payload,
                    new JsonSerializerOptions { WriteIndented = true }));

            SoulLogger.Info(LOG_SOURCE,
                $"Sync payload cached to '{syncFile}'.");
        }
        catch (Exception ex)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Failed to write sync payload to disk: {ex.Message}");
        }
    }
}