// ============================================================
//  ServerSyncPayload — LilithsSoul
//
//  Client-side mirror of LilithsHeart.Network.ServerSyncPayload.
//  Deserialize-only.
//
//  [CHANGED] Added PlayerRecipesToAdd and PlayerRecipesToRemove
//            to mirror Heart's payload additions.
// ============================================================

namespace LilithsSoul.Network;

public sealed class ServerSyncPayload
{
    public string ServerIdentity { get; set; } = string.Empty;
    public string PayloadHash    { get; set; } = string.Empty;

    public Dictionary<string, string> DisplayNameOverrides { get; set; } = new();
    public Dictionary<string, string> TooltipOverrides     { get; set; } = new();

    public Dictionary<string, RecipeOverrideData> RecipeOverrides { get; set; } = new();

    /// <summary>
    /// Station recipe overrides keyed by station prefab name.
    /// Applied by RecipePatcher.ApplyStationRecipes().
    /// [CHANGED] Added to fix WorkstationRecipesBuffer crafting stations
    ///           not reflecting server-side recipe changes on the client.
    /// </summary>
    public Dictionary<string, StationRecipeOverrideData> StationRecipeOverrides { get; set; } = new();

    public List<string> PlayerRecipesToAdd    { get; set; } = new();

    /// <summary>
    /// Recipe prefab names to remove from the client player's WorkstationRecipesBuffer.
    /// Applied by RecipePatcher.ApplyPlayerRecipes().
    /// [CHANGED] Added to support client-side player crafting menu accuracy.
    /// </summary>
    public List<string> PlayerRecipesToRemove { get; set; } = new();
}