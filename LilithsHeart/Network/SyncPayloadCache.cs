using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using LilithsHeart.Config;
using LilithsHeart.Foundation;
using LilithsMind.Network;

// ============================================================
//  SyncPayloadCache — LilithsHeart
//  LilithsHeart/Network/SyncPayloadCache.cs
//
//  Builds, compresses, and caches one payload blob per sync tier.
//  SyncSender reads the cached blobs on client connect and
//  enqueues them into SyncQueue for rate-limited delivery.
//
//  [CHANGED] No longer caches a single flat JSON string.
//            Now caches four compressed Base64 blobs — one per
//            SyncTier — built from the payload data split by
//            TierAssignments. Each blob is independent: GZip
//            compressed JSON, Base64 encoded for chat transport.
//
//  Blob pipeline per tier:
//  ────────────────────────
//      Raw payload section
//        → JSON serialize (System.Text.Json)
//        → GZip compress  (System.IO.Compression)
//        → Base64 encode  (Convert.ToBase64String)
//        → Split into 450-char chunks
//        → Store as TierBlob (chunks + checksum + tier)
//
//  Why GZip + Base64?
//  ───────────────────
//  GZip reduces string-heavy JSON by ~85-90%. Base64 is required
//  because FixedString512Bytes in ChatMessageServerEvent cannot
//  carry arbitrary binary data. Together they give us ~120 chunks
//  worst-case vs ~290 without compression — a 2.5x improvement.
//
//  [PERFORMANCE] Blob building runs at most twice at startup
//                (baseline + after modules register). No per-connect
//                serialization cost. Blobs are reused for every
//                client that connects until Rebuild() is called.
// ============================================================

namespace LilithsHeart.Network;

/// <summary>
/// A single compressed tier payload ready for chunked transport.
/// </summary>
public sealed class TierBlob
{
    public SyncTier    Tier      { get; init; }
    public string[]    Chunks    { get; init; } = [];
    public string      Checksum  { get; init; } = string.Empty;
    public int         ChunkCount => Chunks.Length;
}

public static class SyncPayloadCache
{
    private const string LOG_SOURCE = "LilithsHeart.SyncPayloadCache";

    private const int MAX_CHUNK_CONTENT = 450;

    static readonly JsonSerializerOptions _writeOptions = new() { WriteIndented = false };

    // One blob per tier — null until Rebuild() is called.
    // Indexed by (int)SyncTier - 1 for zero-based access.
    static volatile TierBlob?[] _tierBlobs = new TierBlob?[4];

    // Retained for disk cache writes on Soul side — JSON is still
    // written to sync.json for human readability and version tolerance.
    static volatile string? _cachedJson;
    public static string? CachedJson => _cachedJson;

    /// <summary>
    /// Returns the cached blob for a specific tier, or null if not built.
    /// </summary>
    public static TierBlob? GetTierBlob(SyncTier tier)
        => _tierBlobs[(int)tier - 1];

    /// <summary>
    /// Returns all non-null tier blobs in tier order (Critical first).
    /// </summary>
    public static IEnumerable<TierBlob> GetAllTierBlobs()
        => _tierBlobs.Where(b => b != null).Select(b => b!);

