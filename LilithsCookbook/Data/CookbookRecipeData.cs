// ============================================================
//  CookbookRecipeData — LilithsCookbook
//  LilithsCookbook/Data/CookbookRecipeData.cs
//
//  Top-level container and entry record for recipe config files.
//  Deserialized from *.json files in:
//      BepInEx/config/LilithsHeart/Recipes/
//
//  [CHANGED] CookbookItemData , CookbookItemData , RecipeRepairCost,
//            and CookbookItemData have been consolidated into
//            CookbookItemData — a single reusable item + amount
//            type. All list fields now use CookbookItemData.
//
//  [CHANGED] RecipeEntryData renamed to RecipeEntryData to follow
//            the suite Data suffix naming convention.
//
//  [PERFORMANCE] Plain DTOs — no ECS types, no Unity dependencies.
//                Deserialized once at startup by CookbookLoader.
// ============================================================

namespace LilithsCookbook.Data;

/// <summary>
/// Top-level container for all recipe config entries.
/// Deserialized from *.json files in the Recipes directory.
/// Multiple files are merged by CookbookLoader — later files win on key conflicts.
/// </summary>
public class CookbookRecipeData
{
    /// <summary>
    /// Recipe entries keyed by prefab name or LilithsMind Name alias.
    /// e.g. "Recipe_Weapon_Sword_T01_Bone" or "BoneSword"
    /// </summary>
    public Dictionary<string, RecipeEntryData> Recipes { get; set; } = new();
}

/// <summary>
/// Full configuration record for a single recipe.
/// All fields are nullable — only specified fields are applied.
/// Unspecified fields retain their vanilla values.
/// </summary>
public class RecipeEntryData
{
    /// <summary>
    /// When false, this entry is skipped entirely during apply.
    /// Set to true to activate changes for this recipe.
    /// </summary>
    public bool ChangesEnabled { get; set; } = false;

    /// <summary>Craft duration in seconds. Null = keep vanilla.</summary>
    public float? CraftDuration { get; set; }

    /// <summary>Whether the recipe is always unlocked. Null = keep vanilla.</summary>
    public bool? AlwaysUnlocked { get; set; }

    /// <summary>Whether the recipe is hidden in the station UI. Null = keep vanilla.</summary>
    public bool? HideInStation { get; set; }

    /// <summary>Whether the recipe ignores server settings. Null = keep vanilla.</summary>
    public bool? IgnoreServerSettings { get; set; }

    /// <summary>HUD sort order for this recipe. Null = keep vanilla.</summary>
    public int? HudSortingOrder { get; set; }

    /// <summary>
    /// Ingredient requirements. Null = keep vanilla requirements.
    /// Each entry is an item prefab name and stack amount.
    /// </summary>
    public List<CookbookItemData>? Requirements { get; set; }

    /// <summary>
    /// Output items. Null = keep vanilla outputs.
    /// Each entry is an item prefab name and stack amount.
    /// </summary>
    public List<CookbookItemData>? Outputs { get; set; }

    // ── Optional buffer control ──────────────────────────────
    // null  — not specified, buffer is left untouched
    // false — remove the buffer entirely from the entity
    // true  — ensure buffer exists and apply the list below

    /// <summary>Controls whether ItemRepairBuffer is present. Null = untouched.</summary>
    public bool? UseRepairCosts { get; set; }

    /// <summary>
    /// Repair cost items. Only applied when UseRepairCosts = true.
    /// Each entry is an item prefab name and stack amount.
    /// </summary>
    public List<CookbookItemData>? RepairCosts { get; set; }

    /// <summary>Controls whether CookbookItemData UnitBuffer is present. Null = untouched.</summary>
    public bool? UseUnitOutputs { get; set; }

    /// <summary>
    /// Unit outputs. Only applied when UseUnitOutputs = true.
    /// Each entry is a unit prefab name and stack amount.
    /// </summary>
    public List<CookbookItemData>? UnitOutputs { get; set; }

    /// <summary>Controls whether RecipeLinkBuffer is present. Null = untouched.</summary>
    public bool? UseRecipeLinks { get; set; }

    /// <summary>
    /// Linked recipe prefab names. Only applied when UseRecipeLinks = true.
    /// </summary>
    public List<string>? RecipeLinks { get; set; }
}