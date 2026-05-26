using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using LilithsHeart.Foundation;

// ============================================================
//  SyncPayloadCache — LilithsHeart
//
//  [CHANGED] Rebuild() now accepts player recipe add/remove lists
//            in addition to recipe overrides, so localization
//            reloads preserve all registered module changes.
// ============================================================

namespace LilithsHeart.Network;

public static class SyncPayloadCache
{
    private const string LOG_SOURCE = "LilithsHeart.SyncPayloadCache";

    static volatile string? _cachedJson;

    public static string? CachedJson => _cachedJson;

    public static void Build(string serverIdentity)
        => BuildInternal(serverIdentity,
            new Dictionary<string, RecipeOverrideData>(),
            new Dictionary<string, StationRecipeOverrideData>(),
            new List<string>(),
            new List<string>());

    public static void Rebuild(
        string serverIdentity,
        Dictionary<string, RecipeOverrideData> recipeOverrides,
        Dictionary<string, StationRecipeOverrideData> stationRecipeOverrides,
        List<string> playerRecipesToAdd,
        List<string> playerRecipesToRemove)
        => BuildInternal(serverIdentity, recipeOverrides, stationRecipeOverrides,
            playerRecipesToAdd, playerRecipesToRemove);

    // ── Internal ─────────────────────────────────────────────

    static void BuildInternal(
        string serverIdentity,
        Dictionary<string, RecipeOverrideData> recipeOverrides,
        Dictionary<string, StationRecipeOverrideData> stationRecipeOverrides,
        List<string> playerRecipesToAdd,
        List<string> playerRecipesToRemove)
    {
        try
        {
            var payload = ServerSyncPayload.Build(serverIdentity);

            foreach (var (key, value) in recipeOverrides)
                payload.RecipeOverrides[key] = value;

            // [CHANGED] Populate station recipe overrides.
            foreach (var (key, value) in stationRecipeOverrides)
                payload.StationRecipeOverrides[key] = value;

            payload.PlayerRecipesToAdd    = new List<string>(playerRecipesToAdd);
            payload.PlayerRecipesToRemove = new List<string>(playerRecipesToRemove);

            var json = JsonSerializer.Serialize(payload,
                new JsonSerializerOptions { WriteIndented = false });

            payload.PayloadHash = ComputeHash(json);

            _cachedJson = JsonSerializer.Serialize(payload,
                new JsonSerializerOptions { WriteIndented = false });

            HeartLogger.Info(LOG_SOURCE,
                $"Payload cached — {_cachedJson.Length} chars, " +
                $"hash {payload.PayloadHash}, " +
                $"{payload.RecipeOverrides.Count} recipe override(s), " +
                $"{payload.StationRecipeOverrides.Count} station override(s), " +
                $"{payload.PlayerRecipesToAdd.Count} player add(s), " +
                $"{payload.PlayerRecipesToRemove.Count} player remove(s).");
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