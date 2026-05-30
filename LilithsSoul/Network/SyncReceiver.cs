using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using LilithsSoul.Config;
using LilithsSoul.Foundation;
using LilithsSoul.Services;
using LilithsMind.Network;

// ============================================================
//  SyncReceiver — LilithsSoul
//
//  Intercepts system chat messages from Heart and reassembles
//  the tiered, compressed ServerSyncPayload.
//
//  [CHANGED] Migrated from the old flat protocol to the tiered
//            protocol that SyncSender/SyncPayloadCache emit.
//            Previously this file expected:
//                [[LG:N]]<plain-json-fragment>  ... [[LG:end]]
//            and simply concatenated fragments and JSON-parsed
//            the result. The sender was migrated to per-tier
//            GZip+base64 chunks with begin/end sentinels and
//            checksums some time ago; this receiver was never
//            updated, so live sync silently did nothing (the new
//            "[[LG:end:T:CKSUM]]" never matched the old exact
//            "[[LG:end]]" sentinel, and even if it had, the body
//            is base64+gzip, not plain JSON). This rewrite brings
//            the receive path back in line with the sender.
//
//  [CHANGED] Now uses the shared LilithsMind.Network.SyncTierEnum
//            instead of locally-duplicated tier int constants.
//            SyncTierEnum was relocated from LilithsHeart.Network
//            into LilithsMind so both sender and receiver reference
//            one definition — see SyncTierEnum.cs.
//
//  Wire protocol (mirrors SyncSender.BuildTierMessages):
//  ──────────────────────────────────────────────────────
//    [[LG:begin:T:N:CKSUM]]     — open tier T, expect N chunks
//    [[LG:T:NNNN]]<base64>      — chunk NNNN of tier T (zero-padded)
//    [[LG:end:T:CKSUM]]         — close tier T, verify + process
//
//  Each tier is independent and applied the moment its end
//  sentinel arrives — Critical (names/icons) lands before High
//  (recipes) without waiting for the whole payload.
//
//  Decode per tier (reverse of SyncPayloadCache.BuildBlob):
//    concat chunks in index order → base64 string
//      → verify SHA256(base64)[..8] == checksum
//      → Convert.FromBase64String → GZipStream decompress
//      → UTF-8 → JsonSerializer.Deserialize<ServerSyncPayload>
//
//  The per-tier JSON is only a *slice* of ServerSyncPayload
//  (e.g. Critical carries just ItemAppearanceOverrides). The
//  missing fields deserialize to their empty defaults, which is
//  exactly what we want — each slice is applied by ApplyTier()
//  and merged into a single cached payload for disk.
//
//  Integration point:
//  ──────────────────
//  ClientChatSystemPatch calls TryHandleMessage(string) for
//  every incoming system message. Returns true if the message
//  was a LilithsGarden sentinel/chunk (consumed), false otherwise.
//
//  Per-tier Application Order (FIXED — DO NOT REORDER):
//  ─────────────────────────────────────────────────────
//  Critical: 1. LocalizationInjector.Inject()   — text  → _LocalizedStrings
//            2. IconPatcher.ClearPrevious()      — restore prior icons
//            3. IconPatcher.Apply()              — sprites → ManagedItemData
//  High:     4. RecipePatcher.Apply()            — recipe ECS data
//            5. RecipePatcher.ApplyStationRecipes() — station buffers
//  Normal:   6. RecipePatcher.ApplyPlayerRecipes()  — player buffer
//  (The full-payload path ApplyPayload() runs the same order in
//   one shot — used for the disk-cached pre-apply only.)
//
//  [PERFORMANCE] Per-message inspection is a handful of ordinal
//                StartsWith checks on the hot chat path —
//                effectively free outside a connect burst.
//                Checksum + GZip decompress + deserialize run
//                once per tier per connect (≤5 tiers), not per
//                message. Disk I/O runs only when the payload
//                hash differs from the cached copy.
//
//  Inspiration: internal symmetry with LilithsHeart's
//               SyncSender + SyncPayloadCache (no external mod) —
//               the receive format is the exact inverse of the
//               send format, kept in one place each side.
// ============================================================

