using System.IO.Compression;
using System.Text;
using System.Text.Json;
using LilithsSoul.Config;
using LilithsSoul.Foundation;
using LilithsSoul.Services;
using LilithsMind.Network;

// ============================================================
//  SyncReceiver — LilithsSoul
//  LilithsSoul/Network/SyncReceiver.cs
//
//  Intercepts system chat messages from Heart and reassembles
//  the tiered compressed ServerSyncPayload.
//
//  [CHANGED] Complete rewrite for tiered sync architecture.
//            Previous version accumulated one flat chunk list.
//            Now maintains a separate accumulator per SyncTier.
//            Each tier is an independent compressed blob with its
//            own begin/end sentinels and checksum validation.
//
//  Protocol:
//  ──────────
//  [[LG:begin:T:N:CKSUM]]   — begin sentinel — initialise tier T state
//  [[LG:T:NNNN]]<data>      — chunk — accumulate content for tier T
//  [[LG:end:T:CKSUM]]       — end sentinel — validate + decompress + apply
//
//  Decompression pipeline:
//  ────────────────────────
//  Accumulated Base64 chunks → concat → Base64 decode → GZip
//  decompress → JSON deserialize → apply to game systems.
//
//  Disk cache:
//  ────────────
//  Disk cache (sync.json) is still written as full JSON from the
//  first Critical tier payload which carries ServerIdentity and
//  PayloadHash. Soul reads from disk on reconnect to pre-apply
//  before the server payload arrives.
//
//  [PERFORMANCE] Per-message check is O(1) string prefix match.
//                Decompression and injection run once per tier
//                on end sentinel receipt — not per-frame.
// ============================================================

namespace LilithsSoul.Network;

public static class SyncReceiver
{
    private const string LOG_SOURCE   = "LilithsSoul.SyncReceiver";
    private const string BEGIN_PREFIX = "[[LG:begin:";
    private const string CHUNK_PREFIX = "[[LG:";
    private const string END_PREFIX   = "[[LG:end:";

    // Per-tier accumulation state.
    static readonly Dictionary<int, List<string>> _tierChunks    = new();
    static readonly Dictionary<int, string>       _tierChecksums = new();
    static readonly Dictionary<int, int>          _tierExpected  = new();

    // World readiness and pending payload state.
    static bool               _clientWorldReady;
    static ServerSyncPayload? _pendingPayload;
    static string             _connectionString = string.Empty;

    // Tracks identity received in Critical tier for disk writes.
    static string _serverIdentity = string.Empty;
    static string _payloadHash    = string.Empty;

    // ── Called from ClientChatSystemPatch ────────────────────

    /// <summary>
    /// Inspects an incoming system message. Returns true if consumed.
    /// </summary>
    public static bool TryHandleMessage(string message)
    {
        if (string.IsNullOrEmpty(message)) return false;

        if (message.StartsWith(BEGIN_PREFIX))
        {
            HandleBeginSentinel(message);
            return true;
        }

        if (message.StartsWith(END_PREFIX))
        {
            HandleEndSentinel(message);
            return true;
        }

        if (message.StartsWith(CHUNK_PREFIX))
        {
            HandleChunk(message);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Called by ClientInitPatch when the client ECS world is ready.
    /// </summary>
    public static void NotifyWorldReady(string connectionString)
    {
        _clientWorldReady = true;
        _connectionString = connectionString;

        LocalizationInjector.BuildLookupTable();
        RecipePatcher.BuildNameMap();

        TryPreApplyCachedSync(connectionString);

        if (_pendingPayload != null)
        {
            SoulLogger.Info(LOG_SOURCE, "Client world now ready — applying queued sync payload.");
            ApplyPayload(_pendingPayload);
            _pendingPayload = null;
        }
    }

    // ── Sentinel handlers ─────────────────────────────────────

    static void HandleBeginSentinel(string message)
    {
        // Format: [[LG:begin:T:N:CKSUM]]
        var inner = message[BEGIN_PREFIX.Length..^2];
        var parts = inner.Split(':');
        if (parts.Length != 3) { SoulLogger.Warning(LOG_SOURCE, $"Malformed begin sentinel: '{message}'"); return; }

        if (!int.TryParse(parts[0], out int tier) || !int.TryParse(parts[1], out int count))
        {
            SoulLogger.Warning(LOG_SOURCE, $"Could not parse tier/count from: '{message}'");
            return;
        }

        _tierChunks[tier]    = new List<string>(count);
        _tierChecksums[tier] = parts[2];
        _tierExpected[tier]  = count;

        SoulLogger.Debug(LOG_SOURCE, $"Tier {tier} begin — expecting {count} chunk(s).");
    }

    static void HandleChunk(string message)
    {
        // Format: [[LG:T:NNNN]]<data>
        int closeBracket = message.IndexOf("]]", CHUNK_PREFIX.Length, StringComparison.Ordinal);
        if (closeBracket < 0) return;

        var header  = message[CHUNK_PREFIX.Length..closeBracket];
        var content = message[(closeBracket + 2)..];
        var hParts  = header.Split(':');
        if (hParts.Length != 2) return;

        if (!int.TryParse(hParts[0], out int tier)) return;

        if (!_tierChunks.TryGetValue(tier, out var chunks))
        {
            SoulLogger.Warning(LOG_SOURCE, $"Chunk for tier {tier} with no begin sentinel — discarding.");
            return;
        }

        chunks.Add(content);
    }

    static void HandleEndSentinel(string message)
    {
        // Format: [[LG:end:T:CKSUM]]
        var inner = message[END_PREFIX.Length..^2];
        var parts = inner.Split(':');
        if (parts.Length != 2) { SoulLogger.Warning(LOG_SOURCE, $"Malformed end sentinel: '{message}'"); return; }

        if (!int.TryParse(parts[0], out int tier))
        {
            SoulLogger.Warning(LOG_SOURCE, $"Could not parse tier from end sentinel: '{message}'");
            return;
        }

        string receivedChecksum = parts[1];

        if (!_tierChunks.TryGetValue(tier, out var chunks))
        {
            SoulLogger.Warning(LOG_SOURCE, $"End sentinel for tier {tier} with no accumulated chunks.");
            return;
        }

        // Validate chunk count.
        if (_tierExpected.TryGetValue(tier, out int expected) && chunks.Count != expected)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Tier {tier} count mismatch — expected {expected}, got {chunks.Count}. Discarding.");
            ClearTier(tier);
            return;
        }

        // Validate checksum.
        var assembled = string.Concat(chunks);
        var hash      = ComputeChecksum(assembled);

        if (!string.Equals(hash, receivedChecksum, StringComparison.OrdinalIgnoreCase))
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Tier {tier} checksum mismatch — expected {receivedChecksum}, got {hash}. Discarding.");
            ClearTier(tier);
            return;
        }

        SoulLogger.Debug(LOG_SOURCE, $"Tier {tier} complete — {chunks.Count} chunk(s), checksum valid.");
        ProcessTierBlob(tier, assembled);
        ClearTier(tier);
    }

