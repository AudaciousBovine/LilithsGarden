using ProjectM;
using Stunlock.Core;
using Unity.Entities;
using LilithsHeart.Foundation;
using LilithsHeart.Services;
using LilithsCookbook.Data;
namespace LilithsCookbook.Systems;

// ============================================================
//  StationSystem — LilithsCookbook
//
//  Applies crafting station recipe changes from stations.json.
//
//  Supports two buffer types:
//    • RefinementstationRecipesBuffer — refining stations
//      (Furnace, Grinder, etc.) where production is automatic.
//    • WorkstationRecipesBuffer — crafting stations (Simple
//      Workbench, etc.) and the player entity crafting menu.
//      Buffer type is detected automatically per station entry.
//
//  Two-pass approach:
//  ──────────────────
//  Pass 1: Patch all prefab entities (all buffer types).
//  Registration: RegisterRecipes() + RegisterGameData().
//  Pass 2: Patch live entities only — User entities for player
//          crafting, placed station entities via single batched
//          GetAllEntities() scan.
//
//  Why two passes?
//  ───────────────
//  RegisterGameData() resets WorkstationRecipesBuffer on all live
//  entities. Pass 1 prefab patches survive this reset. Pass 2 live
//  entity patches happen after registration so they persist.
//
//  Why GetAllEntities() for placed stations:
//  ──────────────────────────────────────────
//  V Rising keeps the Unity.Entities.Prefab tag on placed world
//  instances, making None=[Prefab] query exclusion ineffective.
//  GetAllEntities() with direct prefab entity identity exclusion
//  (entity == prefabEntity) is the only reliable approach.
//
//  [CHANGED] PatchAllLiveStationEntities() replaces the per-station
//            PatchLiveStationEntities() call. A single GetAllEntities()
//            scan handles all configured WorkstationRecipesBuffer
//            stations in one pass — O(entities) instead of
//            O(entities × station count).
//
//  [PERFORMANCE] All ECS operations run once at startup only.
//                No per-frame cost after initialization.
//                Single GetAllEntities() scan for all stations.
// ============================================================

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

        int enabled = config.Stations.Count(kvp => kvp.Value.ChangesEnabled);
        if (enabled == 0)
        {
            HeartLogger.Info(LOG_SOURCE, "No stations had ChangesEnabled = true, skipping.");
            return;
        }

        // ── Pass 1: Patch all prefab entities ─────────────────────────────────
        // Patches RefinementstationRecipesBuffer and WorkstationRecipesBuffer
        // prefab entities. RegisterGameData() resets WorkstationRecipesBuffer on
        // live entities after this — prefab patches survive unaffected.

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

            HeartLogger.Info(LOG_SOURCE, $"[Pass 1] Patched prefab: '{stationName}'");
        }

        // ── Registration ──────────────────────────────────────────────────────
        Heart.GameDataSystem.RegisterRecipes();
        Heart.PrefabCollectionSystem.RegisterGameData();

        // ── Pass 2: Patch all live entities ───────────────────────────────────
        // Build lookup maps for Pass 2 before scanning entities.

        // User entity patching — handled per-station as before (cheap query).
        // Workstation live entity patching — batched into one GetAllEntities() scan.

        // [CHANGED] Build a map of PrefabGUID → (stationName, entry, prefabEntity)
        //           for all WorkstationRecipesBuffer stations that need live patching.
        //           This allows a single GetAllEntities() scan to handle all of them.
        var workstationTargets = new Dictionary<int, (string Name, StationEntryData Entry, Entity PrefabEntity)>();

        int changed = 0;

        foreach (var (stationName, entry) in config.Stations)
        {
            if (!entry.ChangesEnabled) continue;

            if (!PrefabNameResolver.TryResolve(stationName, out PrefabGUID guid)) continue;

            if (!Heart.PrefabCollectionSystem._PrefabGuidToEntityMap.TryGetValue(guid, out Entity stationEntity)) continue;

            bool hasWorkstation = stationEntity.Has<WorkstationRecipesBuffer>();
            bool isPlayerEntity = stationEntity.Has<ProjectM.Network.User>();

            if (!hasWorkstation) continue;

            if (isPlayerEntity)
            {
                // User entity patching uses a targeted query — cheap, no batching needed.
                PatchLiveUserEntities(entry.AddRecipes, entry.RemoveRecipes, stationName);
                Heart.RegisterPlayerRecipeChanges(entry.AddRecipes, entry.RemoveRecipes);
                HeartLogger.Info(LOG_SOURCE,
                    $"[{stationName}] Registered {entry.AddRecipes.Count} add(s) and " +
                    $"{entry.RemoveRecipes.Count} remove(s) with Heart for Soul sync.");
                changed++;
            }
            else
            {
                // Queue for the batched live station scan.
                workstationTargets[guid._Value] = (stationName, entry, stationEntity);
                Heart.RegisterStationRecipeChanges(stationName, entry.AddRecipes, entry.RemoveRecipes);
                changed++;
            }
        }

        // Single batched scan for all WorkstationRecipesBuffer placed stations.
        if (workstationTargets.Count > 0)
            PatchAllLiveStationEntities(workstationTargets);

        HeartLogger.Info(LOG_SOURCE, $"LilithsCookbook applied changes to {changed} station(s).");
    }

    // ── Live User entity patching ─────────────────────────────────────────────

    static void PatchLiveUserEntities(
        List<string> addRecipes,
        List<string> removeRecipes,
        string stationName)
    {
        var em = Heart.EntityManager;

        var query = em.CreateEntityQuery(
            ComponentType.ReadWrite<WorkstationRecipesBuffer>(),
            ComponentType.ReadOnly<ProjectM.Network.User>()
        );

        var entities = query.ToEntityArray(Unity.Collections.Allocator.Temp);

        try
        {
            HeartLogger.Info(LOG_SOURCE,
                $"[{stationName}] Patching {entities.Length} live User entity(s).");

            foreach (var userEntity in entities)
            {
                if (addRecipes.Count > 0)
                    AddWorkstationRecipes(userEntity, addRecipes, stationName);

                if (removeRecipes.Count > 0)
                    RemoveWorkstationRecipes(userEntity, removeRecipes, stationName);
            }
        }
        finally
        {
            entities.Dispose();
        }
    }

    // ── Batched live placed station entity patching ───────────────────────────

    /// <summary>
    /// Patches WorkstationRecipesBuffer on all placed world instances of all
    /// configured stations in a single GetAllEntities() scan.
    ///
    /// [CHANGED] Replaces per-station PatchLiveStationEntities() calls.
    ///           Previously each station triggered its own GetAllEntities() scan —
    ///           O(entities × station count). Now a single scan handles all
    ///           configured stations — O(entities) regardless of station count.
    ///
    ///           V Rising keeps Unity.Entities.Prefab on placed world instances
    ///           so None=[Prefab] query exclusion is ineffective. GetAllEntities()
    ///           with direct prefab entity identity exclusion is required.
    ///
    /// [PERFORMANCE] One GetAllEntities() scan at startup covering all stations.
    ///               Patched counts are logged per station for diagnostics.
    /// </summary>
    static void PatchAllLiveStationEntities(
        Dictionary<int, (string Name, StationEntryData Entry, Entity PrefabEntity)> targets)
    {
        var em          = Heart.EntityManager;
        var allEntities = em.GetAllEntities(Unity.Collections.Allocator.Temp);

        // Track patch counts per station for logging.
        var patchedCounts = new Dictionary<int, int>();
        foreach (var guid in targets.Keys)
            patchedCounts[guid] = 0;

        try
        {
            foreach (var entity in allEntities)
            {
                if (!em.HasComponent<Stunlock.Core.PrefabGUID>(entity)) continue;

                var entityGuid = em.GetComponentData<Stunlock.Core.PrefabGUID>(entity);

                if (!targets.TryGetValue(entityGuid._Value, out var target)) continue;

                if (!em.HasBuffer<WorkstationRecipesBuffer>(entity)) continue;

                // Skip the prefab template entity — already patched in Pass 1.
                if (entity == target.PrefabEntity) continue;

                if (target.Entry.AddRecipes.Count > 0)
                    AddWorkstationRecipes(entity, target.Entry.AddRecipes, target.Name);

                if (target.Entry.RemoveRecipes.Count > 0)
                    RemoveWorkstationRecipes(entity, target.Entry.RemoveRecipes, target.Name);

                patchedCounts[entityGuid._Value]++;
            }
        }
        finally
        {
            allEntities.Dispose();
        }

        // Log results per station.
        foreach (var (guidValue, (name, _, _)) in targets)
            HeartLogger.Info(LOG_SOURCE,
                $"[{name}] Patched {patchedCounts[guidValue]} live station entity(s).");
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

            bool alreadyExists = false;
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i].RecipeGuid.Equals(recipeGuid)) { alreadyExists = true; break; }
            }

            if (alreadyExists)
            {
                HeartLogger.Info(LOG_SOURCE, $"[{stationName}] Recipe '{recipeName}' already present, skipping.");
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

            bool alreadyExists = false;
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i].RecipeGuid.Equals(recipeGuid)) { alreadyExists = true; break; }
            }

            if (alreadyExists)
            {
                HeartLogger.Info(LOG_SOURCE, $"[{stationName}] Recipe '{recipeName}' already present, skipping.");
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