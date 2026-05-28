using HarmonyLib;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;
using Unity.Entities;
using LilithsHeart.Foundation;
using LilithsHeart.Network;

// ============================================================
//  ClientConnectPatch — LilithsHeart
//  LilithsHeart/Patches/ClientConnectPatch.cs
//
//  Detects when a client successfully joins and enqueues the
//  tiered sync payload into SyncQueue for rate-limited delivery.
//
//  [CHANGED] No longer calls SyncSender.SendSyncToClient() which
//            sent all chunks immediately in one frame.
//            Now calls SyncSender.EnqueueSyncTiers() which
//            enqueues all tier blobs into SyncQueue.
//            SchedulerPatch drains the queue at ChunksPerFrame
//            rate each frame — no connect-frame spike.
//
//  [PERFORMANCE] Runs once per client connect — negligible cost.
//                Chunk entity creation is deferred to SchedulerPatch.
// ============================================================

namespace LilithsHeart.Patches;

[HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserConnected))]
internal static class ClientConnectPatch
{
    private const string LOG_SOURCE = "LilithsHeart.ClientConnectPatch";

    [HarmonyPostfix]
    static void Postfix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId)
    {
        try
        {
            if (!Heart.IsReady)
            {
                HeartLogger.Warning(LOG_SOURCE,
                    "Client connected before Heart was ready — sync not sent. " +
                    "Client should reconnect to receive server config.");
                return;
            }

            if (!__instance._NetEndPointToApprovedUserIndex.TryGetValue(
                    netConnectionId, out int userIndex))
            {
                HeartLogger.Warning(LOG_SOURCE,
                    $"Could not resolve connection {netConnectionId} to user index.");
                return;
            }

            var serverClient  = __instance._ApprovedUsersLookup[userIndex];
            Entity userEntity = serverClient.UserEntity;

            var user = userEntity.Read<User>();
            Entity characterEntity = user.LocalCharacter.GetEntityOnServer();

            if (characterEntity == Entity.Null)
            {
                HeartLogger.Warning(LOG_SOURCE,
                    $"Character entity null for user {user.CharacterName} — " +
                    "payload deferred. Client should reconnect.");
                return;
            }

            HeartLogger.Info(LOG_SOURCE,
                $"Client '{user.CharacterName}' connected — enqueuing tiered sync payload.");

            // [CHANGED] EnqueueSyncTiers replaces SendSyncToClient.
            //           All tier blobs are enqueued into SyncQueue here.
            //           SchedulerPatch drains at ChunksPerFrame per frame.
            SyncSender.EnqueueSyncTiers(userEntity, characterEntity, userIndex);
        }
        catch (Exception ex)
        {
            HeartLogger.Error(LOG_SOURCE, $"ClientConnectPatch failed: {ex.Message}");
        }
    }
}