    // ── Tier processing ───────────────────────────────────────

    static void ProcessTierBlob(int tier, string base64Data)
    {
        try
        {
            var compressed = Convert.FromBase64String(base64Data);
            var json       = GZipDecompress(compressed);

            SoulLogger.Debug(LOG_SOURCE,
                $"Tier {tier} decompressed: {compressed.Length} bytes → {json.Length} chars.");

            switch ((SyncTier)tier)
            {
                case SyncTier.Critical: ProcessCriticalTier(json); break;
                case SyncTier.High:     ProcessHighTier(json);     break;
                case SyncTier.Normal:   ProcessNormalTier(json);   break;
                case SyncTier.Low:      ProcessLowTier(json);      break;
                default: SoulLogger.Warning(LOG_SOURCE, $"Unknown tier {tier}."); break;
            }
        }
        catch (Exception ex)
        {
            SoulLogger.Error(LOG_SOURCE, $"Failed to process tier {tier} blob: {ex.Message}");
        }
    }

    static void ProcessCriticalTier(string json)
    {
        var opts    = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var section = JsonSerializer.Deserialize<CriticalTierSection>(json, opts);
        if (section == null) return;

        _serverIdentity = section.ServerIdentity ?? string.Empty;
        _payloadHash    = section.PayloadHash    ?? string.Empty;

        SoulLogger.Info(LOG_SOURCE,
            $"Critical tier received from '{_serverIdentity}' (hash: {_payloadHash}).");

        var payload = new ServerSyncPayload
        {
            ServerIdentity       = _serverIdentity,
            PayloadHash          = _payloadHash,
            DisplayNameOverrides = section.DisplayNameOverrides ?? new(),
            TooltipOverrides     = section.TooltipOverrides     ?? new(),
        };

        if (!string.IsNullOrEmpty(_connectionString))
            ServerRegistry.Register(_connectionString, _serverIdentity);

        WriteToDiskIfChanged(payload);

        if (_clientWorldReady)
            LocalizationInjector.Inject(payload);
        else
            _pendingPayload = payload;
    }

    static void ProcessHighTier(string json)
    {
        var opts    = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var section = JsonSerializer.Deserialize<HighTierSection>(json, opts);
        if (section == null) return;

        SoulLogger.Info(LOG_SOURCE,
            $"High tier received — {section.RecipeOverrides?.Count ?? 0} recipe(s), " +
            $"{section.StationRecipeOverrides?.Count ?? 0} station(s).");

        if (!_clientWorldReady)
        {
            SoulLogger.Debug(LOG_SOURCE, "World not ready — High tier queued.");
            if (_pendingPayload != null)
                MergeHighSection(_pendingPayload, section);
            return;
        }

        ApplyHighSection(section);
    }

    static void ProcessNormalTier(string json)
        => SoulLogger.Debug(LOG_SOURCE, "Normal tier received — no handlers registered yet.");

    static void ProcessLowTier(string json)
        => SoulLogger.Debug(LOG_SOURCE, "Low tier received — no handlers registered yet.");

    // ── Apply helpers ─────────────────────────────────────────

