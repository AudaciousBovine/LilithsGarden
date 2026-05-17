using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using LilithsHeart.Config;
using LilithsHeart.Events;
using LilithsHeart.Registry;
using LilithsHeart.Resources;

namespace LilithsHeart;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("gg.deca.VampireCommandFramework")]
public class HeartPlugin : BasePlugin
{
    static Harmony? _harmony;

    public override void Load()
    {
        // Logger initialized first and outside the try/catch so it is
        // always available to report any failures that occur after this point.
        LilithsLogger.Initialize(base.Log);

        try
        {
            LilithsLogger.Info("LilithsHeart", $"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} loaded.");

            HeartConfig.Initialize(Config);
            PrefabRegistry.Initialize();
            HeartEventBus.Initialize();
            ModuleRegistry.Initialize();

            // [CHANGED] Unpatch first to prevent orphaned patches if Load()
            //           is somehow called more than once during hot-reload.
            _harmony?.UnpatchSelf();
            _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            _harmony.PatchAll();

            LilithsLogger.Info("LilithsHeart", "LilithsHeart is ready.");
        }
        catch (Exception ex)
        {
            LilithsLogger.Error("LilithsHeart", $"Failed to load: {ex.Message}");
        }
    }

    public override bool Unload()
    {
        _harmony?.UnpatchSelf();
        HeartEventBus.Shutdown();
        ModuleRegistry.Shutdown();

        LilithsLogger.Info("LilithsHeart", "LilithsHeart unloaded.");
        return true;
    }
}