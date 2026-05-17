using System.Text.Json;
using LilithsHeart;
using LilithsCookbook.Data;

namespace LilithsCookbook.Systems;

public static class ConfigLoader
{
    private static readonly string RecipeConfigPath = Path.Combine(
        BepInEx.Paths.ConfigPath,
        "LilithsCookbook",
        "recipes-config.json"
    );

    // Added: Station config path
    private static readonly string StationConfigPath = Path.Combine(
        BepInEx.Paths.ConfigPath,
        "LilithsCookbook",
        "stations-config.json"
    );

    public static CookbookRecipeData LoadRecipes()
    {
        if (!File.Exists(RecipeConfigPath))
        {
            LilithsLogger.Warning($"recipes-config.json not found at {RecipeConfigPath}, using vanilla values.");
            return new CookbookRecipeData();
        }

        try
        {
            var json = File.ReadAllText(RecipeConfigPath);
            var config = JsonSerializer.Deserialize<CookbookRecipeData>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            LilithsLogger.Info($"Loaded recipes-config.json successfully.");
            return config ?? new CookbookRecipeData();
        }
        catch (Exception e)
        {
            LilithsLogger.Error($"Failed to load recipes-config.json: {e.Message}");
            return new CookbookRecipeData();
        }
    }

    // Added: LoadStations method
    public static CookbookStationData LoadStations()
    {
        if (!File.Exists(StationConfigPath))
        {
            LilithsLogger.Warning($"stations-config.json not found at {StationConfigPath}, using vanilla values.");
            return new CookbookStationData();
        }

        try
        {
            var json = File.ReadAllText(StationConfigPath);
            var config = JsonSerializer.Deserialize<CookbookStationData>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            LilithsLogger.Info($"Loaded stations-config.json successfully.");
            return config ?? new CookbookStationData();
        }
        catch (Exception e)
        {
            LilithsLogger.Error($"Failed to load stations-config.json: {e.Message}");
            return new CookbookStationData();
        }
    }
}