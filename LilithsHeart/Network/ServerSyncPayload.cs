// ============================================================
//  ServerSyncPayload — LilithsHeart
//
//  The single data bundle Heart sends to a connecting Soul client.
//  Sent once per connection. Soul writes it to disk under:
//      BepInEx/config/LilithsSoul/<ServerIdentity>/sync.json
//
//  Design decisions:
//  ─────────────────
//  • One packet, one file — all server-defined client data travels
//    together. This keeps the network handshake simple and gives
//    Soul a single source of truth per server on disk.
//
//  • ServerIdentity is used as the folder key on the Soul side.
//    It should be stable across restarts (server name from
//    GameSettings, not a runtime GUID) so Soul can match a cached
//    payload to the right server on reconnect.
//
//  • [CHANGED] Gameplay settings removed from this payload.
//    Heart is infrastructure-only. When gameplay modules need to
//    sync values to Soul (e.g. LilithsArmory stat ranges), they
//    will extend the payload at that point. For now the payload
//    carries only localization overrides.
//
//  • Localization entries are the flattened contents of
//    LocalizationConfig — keyed by prefab name, separate display
//    name and tooltip fields. null means "use vanilla string".
//
//  • PayloadHash is a short SHA256 hash of the serialized content.
//    Soul compares this against the cached file's hash and skips
//    re-writing and re-patching if nothing changed.
//    This avoids unnecessary disk I/O and prefab re-patching on
//    every connect to the same server.
//
//  [PERFORMANCE] Serialized once on connect, deserialized once on
//                the client. Not updated during a session.
//                Keep fields flat — avoid nested collections that
//                would bloat serialization cost.
// ============================================================

using LilithsHeart.Config;

namespace LilithsHeart.Network;

/// <summary>
/// All server-defined configuration that Heart sends to Soul on connect.
/// Serialize to JSON for both network transport and on-disk caching.
/// </summary>
public sealed class ServerSyncPayload
{
    // ── Identity ────────────────────────────────────────────

    /// <summary>
    /// Human-readable server name (from GameSettings).
    /// Used by Soul as the folder name under LilithsSoul/config/.
    /// Must be filesystem-safe — sanitize before use as a path segment.
    /// </summary>
    public string ServerIdentity { get; set; } = string.Empty;

    /// <summary>
    /// Short content hash of this payload (e.g. first 8 chars of SHA256).
    /// Soul compares this to its cached value to skip redundant writes/patches.
    /// Populated by <see cref="BuildHash"/> before sending.
    /// </summary>
    public string PayloadHash { get; set; } = string.Empty;

    // ── Localization ────────────────────────────────────────

    /// <summary>
    /// Display name overrides, keyed by prefab name.
    /// Value is the server-defined display string.
    /// Soul injects these into the client localization system.
    /// </summary>
    public Dictionary<string, string> DisplayNameOverrides { get; set; } = new();

    /// <summary>
    /// Tooltip overrides, keyed by prefab name.
    /// Value is the server-defined tooltip string.
    /// </summary>
    public Dictionary<string, string> TooltipOverrides { get; set; } = new();

    // ── Factory ─────────────────────────────────────────────

    /// <summary>
    /// Builds a ready-to-send payload from the current Heart config state.
    /// Call this once per connecting client, not once per session —
    /// different servers may run different Heart versions with different values.
    /// </summary>
    public static ServerSyncPayload Build(string serverIdentity)
    {
        var payload = new ServerSyncPayload
        {
            ServerIdentity = SanitizeFolderName(serverIdentity),

            // Flatten LocalizationConfig dictionaries into the payload.
            // new Dictionary() avoids sharing the live reference with LocalizationConfig.
            DisplayNameOverrides = new Dictionary<string, string>(LocalizationConfig.DisplayNames),
            TooltipOverrides     = new Dictionary<string, string>(LocalizationConfig.Tooltips),
        };

        payload.PayloadHash = payload.BuildHash();
        return payload;
    }

    /// <summary>
    /// Computes a short stable hash of the payload content (excluding PayloadHash itself).
    /// Used by Soul to detect unchanged payloads and skip redundant work.
    /// </summary>
    public string BuildHash()
    {
        // [PERFORMANCE] Serializes to JSON for a canonical string, then hashes it.
        //               Runs once per connect — cost is acceptable.
        //               If payload size grows significantly, switch to a field-by-field
        //               hash to avoid the intermediate JSON allocation.
        var content = System.Text.Json.JsonSerializer.Serialize(new
        {
            ServerIdentity,
            DisplayNameOverrides,
            TooltipOverrides,
        });

        var bytes = System.Security.Cryptography.SHA256.HashData(
            System.Text.Encoding.UTF8.GetBytes(content));

        // First 8 hex chars — short enough for a filename/log, collision risk is negligible.
        return Convert.ToHexString(bytes)[..8];
    }

    // ── Helpers ─────────────────────────────────────────────

    /// <summary>
    /// Strips characters that are invalid in folder names on Windows and Linux.
    /// Soul uses ServerIdentity directly as a path segment.
    /// </summary>
    static string SanitizeFolderName(string name)
    {
        var invalid = Path.GetInvalidFileNameChars();
        return string.Concat(name.Select(c => invalid.Contains(c) ? '_' : c)).Trim();
    }
}