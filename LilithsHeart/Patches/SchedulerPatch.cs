using HarmonyLib;
using ProjectM;
using LilithsHeart.Foundation;
using LilithsHeart.Network;

// ============================================================
//  SchedulerPatch — LilithsHeart
//  LilithsHeart/Patches/SchedulerPatch.cs
//
//  Drains SyncQueue at a controlled rate each server frame.
//  Calls SyncQueue.Drain() which creates at most
//  SyncQueue.ChunksPerFrame ECS entities per frame.
//
//  Hook target: ServerBootstrapSystem.OnUpdate (postfix)
//  ──────────────────────────────────────────────────────
//  ServerBootstrapSystem.OnUpdate runs every server frame and
//  is the established hook point for per-frame server work
//  in V Rising mods. Postfix ensures game logic runs first.
//
//  Why not a custom ECS system?
//  ─────────────────────────────
//  A Harmony patch on an existing system is simpler and avoids
//  the complexity of registering a custom ComponentSystemBase
//  in an IL2CPP environment. The per-frame cost is a single
//  bool check (HasPending) when the queue is empty — negligible.
//
//  [PERFORMANCE] When SyncQueue.HasPending is false (normal play),
//                cost is a single bool read per frame — effectively
//                free. During a connect event, at most
//                ChunksPerFrame entity creates occur per frame —
//                bounded constant cost regardless of payload size.
// ============================================================

namespace LilithsHeart.Patches;

[HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUpdate))]
internal static class SchedulerPatch
{
    [HarmonyPostfix]
    static void Postfix()
    {
        // Fast path — skip lock acquisition when nothing is pending.
        if (!SyncQueue.HasPending) return;

        if (!Heart.IsReady) return;

        SyncQueue.Drain();
    }
}