    static void ApplyPayload(ServerSyncPayload payload)
    {
        LocalizationInjector.Inject(payload);
        RecipePatcher.Apply(payload.RecipeOverrides);
        RecipePatcher.ApplyStationRecipes(payload.StationRecipeOverrides);
        RecipePatcher.ApplyPlayerRecipes(payload.PlayerRecipesToAdd, payload.PlayerRecipesToRemove);
    }

    static void ApplyHighSection(HighTierSection section)
    {
        if (section.RecipeOverrides != null)
            RecipePatcher.Apply(section.RecipeOverrides);

        if (section.StationRecipeOverrides != null)
            RecipePatcher.ApplyStationRecipes(section.StationRecipeOverrides);

        if (section.PlayerRecipesToAdd != null || section.PlayerRecipesToRemove != null)
            RecipePatcher.ApplyPlayerRecipes(
                section.PlayerRecipesToAdd    ?? new(),
                section.PlayerRecipesToRemove ?? new());
    }

    static void MergeHighSection(ServerSyncPayload payload, HighTierSection section)
    {
        if (section.RecipeOverrides != null)
            foreach (var (k, v) in section.RecipeOverrides)
                payload.RecipeOverrides[k] = v;

        if (section.StationRecipeOverrides != null)
            foreach (var (k, v) in section.StationRecipeOverrides)
                payload.StationRecipeOverrides[k] = v;

        if (section.PlayerRecipesToAdd != null)
            payload.PlayerRecipesToAdd.AddRange(section.PlayerRecipesToAdd);

        if (section.PlayerRecipesToRemove != null)
            payload.PlayerRecipesToRemove.AddRange(section.PlayerRecipesToRemove);
    }

    // ── Disk cache ────────────────────────────────────────────

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
                    SoulLogger.Debug(LOG_SOURCE, $"Hash unchanged ({payload.PayloadHash}) — skipping disk write.");
                    return;
                }
            }
            catch { /* Malformed cache — overwrite. */ }
        }

        try
        {
            Directory.CreateDirectory(SoulPathIndex.ServerDir(payload.ServerIdentity));
            File.WriteAllText(syncFile,
                JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true }));
            SoulLogger.Info(LOG_SOURCE, $"Sync payload cached to '{syncFile}'.");
        }
        catch (Exception ex)
        {
            SoulLogger.Warning(LOG_SOURCE, $"Failed to write sync payload to disk: {ex.Message}");
        }
    }

    static void TryPreApplyCachedSync(string connectionString)
    {
        ServerRegistry.Load();

        if (string.IsNullOrEmpty(connectionString))
        {
            SoulLogger.Debug(LOG_SOURCE, "No connection string — cannot pre-apply cached sync.");
            return;
        }

        if (!ServerRegistry.TryGetFolderName(connectionString, out var folderName))
        {
            SoulLogger.Info(LOG_SOURCE, $"No cached sync for '{connectionString}' — waiting for payload.");
            return;
        }

        var syncFile = SoulPathIndex.SyncFile(folderName);
        if (!File.Exists(syncFile))
        {
            SoulLogger.Info(LOG_SOURCE, $"Sync file not found for '{folderName}' — waiting for payload.");
            return;
        }

        try
        {
            var json    = File.ReadAllText(syncFile);
            var payload = JsonSerializer.Deserialize<ServerSyncPayload>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (payload == null) { SoulLogger.Warning(LOG_SOURCE, "Cached sync.json deserialized to null."); return; }

            SoulLogger.Info(LOG_SOURCE,
                $"Pre-applying cached sync for '{folderName}' (hash: {payload.PayloadHash}).");

            ApplyPayload(payload);
        }
        catch (Exception ex)
        {
            SoulLogger.Warning(LOG_SOURCE, $"Failed to pre-apply cached sync: {ex.Message}");
        }
    }

    // ── Compression ───────────────────────────────────────────

    static string GZipDecompress(byte[] compressed)
    {
        using var input  = new MemoryStream(compressed);
        using var gzip   = new GZipStream(input, CompressionMode.Decompress);
        using var output = new MemoryStream();
        gzip.CopyTo(output);
        return Encoding.UTF8.GetString(output.ToArray());
    }

    static void ClearTier(int tier)
    {
        _tierChunks.Remove(tier);
        _tierChecksums.Remove(tier);
        _tierExpected.Remove(tier);
    }

    static string ComputeChecksum(string input)
    {
        var bytes = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes)[..6];
    }

    // ── Tier section DTOs ─────────────────────────────────────

    sealed class CriticalTierSection
    {
        public string?                     ServerIdentity       { get; set; }
        public string?                     PayloadHash          { get; set; }
        public Dictionary<string, string>? DisplayNameOverrides { get; set; }
        public Dictionary<string, string>? TooltipOverrides     { get; set; }
    }

    sealed class HighTierSection
    {
        public Dictionary<string, LilithRecipeData>?  RecipeOverrides        { get; set; }
        public Dictionary<string, LilithStationData>? StationRecipeOverrides { get; set; }
        public List<string>?                           PlayerRecipesToAdd     { get; set; }
        public List<string>?                           PlayerRecipesToRemove  { get; set; }
    }
}