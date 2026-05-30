using LilithsHeart.Config;
using LilithsHeart.Foundation;

// ============================================================
//  HeartConfigBuilder — LilithsHeart
//  LilithsHeart/Services/HeartConfigBuilder.cs
//
//  Generates example config files for Heart and its registered
//  directories. Called from Heart.OnInitialize() before
//  LocalizationService.Initialize() loads overrides.
//
//  Follows the same pattern as CookbookConfigBuilder — generation
//  logic is separated from loading logic. LocalizationService
//  is a loader only; it does not write files.
//
//  Config flags that trigger generation:
//  ──────────────────────────────────────
//  HeartConfig.GenerateLocalizationExample — writes Items/example.json
//  Each flag resets to false automatically after generation so
//  the file is only written once unless the admin re-enables it.
//
//  Future generation flags (as modules are added):
//    GenerateQuestExample    → MainQuest/example.json  (Machinations)
//    GenerateSpellExample    → Spells/example.json     (Grimoire)
//
//  [PERFORMANCE] File I/O only occurs when a generation flag is
//                true — zero cost on normal boots.
// ============================================================

namespace LilithsHeart.Services;

public static class HeartConfigBuilder
{
    private const string LOG_SOURCE = "LilithsHeart.HeartConfigBuilder";

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Checks all generation flags and writes example files where needed.
    /// Called once by Heart.OnInitialize() before LocalizationService loads.
    /// </summary>
    public static void GenerateIfRequested()
    {
        if (HeartConfig.GenerateLocalizationExample)
        {
            GenerateItemsExample();
            HeartConfig.DisableGenerateLocalizationExample();
        }
    }

    // ── Internal ─────────────────────────────────────────────

    /// <summary>
    /// Writes Items/example.json demonstrating all three icon methods
    /// alongside display name and tooltip overrides.
    /// Skipped if the file already exists.
    /// </summary>
    static void GenerateItemsExample()
    {
        var itemsDir    = HeartPathIndex.ItemsDir;
        var examplePath = Path.Combine(itemsDir, "example.json");

        if (File.Exists(examplePath))
        {
            HeartLogger.Info(LOG_SOURCE,
                $"Items example already exists at '{examplePath}' — skipping.");
            return;
        }

        const string example = """
{
  "_readme": "Keys are the prefab Name or Prefab string from LilithsMind PrefabDef entries (e.g. 'BloodEssence' or 'Item_BloodEssence_T01'). All fields are optional — omit any you do not want to change. Files in subdirectories are included automatically (e.g. Items/Currencies/). Files load in full-path alphabetical order — later files win per-field on key conflicts.",

  "_icon_readme": "Icon can be set three ways: (1) a PNG filename resolved from the client's Icons/ folder — e.g. 'vitae.png'; (2) an in-game sprite name from Resources — e.g. 'Icon_BloodOrb'; (3) an https:// URL the client will download and cache to their Icons/ folder — e.g. 'https://example.com/icons/vitae.png'. The client tries local file first, then in-game sprite, then URL.",

  "Item_BloodEssence_T01": {
    "_comment": "Example 1: rename + tooltip + local PNG icon (client must have vitae.png in their Icons/ folder)",
    "DisplayName": "Vitae",
    "Tooltip": "Concentrated life force, harvested from the living.",
    "Icon": "vitae.png"
  },

  "Item_Ingredient_Gem_Ruby_T01": {
    "_comment": "Example 2: swap with an existing in-game sprite by its sprite name",
    "DisplayName": "Bloodstone",
    "Icon": "Icon_BloodOrb"
  },

  "Item_MagicSource_BloodKey_T01": {
    "_comment": "Example 3: use a hosted image — client downloads once and caches to Icons/",
    "DisplayName": "Crimson Key",
    "Icon": "https://example.com/icons/crimson-key.png"
  }
}
""";

        try
        {
            Directory.CreateDirectory(itemsDir);
            File.WriteAllText(examplePath, example);
            HeartLogger.Info(LOG_SOURCE,
                $"Generated Items example at '{examplePath}'.");
        }
        catch (Exception ex)
        {
            HeartLogger.Warning(LOG_SOURCE,
                $"Could not write Items example: {ex.Message}");
        }
    }
}