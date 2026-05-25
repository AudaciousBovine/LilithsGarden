using ProjectM;
using Stunlock.Core;
using Unity.Entities;
using LilithsHeart.Foundation;
using LilithsHeart.Prefabs;
using LilithsCookbook.Data;

namespace LilithsCookbook.Systems;

// [CHANGED] LilithsLogger → HeartLogger throughout.
//           Added using LilithsHeart.Prefabs for PrefabNameResolver.
//
// [CHANGED] StationSystem now supports both RefinementstationRecipesBuffer
//           (crafting stations) and WorkstationRecipesBuffer (player entity).
//           Detection is automatic — the system checks which buffer type the
//           entity has and operates on whichever is present. This allows the
//           player's crafting menu to be configured in the same stations.json
//           file using the player prefab name (e.g. "VampireUser").
//
//           If an entity has neither buffer type, a warning is logged and
//           the entry is skipped — same behaviour as before.
public static class StationSystem
{
    private const string LOG_SOURCE = "LilithsCookbook.StationSystem";

    public static void ApplyChanges()
    {
        var config = CookbookPlugin.StationData;

        if (config == null || config.Stations.Count == 0)
        {
            HeartLogger.Info(LOG_SOURCE, "No station changes configured.");
            return;
        }

        int changed = 0;

        foreach (var (stationName, entry) in config.Stations)
        {
            if (!entry.ChangesEnabled) continue;

            if (!PrefabNameResolver.TryResolve(stationName, out PrefabGUID guid))
            {
                HeartLogger.Warning(LOG_SOURCE, $"Could not resolve station: '{stationName}'");
                continue;
            }

            if (!Heart.PrefabCollectionSystem._PrefabGuidToEntityMap.TryGetValue(guid, out Entity stationEntity))
            {
                HeartLogger.Warning(LOG_SOURCE, $"Could not find prefab entity for station: '{stationName}'");
                continue;
            }

            // [TEMP DEBUG]
            HeartLogger.Info(LOG_SOURCE, $"[DEBUG] Found entity for '{stationName}': {stationEntity}");
            HeartLogger.Info(LOG_SOURCE, $"[DEBUG] HasRefinement={stationEntity.Has<RefinementstationRecipesBuffer>()} HasWorkstation={stationEntity.Has<WorkstationRecipesBuffer>()}");

            // [CHANGED] Detect buffer type — RefinementstationRecipesBuffer for

            // [CHANGED] Detect buffer type — RefinementstationRecipesBuffer for
            //           crafting stations, WorkstationRecipesBuffer for the player
            //           entity. Whichever is present is used. If neither exists,
            //           the entry is skipped with a warning.
            bool hasRefinement  = stationEntity.Has<RefinementstationRecipesBuffer>();
            bool hasWorkstation = stationEntity.Has<WorkstationRecipesBuffer>();

            if (!hasRefinement && !hasWorkstation)
            {
                HeartLogger.Warning(LOG_SOURCE,
                    $"'{stationName}' has neither RefinementstationRecipesBuffer nor " +
                    $"WorkstationRecipesBuffer — skipping.");
                continue;
            }

            if (entry.AddRecipes.Count > 0)
            {
                if (hasRefinement)
                    AddRefinementRecipes(stationEntity, entry.AddRecipes, stationName);
                else
                    AddWorkstationRecipes(stationEntity, entry.AddRecipes, stationName);
            }

            if (entry.RemoveRecipes.Count > 0)
            {
                if (hasRefinement)
                    RemoveRefinementRecipes(stationEntity, entry.RemoveRecipes, stationName);
                else
                    RemoveWorkstationRecipes(stationEntity, entry.RemoveRecipes, stationName);
            }

            changed++;
            HeartLogger.Info(LOG_SOURCE, $"Applied changes to station: '{stationName}'");
        }

        if (changed > 0)
        {
            Heart.GameDataSystem.RegisterRecipes();
            Heart.PrefabCollectionSystem.RegisterGameData();
            HeartLogger.Info(LOG_SOURCE, $"LilithsCookbook applied changes to {changed} station(s).");
        }
        else
        {
            HeartLogger.Info(LOG_SOURCE, "No stations had ChangesEnabled = true, skipping registration.");
        }
    }

    // ── RefinementstationRecipesBuffer helpers ────────────────────────────────

