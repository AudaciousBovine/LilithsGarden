using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using LilithsHeart.Foundation;

// ============================================================
//  SyncPayloadCache — LilithsHeart
//
//  Holds the pre-serialized ServerSyncPayload JSON string ready
//  to be chunked and sent to any connecting Soul client.
//
//  Build() is called once at Heart initialization and again
//  whenever LocalizationConfig is reloaded (server admin action)
//  or when modules register recipe overrides.
//
//  [CHANGED] Rebuild() now accepts an optional recipe overrides
//  dict so that when localization is reloaded, the existing
//  recipe overrides (registered by Cookbook during init) are
//  preserved in the rebuilt payload rather than being lost.
//
//  [PERFORMANCE] Build() runs O(1) serialization at init time.
//                SyncSender reads CachedJson with no allocation.
//                Thread safety: volatile string reference — safe
//                for single-writer (main thread) / multi-reader.
// ============================================================

namespace LilithsHeart.Network;

public static class SyncPayloadCache
{
    private const string LOG_SOURCE = "LilithsHeart.SyncPayloadCache";

    static volatile string? _cachedJson;

    /// <summary>
    /// The pre-serialized JSON payload ready to be chunked and sent.
    /// Null until Build() has been called successfully.
    /// </summary>
    public static string? CachedJson => _cachedJson;

    /// <summary>
    /// Builds and caches the JSON payload from the current server state.
    /// Recipe overrides start empty — populated by Rebuild() after modules
    /// register their changes.
    /// </summary>
    public static void Build(string serverIdentity)
        => BuildInternal(serverIdentity, new Dictionary<string, RecipeOverrideData>());

    /// <summary>
    /// Rebuilds the cached payload, preserving the provided recipe overrides.
    /// Call when localization is reloaded or when recipe overrides change.
    ///
    /// [CHANGED] Added recipeOverrides parameter so a localization reload
    ///           does not wipe out recipe overrides that were registered
    ///           during module initialization.
    /// </summary>
    public static void Rebuild(string serverIdentity, Dictionary<string, RecipeOverrideData> recipeOverrides)
        => BuildInternal(serverIdentity, recipeOverrides);

    // ── Internal ─────────────────────────────────────────────

    static void BuildInternal(string serverIdentity, Dictionary<string, RecipeOverrideData> recipeOverrides)
    {
        try
        {
            var payload = ServerSyncPayload.Build(serverIdentity);

            // Merge in the recipe overrides supplied by the caller.
            // ServerSyncPayload.Build() leaves RecipeOverrides empty.
            foreach (var (key, value) in recipeOverrides)
                payload.RecipeOverrides[key] = value;

            var json = JsonSerializer.Serialize(payload,
                new JsonSerializerOptions { WriteIndented = false });

            // Compute short hash for Soul's cache-invalidation check.
            payload.PayloadHash = ComputeHash(json);

            // Re-serialize with hash included.
            _cachedJson = JsonSerializer.Serialize(payload,
                new JsonSerializerOptions { WriteIndented = false });

            HeartLogger.Info(LOG_SOURCE,
                $"Payload cached — {_cachedJson.Length} chars, " +
                $"hash {payload.PayloadHash}, " +
                $"{payload.RecipeOverrides.Count} recipe override(s).");
        }
        catch (Exception ex)
        {
            HeartLogger.Error(LOG_SOURCE, $"Build failed: {ex.Message}");
            _cachedJson = null;
        }
    }

    static string ComputeHash(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes)[..8];
    }
}