// ============================================================
//  ServerSyncPayload — LilithsSoul
//  LilithsSoul/Network/ServerSyncPayload.cs
//
//  Client-side duplicate of LilithsHeart.Network.ServerSyncPayload.
//  Deserialize-only — Soul never constructs or hashes a payload,
//  it only reads what Heart sends.
//
//  ⚠️  SYNC REQUIREMENT:
//      Must be kept structurally in sync with
//      LilithsHeart/Network/ServerSyncPayload.cs manually.
//      JSON deserialization silently ignores unknown fields,
//      but missing fields will deserialize as their defaults
//      (empty string, empty dict, etc.).
//
//  Factory methods (Build, SanitizeFolderName) are intentionally
//  absent — Soul has no use for them.
//
//  [CHANGED] Added RecipeOverrides field to mirror Heart's payload.
//            RecipePatcher reads this after SyncReceiver deserializes
//            the payload and applies it to client prefab entities.
// ============================================================

namespace LilithsSoul.Network;

public sealed class ServerSyncPayload
{
    // ── Identity ────────────────────────────────────────────

    /// <summary>
    /// Human-readable server name. Used as the folder key under
    /// BepInEx/config/LilithsSoul/<ServerIdentity>/
    /// Already sanitized by Heart before sending.
    /// </summary>
    public string ServerIdentity { get; set; } = string.Empty;

    /// <summary>
    /// Short SHA256 hash of the payload content.
    /// Soul compares this against the cached sync.json hash to
    /// skip redundant disk writes and re-patching.
    /// </summary>
    public string PayloadHash { get; set; } = string.Empty;

    // ── Localization ────────────────────────────────────────

    /// <summary>
    /// Display name overrides keyed by prefab name.
    /// Injected into the client localization system by LocalizationInjector.
    /// </summary>
    public Dictionary<string, string> DisplayNameOverrides { get; set; } = new();

    /// <summary>
    /// Tooltip overrides keyed by prefab name.
    /// Injected into the client localization system by LocalizationInjector.
    /// </summary>
    public Dictionary<string, string> TooltipOverrides { get; set; } = new();

    // ── Recipe overrides ────────────────────────────────────

    /// <summary>
    /// Recipe data overrides keyed by recipe prefab name.
    /// e.g. "Recipe_Weapon_Sword_T04_Copper_Reinforced" → RecipeOverrideData
    ///
    /// Passed to RecipePatcher.Apply() by SyncReceiver after the payload
    /// is received. RecipePatcher patches RecipeData, RecipeRequirementBuffer,
    /// and RecipeOutputBuffer on client-side prefab entities so the HUD
    /// displays the correct ingredients, outputs, and craft duration.
    ///
    /// Empty if LilithsCookbook is not installed on the server, or if no
    /// recipes have ChangesEnabled = true. RecipePatcher handles this
    /// gracefully — Apply() with an empty dict is a no-op.
    ///
    /// [CHANGED] Added to support client-side recipe display accuracy.
    /// </summary>
    public Dictionary<string, RecipeOverrideData> RecipeOverrides { get; set; } = new();
}