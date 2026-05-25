// ============================================================
//  RecipeOverrideData — LilithsSoul
//  LilithsSoul/Network/RecipeOverrideData.cs
//
//  Client-side mirror of LilithsHeart.Network.RecipeOverrideData.
//  Deserialize-only — Soul never constructs these, only reads
//  them from the received ServerSyncPayload JSON.
//
//  ⚠️  SYNC REQUIREMENT:
//      Must be kept structurally in sync with
//      LilithsHeart/Network/RecipeOverrideData.cs manually.
//      JSON deserialization silently ignores unknown fields,
//      but missing fields will deserialize as their defaults.
//
//  [PERFORMANCE] Plain DTO — no ECS types, no Unity dependencies.
//                Deserialized once on connect as part of the
//                larger ServerSyncPayload JSON.
// ============================================================

namespace LilithsSoul.Network;

/// <summary>
/// A single ingredient or output slot in a recipe override.
/// </summary>
public sealed class RecipeSlotData
{
    /// <summary>
    /// Prefab name of the item. e.g. "Item_Ingredient_Mineral_CopperIngot"
    /// Resolved to a PrefabGUID by RecipePatcher via the client's
    /// PrefabCollectionSystem._PrefabNameToGuid map.
    /// </summary>
    public string Item { get; set; } = string.Empty;

    /// <summary>
    /// Stack count for this slot.
    /// </summary>
    public int Amount { get; set; }
}

/// <summary>
/// Full override data for a single recipe, keyed by recipe prefab name
/// in ServerSyncPayload.RecipeOverrides.
/// </summary>
public sealed class RecipeOverrideData
{
    /// <summary>
    /// Craft duration in seconds. Patched into RecipeData.CraftDuration
    /// on the client prefab entity.
    /// </summary>
    public float CraftDuration { get; set; }

    /// <summary>
    /// Ingredient requirements. Patched into RecipeRequirementBuffer
    /// on the client prefab entity.
    /// </summary>
    public List<RecipeSlotData> Requirements { get; set; } = new();

    /// <summary>
    /// Output items. Patched into RecipeOutputBuffer on the client
    /// prefab entity.
    /// </summary>
    public List<RecipeSlotData> Outputs { get; set; } = new();
}