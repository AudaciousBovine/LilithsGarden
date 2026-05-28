using Il2CppInterop.Runtime;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using LilithsHeart.Foundation;

// ============================================================
//  SyncSender — LilithsHeart
//
//  Sends the ServerSyncPayload to connecting Soul clients using
//  V Rising's existing chat message infrastructure.
//
//  Why chat messages instead of CustomMessagingManager?
//  ─────────────────────────────────────────────────────
//  Unity.Netcode (FastBufferWriter, CustomMessagingManager etc.)
//  is not exposed by VampireReferenceAssemblies and the DLLs do
//  not exist on disk in an IL2CPP build. The established pattern
//  across all shipped V Rising client mods (Eclipse, ZUI, XPShared)
//  is to use ChatMessageServerEvent with ServerChatMessageType.System
//  for server→client data transport. Soul intercepts these on the
//  client side before they reach the chat UI.
//
//  Chunking:
//  ─────────
//  ChatMessageServerEvent.MessageText is FixedString512Bytes (~510
//  usable chars). We split the JSON payload across multiple messages,
//  each prefixed [[LG:N]] where N is the chunk index, and a final
//  [[LG:end]] sentinel. Soul reassembles in order.
//
//  Message format per chunk:
//      [[LG:0]]<chunk content>
//      [[LG:1]]<chunk content>
//      [[LG:end]]
//
//  [PERFORMANCE] Chunking runs once per client connect on the server
//                main thread. A typical localization payload will be
//                a few KB of JSON — roughly 10-20 messages.
//                Acceptable cost for a one-time connect event.
// ============================================================

namespace LilithsHeart.Network;

public static class SyncSender
{
    private const string LOG_SOURCE = "LilithsHeart.SyncSender";

    public const string CHUNK_PREFIX = "[[LG:";
    public const string CHUNK_END    = "[[LG:end]]";

    private const int MAX_CHUNK_CONTENT = 450;

    // [CHANGED] Added SendEventToUser to the archetype.
    //           V Rising's network event system requires this component
    //           to route the event to the correct client. Without it,
    //           the engine throws "Incorrect usage of SendEvent detected."
    // [PERFORMANCE] Static readonly — allocated once, reused per send.
    static readonly ComponentType[] _networkEventComponents =
    [
        ComponentType.ReadOnly(Il2CppType.Of<FromCharacter>()),
        ComponentType.ReadOnly(Il2CppType.Of<NetworkEventType>()),
        ComponentType.ReadOnly(Il2CppType.Of<SendNetworkEventTag>()),
        ComponentType.ReadOnly(Il2CppType.Of<ChatMessageServerEvent>()),
        ComponentType.ReadOnly(Il2CppType.Of<SendEventToUser>()),   // [ADDED] required routing component
    ];

    static readonly NetworkEventType _networkEventType = new()
    {
        IsAdminEvent = false,
        EventId      = NetworkEvents.EventId_ChatMessageServerEvent,
        IsDebugEvent = false,
    };

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Sends the cached sync payload to a connecting client.
    /// Called from ClientConnectPatch.
    /// </summary>
    // [CHANGED] Added userIndex (int) parameter.
    //           SendEventToUser.UserIndex is typed int — the approved user slot index
    //           from ServerBootstrapSystem._ApprovedUsersLookup, not a NetworkId struct.
    //           The caller (ClientConnectPatch) already has this value from the
    //           _NetEndPointToApprovedUserIndex lookup so we thread it through
    //           rather than re-resolving it here.
    public static void SendSyncToClient(Entity userEntity, Entity characterEntity, int userIndex)
    {
        var json = SyncPayloadCache.CachedJson;

        if (json == null)
        {
            HeartLogger.Warning(LOG_SOURCE,
                "Sync payload cache is empty — cannot send. Is Heart fully initialized?");
            return;
        }

        try
        {
            var chunks    = Chunkify(json);
            var em        = Heart.EntityManager;
            // Read NetworkId once — reused for every chunk's ChatMessageServerEvent.FromUser.
            // userIndex is passed separately for SendEventToUser routing.
            var userNetId = userEntity.Read<NetworkId>();

            for (int i = 0; i < chunks.Count; i++)
            {
                SendSystemMessage(em, userEntity, characterEntity, userNetId, userIndex,
                    $"{CHUNK_PREFIX}{i}]]{chunks[i]}");
            }

            // End sentinel — tells Soul to reassemble and process.
            SendSystemMessage(em, userEntity, characterEntity, userNetId, userIndex, CHUNK_END);

            HeartLogger.Info(LOG_SOURCE,
                $"Sync payload sent in {chunks.Count} chunk(s) + end sentinel.");
        }
        catch (Exception ex)
        {
            HeartLogger.Error(LOG_SOURCE, $"SendSyncToClient failed: {ex.Message}");
        }
    }

    // ── Internal ─────────────────────────────────────────────

    // [CHANGED] Added userIndex (int) parameter to match SendEventToUser.UserIndex type.
    //           Previous version passed userNetId (NetworkId) to UserIndex which is
    //           typed int — that was the CS0029 implicit conversion error.
    static void SendSystemMessage(
        EntityManager em,
        Entity userEntity,
        Entity characterEntity,
        NetworkId userNetId,
        int userIndex,
        string text)
    {
        // Defensive truncation — should never trigger if MAX_CHUNK_CONTENT is correct.
        if (text.Length > 509) text = text[..509];

        ChatMessageServerEvent chatEvent = new()
        {
            MessageText   = new FixedString512Bytes(text),
            MessageType   = ServerChatMessageType.System,
            FromCharacter = characterEntity.Read<NetworkId>(),
            FromUser      = userNetId,
            TimeUTC       = DateTime.UtcNow.Ticks
        };

        Entity entity = em.CreateEntity(_networkEventComponents);
        entity.Write(new FromCharacter { Character = characterEntity, User = userEntity });
        entity.Write(_networkEventType);
        entity.Write(chatEvent);

        // [CHANGED] UserIndex is int — the approved user slot index from
        //           _ApprovedUsersLookup, not a NetworkId. This is what
        //           V Rising's network event system uses to route the
        //           event to the correct client connection.
        entity.Write(new SendEventToUser { UserIndex = userIndex });
    }

    static List<string> Chunkify(string input)
    {
        var chunks = new List<string>();
        int pos    = 0;

        while (pos < input.Length)
        {
            int len = Math.Min(MAX_CHUNK_CONTENT, input.Length - pos);
            chunks.Add(input.Substring(pos, len));
            pos += len;
        }

        return chunks;
    }
}