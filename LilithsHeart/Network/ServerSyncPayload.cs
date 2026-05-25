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
//    HeartConfig.ServerName) so Soul can match a cached payload
//    to the right server on reconnect.
//
//  • PayloadHash is computed by SyncPayloadCache after serialization
//    and written back into the payload before the final cache write.
//    Soul compares this against the cached file's hash and skips
//    re-writing and re-patching if nothing changed.
//
//  • Localization entries are the flattened contents of
//    LocalizationConfig — keyed by prefab name, separate display
//    name and tooltip fields.
//
//  • [CHANGED] Added RecipeOverrides — a dict of recipe prefab name
//    → RecipeOverrideData. Populated by LilithsCookbook via
//    Heart.RegisterRecipeOverrides() after applying server changes.
//    Soul uses this to patch client-side prefab ECS entities so the
//    HUD displays the correct ingredients, outputs, and duration.
//    Only recipes with ChangesEnabled = true are included — vanilla
//    recipes are not sent to keep payload size minimal.
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
    /// Human-readable server name (from HeartConfig.ServerName).
    /// Used by Soul as the folder name under LilithsSoul/config/.
    /// Must be filesystem-safe — sanitized by SanitizeFolderName before use.
    /// </summary>
    public string ServerIdentity { get; set; } = string.Empty;

    /// <summary>
    /// Short content hash of this payload (e.g. first 8 chars of SHA256).
    /// Populated by SyncPayloadCache.Build() before the payload is cached.
    /// Soul compares this to its cached value to skip redundant writes/patches.
    /// </summary>
    public string PayloadHash { get; set; } = string.Empty;

    // ── Localization ────────────────────────────────────────

    /// <summary>
    /// Display name overrides, keyed by prefab name.
    /// Soul injects these into the client localization system.
    /// </summary>
    public Dictionary<string, string> DisplayNameOverrides { get; set; } = new();

    /// <summary>
    /// Tooltip overrides, keyed by prefab name.
    /// </summary>
    public Dictionary<string, string> TooltipOverrides { get; set; } = new();

    // ── Recipe overrides ────────────────────────────────────

    /// <summary>
    /// Recipe data overrides, keyed by recipe prefab name.
    /// e.g. "Recipe_Weapon_Sword_T04_Copper_Reinforced" → RecipeOverrideData
    ///
    /// Only recipes with ChangesEnabled = true in LilithsCookbook config
    /// are included. Soul patches RecipeData, RecipeRequirementBuffer, and
    /// RecipeOutputBuffer on client prefab entities from this dict.
    ///
    /// [CHANGED] Added to support client-side recipe display accuracy.
    /// </summary>
    public Dictionary<string, RecipeOverrideData> RecipeOverrides { get; set; } = new();

    // ── Factory ─────────────────────────────────────────────

    /// <summary>
    /// Builds a ready-to-send payload from the current Heart config state.
    /// RecipeOverrides starts empty — LilithsCookbook calls
    /// Heart.RegisterRecipeOverrides() after applying its changes, which
    /// populates this before SyncPayloadCache.Build() serializes it.
    /// PayloadHash is left empty here — SyncPayloadCache.Build() fills it
    /// after serialization so the hash covers the full content.
    /// </summary>
    public static ServerSyncPayload Build(string serverIdentity)
    {
        return new ServerSyncPayload
        {
            ServerIdentity       = SanitizeFolderName(serverIdentity),
            DisplayNameOverrides = new Dictionary<string, string>(LocalizationConfig.DisplayNames),
            TooltipOverrides     = new Dictionary<string, string>(LocalizationConfig.Tooltips),
            // RecipeOverrides populated separately by LilithsCookbook
        };
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