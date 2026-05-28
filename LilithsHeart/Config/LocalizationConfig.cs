// ============================================================
//  LocalizationConfig — LilithsHeart
//  LilithsHeart/Config/LocalizationConfig.cs
//
//  Pure data surface for server-defined display name and tooltip
//  overrides. Holds the merged results of all localization JSON
//  files loaded by LocalizationService.
//
//  [CHANGED] Split from the original monolithic LocalizationConfig.
//            Loading logic (Initialize, Reload, Load, LoadFile,
//            EnsureExampleFile) has moved to:
//                LilithsHeart/Services/LocalizationService.cs
//            This file now owns only the data surface — the two
//            dictionaries and their read accessors.
//
//  Key format: prefab Name (from LilithsMind PrefabDef.Name) or
//  Prefab string (e.g. "Item_BloodEssence_T01"). Soul resolves
//  these to AssetGuids via LilithsMind's NameKey/DescKey fields.
//
//  ⚠️  IMPORTANT: Overrides only take effect on the client if
//  LilithsMind has a PrefabDef entry with NameKey (for display names)
//  or DescKey (for tooltips) populated for that prefab. Entries
//  referencing unknown or incomplete prefabs are silently skipped
//  on the client with a warning in the Soul log.
//
//  [PERFORMANCE] Two flat dictionaries — O(1) lookup per key.
//                Populated once at world ready by LocalizationService.
//                No file I/O occurs here.
// ============================================================

namespace LilithsHeart.Config;

public static class LocalizationConfig
{
    static readonly Dictionary<string, string> _displayNames = new();
    static readonly Dictionary<string, string> _tooltips     = new();

    /// <summary>
    /// All display name overrides keyed by prefab name.
    /// Populated by LocalizationService.Initialize() / Reload().
    /// </summary>
    public static IReadOnlyDictionary<string, string> DisplayNames => _displayNames;

    /// <summary>
    /// All tooltip overrides keyed by prefab name.
    /// Populated by LocalizationService.Initialize() / Reload().
    /// </summary>
    public static IReadOnlyDictionary<string, string> Tooltips => _tooltips;

    /// <summary>
    /// True once LocalizationService has completed its initial load.
    /// </summary>
    public static bool IsLoaded { get; private set; }

    /// <summary>
    /// Returns the display name override for a prefab, or null if none exists.
    /// </summary>
    public static string? GetDisplayName(string prefabName)
        => _displayNames.TryGetValue(prefabName, out var v) ? v : null;

    /// <summary>
    /// Returns the tooltip override for a prefab, or null if none exists.
    /// </summary>
    public static string? GetTooltip(string prefabName)
        => _tooltips.TryGetValue(prefabName, out var v) ? v : null;

    // ── Called by LocalizationService only ───────────────────

    /// <summary>
    /// Clears both dictionaries and resets IsLoaded.
    /// Called by LocalizationService before reloading.
    /// </summary>
    internal static void Clear()
    {
        _displayNames.Clear();
        _tooltips.Clear();
        IsLoaded = false;
    }

    /// <summary>
    /// Adds a display name override entry.
    /// Called by LocalizationService during file loading.
    /// </summary>
    internal static void AddDisplayName(string key, string value)
        => _displayNames[key] = value;

    /// <summary>
    /// Adds a tooltip override entry.
    /// Called by LocalizationService during file loading.
    /// </summary>
    internal static void AddTooltip(string key, string value)
        => _tooltips[key] = value;

    /// <summary>
    /// Marks the config as fully loaded.
    /// Called by LocalizationService after all files are processed.
    /// </summary>
    internal static void MarkLoaded()
        => IsLoaded = true;
}