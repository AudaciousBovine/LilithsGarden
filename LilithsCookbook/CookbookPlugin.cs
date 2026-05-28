using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using LilithsHeart.Config;
using LilithsHeart.Foundation;
using LilithsHeart.Modules;
using LilithsCookbook.Config;
using LilithsCookbook.Data;
using LilithsCookbook.Systems;

// [CHANGED] All MyPluginInfo references are fully qualified as LilithsCookbook.MyPluginInfo.
//           BepInEx.PluginInfoProps generates a MyPluginInfo class per project, and since
//           CookbookPlugin has a ProjectReference to LilithsHeart, both LilithsCookbook.MyPluginInfo
//           and LilithsHeart.MyPluginInfo are in scope. The compiler cannot choose between them
//           without qualification. Any child module that references Heart will need to do the same.

namespace LilithsCookbook;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("audaciousbovine.lilithsheart")]
public class CookbookPlugin : BasePlugin
{
    private const string LOG_SOURCE = "LilithsCookbook";

    public static CookbookRecipeData?  RecipeData  { get; private set; }
    public static CookbookStationData? StationData { get; private set; }

    public override void Load()
    {
        HeartLogger.Info(LOG_SOURCE, $"{LilithsCookbook.MyPluginInfo.PLUGIN_NAME} v{LilithsCookbook.MyPluginInfo.PLUGIN_VERSION} loading.");

        var configFile = new ConfigFile(HeartPathIndex.ModuleConfig("LilithsCookbook"), saveOnInit: true);

        CookbookConfig.Initialize(configFile);
        CookbookBuilder.Initialize();

        HeartModuleRegistry.Register(new HeartModuleData
        {
            ModuleId   = LilithsCookbook.MyPluginInfo.PLUGIN_GUID,
            ModuleName = LilithsCookbook.MyPluginInfo.PLUGIN_NAME,
            Version    = LilithsCookbook.MyPluginInfo.PLUGIN_VERSION,
        });

        Heart.OnInitialized += OnHeartInitialized;
    }

    public override bool Unload()
    {
        Heart.OnInitialized -= OnHeartInitialized;
        HeartLogger.Info(LOG_SOURCE, $"{LilithsCookbook.MyPluginInfo.PLUGIN_NAME} unloaded.");
        return true;
    }

    static void OnHeartInitialized()
    {
        CookbookBuilder.GenerateAllRecipesIfRequested();

        RecipeData  = CookbookLoader.LoadRecipes(CookbookBuilder.RecipesDir);
        StationData = CookbookLoader.LoadStations(CookbookBuilder.StationsDir);

        RecipeSystem.ApplyChanges();
        StationSystem.ApplyChanges();
    }
}