using System.Text.Json;
using LilithsHeart.Foundation;

// ============================================================
//  LocalizationConfig — LilithsHeart
//
//  Reads server-defined display name and tooltip overrides from
//  ALL *.json files found in:
//      BepInEx/config/LilithsHeart/Localization/
//
//  Files are loaded and merged in alphabetical order.
//  Later files win on key conflicts — admins can layer overrides.
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
//  [PERFORMANCE] All files are read once at world ready and merged
//                into two flat dictionaries for O(1) lookup.
//                No file I/O occurs after initialization.
// ============================================================

namespace LilithsHeart.Config;

public static class LocalizationConfig
{
    private const string LOG_SOURCE = "LilithsHeart.LocalizationConfig";

    static readonly Dictionary<string, string> _displayNames = new();
    static readonly Dictionary<string, string> _tooltips     = new();

    public static IReadOnlyDictionary<string, string> DisplayNames => _displayNames;
    public static IReadOnlyDictionary<string, string> Tooltips     => _tooltips;

    public static bool IsLoaded { get; private set; }

    public static void Initialize()
    {
        Directory.CreateDirectory(HeartPaths.LocalizationDir);
        EnsureExampleFile();
        Load();
    }

    public static void Reload()
    {
        _displayNames.Clear();
        _tooltips.Clear();
        IsLoaded = false;

        HeartLogger.Info(LOG_SOURCE, "Reloading localization overrides...");
        Load();

        Heart.OnLocalizationReloaded();
    }

    public static string? GetDisplayName(string prefabName)
        => _displayNames.TryGetValue(prefabName, out var v) ? v : null;

    public static string? GetTooltip(string prefabName)
        => _tooltips.TryGetValue(prefabName, out var v) ? v : null;

    // ── Internal ────────────────────────────────────────────

    static void Load()
    {
        var files = Directory.GetFiles(HeartPaths.LocalizationDir, "*.json")
                             .OrderBy(f => f)
                             .ToArray();

        if (files.Length == 0)
        {
            HeartLogger.Info(LOG_SOURCE, "No localization JSON files found. Overrides disabled.");
            IsLoaded = true;
            return;
        }

        foreach (var file in files)
            LoadFile(file);

        IsLoaded = true;
        HeartLogger.Info(LOG_SOURCE,
            $"Loaded {_displayNames.Count} display name(s) and {_tooltips.Count} tooltip(s) " +
            $"from {files.Length} file(s).");
    }

    static void LoadFile(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);
            var raw  = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (raw == null)
            {
                HeartLogger.Warning(LOG_SOURCE,
                    $"'{Path.GetFileName(filePath)}' parsed as null — check for malformed JSON.");
                return;
            }

            int nameCount    = 0;
            int tooltipCount = 0;

            foreach (var (key, element) in raw)
            {
                // Skip non-object values (e.g. _readme string).
                if (element.ValueKind != JsonValueKind.Object) continue;

                string? displayName = null;
                string? tooltip     = null;

                if (element.TryGetProperty("DisplayName", out var dn) &&
                    dn.ValueKind == JsonValueKind.String)
                    displayName = dn.GetString();

                if (element.TryGetProperty("Tooltip", out var tt) &&
                    tt.ValueKind == JsonValueKind.String)
                    tooltip = tt.GetString();

                if (!string.IsNullOrWhiteSpace(displayName))
                {
                    _displayNames[key] = displayName!;
                    nameCount++;
                }

                if (!string.IsNullOrWhiteSpace(tooltip))
                {
                    _tooltips[key] = tooltip!;
                    tooltipCount++;
                }
            }

            HeartLogger.Info(LOG_SOURCE,
                $"Loaded '{Path.GetFileName(filePath)}' — " +
                $"{nameCount} name(s), {tooltipCount} tooltip(s).");
        }
        catch (Exception ex)
        {
            HeartLogger.Error(LOG_SOURCE,
                $"Failed to parse '{Path.GetFileName(filePath)}': {ex.Message}");
        }
    }

    // [CHANGED] Example file simplified to use only Item_BloodEssence_T01,
    //           which has NameKey and DescKey confirmed in LilithsMind and
    //           is verified working end-to-end via Soul log output.
    //           The previous example also referenced Item_Ingredient_Plant_Cotton
    //           which has no LilithsMind entry and caused a skipped-entry warning
    //           on every client connect. Examples should only show working cases.
    static void EnsureExampleFile()
    {
        var examplePath = Path.Combine(HeartPaths.LocalizationDir, "example.json");
        if (File.Exists(examplePath)) return;

        const string example = """
{
  "_readme": "Copy and rename this file (e.g. items.json). Keys are the prefab Name or Prefab string from LilithsMind PrefabDef entries (e.g. 'BloodEssence' or 'Item_BloodEssence_T01'). Overrides only take effect on clients if LilithsMind has NameKey (for DisplayName) or DescKey (for Tooltip) populated for that prefab — check the Soul client log for any skipped entries. Files load alphabetically; later files win on key conflicts.",
  "Item_BloodEssence_T01": {
    "DisplayName": "Red Marble",
    "Tooltip": "A gorgeous Red Marble dropped from the living, it feels pleasant in the palm."
  }
}
""";

        try
        {
            File.WriteAllText(examplePath, example);
            HeartLogger.Info(LOG_SOURCE, $"Created example localization file at '{examplePath}'.");
        }
        catch (Exception ex)
        {
            HeartLogger.Warning(LOG_SOURCE, $"Could not write example localization file: {ex.Message}");
        }
    }
}