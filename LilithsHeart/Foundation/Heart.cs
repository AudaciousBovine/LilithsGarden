using ProjectM;
using Stunlock.Core;
using Unity.Entities;
using LilithsHeart.Config;
using LilithsHeart.Events;
using LilithsHeart.Network;
using LilithsHeart.Prefabs;
using LilithsHeart.Modules;

namespace LilithsHeart.Foundation;

public static class Heart
{
    private const string LOG_SOURCE = "LilithsHeart";

    static World? _server;
    static World Server
    {
        get
        {
            if (_server?.IsCreated == true)
                return _server;
            _server = WorldUtility.FindServerWorld();
            if (_server?.IsCreated != true)
                throw new InvalidOperationException("Server world is not ready yet.");
            return _server;
        }
    }

    public static EntityManager EntityManager
        => Server.EntityManager;

    public static PrefabCollectionSystem PrefabCollectionSystem
        => Server.GetExistingSystemManaged<PrefabCollectionSystem>();

    public static GameDataSystem GameDataSystem
        => Server.GetExistingSystemManaged<GameDataSystem>();

    public static event Action? OnInitialized;
    static bool _initialized;
    public static bool IsReady => _initialized;

    static string _serverIdentity = string.Empty;

    static readonly Dictionary<string, RecipeOverrideData> _pendingRecipeOverrides = new();
    static readonly Dictionary<string, StationRecipeOverrideData> _pendingStationRecipeOverrides = new();

    // [CHANGED] Player recipe changes registered by StationSystem after
    //           patching live User entities. Soul uses these to patch the
    //           client's own player entity WorkstationRecipesBuffer so the
    //           player crafting menu reflects server-side changes.
    static readonly List<string> _pendingPlayerRecipesToAdd    = new();
    static readonly List<string> _pendingPlayerRecipesToRemove = new();

    internal static void OnInitialize()
    {
        if (_initialized) return;

        HeartLogger.Info(LOG_SOURCE, "Heart initializing...");

        PrefabNameResolver.Initialize();
        LocalizationConfig.Initialize();

        _serverIdentity = ResolveServerIdentity();

        SyncPayloadCache.Build(_serverIdentity);

        _initialized = true;

        HeartLogger.Info(LOG_SOURCE, "Heart initialized.");

        OnInitialized?.Invoke();

        // [CHANGED] Rebuild after all modules have registered their overrides —
        //           includes both recipe overrides and player recipe changes.
        bool needsRebuild = _pendingRecipeOverrides.Count > 0 ||
                            _pendingStationRecipeOverrides.Count > 0 ||
                            _pendingPlayerRecipesToAdd.Count > 0 ||
                            _pendingPlayerRecipesToRemove.Count > 0;

        if (needsRebuild)
        {
            HeartLogger.Info(LOG_SOURCE,
                $"Rebuilding sync payload with {_pendingRecipeOverrides.Count} recipe override(s), " +
                $"{_pendingStationRecipeOverrides.Count} station override(s), " +
                $"{_pendingPlayerRecipesToAdd.Count} player recipe addition(s), " +
                $"{_pendingPlayerRecipesToRemove.Count} player recipe removal(s).");
            SyncPayloadCache.Rebuild(_serverIdentity, _pendingRecipeOverrides,
                _pendingStationRecipeOverrides,
                _pendingPlayerRecipesToAdd, _pendingPlayerRecipesToRemove);
        }

        HeartRegistry.LogSummary();

        HeartEventBus.Publish(new OnWorldReady());
    }

    /// <summary>
    /// Called by modules after applying recipe ECS changes.
    /// Registers overrides for inclusion in ServerSyncPayload.
    /// </summary>
    /// <summary>
    /// Called by StationSystem after re-patching WorkstationRecipesBuffer station
    /// prefab entities in Pass 2. Registers station recipe changes for Soul so
    /// the client can patch placed workstation entities to match.
    ///
    /// [CHANGED] Added to support client-side WorkstationRecipesBuffer station patching.
    ///
    /// [PERFORMANCE] Called once at startup per WorkstationRecipesBuffer station.
    /// </summary>
    public static void RegisterStationRecipeChanges(string stationName, List<string> toAdd, List<string> toRemove)
    {
        if (!_pendingStationRecipeOverrides.TryGetValue(stationName, out var existing))
        {
            existing = new StationRecipeOverrideData();
            _pendingStationRecipeOverrides[stationName] = existing;
        }

        foreach (var r in toAdd)
            if (!existing.RecipesToAdd.Contains(r))
                existing.RecipesToAdd.Add(r);

        foreach (var r in toRemove)
            if (!existing.RecipesToRemove.Contains(r))
                existing.RecipesToRemove.Add(r);

        HeartLogger.Debug(LOG_SOURCE,
            $"RegisterStationRecipeChanges: '{stationName}' +{toAdd.Count} add, +{toRemove.Count} remove.");
    }

    public static void RegisterRecipeOverrides(Dictionary<string, RecipeOverrideData> overrides)
    {
        foreach (var (key, value) in overrides)
            _pendingRecipeOverrides[key] = value;

        HeartLogger.Debug(LOG_SOURCE,
            $"RegisterRecipeOverrides: +{overrides.Count} entries, total={_pendingRecipeOverrides.Count}");
    }

    /// <summary>
    /// Called by StationSystem after patching the player prefab and live User entities.
    /// Registers player recipe additions and removals for inclusion in ServerSyncPayload
    /// so Soul can patch the client's own player entity WorkstationRecipesBuffer.
    ///
    /// [CHANGED] Added to support client-side player crafting menu accuracy.
    ///
    /// [PERFORMANCE] Called once at startup per WorkstationRecipesBuffer target.
    ///               Lists are accumulated — later calls append, not replace.
    /// </summary>
    public static void RegisterPlayerRecipeChanges(List<string> toAdd, List<string> toRemove)
    {
        foreach (var r in toAdd)
            if (!_pendingPlayerRecipesToAdd.Contains(r))
                _pendingPlayerRecipesToAdd.Add(r);

        foreach (var r in toRemove)
            if (!_pendingPlayerRecipesToRemove.Contains(r))
                _pendingPlayerRecipesToRemove.Add(r);

        HeartLogger.Debug(LOG_SOURCE,
            $"RegisterPlayerRecipeChanges: +{toAdd.Count} add, +{toRemove.Count} remove.");
    }

    internal static void OnLocalizationReloaded()
    {
        SyncPayloadCache.Rebuild(_serverIdentity, _pendingRecipeOverrides,
            _pendingStationRecipeOverrides,
            _pendingPlayerRecipesToAdd, _pendingPlayerRecipesToRemove);
    }

    internal static void OnDestroy()
    {
        _initialized = false;
        _server      = null;
        _serverIdentity = string.Empty;
        _pendingRecipeOverrides.Clear();
        _pendingStationRecipeOverrides.Clear();
        _pendingPlayerRecipesToAdd.Clear();
        _pendingPlayerRecipesToRemove.Clear();
        OnInitialized = null;
        HeartLogger.Info(LOG_SOURCE, "Heart destroyed.");
    }

    static string ResolveServerIdentity()
    {
        var name = HeartConfig.ServerName.Value;
        return string.IsNullOrWhiteSpace(name) ? "LilithsGarden" : name;
    }
}