namespace LilithsSoul.Network;

public static class SyncReceiver
{
    private const string LOG_SOURCE = "LilithsSoul.SyncReceiver";

    // Sentinel/chunk prefixes — must be tested in this order because
    // BEGIN_PREFIX and END_PREFIX both start with CHUNK_PREFIX.
    private const string BEGIN_PREFIX = "[[LG:begin:";
    private const string END_PREFIX   = "[[LG:end:";
    private const string CHUNK_PREFIX = "[[LG:";

    // [PERFORMANCE] Reused serializer options — avoids per-call allocation.
    static readonly JsonSerializerOptions _readOptions =
        new() { PropertyNameCaseInsensitive = true };
    static readonly JsonSerializerOptions _writeOptions =
        new() { WriteIndented = true };

    // In-flight tier accumulators, keyed by tier int. An entry exists
    // only between that tier's begin and end sentinels.
    static readonly Dictionary<int, TierAccumulator> _tiers = new();

    // Tiers that arrived before the client world was ready, applied
    // (in tier order) once NotifyWorldReady fires.
    static readonly List<(int tier, ServerSyncPayload payload)> _pendingTiers = [];

    // Merge accumulator — assembles the per-tier slices back into one
    // complete payload for the disk cache. Reset whenever a new
    // PayloadHash is observed.
    static ServerSyncPayload? _merged;
    static string _mergeHash = string.Empty;

    // True when the on-disk cache already matches the current hash, so
    // we can skip rewriting it tier-by-tier this session.
    static bool _cacheUpToDate;

    static bool _clientWorldReady;
    static string _connectionString = string.Empty;

    // ── Called from ClientChatSystemPatch ────────────────────

