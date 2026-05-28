using System.Text.Json;
using LilithsHeart.Config;
using LilithsHeart.Foundation;

// ============================================================
//  LocalizationService — LilithsHeart
//  LilithsHeart/Services/LocalizationService.cs
//
//  Owns the loading pipeline for server-defined display name and
//  tooltip overrides. Reads ALL *.json files found in:
//      BepInEx/config/LilithsHeart/Localization/
//
//  Files are loaded and merged in alphabetical order.
//  Later files win on key conflicts — admins can layer overrides.
//
//  Results are stored in LocalizationConfig via internal mutators.
//  Consumers read from LocalizationConfig — not from this class.
//
//  [CHANGED] Extracted from LocalizationConfig which previously
//            mixed data storage with loading logic. LocalizationConfig
//            is now a pure data surface. This class owns:
//              • Initialize() — first load at world ready
//              • Reload()     — hot-reload during a session
//              • Load()       — internal scan and merge
//              • LoadFile()   — per-file parse
//              • EnsureExampleFile() — writes example on first boot
//
//  Call order:
//      Heart.OnWorldReady() → LocalizationService.Initialize()
//      Admin command        → LocalizationService.Reload()
//
//  [PERFORMANCE] All files are read once at world ready and merged
//                into LocalizationConfig's flat dictionaries for
//                O(1) lookup. No file I/O occurs after initialization
//                unless Reload() is explicitly called.
// ============================================================

namespace LilithsHeart.Services;

public static class LocalizationService
{
    private const string LOG_SOURCE = "LilithsHeart.LocalizationService";

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Creates the Localization directory, writes the example file on
    /// first boot, and loads all override files into LocalizationConfig.
    /// Called once by Heart.OnWorldReady().
    /// </summary>
    public static void Initialize()
    {
        Directory.CreateDirectory(HeartPathIndex.LocalizationDir);

        // [CHANGED] Example file is no longer written on every first boot.
        //           It is only generated when the admin explicitly sets
        //           HeartConfig.GenerateLocalizationExample = true in the
        //           .cfg file. The flag resets to false after generation
        //           so the file is never overwritten on subsequent boots.
        //           This pattern is consistent with CookbookConfig.GenerateAllRecipes.
        if (HeartConfig.GenerateLocalizationExample)
        {
            EnsureExampleFile();
            HeartConfig.DisableGenerateLocalizationExample();
        }

        Load();
    }

    /// <summary>
    /// Clears LocalizationConfig and reloads all files from disk.
    /// Notifies Heart so the sync payload is rebuilt and resent.
    /// Called by admin reload commands.
    /// </summary>
    public static void Reload()
    {
        LocalizationConfig.Clear();
        HeartLogger.Info(LOG_SOURCE, "Reloading localization overrides...");
        Load();
        Heart.OnLocalizationReloaded();
    }

    // ── Internal ─────────────────────────────────────────────

    static void Load()
    {
        var files = Directory.GetFiles(HeartPathIndex.LocalizationDir, "*.json")
                             .OrderBy(f => f)
                             .ToArray();

        if (files.Length == 0)
        {
            HeartLogger.Info(LOG_SOURCE,
                "No localization JSON files found. Overrides disabled.");
            LocalizationConfig.MarkLoaded();
            return;
        }

        foreach (var file in files)
            LoadFile(file);

        LocalizationConfig.MarkLoaded();

        HeartLogger.Info(LOG_SOURCE,
            $"Loaded {LocalizationConfig.DisplayNames.Count} display name(s) and " +
            $"{LocalizationConfig.Tooltips.Count} tooltip(s) from {files.Length} file(s).");
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
                    LocalizationConfig.AddDisplayName(key, displayName!);
                    nameCount++;
                }

                if (!string.IsNullOrWhiteSpace(tooltip))
                {
                    LocalizationConfig.AddTooltip(key, tooltip!);
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

    /// <summary>
    /// Writes an example localization JSON file on first boot if none exists.
    /// The example demonstrates the correct key and field format.
    /// Only Item_BloodEssence_T01 is used — it has NameKey and DescKey
    /// confirmed in LilithsMind and is verified working end-to-end.
    /// </summary>
    static void EnsureExampleFile()
    {
        var examplePath = Path.Combine(HeartPathIndex.LocalizationDir, "example.json");
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
            HeartLogger.Info(LOG_SOURCE,
                $"Created example localization file at '{examplePath}'.");
        }
        catch (Exception ex)
        {
            HeartLogger.Warning(LOG_SOURCE,
                $"Could not write example localization file: {ex.Message}");
        }
    }
}