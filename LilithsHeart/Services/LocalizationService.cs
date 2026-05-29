using System.Text.Json;
using LilithsMind.Data;
using LilithsHeart.Config;
using LilithsHeart.Foundation;

// ============================================================
//  LocalizationService — LilithsHeart
//  LilithsHeart/Services/LocalizationService.cs
//
//  Central service responsible for loading all localization and
//  appearance overrides across the entire LilithsGarden suite.
//
//  [CHANGED] Now supports multiple registered directories instead
//            of a single hardcoded Localization/ folder. Each module
//            registers its own directory at startup. LocalizationService
//            scans all registered directories recursively for *.json
//            files and merges results into LocalizationConfig.
//
//  Registration pattern:
//  ──────────────────────
//  Heart.OnInitialize() registers ItemsDir before firing OnInitialized.
//  Child modules register their own directories in their Load():
//
//      Heart.OnInitialized += () =>
//          LocalizationService.RegisterDirectory(HeartPathIndex.DataDir("MainQuest"));
//
//  Current registered directories:
//    • Items/          — Heart core (display names, tooltips, icons)
//    • MainQuest/      — LilithsMachinations (future)
//    • Spells/         — LilithsGrimoire (future)
//
//  Scan behaviour:
//  ────────────────
//  Each registered directory is scanned with SearchOption.AllDirectories
//  so admins can organize files into subdirectories freely:
//      Items/
//          Currencies/blood-essence.json
//          Weapons/swords.json
//          items.json
//  All files are collected, sorted by full path alphabetically across
//  all registered directories, then loaded in that order. Later files
//  win on a per-field basis via LocalizationConfig.AddOverride().
//
//  JSON format (combined appearance):
//  ────────────────────────────────────
//  {
//    "_readme": "...",
//    "Item_BloodEssence_T01": {
//      "DisplayName": "Vitae",
//      "Tooltip": "Concentrated life force.",
//      "Icon": "vitae.png"
//    }
//  }
//  All fields are optional. Non-object values (e.g. _readme) are skipped.
//
//  [PERFORMANCE] All files read once at world ready. No file I/O after
//                initialization unless Reload() is explicitly called.
//                Per-field merge in LocalizationConfig.AddOverride() is O(1).
// ============================================================

namespace LilithsHeart.Services;

public static class LocalizationService
{
    private const string LOG_SOURCE = "LilithsHeart.LocalizationService";

    // Registered directories to scan. Populated before Initialize() fires.
    // [PERFORMANCE] Small list — iteration is negligible.
    static readonly List<string> _registeredDirectories = [];

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Registers a directory to be scanned for *.json override files.
    /// Must be called before Initialize() to take effect on first load.
    /// Child modules call this in their Load() or OnInitialized handler.
    /// Directory does not need to exist yet — missing dirs are skipped gracefully.
    /// </summary>
    public static void RegisterDirectory(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return;

        if (!_registeredDirectories.Contains(path))
        {
            _registeredDirectories.Add(path);
            HeartLogger.Debug(LOG_SOURCE, $"Registered directory: '{path}'");
        }
    }

    /// <summary>
    /// Creates registered directories, writes the example file on first boot
    /// if configured, and loads all override files into LocalizationConfig.
    /// Called once by Heart.OnInitialize().
    /// </summary>
    public static void Initialize()
    {
        foreach (var dir in _registeredDirectories)
            Directory.CreateDirectory(dir);

        if (HeartConfig.GenerateLocalizationExample)
        {
            EnsureExampleFile();
            HeartConfig.DisableGenerateLocalizationExample();
        }

        Load();
    }

    /// <summary>
    /// Clears LocalizationConfig and reloads all files from all registered
    /// directories. Notifies Heart so the sync payload is rebuilt.
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
        // Collect all *.json files from all registered directories recursively.
        // Sort by full path alphabetically so merge order is consistent.
        var files = _registeredDirectories
            .Where(Directory.Exists)
            .SelectMany(dir =>
                Directory.GetFiles(dir, "*.json", SearchOption.AllDirectories))
            .OrderBy(f => f, StringComparer.Ordinal)
            .ToArray();

        if (files.Length == 0)
        {
            HeartLogger.Info(LOG_SOURCE,
                "No localization JSON files found in any registered directory. " +
                "Overrides disabled.");
            LocalizationConfig.MarkLoaded();
            return;
        }

        foreach (var file in files)
            LoadFile(file);

        LocalizationConfig.MarkLoaded();

        HeartLogger.Info(LOG_SOURCE,
            $"Loaded {LocalizationConfig.Overrides.Count} item appearance override(s) " +
            $"from {files.Length} file(s) across {_registeredDirectories.Count} directory(s).");
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
                    $"'{Path.GetFileName(filePath)}' parsed as null — " +
                    "check for malformed JSON.");
                return;
            }

            int count = 0;

            foreach (var (key, element) in raw)
            {
                // Skip non-object values (e.g. _readme string).
                if (element.ValueKind != JsonValueKind.Object) continue;

                string? displayName = null;
                string? tooltip     = null;
                string? icon        = null;

                if (element.TryGetProperty("DisplayName", out var dn) &&
                    dn.ValueKind == JsonValueKind.String)
                    displayName = dn.GetString();

                if (element.TryGetProperty("Tooltip", out var tt) &&
                    tt.ValueKind == JsonValueKind.String)
                    tooltip = tt.GetString();

                if (element.TryGetProperty("Icon", out var ic) &&
                    ic.ValueKind == JsonValueKind.String)
                    icon = ic.GetString();

                // Skip entirely empty entries.
                if (displayName is null && tooltip is null && icon is null) continue;

                LocalizationConfig.AddOverride(key, new ItemAppearanceData
                {
                    DisplayName = displayName,
                    Tooltip     = tooltip,
                    Icon        = icon,
                });

                count++;
            }

            HeartLogger.Info(LOG_SOURCE,
                $"Loaded '{Path.GetFileName(filePath)}' — {count} override(s).");
        }
        catch (Exception ex)
        {
            HeartLogger.Error(LOG_SOURCE,
                $"Failed to parse '{Path.GetFileName(filePath)}': {ex.Message}");
        }
    }

    /// <summary>
    /// Writes an example items.json to the Items/ directory on first boot.
    /// Only runs when HeartConfig.GenerateLocalizationExample is true.
    /// </summary>
    static void EnsureExampleFile()
    {
        var itemsDir  = HeartPathIndex.ItemsDir;
        var examplePath = Path.Combine(itemsDir, "example.json");
        if (File.Exists(examplePath)) return;

        const string example = """
{
  "_readme": "Keys are the prefab Name or Prefab string from LilithsMind PrefabDef entries (e.g. 'BloodEssence' or 'Item_BloodEssence_T01'). All fields are optional — omit any you do not want to change. Icon can be a local PNG filename (resolved from Icons/ folder on each client), an in-game sprite name, or an https:// URL. Files in subdirectories are included automatically. Files load in full-path alphabetical order — later files win per field on key conflicts.",
  "Item_BloodEssence_T01": {
    "DisplayName": "Vitae",
    "Tooltip": "Concentrated life force, harvested from the living.",
    "Icon": "vitae.png"
  }
}
""";

        try
        {
            Directory.CreateDirectory(itemsDir);
            File.WriteAllText(examplePath, example);
            HeartLogger.Info(LOG_SOURCE,
                $"Created example file at '{examplePath}'.");
        }
        catch (Exception ex)
        {
            HeartLogger.Warning(LOG_SOURCE,
                $"Could not write example file: {ex.Message}");
        }
    }
}