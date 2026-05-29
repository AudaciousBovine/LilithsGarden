using Unity.Entities;

// ============================================================
//  SyncQueue — LilithsHeart
//  LilithsHeart/Network/SyncQueue.cs
//
//  Thread-safe queue of pending sync messages to be sent to
//  connecting clients. SchedulerPatch drains this queue at a
//  controlled rate each server frame.
//
//  Why queued instead of immediate?
//  ──────────────────────────────────
//  Sending all chunks immediately on connect creates a spike of
//  ECS entity creations in a single frame. On a busy server with
//  multiple simultaneous connects this could cause frame hitches.
//  SyncQueue decouples enqueueing (connect event) from sending
//  (frame drain) so the cost is spread across frames.
//
//  Structure:
//  ───────────
//  Each pending send is a SyncPendingEntry — a client's routing
//  info plus a queue of message strings to send. Entries are
//  processed in FIFO order. Within each entry, messages are
//  sent in the order they were enqueued (tier order preserved).
//
//  Thread safety:
//  ───────────────
//  Enqueue() may be called from the connect event (main thread).
//  Drain() is called from SchedulerPatch (main thread).
//  Both run on the server main thread so a simple lock suffices.
//
//  [PERFORMANCE] Enqueue() is O(n) over messages — called once
//                per connect. Drain() processes at most
//                ChunksPerFrame entities per frame — O(1) amortized.
//                Lock contention is negligible — both callers are
//                on the same thread.
// ============================================================

namespace LilithsHeart.Network;

public static class SyncQueue
{
    private const string LOG_SOURCE = "LilithsHeart.SyncQueue";

    // How many chunk entities to create per server frame.
    // Keeps per-frame ECS entity creation bounded.
    // [PERFORMANCE] Tune this if large connects cause frame hitches.
    public const int ChunksPerFrame = 10;

    static readonly object _lock = new();

    // FIFO queue of pending client sends.
    static readonly Queue<SyncPendingEntry> _pending = new();

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Enqueues all messages for a connecting client.
    /// Called once per connect from SyncSender.EnqueueSyncTiers().
    /// Messages are sent in the order they are enqueued — tier
    /// order is preserved by the caller.
    ///
    /// [PERFORMANCE] O(n) over messages — called once per connect.
    /// </summary>
    public static void Enqueue(
        Entity userEntity,
        Entity characterEntity,
        int    userIndex,
        IEnumerable<string> messages)
    {
        var entry = new SyncPendingEntry(userEntity, characterEntity, userIndex);

        foreach (var message in messages)
            entry.Messages.Enqueue(message);

        lock (_lock)
            _pending.Enqueue(entry);
    }

    /// <summary>
    /// Drains up to ChunksPerFrame messages from the front of the queue.
    /// Called each server frame by SchedulerPatch.
    /// Sends each message via SyncSender.SendQueuedChunk().
    /// Removes entries when all their messages have been sent.
    ///
    /// [PERFORMANCE] Creates at most ChunksPerFrame ECS entities per frame.
    ///               O(ChunksPerFrame) — bounded constant cost per frame.
    /// </summary>
    public static void Drain()
    {
        int sent = 0;

        lock (_lock)
        {
            while (sent < ChunksPerFrame && _pending.Count > 0)
            {
                var entry = _pending.Peek();

                if (entry.Messages.Count == 0)
                {
                    _pending.Dequeue();
                    continue;
                }

                var message = entry.Messages.Dequeue();

                SyncSender.SendQueuedChunk(
                    entry.UserEntity,
                    entry.CharacterEntity,
                    entry.UserIndex,
                    message);

                sent++;

                // If this entry is exhausted, remove it.
                if (entry.Messages.Count == 0)
                    _pending.Dequeue();
            }
        }
    }

    /// <summary>
    /// Returns true if there are pending messages to send.
    /// Used by SchedulerPatch to skip the drain call when idle.
    /// [PERFORMANCE] O(1) — avoids lock acquisition when queue is empty.
    /// </summary>
    public static bool HasPending => _pending.Count > 0;

    /// <summary>
    /// Clears all pending entries.
    /// Called by Heart.OnDestroy() on server shutdown.
    /// </summary>
    public static void Clear()
    {
        lock (_lock)
            _pending.Clear();
    }

    // ── Internal ─────────────────────────────────────────────

    sealed class SyncPendingEntry
    {
        public Entity UserEntity      { get; }
        public Entity CharacterEntity { get; }
        public int    UserIndex       { get; }

        // Messages remaining to send for this client.
        public Queue<string> Messages { get; } = new();

        public SyncPendingEntry(Entity userEntity, Entity characterEntity, int userIndex)
        {
            UserEntity      = userEntity;
            CharacterEntity = characterEntity;
            UserIndex       = userIndex;
        }
    }
}