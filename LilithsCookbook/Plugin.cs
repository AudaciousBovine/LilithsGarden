using BepInEx;
using BepInEx.Unity.IL2CPP;
using LilithsHeart;

namespace LilithsCookbook;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("audaciousbovine.lilithsheart")]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        LilithsLogger.Info($"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} loaded.");
    }

    public override bool Unload()
    {
        return true;
    }
}