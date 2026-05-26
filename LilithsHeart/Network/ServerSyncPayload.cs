// ============================================================
//  ServerSyncPayload — LilithsHeart
//
//  The single data bundle Heart sends to a connecting Soul client.
//  Sent once per connection. Soul writes it to disk under:
//      BepInEx/config/LilithsSoul/<ServerIdentity>/sync.json
//
//  [CHANGED] Added PlayerRecipesToAdd and PlayerRecipesToRemove.
//            These are lists of recipe prefab names that Soul uses
//            to patch the client's own player entity's
//            WorkstationRecipesBuffer, so the player crafting menu
//            reflects server-side changes.
//
//  [PERFORMANCE] Serialized once on connect, deserialized once on
//                the client. Not updated during a session.
// ============================================================

using LilithsHeart.Config;

namespace LilithsHeart.Network;

public sealed class ServerSyncPayload
{
    // ── Identity ────────────────────────────────────────────

    public string ServerIdentity { get; set; } = string.Empty;
    public string PayloadHash    { get; set; } = string.Empty;

    // ── Localization ────────────────────────────────────────

    public Dictionary<string, string> DisplayNameOverrides { get; set; } = new();
    public Dictionary<string, string> TooltipOverrides     { get; set; } = new();

    // ── Recipe overrides ────────────────────────────────────

    /// <summary>
    /// Recipe data overrides keyed by recipe prefab name.
    /// Soul patches RecipeData, RecipeRequirementBuffer, RecipeOutputBuffer
    /// and RecipeHashLookupMap on client prefab entities from this dict.
    /// </summary>
    public Dictionary<string, RecipeOverrideData> RecipeOverrides { get; set; } = new();

    /// <summary>
    /// Station recipe overrides keyed by station prefab name.
    /// Soul patches WorkstationRecipesBuffer on matching client-side station
    /// entities so the crafting UI reflects server-side changes.
    ///
    /// [CHANGED] Added to fix WorkstationRecipesBuffer crafting stations
    ///           not reflecting server-side recipe changes on the client.
    /// </summary>
    public Dictionary<string, StationRecipeOverrideData> StationRecipeOverrides { get; set; } = new();

    // ── Player crafting overrides ────────────────────────────

    /// <summary>
    /// Recipe prefab names to add to the client's player WorkstationRecipesBuffer.
    /// Soul patches the local player entity's buffer so the player crafting
    /// menu reflects server-side additions.
    ///
    /// [CHANGED] Added to fix player crafting menu not reflecting server changes.
    /// </summary>
    public List<string> PlayerRecipesToAdd    { get; set; } = new();

    /// <summary>
    /// Recipe prefab names to remove from the client's player WorkstationRecipesBuffer.
    /// Soul patches the local player entity's buffer so the player crafting
    /// menu reflects server-side removals.
    ///
    /// [CHANGED] Added to fix player crafting menu not reflecting server changes.
    /// </summary>
    public List<string> PlayerRecipesToRemove { get; set; } = new();

    // ── Factory ─────────────────────────────────────────────

    public static ServerSyncPayload Build(string serverIdentity)
    {
        return new ServerSyncPayload
        {
            ServerIdentity       = SanitizeFolderName(serverIdentity),
            DisplayNameOverrides = new Dictionary<string, string>(LocalizationConfig.DisplayNames),
            TooltipOverrides     = new Dictionary<string, string>(LocalizationConfig.Tooltips),
            // RecipeOverrides, PlayerRecipesToAdd, PlayerRecipesToRemove
            // populated separately by modules via Heart.Register*() methods.
        };
    }

    static string SanitizeFolderName(string name)
    {
        var invalid = Path.GetInvalidFileNameChars();
        return string.Concat(name.Select(c => invalid.Contains(c) ? '_' : c)).Trim();
    }
}