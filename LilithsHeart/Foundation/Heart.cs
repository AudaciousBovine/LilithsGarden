using ProjectM;
using Stunlock.Core;
using Unity.Entities;
using LilithsHeart.Config;
using LilithsHeart.Events;
using LilithsHeart.Network;
using LilithsHeart.Prefabs;
using LilithsHeart.Modules;

// [CHANGED] Added LilithsHeart.Modules using for HeartRegistry.LogSummary().

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

        // Fire the C# event first — modules subscribe to this in their Load()
        // and use it to run their own initialization against ECS.
        OnInitialized?.Invoke();

        // [CHANGED] Log the registry summary after OnInitialized fires so that
        //           any module that registers itself inside its OnInitialized
        //           handler is included in the summary output.
        HeartRegistry.LogSummary();

        // [CHANGED] Publish OnWorldReady to the event bus after all OnInitialized
        //           handlers have run. Modules can subscribe to either pattern —
        //           the C# event (OnInitialized) for direct coupling, or the bus
        //           (OnWorldReady) for looser pub/sub. Both are supported.
        //
        // [PERFORMANCE] Publish dispatches synchronously to a snapshot of
        //               subscribers. Keep OnWorldReady handlers fast —
        //               no heavy ECS queries or I/O inside them.
        HeartEventBus.Publish(new OnWorldReady());
    }

    internal static void OnLocalizationReloaded()
        => SyncPayloadCache.Rebuild(_serverIdentity);

    static string ResolveServerIdentity()
    {
        var name = HeartConfig.ServerName.Value;
        return string.IsNullOrWhiteSpace(name) ? "LilithsGarden" : name;
    }
}