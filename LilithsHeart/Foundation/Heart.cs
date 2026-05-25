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

    // [CHANGED] Pending recipe overrides collected by modules before
    //           SyncPayloadCache.Build() is called. Modules call
    //           RegisterRecipeOverrides() during their OnInitialized
    //           handler — after applying ECS changes — so the data
    //           is ready when the first client connects.
    //
    //           Using a static dict here means modules accumulate
    //           overrides additionally. If two modules touch the same
    //           recipe the last writer wins — consistent with how
    //           multi-file JSON merge works in CookbookLoader.
    static readonly Dictionary<string, RecipeOverrideData> _pendingRecipeOverrides = new();

    internal static void OnInitialize()
    {
        if (_initialized) return;

        HeartLogger.Info(LOG_SOURCE, "Heart initializing...");

        PrefabNameResolver.Initialize();
        LocalizationConfig.Initialize();

        _serverIdentity = ResolveServerIdentity();

        // Build the initial payload — RecipeOverrides is empty at this point.
        // Modules that register overrides via RegisterRecipeOverrides() during
        // their OnInitialized handler will trigger a Rebuild() via
        // OnRecipeOverridesRegistered() called at the end of OnInitialize.
        SyncPayloadCache.Build(_serverIdentity);

        _initialized = true;

        HeartLogger.Info(LOG_SOURCE, "Heart initialized.");

        // Fire the C# event — modules subscribe to this in their Load()
        // and use it to run their own initialization against ECS.
        OnInitialized?.Invoke();

        // [CHANGED] Rebuild the payload after all OnInitialized handlers have
        //           run so any recipe overrides registered during initialization
        //           are included in the cached payload sent to connecting clients.
        //           If no overrides were registered, the rebuild is cheap —
        //           SyncPayloadCache serializes the same data a second time.
        //
        // [PERFORMANCE] Two serialization passes at startup — one here, one
        //               after modules register overrides. Acceptable: this
        //               happens once per server start, not per-frame.
        if (_pendingRecipeOverrides.Count > 0)
        {
            HeartLogger.Info(LOG_SOURCE,
                $"Rebuilding sync payload with {_pendingRecipeOverrides.Count} recipe override(s).");
            SyncPayloadCache.Rebuild(_serverIdentity, _pendingRecipeOverrides);
        }

        HeartRegistry.LogSummary();

        HeartEventBus.Publish(new OnWorldReady());
    }

    /// <summary>
    /// Called by modules (e.g. LilithsCookbook) after applying recipe changes
    /// to register those changes for inclusion in the ServerSyncPayload sent
    /// to Soul clients. Call this from your OnInitialized handler, after
    /// ApplyChanges() has run.
    ///
    /// Safe to call multiple times — later registrations merge into the dict,
    /// last writer wins per recipe key.
    ///
    /// [PERFORMANCE] O(n) dict merge — called once per module at startup only.
    /// </summary>
    public static void RegisterRecipeOverrides(Dictionary<string, RecipeOverrideData> overrides)
    {
        foreach (var (key, value) in overrides)
            _pendingRecipeOverrides[key] = value;

        HeartLogger.Debug(LOG_SOURCE,
            $"RegisterRecipeOverrides: +{overrides.Count} entries, total={_pendingRecipeOverrides.Count}");
    }

    internal static void OnLocalizationReloaded()
    {
        // [CHANGED] Pass current recipe overrides so they're preserved
        //           in the rebuilt payload after a localization reload.
        SyncPayloadCache.Rebuild(_serverIdentity, _pendingRecipeOverrides);
    }

    /// <summary>
    /// Called from HeartPlugin.Unload(). Resets Heart state so a
    /// subsequent hot-reload starts clean.
    /// </summary>
    internal static void OnDestroy()
    {
        _initialized = false;
        _server      = null;
        _serverIdentity = string.Empty;
        _pendingRecipeOverrides.Clear();
        OnInitialized = null;
        HeartLogger.Info(LOG_SOURCE, "Heart destroyed.");
    }

    static string ResolveServerIdentity()
    {
        var name = HeartConfig.ServerName.Value;
        return string.IsNullOrWhiteSpace(name) ? "LilithsGarden" : name;
    }
}