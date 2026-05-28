using BepInEx.Configuration;
using LilithsHeart.Foundation;

namespace LilithsHeart.Config;

// [CHANGED] Removed Lazy<T> wrappers from all config accessors.
//           BepInEx's ConfigEntry<T>.Value already caches the parsed value
//           after the first read. Lazy<T> on top of that added no benefit and
//           introduced a hot-reload bug: once evaluated, Lazy<T> never
//           re-reads even if the ConfigFile is reloaded at runtime.
//           Reading .Value directly matches the pattern used in CookbookConfig
//           and is safe — no file I/O occurs after Initialize().
//
// [CHANGED] Removed StartingInventorySize and GlobalPlayerMovementSpeedMultiplier.
//           HeartConfig is infrastructure-only. Gameplay settings belong in the
//           module that owns the feature, not in the shared core. Those two
//           settings will move to the appropriate gameplay module when built.
//
// [ADDED] GenerateLocalizationExample — opt-in example file generation.
//         Follows the same pattern as CookbookConfig.GenerateAllRecipes.
//         The example is only written when explicitly requested by the admin.
//         The flag resets to false automatically after generation so the
//         file is never overwritten on subsequent boots.
public static class HeartConfig
{
    private const string LOG_SOURCE = "LilithsHeart.HeartConfig";

    static ConfigEntry<bool> _debugLogging              = null!;
    static ConfigEntry<bool> _generateLocalizationExample = null!;

    public static ConfigEntry<string> ServerName { get; private set; } = null!;

    public static bool IsDebug => _debugLogging.Value;

    /// <summary>
    /// When true, LocalizationService writes an example localization JSON
    /// to BepInEx/config/LilithsHeart/Localization/example.json on next boot.
    /// Resets to false automatically after the file is written.
    /// </summary>
    public static bool GenerateLocalizationExample => _generateLocalizationExample.Value;

    public static void Initialize(ConfigFile config)
    {
        _debugLogging = config.Bind(
            section:      "Core",
            key:          "DebugLogging",
            defaultValue: false,
            description:  "Enable verbose debug logging for LilithsHeart. " +
                          "Useful during development, disable on live servers."
        );

        ServerName = config.Bind(
            section:      "General",
            key:          "ServerName",
            defaultValue: "LilithsGarden",
            description:  "Unique name for this server. Used by Soul clients to cache server-specific " +
                          "configs. Change this if you run multiple LilithsGarden servers."
        );

        // [ADDED] Opt-in example localization file generation.
        //         Disabled by default — only generates when the admin explicitly
        //         sets this to true. Resets automatically after generation via
        //         DisableGenerateLocalizationExample().
        _generateLocalizationExample = config.Bind(
            section:      "Generation",
            key:          "GenerateLocalizationExample",
            defaultValue: false,
            description:  "When set to true, generates an example localization JSON file at " +
                          "BepInEx/config/LilithsHeart/Localization/example.json on next boot. " +
                          "Use this as a starting point for renaming items, spells, and other " +
                          "game objects. This setting resets to false automatically after generation."
        );

        HeartLogger.Info(LOG_SOURCE, $"HeartConfig loaded. Debug={IsDebug}");
    }

    /// <summary>
    /// Resets GenerateLocalizationExample to false after the example file is written.
    /// Called automatically by LocalizationService after generation completes.
    /// </summary>
    public static void DisableGenerateLocalizationExample()
    {
        _generateLocalizationExample.Value = false;
        HeartLogger.Info(LOG_SOURCE, "GenerateLocalizationExample reset to false.");
    }
}