// ============================================================
//  StationRecipeOverrideData — LilithsHeart
//
//  Data transferred from Heart to Soul describing which recipes
//  to add or remove from a specific crafting station's
//  WorkstationRecipesBuffer on the client side.
//
//  Keyed by prefab name in ServerSyncPayload.StationRecipeOverrides.
//
//  [PERFORMANCE] Small flat lists — no nested collections.
//                Serialized once per connect.
// ============================================================

namespace LilithsHeart.Network;

public sealed class StationRecipeOverrideData
{
    /// <summary>Recipe prefab names to add to the station's WorkstationRecipesBuffer.</summary>
    public List<string> RecipesToAdd    { get; set; } = new();

    /// <summary>Recipe prefab names to remove from the station's WorkstationRecipesBuffer.</summary>
    public List<string> RecipesToRemove { get; set; } = new();
}