    /// <summary>
    /// Inspects an incoming system message. If it is a LilithsGarden
    /// sentinel or chunk, handles it and returns true (consumed).
    /// Returns false for unrelated messages.
    /// </summary>
    public static bool TryHandleMessage(string message)
    {
        if (string.IsNullOrEmpty(message)) return false;

        // Order matters: begin/end are more specific than the bare chunk prefix.
        if (message.StartsWith(BEGIN_PREFIX, StringComparison.Ordinal))
        {
            HandleBegin(message);
            return true;
        }

        if (message.StartsWith(END_PREFIX, StringComparison.Ordinal))
        {
            HandleEnd(message);
            return true;
        }

        if (message.StartsWith(CHUNK_PREFIX, StringComparison.Ordinal))
        {
            HandleChunk(message);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Called by ClientInitPatch when the client ECS world is ready.
    /// Builds all lookup tables, pre-applies cached sync, and applies
    /// any tiers that arrived before the world was ready.
    /// </summary>
    public static void NotifyWorldReady(string connectionString)
    {
        _clientWorldReady = true;
        _connectionString = connectionString;

        // Build all lookup tables now that game data is available.
        LocalizationInjector.BuildLookupTable();
        RecipePatcher.BuildNameMap();

        // IconPatcher needs world ready — Resources.FindObjectsOfTypeAll<Sprite>().
        IconPatcher.BuildSpriteMaps();

        TryPreApplyCachedSync(connectionString);

        // Drain any tiers that arrived early, in priority order.
        if (_pendingTiers.Count > 0)
        {
            SoulLogger.Info(LOG_SOURCE,
                $"Client world now ready — applying {_pendingTiers.Count} queued tier(s).");

            foreach (var (tier, payload) in _pendingTiers.OrderBy(t => t.tier))
                ApplyTier(tier, payload);

            _pendingTiers.Clear();
        }
    }

    // ── Sentinel / chunk handlers ────────────────────────────

    // [[LG:begin:T:N:CKSUM]]
    static void HandleBegin(string message)
    {
        var body = StripSentinel(message, BEGIN_PREFIX);
        var parts = body.Split(':');
        if (parts.Length != 3 ||
            !int.TryParse(parts[0], out int tier) ||
            !int.TryParse(parts[1], out int count))
        {
            SoulLogger.Warning(LOG_SOURCE, $"Malformed begin sentinel — ignoring: '{message}'");
            return;
        }

        // A fresh begin replaces any stale accumulator for that tier
        // (e.g. a previous transmission that never completed).
        _tiers[tier] = new TierAccumulator
        {
            ExpectedCount = count,
            Checksum      = parts[2],
        };
    }

    // [[LG:T:NNNN]]<base64>
    static void HandleChunk(string message)
    {
        int close = message.IndexOf("]]", CHUNK_PREFIX.Length, StringComparison.Ordinal);
        if (close < 0)
        {
            SoulLogger.Warning(LOG_SOURCE, "Chunk missing ']]' terminator — ignoring.");
            return;
        }

        var header = message[CHUNK_PREFIX.Length..close];   // "T:NNNN"
        var data   = message[(close + 2)..];                 // base64 fragment

        var parts = header.Split(':');
        if (parts.Length != 2 ||
            !int.TryParse(parts[0], out int tier) ||
            !int.TryParse(parts[1], out int index))
        {
            SoulLogger.Warning(LOG_SOURCE, $"Malformed chunk header — ignoring: '{header}'");
            return;
        }

        if (!_tiers.TryGetValue(tier, out var acc))
        {
            // Chunk arrived without a begin — drop it; the end sentinel
            // will fail the count check and the tier will be discarded.
            SoulLogger.Warning(LOG_SOURCE,
                $"Chunk for tier {tier} with no open accumulator — ignoring.");
            return;
        }

        acc.Chunks[index] = data;
    }

    // [[LG:end:T:CKSUM]]
    static void HandleEnd(string message)
    {
        var body = StripSentinel(message, END_PREFIX);
        var parts = body.Split(':');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int tier))
        {
            SoulLogger.Warning(LOG_SOURCE, $"Malformed end sentinel — ignoring: '{message}'");
            return;
        }

        string expectedChecksum = parts[1];

        if (!_tiers.TryGetValue(tier, out var acc))
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"End for tier {tier} with no open accumulator — ignoring.");
            return;
        }

        // Consume the accumulator regardless of outcome below.
        _tiers.Remove(tier);

        // Verify we received every chunk.
        if (acc.Chunks.Count != acc.ExpectedCount)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Tier {tier} incomplete — got {acc.Chunks.Count}/{acc.ExpectedCount} " +
                "chunk(s). Dropping tier; client should reconnect.");
            return;
        }

        // Reassemble base64 in index order.
        var sb = new StringBuilder();
        for (int i = 0; i < acc.ExpectedCount; i++)
        {
            if (!acc.Chunks.TryGetValue(i, out var part))
            {
                SoulLogger.Warning(LOG_SOURCE,
                    $"Tier {tier} missing chunk {i} — dropping tier.");
                return;
            }
            sb.Append(part);
        }

        var base64 = sb.ToString();

        // Integrity check against the sender's checksum.
        var actualChecksum = ComputeHash(base64);
        if (!string.Equals(actualChecksum, expectedChecksum, StringComparison.Ordinal))
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Tier {tier} checksum mismatch (got {actualChecksum}, " +
                $"expected {expectedChecksum}) — dropping tier.");
            return;
        }

        ProcessTier(tier, base64);
    }

    // ── Tier processing ──────────────────────────────────────

    static void ProcessTier(int tier, string base64)
    {
        ServerSyncPayload? payload;

        try
        {
            var json = Decompress(base64);
            payload  = JsonSerializer.Deserialize<ServerSyncPayload>(json, _readOptions);
        }
        catch (Exception ex)
        {
            SoulLogger.Error(LOG_SOURCE,
                $"Failed to decode tier {tier}: {ex.Message}");
            return;
        }

        if (payload == null)
        {
            SoulLogger.Warning(LOG_SOURCE, $"Tier {tier} deserialized to null — ignoring.");
            return;
        }

        SoulLogger.Info(LOG_SOURCE,
            $"Tier {tier} received from '{payload.ServerIdentity}' " +
            $"(hash: {payload.PayloadHash}).");

        // Map connection → server identity for future cached pre-apply,
        // and merge this slice into the on-disk cache.
        MergeAndCache(tier, payload);

        // Apply now if the world is ready, otherwise defer until it is.
        if (_clientWorldReady)
            ApplyTier(tier, payload);
        else
            _pendingTiers.Add((tier, payload));
    }

    /// <summary>
    /// Applies a single tier's slice. Each tier touches a disjoint part
    /// of the fixed application order, so per-tier application preserves
    /// the same overall ordering guarantees as the full payload.
    /// </summary>
    static void ApplyTier(int tier, ServerSyncPayload payload)
    {
        switch ((SyncTierEnum)tier)
        {
            case SyncTierEnum.Critical:
                LocalizationInjector.Inject(payload);
                IconPatcher.ClearPrevious();
                IconPatcher.Apply(payload);
                break;

            case SyncTierEnum.High:
                RecipePatcher.Apply(payload.RecipeOverrides);
                RecipePatcher.ApplyStationRecipes(payload.StationRecipeOverrides);
                break;

            case SyncTierEnum.Normal:
                RecipePatcher.ApplyPlayerRecipes(
                    payload.PlayerRecipesToAdd,
                    payload.PlayerRecipesToRemove);
                break;

            case SyncTierEnum.Low:
            case SyncTierEnum.Background:
                // Reserved for future modules (Machinations, Grimoire,
                // Menagerie, Bounty). No handler yet — slice is still
                // merged + cached above so nothing is lost.
                SoulLogger.Debug(LOG_SOURCE,
                    $"Tier {tier} received — no handler yet (reserved).");
                break;

            default:
                SoulLogger.Warning(LOG_SOURCE, $"Unknown tier {tier} — ignoring.");
                break;
        }
    }

    // ── Disk cache merge ─────────────────────────────────────

    /// <summary>
    /// Merges a tier slice into the complete cached payload and writes it
    /// to disk. Because tiers carry disjoint fields, each slice fills in
    /// its part of the merged whole. The on-disk cache lets the next
    /// connect pre-apply config before the UI builds (TryPreApplyCachedSync).
    /// </summary>
    static void MergeAndCache(int tier, ServerSyncPayload slice)
    {
        // A new hash starts a fresh merge and re-evaluates the disk cache.
        if (_merged == null ||
            !string.Equals(_mergeHash, slice.PayloadHash, StringComparison.Ordinal))
        {
            _merged = new ServerSyncPayload
            {
                ServerIdentity = slice.ServerIdentity,
                PayloadHash    = slice.PayloadHash,
            };
            _mergeHash     = slice.PayloadHash;
            _cacheUpToDate = DiskHashMatches(slice.ServerIdentity, slice.PayloadHash);

            if (!string.IsNullOrEmpty(_connectionString))
                ServerRegistry.Register(_connectionString, slice.ServerIdentity);
        }

        switch ((SyncTierEnum)tier)
        {
            case SyncTierEnum.Critical:
                _merged.ItemAppearanceOverrides = slice.ItemAppearanceOverrides;
                break;
            case SyncTierEnum.High:
                _merged.RecipeOverrides        = slice.RecipeOverrides;
                _merged.StationRecipeOverrides = slice.StationRecipeOverrides;
                break;
            case SyncTierEnum.Normal:
                _merged.PlayerRecipesToAdd    = slice.PlayerRecipesToAdd;
                _merged.PlayerRecipesToRemove = slice.PlayerRecipesToRemove;
                break;
            // Low/Background carry no known fields yet — nothing to merge.
        }

        // Skip rewriting when the cache already holds this exact hash
        // (reconnect with unchanged server config).
        if (!_cacheUpToDate)
            WriteMergedToDisk(_merged);
    }

    // ── Cached pre-apply (UI race fix) ───────────────────────

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
                $"No cached sync for '{connectionString}' — waiting for server payload.");
            return;
        }

        var syncFile = SoulPathIndex.SyncFile(folderName);
        if (!File.Exists(syncFile))
        {
            SoulLogger.Info(LOG_SOURCE,
                $"Sync file not found for '{folderName}' — waiting for server payload.");
            return;
        }

        try
        {
            var json    = File.ReadAllText(syncFile);
            var payload = JsonSerializer.Deserialize<ServerSyncPayload>(json, _readOptions);

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

    /// <summary>
    /// Applies a complete payload in one shot. Used only for the disk-cached
    /// pre-apply path — live transmissions apply per tier via ApplyTier().
    /// Same fixed order as the per-tier handlers, just combined.
    /// </summary>
    static void ApplyPayload(ServerSyncPayload payload)
    {
        // Critical
        LocalizationInjector.Inject(payload);
        IconPatcher.ClearPrevious();
        IconPatcher.Apply(payload);

        // High
        RecipePatcher.Apply(payload.RecipeOverrides);
        RecipePatcher.ApplyStationRecipes(payload.StationRecipeOverrides);

        // Normal
        RecipePatcher.ApplyPlayerRecipes(
            payload.PlayerRecipesToAdd,
            payload.PlayerRecipesToRemove);
    }

    // ── Disk helpers ─────────────────────────────────────────

    static bool DiskHashMatches(string serverIdentity, string hash)
    {
        var syncFile = SoulPathIndex.SyncFile(serverIdentity);
        if (!File.Exists(syncFile)) return false;

        try
        {
            var existing = JsonSerializer.Deserialize<ServerSyncPayload>(
                File.ReadAllText(syncFile), _readOptions);
            return existing?.PayloadHash == hash;
        }
        catch
        {
            // Malformed cache — treat as a miss so it gets overwritten.
            return false;
        }
    }

    static void WriteMergedToDisk(ServerSyncPayload payload)
    {
        try
        {
            Directory.CreateDirectory(SoulPathIndex.ServerDir(payload.ServerIdentity));
            File.WriteAllText(
                SoulPathIndex.SyncFile(payload.ServerIdentity),
                JsonSerializer.Serialize(payload, _writeOptions));

            SoulLogger.Debug(LOG_SOURCE,
                $"Sync cache updated for '{payload.ServerIdentity}' ({payload.PayloadHash}).");
        }
        catch (Exception ex)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Failed to write sync payload to disk: {ex.Message}");
        }
    }

    // ── Encoding helpers (inverse of SyncPayloadCache.BuildBlob) ──

    /// <summary>
    /// base64 → GZip-decompressed UTF-8 JSON.
    /// [PERFORMANCE] Runs once per tier per connect — not per message.
    /// </summary>
    static string Decompress(string base64)
    {
        var compressed = Convert.FromBase64String(base64);

        using var input  = new MemoryStream(compressed);
        using var gz     = new GZipStream(input, CompressionMode.Decompress);
        using var output = new MemoryStream();

        gz.CopyTo(output);
        return Encoding.UTF8.GetString(output.ToArray());
    }

    /// <summary>
    /// First 8 hex chars of SHA256 over the input — identical formula to
    /// SyncPayloadCache.ComputeHash so checksums match end to end.
    /// </summary>
    static string ComputeHash(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes)[..8];
    }

    /// <summary>Strips a leading sentinel prefix and the trailing "]]".</summary>
    static string StripSentinel(string message, string prefix)
    {
        var inner = message[prefix.Length..];
        return inner.EndsWith("]]", StringComparison.Ordinal)
            ? inner[..^2]
            : inner;
    }

    // ── Types ────────────────────────────────────────────────

    /// <summary>Accumulates chunks for one in-flight tier.</summary>
    sealed class TierAccumulator
    {
        public int ExpectedCount;
        public string Checksum = string.Empty;
        public readonly Dictionary<int, string> Chunks = new();
    }
}