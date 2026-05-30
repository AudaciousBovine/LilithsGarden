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
//           module that owns the feature, not in the shared core.
//
// [ADDED] GenerateLocalizationExample — opt-in example file generation.
//         Follows the same pattern as CookbookConfig.GenerateAllRecipes.
//
// [ADDED] ChunksPerFrame — controls the tiered sync send rate.
//         Limits how many chat message entities are created per frame
//         when sending sync payloads to connecting clients.
//
// [CHANGED] Corrected the example-file path in GenerateLocalizationExample's
//           summary and config description from the old Localization/ folder
//           to Items/. The writer (LocalizationService.EnsureExampleFile)
//           has always targeted Items/ — only these comments were stale.
public static class HeartConfig
{
    private const string LOG_SOURCE = "LilithsHeart.HeartConfig";

    static ConfigEntry<bool> _debugLogging                = null!;
    static ConfigEntry<bool> _generateLocalizationExample = null!;
    static ConfigEntry<int>  _chunksPerFrame              = null!;

    public static ConfigEntry<string> ServerName { get; private set; } = null!;

    public static bool IsDebug        => _debugLogging.Value;
    public static int  ChunksPerFrame => _chunksPerFrame.Value;

    /// <summary>
    /// When true, LocalizationService writes an example localization JSON
    /// to BepInEx/config/LilithsHeart/Items/example.json on next boot.
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

        _generateLocalizationExample = config.Bind(
            section:      "Generation",
            key:          "GenerateLocalizationExample",
            defaultValue: false,
            description:  "When set to true, generates an example localization JSON file at " +
                          "BepInEx/config/LilithsHeart/Items/example.json on next boot. " +
                          "Use this as a starting point for renaming items, spells, and other " +
                          "game objects. This setting resets to false automatically after generation."
        );

        // [ADDED] ChunksPerFrame — tiered sync rate limiter.
        //         Controls how many ChatMessageServerEvent entities are created
        //         per frame when draining the SyncQueue for connected clients.
        //
        //         Lower values reduce per-frame entity creation cost at the
        //         expense of longer sync times. Higher values speed up sync
        //         but increase frame load on connect spikes.
        //
        //         At 10 chunks/frame and 60fps:
        //           ~290 total chunks → ~0.5 seconds to fully sync one client
        //           With 20 simultaneous connects: 200 entity creates/frame
        //
        //         [PERFORMANCE] Reduce this value if you observe frame drops
        //         during large simultaneous-connect events (e.g. server restart
        //         when all players reconnect at once).
        _chunksPerFrame = config.Bind(
            section:      "Sync",
            key:          "ChunksPerFrame",
            defaultValue: 10,
            description:  "Maximum number of sync payload chunks sent per server frame. " +
                          "Higher values sync clients faster but increase CPU load on connect. " +
                          "Reduce if you see frame drops when many players connect simultaneously. " +
                          "Default: 10. Range: 1-50."
        );

        HeartLogger.Info(LOG_SOURCE,
            $"HeartConfig loaded. Debug={IsDebug}, ChunksPerFrame={ChunksPerFrame}");
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