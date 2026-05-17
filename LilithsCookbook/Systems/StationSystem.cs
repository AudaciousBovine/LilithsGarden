using ProjectM;
using Stunlock.Core;
using Unity.Entities;
using LilithsHeart;
using LilithsHeart.Systems;
using LilithsHeart.Extensions;
using LilithsCookbook.Data;

namespace LilithsCookbook.Systems;

public static class StationSystem
{
    public static void ApplyChanges()
    {
        var config = Plugin.StationData;

        if (config == null || config.Stations.Count == 0)
        {
            LilithsLogger.Info("No station changes configured.");
            return;
        }

        int changed = 0;

        foreach (var (stationName, entry) in config.Stations)
        {
            if (!entry.ChangesEnabled) continue;

            // Resolve station name to GUID
            if (!PrefabNameResolver.TryResolve(stationName, out PrefabGUID guid))
            {
                LilithsLogger.Warning($"Could not resolve station: {stationName}");
                continue;
            }

            // Look up prefab entity
            if (!Core.PrefabCollectionSystem._PrefabGuidToEntityMap.TryGetValue(guid, out Entity stationEntity))
            {
                LilithsLogger.Warning($"Could not find prefab entity for station: {stationName}");
                continue;
            }

            // Add recipes
            if (entry.AddRecipes.Count > 0)
                AddRecipes(stationEntity, entry.AddRecipes, stationName);

            // Remove recipes
            if (entry.RemoveRecipes.Count > 0)
                RemoveRecipes(stationEntity, entry.RemoveRecipes, stationName);

            changed++;
            LilithsLogger.Info($"Applied changes to station: {stationName}");
        }

        // Register changes with game systems
        Core.GameDataSystem.RegisterRecipes();
        Core.PrefabCollectionSystem.RegisterGameData();

        LilithsLogger.Info($"LilithsCookbook applied changes to {changed} stations.");
    }

static void AddRecipes(Entity stationEntity, List<string> recipes, string stationName)
{
    if (!stationEntity.Has<RefinementstationRecipesBuffer>())
    {
        LilithsLogger.Warning($"Station {stationName} does not have a recipe buffer.");
        return;
    }

    var buffer = stationEntity.ReadBuffer<RefinementstationRecipesBuffer>();

    foreach (var recipeName in recipes)
    {
        if (!PrefabNameResolver.TryResolve(recipeName, out PrefabGUID recipeGuid))
        {
            LilithsLogger.Warning($"Could not resolve recipe to add: {recipeName}");
            continue;
        }

        // Added: Check if recipe already exists in station
        bool alreadyExists = false;
        for (int i = 0; i < buffer.Length; i++)
        {
            if (buffer[i].RecipeGuid.Equals(recipeGuid))
            {
                alreadyExists = true;
                break;
            }
        }

        if (alreadyExists)
        {
            LilithsLogger.Warning($"Recipe {recipeName} already exists in station {stationName}, skipping.");
            continue;
        }

        buffer.Add(new RefinementstationRecipesBuffer
        {
            RecipeGuid = recipeGuid,
            Disabled = false,
            Unlocked = true
        });

        LilithsLogger.Info($"Added recipe {recipeName} to station {stationName}");
    }
}

    static void RemoveRecipes(Entity stationEntity, List<string> recipes, string stationName)
    {
        if (!stationEntity.Has<RefinementstationRecipesBuffer>())
        {
            LilithsLogger.Warning($"Station {stationName} does not have a recipe buffer.");
            return;
        }

        var buffer = stationEntity.ReadBuffer<RefinementstationRecipesBuffer>();

        foreach (var recipeName in recipes)
        {
            if (!PrefabNameResolver.TryResolve(recipeName, out PrefabGUID recipeGuid))
            {
                LilithsLogger.Warning($"Could not resolve recipe to remove: {recipeName}");
                continue;
            }

            // Iterate backwards when removing from buffer
            for (int i = buffer.Length - 1; i >= 0; i--)
            {
                if (buffer[i].RecipeGuid.Equals(recipeGuid))
                {
                    buffer.RemoveAt(i);
                    LilithsLogger.Info($"Removed recipe {recipeName} from station {stationName}");
                    break;
                }
            }
        }
    }
}