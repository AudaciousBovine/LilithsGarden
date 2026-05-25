// ============================================================
//  RecipePatcher — LilithsSoul
//  LilithsSoul/Services/RecipePatcher.cs
//
//  Patches client-side prefab ECS entities to reflect the recipe
//  overrides received from LilithsHeart via ServerSyncPayload.
//
//  Why this is needed:
//  ───────────────────
//  V Rising's WorkstationSubMenu reads RecipeRequirementBuffer,
//  RecipeOutputBuffer, and RecipeData.CraftDuration directly from
//  client-local prefab entities loaded at startup. There is no
//  network sync mechanism for these buffers — the server enforces
//  the correct values but the client HUD always shows vanilla.
//  RecipePatcher fixes this by patching the client's local prefab
//  entities after receiving Heart's overrides on connect.
//
//  Name → GUID resolution:
//  ────────────────────────
//  Heart sends prefab names (strings) in the payload. The client
//  resolves these via a name→GUID map built once at world ready
//  from PrefabCollectionSystem._PrefabDataLookup.AssetName.
//  This is the same data source LocalizationInjector uses for its
//  display name lookup — no new ECS iteration needed beyond what
//  Soul already does at world ready.
//
//  PrefabCollectionSystem on the client exposes:
//    _PrefabGuidToEntityMap  — PrefabGUID → Entity
//    _PrefabDataLookup       — PrefabGUID → PrefabData (has AssetName)
//  There is no _PrefabNameToGuidMap — we build our own from AssetName.
//
//  [PERFORMANCE] BuildNameMap() runs once at world ready — O(n) over
//                all prefabs, same pass LocalizationInjector already
//                does. Apply() iterates only overridden recipes.
//                Buffer operations are O(n) per recipe slot.
//                No per-frame cost after initialization.
// ============================================================

using System.Reflection;
using ProjectM;
using Stunlock.Core;
using Unity.Collections;
using Unity.Entities;
using LilithsMind.Prefabs;
using LilithsSoul.Foundation;
using LilithsSoul.Network;

namespace LilithsSoul.Services;

public static class RecipePatcher
{
    private const string LOG_SOURCE = "LilithsSoul.RecipePatcher";

    // Built once at world ready from PrefabCollectionSystem._PrefabDataLookup.
    // Keyed by AssetName string (e.g. "Recipe_Weapon_Sword_T04_Copper_Reinforced").
    // [PERFORMANCE] Dictionary<string, PrefabGUID> — O(1) lookup per recipe.
    static readonly Dictionary<string, PrefabGUID> _nameToGuid = new();

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Builds the prefab name → GUID lookup from two sources:
    ///   1. PrefabCollectionSystem._PrefabDataLookup — keyed by AssetName
    ///      (full prefab string, e.g. "Item_BloodEssence_T01")
    ///   2. LilithsMind definition classes — also keyed by Name alias
    ///      (short name, e.g. "BloodEssence")
    ///
    /// Both are needed because BuildSoulOverride() on the server uses
    /// PrefabNameResolver.TryResolveName() which returns the LilithsMind
    /// Name field (short alias) — so the client must be able to resolve
    /// both forms to the same GUID.
    ///
    /// Called by SyncReceiver.NotifyWorldReady() once the client world is ready.
    /// Safe to call multiple times — clears and rebuilds each time.
    ///
    /// [PERFORMANCE] O(n) over _PrefabDataLookup + O(m) over LilithsMind
    ///               definitions — both run once at world ready only.
    /// </summary>
    public static void BuildNameMap()
    {
        _nameToGuid.Clear();

        var world = Soul.ClientWorld;
        if (world == null)
        {
            SoulLogger.Warning(LOG_SOURCE,
                "Client world not available — cannot build name→GUID map.");
            return;
        }

        var prefabSystem = world.GetExistingSystemManaged<PrefabCollectionSystem>();
        if (prefabSystem == null)
        {
            SoulLogger.Warning(LOG_SOURCE,
                "PrefabCollectionSystem not found — cannot build name→GUID map.");
            return;
        }

        // ── Pass 1: AssetName → GUID from ECS ────────────────
        var lookup = prefabSystem._PrefabDataLookup;
        var keys   = lookup.GetKeyArray(Allocator.Temp);
        var vals   = lookup.GetValueArray(Allocator.Temp);

        try
        {
            for (int i = 0; i < keys.Length; i++)
            {
                var assetName = vals[i].AssetName.Value;
                if (!string.IsNullOrEmpty(assetName))
                    _nameToGuid[assetName] = keys[i];
            }
        }
        finally
        {
            keys.Dispose();
            vals.Dispose();
        }

        // ── Pass 2: LilithsMind Name alias → GUID ────────────
        // BuildSoulOverride() on the server uses TryResolveName() which
        // returns the LilithsMind Name field (e.g. "BloodEssence") rather
        // than the full Prefab string. We index those aliases here so both
        // forms resolve to the same GUID on the client.
        var mindAssembly = typeof(LilithsMind.Prefabs.PrefabDef).Assembly;

        var definitionTypes = mindAssembly
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAbstract &&
                t.IsSealed &&
                t.Namespace == "LilithsMind.Prefabs.Definitions")
            .ToList();

