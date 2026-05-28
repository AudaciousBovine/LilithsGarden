// ============================================================
//  CookbookStationData — LilithsCookbook
//  LilithsCookbook/Data/CookbookStationData.cs
//
//  Top-level container and entry record for station config files.
//  Deserialized from *.json files in:
//      BepInEx/config/LilithsHeart/Stations/
//
//  [CHANGED] StationEntryData renamed to StationEntryData to follow
//            the suite Data suffix naming convention.
//
//  [PERFORMANCE] Plain DTOs — no ECS types, no Unity dependencies.
//                Deserialized once at startup by CookbookLoader.
// ============================================================

namespace LilithsCookbook.Data;

/// <summary>
/// Top-level container for all station config entries.
/// Deserialized from *.json files in the Stations directory.
/// Multiple files are merged by CookbookLoader — later files win on key conflicts.
/// </summary>
public class CookbookStationData
{
    /// <summary>
    /// Station entries keyed by prefab name or LilithsMind Name alias.
    /// e.g. "TM_Blacksmith_Stations_Standard" or "Blacksmith"
    /// </summary>
    public Dictionary<string, StationEntryData> Stations { get; set; } = new();
}

/// <summary>
/// Configuration record for a single crafting station.
/// Describes which recipes to add or remove from the station's recipe buffer.
/// </summary>
public class StationEntryData
{
    /// <summary>
    /// When false, this entry is skipped entirely during apply.
    /// Set to true to activate changes for this station.
    /// </summary>
    public bool ChangesEnabled { get; set; } = false;

    /// <summary>
    /// Recipe prefab names to add to the station's recipe buffer.
    /// e.g. "Recipe_Weapon_Sword_T04_Copper_Reinforced"
    /// </summary>
    public List<string> AddRecipes { get; set; } = new();

    /// <summary>
    /// Recipe prefab names to remove from the station's recipe buffer.
    /// </summary>
    public List<string> RemoveRecipes { get; set; } = new();
}