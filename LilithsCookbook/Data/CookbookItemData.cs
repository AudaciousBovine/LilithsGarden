// ============================================================
//  CookbookItemData — LilithsCookbook
//  LilithsCookbook/Data/CookbookItemData.cs
//
//  A single item reference with a stack amount.
//  Used across all recipe slot contexts:
//    • Requirements  — ingredients needed to craft
//    • Outputs       — items produced by the recipe
//    • RepairCosts   — items consumed on repair
//    • UnitOutputs   — units spawned by the recipe
//
//  [CHANGED] Consolidates four near-identical classes:
//              CookbookItemData 
//              CookbookItemData 
//              RecipeRepairCost
//              RecipeUnitOutput
//            All had the same shape (Item string + Amount int).
//            CookbookItemData used 'Unit' instead of 'Item' —
//            unified to 'Item' here for consistency.
//
//  [PERFORMANCE] Plain DTO — no ECS types, no Unity dependencies.
//                Deserialized from JSON config at startup only.
// ============================================================

namespace LilithsCookbook.Data;

/// <summary>
/// A single item reference with a stack amount.
/// Used for recipe requirements, outputs, repair costs, and unit outputs.
/// </summary>
public class CookbookItemData
{
    /// <summary>
    /// Prefab name of the item or unit.
    /// e.g. "Item_Ingredient_Mineral_CopperIngot"
    /// Resolved to a PrefabGUID by PrefabNameResolver at apply time.
    /// </summary>
    public string Item { get; set; } = string.Empty;

    /// <summary>Stack count for this slot.</summary>
    public int Amount { get; set; }
}