using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;

namespace LilithsHeart;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        LilithsLogger.Initialize(base.Log);
        LilithsLogger.Info($"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} loaded.");
    }

    public override bool Unload()
    {
        return true;
    }
}