    static void AddRefinementRecipes(Entity stationEntity, List<string> recipes, string stationName)
    {
        var buffer = stationEntity.ReadBuffer<RefinementstationRecipesBuffer>();

        foreach (var recipeName in recipes)
        {
            if (!PrefabNameResolver.TryResolve(recipeName, out PrefabGUID recipeGuid))
            {
                HeartLogger.Warning(LOG_SOURCE,
                    $"[{stationName}] Could not resolve recipe to add: '{recipeName}', skipping.");
                continue;
            }

            // Check for duplicates before adding.
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
                HeartLogger.Info(LOG_SOURCE,
                    $"[{stationName}] Recipe '{recipeName}' already present, skipping.");
                continue;
            }

            buffer.Add(new RefinementstationRecipesBuffer
            {
                RecipeGuid = recipeGuid,
                Disabled   = false,
                Unlocked   = true
            });

            HeartLogger.Info(LOG_SOURCE, $"[{stationName}] Added recipe '{recipeName}'.");
        }
    }

    static void RemoveRefinementRecipes(Entity stationEntity, List<string> recipes, string stationName)
    {
        var buffer = stationEntity.ReadBuffer<RefinementstationRecipesBuffer>();

        foreach (var recipeName in recipes)
        {
            if (!PrefabNameResolver.TryResolve(recipeName, out PrefabGUID recipeGuid))
            {
                HeartLogger.Warning(LOG_SOURCE,
                    $"[{stationName}] Could not resolve recipe to remove: '{recipeName}', skipping.");
                continue;
            }

            bool found = false;

            // Iterate backwards when removing from a DynamicBuffer to keep indices stable.
            for (int i = buffer.Length - 1; i >= 0; i--)
            {
                if (buffer[i].RecipeGuid.Equals(recipeGuid))
                {
                    buffer.RemoveAt(i);
                    HeartLogger.Info(LOG_SOURCE, $"[{stationName}] Removed recipe '{recipeName}'.");
                    found = true;
                    break;
                }
            }

            if (!found)
                HeartLogger.Info(LOG_SOURCE,
                    $"[{stationName}] Recipe '{recipeName}' not found in station, nothing to remove.");
        }
    }

    // ── WorkstationRecipesBuffer helpers ──────────────────────────────────────

    // [CHANGED] WorkstationRecipesBuffer uses a different struct type than
    //           RefinementstationRecipesBuffer — it has only RecipeGuid with
    //           no Disabled/Unlocked fields. Separate helpers handle it cleanly.

    static void AddWorkstationRecipes(Entity stationEntity, List<string> recipes, string stationName)
    {
        var buffer = stationEntity.ReadBuffer<WorkstationRecipesBuffer>();

        foreach (var recipeName in recipes)
        {
            if (!PrefabNameResolver.TryResolve(recipeName, out PrefabGUID recipeGuid))
            {
                HeartLogger.Warning(LOG_SOURCE,
                    $"[{stationName}] Could not resolve recipe to add: '{recipeName}', skipping.");
                continue;
            }

            // Check for duplicates before adding.
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
                HeartLogger.Info(LOG_SOURCE,
                    $"[{stationName}] Recipe '{recipeName}' already present, skipping.");
                continue;
            }

            buffer.Add(new WorkstationRecipesBuffer { RecipeGuid = recipeGuid });

            HeartLogger.Info(LOG_SOURCE, $"[{stationName}] Added recipe '{recipeName}'.");
        }
    }

    static void RemoveWorkstationRecipes(Entity stationEntity, List<string> recipes, string stationName)
    {
        var buffer = stationEntity.ReadBuffer<WorkstationRecipesBuffer>();

        foreach (var recipeName in recipes)
        {
            if (!PrefabNameResolver.TryResolve(recipeName, out PrefabGUID recipeGuid))
            {
                HeartLogger.Warning(LOG_SOURCE,
                    $"[{stationName}] Could not resolve recipe to remove: '{recipeName}', skipping.");
                continue;
            }

            bool found = false;

            // Iterate backwards when removing from a DynamicBuffer to keep indices stable.
            for (int i = buffer.Length - 1; i >= 0; i--)
            {
                if (buffer[i].RecipeGuid.Equals(recipeGuid))
                {
                    buffer.RemoveAt(i);
                    HeartLogger.Info(LOG_SOURCE, $"[{stationName}] Removed recipe '{recipeName}'.");
                    found = true;
                    break;
                }
            }

            if (!found)
                HeartLogger.Info(LOG_SOURCE,
                    $"[{stationName}] Recipe '{recipeName}' not found in station, nothing to remove.");
        }
    }
}