        foreach (var type in definitionTypes)
        {
            var fields = type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .Where(f => f.FieldType == typeof(LilithsMind.Prefabs.PrefabDef));

            foreach (var field in fields)
            {
                var def = (LilithsMind.Prefabs.PrefabDef)field.GetValue(null)!;
                if (def.Name is not null)
                {
                    var guid = new PrefabGUID(def.GuidHash);
                    _nameToGuid[def.Name] = guid;
                }
            }
        }

        SoulLogger.Info(LOG_SOURCE,
            $"Name→GUID map built with {_nameToGuid.Count} entries " +
            $"(AssetName + LilithsMind aliases).");
    }

    /// <summary>
    /// Patches client prefab entities from the received recipe overrides.
    /// Called by SyncReceiver.ApplyPayload() after LocalizationInjector.Inject().
    /// Safe to call with an empty dict — exits immediately.
    ///
    /// [PERFORMANCE] Iterates only overridden recipes, not all prefabs.
    /// </summary>
    public static void Apply(Dictionary<string, RecipeOverrideData> overrides)
    {
        if (overrides.Count == 0)
        {
            SoulLogger.Debug(LOG_SOURCE, "No recipe overrides to apply.");
            return;
        }

        var world = Soul.ClientWorld;
        if (world == null)
        {
            SoulLogger.Error(LOG_SOURCE, "Client world not ready — cannot patch recipes.");
            return;
        }

        var prefabSystem = world.GetExistingSystemManaged<PrefabCollectionSystem>();
        if (prefabSystem == null)
        {
            SoulLogger.Error(LOG_SOURCE, "PrefabCollectionSystem not found — cannot patch recipes.");
            return;
        }

        // [CHANGED] Get client GameDataSystem so we can also write into
        //           RecipeHashLookupMap — the client HUD reads CraftDuration
        //           from the map, not from the prefab entity component.
        var gameDataSystem = world.GetExistingSystemManaged<GameDataSystem>();
        if (gameDataSystem == null)
            SoulLogger.Warning(LOG_SOURCE,
                "Client GameDataSystem not found — CraftDuration display may not update.");

        var prefabMap = prefabSystem._PrefabGuidToEntityMap;
        var em        = world.EntityManager;

        int patched = 0;
        int failed  = 0;

        foreach (var (recipeName, data) in overrides)
        {
            // Resolve recipe prefab name → GUID using our built map.
            if (!_nameToGuid.TryGetValue(recipeName, out PrefabGUID recipeGuid))
            {
                SoulLogger.Warning(LOG_SOURCE,
                    $"Could not resolve recipe name '{recipeName}' to GUID — skipping.");
                failed++;
                continue;
            }

            if (!prefabMap.TryGetValue(recipeGuid, out Entity recipeEntity))
            {
                SoulLogger.Warning(LOG_SOURCE,
                    $"Could not find client entity for recipe '{recipeName}' — skipping.");
                failed++;
                continue;
            }

            try
            {
                PatchRecipe(em, recipeEntity, recipeGuid, recipeName, data, gameDataSystem);
                patched++;
            }
            catch (Exception ex)
            {
                SoulLogger.Error(LOG_SOURCE,
                    $"Failed to patch recipe '{recipeName}': {ex.Message}");
                failed++;
            }
        }

        SoulLogger.Info(LOG_SOURCE,
            $"Recipe patching complete — {patched} patched, {failed} failed.");
    }

    // ── Internal ─────────────────────────────────────────────

    static void PatchRecipe(
        EntityManager em,
        Entity recipeEntity,
        PrefabGUID recipeGuid,
        string recipeName,
        RecipeOverrideData data,
        GameDataSystem? gameDataSystem)
    {
        // ── RecipeData component on prefab entity ─────────────
        if (em.HasComponent<RecipeData>(recipeEntity))
        {
            var recipeData = em.GetComponentData<RecipeData>(recipeEntity);
            recipeData.CraftDuration = data.CraftDuration;
            em.SetComponentData(recipeEntity, recipeData);
        }

        // ── RecipeHashLookupMap ───────────────────────────────
        // [CHANGED] The client HUD reads CraftDuration from the client's
        //           RecipeHashLookupMap, not from the prefab entity component —
        //           same issue as on the server side. Write into both so the
        //           displayed timer matches what the server enforces.
        if (gameDataSystem != null)
        {
            var map = gameDataSystem.RecipeHashLookupMap;
            if (map.TryGetValue(recipeGuid, out var mapEntry))
            {
                mapEntry.CraftDuration = data.CraftDuration;
                map[recipeGuid] = mapEntry;
            }
        }

        // ── RecipeRequirementBuffer ───────────────────────────
        PatchRequirementBuffer(em, recipeEntity, recipeName, data.Requirements);

        // ── RecipeOutputBuffer ────────────────────────────────
        PatchOutputBuffer(em, recipeEntity, recipeName, data.Outputs);
    }

    static void PatchRequirementBuffer(
        EntityManager em,
        Entity recipeEntity,
        string recipeName,
        List<RecipeSlotData> slots)
    {
        DynamicBuffer<RecipeRequirementBuffer> buffer;

        if (em.HasBuffer<RecipeRequirementBuffer>(recipeEntity))
            buffer = em.GetBuffer<RecipeRequirementBuffer>(recipeEntity);
        else
            buffer = em.AddBuffer<RecipeRequirementBuffer>(recipeEntity);

        buffer.Clear();

        foreach (var slot in slots)
        {
            if (!_nameToGuid.TryGetValue(slot.Item, out PrefabGUID itemGuid))
            {
                SoulLogger.Warning(LOG_SOURCE,
                    $"[{recipeName}] Could not resolve requirement item '{slot.Item}' — skipping slot.");
                continue;
            }

            buffer.Add(new RecipeRequirementBuffer { Guid = itemGuid, Amount = slot.Amount });
        }
    }

    static void PatchOutputBuffer(
        EntityManager em,
        Entity recipeEntity,
        string recipeName,
        List<RecipeSlotData> slots)
    {
        DynamicBuffer<RecipeOutputBuffer> buffer;

        if (em.HasBuffer<RecipeOutputBuffer>(recipeEntity))
            buffer = em.GetBuffer<RecipeOutputBuffer>(recipeEntity);
        else
            buffer = em.AddBuffer<RecipeOutputBuffer>(recipeEntity);

        buffer.Clear();

        foreach (var slot in slots)
        {
            if (!_nameToGuid.TryGetValue(slot.Item, out PrefabGUID itemGuid))
            {
                SoulLogger.Warning(LOG_SOURCE,
                    $"[{recipeName}] Could not resolve output item '{slot.Item}' — skipping slot.");
                continue;
            }

            buffer.Add(new RecipeOutputBuffer { Guid = itemGuid, Amount = slot.Amount });
        }
    }
}