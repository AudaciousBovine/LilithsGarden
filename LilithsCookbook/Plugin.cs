using BepInEx;
using BepInEx.Unity.IL2CPP;
using LilithsHeart;
using LilithsCookbook.Data;
using LilithsCookbook.Systems;

namespace LilithsCookbook;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("audaciousbovine.lilithsheart")]
public class Plugin : BasePlugin
{
    public static CookbookRecipeData? RecipeData { get; private set; }
    // Added: StationData property
    public static CookbookStationData? StationData { get; private set; }

    public override void Load()
    {
        LilithsLogger.Info($"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} loaded.");

        RecipeData = ConfigLoader.LoadRecipes();
        // Added: Load station config
        StationData = ConfigLoader.LoadStations();

        Core.OnInitialized += RecipeSystem.ApplyChanges;
        // Added: Subscribe station system to initialization event
        Core.OnInitialized += StationSystem.ApplyChanges;
    }

    public override bool Unload()
    {
        Core.OnInitialized -= RecipeSystem.ApplyChanges;
        // Added: Unsubscribe station system
        Core.OnInitialized -= StationSystem.ApplyChanges;
        return true;
    }
}