    /// <summary>
    /// Builds and caches compressed tier blobs from the current payload data.
    /// Called by Heart.OnInitialize() before and after module registration.
    ///
    /// [PERFORMANCE] GZip compression + Base64 encoding runs once per call.
    ///               Runs at most twice at startup — no per-connect cost.
    /// </summary>
    public static void Rebuild(
        string serverIdentity,
        Dictionary<string, LilithRecipeData> recipeOverrides,
        Dictionary<string, LilithStationData> stationRecipeOverrides,
        List<string> playerRecipesToAdd,
        List<string> playerRecipesToRemove)
    {
        try
        {
            var payload = new ServerSyncPayload
            {
                ServerIdentity       = SanitizeFolderName(serverIdentity),
                DisplayNameOverrides = new Dictionary<string, string>(LocalizationConfig.DisplayNames),
                TooltipOverrides     = new Dictionary<string, string>(LocalizationConfig.Tooltips),
            };

            foreach (var (key, value) in recipeOverrides)
                payload.RecipeOverrides[key] = value;

            foreach (var (key, value) in stationRecipeOverrides)
                payload.StationRecipeOverrides[key] = value;

            payload.PlayerRecipesToAdd    = new List<string>(playerRecipesToAdd);
            payload.PlayerRecipesToRemove = new List<string>(playerRecipesToRemove);

            // Compute hash on full payload for disk cache comparison.
            var jsonForHash = JsonSerializer.Serialize(payload, _writeOptions);
            payload.PayloadHash = ComputeHash(jsonForHash);

            // Cache full JSON for disk write (sync.json stays human-readable JSON).
            _cachedJson = JsonSerializer.Serialize(payload, _writeOptions);

            // Build one compressed blob per tier.
            var newBlobs = new TierBlob?[4];
            newBlobs[(int)SyncTier.Critical - 1] = BuildTierBlob(SyncTier.Critical, BuildCriticalSection(payload));
            newBlobs[(int)SyncTier.High     - 1] = BuildTierBlob(SyncTier.High,     BuildHighSection(payload));
            newBlobs[(int)SyncTier.Normal   - 1] = BuildTierBlob(SyncTier.Normal,   BuildNormalSection(payload));
            newBlobs[(int)SyncTier.Low      - 1] = BuildTierBlob(SyncTier.Low,      BuildLowSection(payload));

            _tierBlobs = newBlobs;

            int totalChunks = newBlobs.Where(b => b != null).Sum(b => b!.ChunkCount);

            HeartLogger.Info(LOG_SOURCE,
                $"Payload cached — hash {payload.PayloadHash}, " +
                $"total chunks: {totalChunks} across {newBlobs.Count(b => b != null)} tier(s). " +
                $"T1:{newBlobs[0]?.ChunkCount ?? 0} " +
                $"T2:{newBlobs[1]?.ChunkCount ?? 0} " +
                $"T3:{newBlobs[2]?.ChunkCount ?? 0} " +
                $"T4:{newBlobs[3]?.ChunkCount ?? 0}");
        }
        catch (Exception ex)
        {
            HeartLogger.Error(LOG_SOURCE, $"Rebuild failed: {ex.Message}");
            _cachedJson = null;
            _tierBlobs  = new TierBlob?[4];
        }
    }

    // ── Tier section builders ─────────────────────────────────

    // Each builder produces a minimal DTO containing only the data
    // for that tier. Soul deserializes each tier independently.

    static object BuildCriticalSection(ServerSyncPayload payload) => new
    {
        payload.ServerIdentity,
        payload.PayloadHash,
        DisplayNameOverrides = TierAssignments.ItemNames    == SyncTier.Critical ? payload.DisplayNameOverrides : null,
        TooltipOverrides     = TierAssignments.ItemTooltips == SyncTier.Critical ? payload.TooltipOverrides     : null,
    };

    static object BuildHighSection(ServerSyncPayload payload) => new
    {
        RecipeOverrides        = TierAssignments.RecipeData     == SyncTier.High ? payload.RecipeOverrides        : null,
        StationRecipeOverrides = TierAssignments.StationRecipes == SyncTier.High ? payload.StationRecipeOverrides : null,
        PlayerRecipesToAdd     = TierAssignments.PlayerRecipes  == SyncTier.High ? payload.PlayerRecipesToAdd     : null,
        PlayerRecipesToRemove  = TierAssignments.PlayerRecipes  == SyncTier.High ? payload.PlayerRecipesToRemove  : null,
    };

    static object BuildNormalSection(ServerSyncPayload payload) => new { };

    static object BuildLowSection(ServerSyncPayload payload) => new { };

    // ── Blob builder ──────────────────────────────────────────

    static TierBlob BuildTierBlob(SyncTier tier, object section)
    {
        // Serialize → GZip → Base64 → chunk.
        var json        = JsonSerializer.Serialize(section, _writeOptions);
        var compressed  = GZipCompress(json);
        var base64      = Convert.ToBase64String(compressed);
        var chunks      = Chunkify(base64);
        var checksum    = ComputeHash(base64)[..6];

        return new TierBlob
        {
            Tier     = tier,
            Chunks   = chunks,
            Checksum = checksum,
        };
    }

    // ── Compression ───────────────────────────────────────────

    static byte[] GZipCompress(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        using var output     = new MemoryStream();
        using var gzip       = new GZipStream(output, CompressionLevel.Optimal);
        gzip.Write(inputBytes, 0, inputBytes.Length);
        gzip.Close();
        return output.ToArray();
    }

    // ── Chunking ──────────────────────────────────────────────

    static string[] Chunkify(string input)
    {
        if (input.Length == 0) return [];

        var chunks = new List<string>();
        int pos    = 0;

        while (pos < input.Length)
        {
            int len = Math.Min(MAX_CHUNK_CONTENT, input.Length - pos);
            chunks.Add(input.Substring(pos, len));
            pos += len;
        }

        return chunks.ToArray();
    }

    // ── Helpers ───────────────────────────────────────────────

    static string SanitizeFolderName(string name)
    {
        var invalid = Path.GetInvalidFileNameChars();
        return string.Concat(name.Select(c => invalid.Contains(c) ? '_' : c)).Trim();
    }

    static string ComputeHash(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes)[..8];
    }
}