// ============================================================
//  RecipeOverrideData — LilithsHeart
//  LilithsHeart/Network/RecipeOverrideData.cs
//
//  DTO representing a single recipe's overridden state, sent
//  inside ServerSyncPayload.RecipeOverrides.
//
//  Only fields the client HUD actually reads are included:
//    • CraftDuration  — displayed in the craft button
//    • Requirements   — ingredient list shown before crafting
//    • Outputs        — output item list shown in the recipe card
//
//  Soul uses these to patch RecipeData, RecipeRequirementBuffer,
//  and RecipeOutputBuffer on client-side prefab entities so the
//  UI reflects what Heart enforces server-side.
//
//  ⚠️  SYNC REQUIREMENT:
//      Must be kept structurally in sync with
//      LilithsSoul/Network/RecipeOverrideData.cs manually.
//
//  [PERFORMANCE] This is a plain DTO — no ECS types, no Unity
//                dependencies. Serializes/deserializes cheaply
//                as part of the larger ServerSyncPayload JSON.
// ============================================================

namespace LilithsHeart.Network;

/// <summary>
/// A single ingredient or output slot in a recipe override.
/// </summary>
public sealed class RecipeSlotData
{
    /// <summary>
    /// Prefab name of the item. e.g. "Item_Ingredient_Mineral_CopperIngot"
    /// Resolved to a PrefabGUID by Soul via PrefabNameResolver on the client.
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
    /// Craft duration in seconds. Displayed in the craft button.
    /// </summary>
    public float CraftDuration { get; set; }

    /// <summary>
    /// Ingredient requirements. Soul patches RecipeRequirementBuffer from this.
    /// </summary>
    public List<RecipeSlotData> Requirements { get; set; } = new();

    /// <summary>
    /// Output items. Soul patches RecipeOutputBuffer from this.
    /// </summary>
    public List<RecipeSlotData> Outputs { get; set; } = new();
}