using HarmonyLib;
using ProjectM;
using LilithsHeart.Foundation;
using LilithsHeart.Network;

// ============================================================
//  SchedulerPatch — LilithsHeart
//  LilithsHeart/Patches/SchedulerPatch.cs
//
//  Drains the SyncQueue at a controlled rate every server frame.
//
//  Hook target: ServerBootstrapSystem.OnUpdate
//  ──────────────────────────────────────────
//  ServerBootstrapSystem.OnUpdate runs every frame on the server
//  main thread. This is the same hook point used by other V Rising
//  mods for per-frame server-side work (Bloodcraft, KindredCommands).
//  It gives us reliable main-thread access to EntityManager for
//  ChatMessageServerEvent creation without threading concerns.
//
//  Why this system?
//  ─────────────────
//  ChatMessageServerEvent entities must be created on the main
//  thread — EntityManager is not thread-safe. ServerBootstrapSystem
//  runs every frame before network processing, so entities created
//  here are dispatched in the same frame.
//
//  Rate limiting:
//  ──────────────
//  SyncQueue.Drain() sends at most HeartConfig.ChunksPerFrame
//  chunks per frame across all connected clients. This prevents
//  large simultaneous-connect spikes from creating thousands of
//  entities in one frame. Default is 10 chunks/frame — tunable
//  in HeartConfig for server hardware.
//
//  [PERFORMANCE] OnUpdate fires every frame. The Drain() call is
//                O(n) over active client queues where n is server
//                player count. When all queues are empty (steady
//                state), the call returns immediately after the
//                TotalPending == 0 early exit — effectively free.
// ============================================================

namespace LilithsHeart.Patches;

[HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUpdate))]
internal static class SchedulerPatch
{
    [HarmonyPostfix]
    static void Postfix()
    {
        // Early exit when nothing is queued — no lock contention, no allocation.
        // [PERFORMANCE] This is the hot path — must be as cheap as possible.
        if (SyncQueue.TotalPending == 0) return;

        if (!Heart.IsReady) return;

        // Drain up to ChunksPerFrame chunks, sending each via SyncSender.
        SyncQueue.Drain(chunk =>
            SyncSender.SendQueuedChunk(
                chunk.UserEntity,
                chunk.CharacterEntity,
                chunk.UserIndex,
                chunk.Message));
    }
}