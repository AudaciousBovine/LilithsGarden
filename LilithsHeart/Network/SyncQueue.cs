using Unity.Entities;
using LilithsHeart.Config;
using LilithsHeart.Foundation;

// ============================================================
//  SyncQueue — LilithsHeart
//  LilithsHeart/Network/SyncQueue.cs
//
//  Per-client chunk queue for the tiered sync transport.
//  Holds pending chat message strings for each connected client
//  and drains them at a controlled rate per frame via
//  SchedulerPatch.
//
//  Why rate limiting?
//  ──────────────────
//  Sending all chunks in one frame creates N × ChunkCount
//  EntityManager.CreateEntity calls simultaneously. With 20+
//  simultaneous connects and ~290 total chunks per client, this
//  could produce thousands of entity creates on one frame.
//  Spreading across frames keeps the server frame time stable.
//
//  Queue structure:
//  ─────────────────
//  One queue per client, keyed by userIndex (int).
//  Each queue entry is a pre-formatted chat message string
//  ready to send — the sentinel and chunk prefix are already
//  embedded. SyncSender enqueues; SchedulerPatch dequeues.
//
//  Tier ordering:
//  ──────────────
//  Tiers are enqueued in order (Critical first). The queue is
//  FIFO so tier ordering is preserved automatically — no
//  additional sorting needed.
//
//  [PERFORMANCE] Queue operations are O(1) — Enqueue/Dequeue
//                on Queue<T>. Lock is held only briefly per
//                Drain() call. One lock per frame per active
//                client — negligible at typical server pop.
// ============================================================

namespace LilithsHeart.Network;

/// <summary>
/// Holds the routing context for a queued chunk — where to send it.
/// </summary>
public readonly struct QueuedChunk
{
    public readonly Entity    UserEntity;
    public readonly Entity    CharacterEntity;
    public readonly int       UserIndex;
    public readonly string    Message;

    public QueuedChunk(Entity userEntity, Entity characterEntity, int userIndex, string message)
    {
        UserEntity      = userEntity;
        CharacterEntity = characterEntity;
        UserIndex       = userIndex;
        Message         = message;
    }
}

public static class SyncQueue
{
    private const string LOG_SOURCE = "LilithsHeart.SyncQueue";

    // One queue per connected client, keyed by userIndex.
    // [PERFORMANCE] Dictionary<int, Queue<QueuedChunk>> — O(1) per client lookup.
    static readonly Dictionary<int, Queue<QueuedChunk>> _queues = new();
    static readonly object _lock = new();

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Enqueues a batch of pre-formatted message strings for a specific client.
    /// Called by SyncSender once per tier per connect.
    /// Thread-safe.
    /// </summary>
    public static void Enqueue(
        Entity userEntity,
        Entity characterEntity,
        int    userIndex,
        IEnumerable<string> messages)
    {
        lock (_lock)
        {
            if (!_queues.TryGetValue(userIndex, out var queue))
            {
                queue = new Queue<QueuedChunk>();
                _queues[userIndex] = queue;
            }

            foreach (var msg in messages)
                queue.Enqueue(new QueuedChunk(userEntity, characterEntity, userIndex, msg));
        }
    }

    /// <summary>
    /// Drains up to ChunksPerFrame chunks across all client queues.
    /// Called every frame by SchedulerPatch.
    /// Removes empty queues automatically.
    /// Thread-safe.
    ///
    /// [PERFORMANCE] O(n) over active client queues per frame.
    ///               n is bounded by server player count — negligible.
    /// </summary>
    public static void Drain(Action<QueuedChunk> sendAction)
    {
        int remaining = HeartConfig.ChunksPerFrame;
        if (remaining <= 0) return;

        lock (_lock)
        {
            // Collect keys first to avoid modifying during iteration.
            var toRemove = new List<int>();

            foreach (var (userIndex, queue) in _queues)
            {
                while (remaining > 0 && queue.Count > 0)
                {
                    var chunk = queue.Dequeue();
                    try
                    {
                        sendAction(chunk);
                    }
                    catch (Exception ex)
                    {
                        HeartLogger.Error(LOG_SOURCE,
                            $"Failed to send chunk for userIndex {userIndex}: {ex.Message}");
                    }
                    remaining--;
                }

                if (queue.Count == 0)
                    toRemove.Add(userIndex);
            }

            foreach (var key in toRemove)
                _queues.Remove(key);
        }
    }

    /// <summary>
    /// Removes all queued chunks for a specific client.
    /// Called when a client disconnects to prevent stale sends.
    /// </summary>
    public static void ClearClient(int userIndex)
    {
        lock (_lock)
        {
            if (_queues.Remove(userIndex))
                HeartLogger.Debug(LOG_SOURCE,
                    $"Cleared queue for userIndex {userIndex} on disconnect.");
        }
    }

    /// <summary>
    /// Clears all queues. Called on world destroy.
    /// </summary>
    public static void ClearAll()
    {
        lock (_lock)
        {
            _queues.Clear();
            HeartLogger.Debug(LOG_SOURCE, "All sync queues cleared.");
        }
    }

    /// <summary>Returns the total number of pending chunks across all client queues.</summary>
    public static int TotalPending
    {
        get
        {
            lock (_lock)
                return _queues.Values.Sum(q => q.Count);
        }
    }
}