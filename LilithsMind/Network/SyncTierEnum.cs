// ============================================================
//  SyncTierEnum — LilithsMind
//  LilithsMind/Network/SyncTierEnum.cs
//
//  Defines the priority tiers used by the Heart→Soul sync
//  transport. Tiers control the order in which payload sections
//  are sent to connecting clients.
//
//  Design:
//  ───────
//  Heart builds one compressed blob per tier at startup.
//  On client connect, tiers are sent sequentially — Critical
//  first, Low last. Each tier is an independent compressed
//  payload with its own begin/end sentinels and checksum.
//
//  Soul applies each tier as it arrives, independently of
//  the others. Critical data (item names) is applied during
//  the loading screen. Lower tiers arrive after the player
//  is in the world.
//
//  TierAssignments:
//  ─────────────────
//  Change a single const to move a data section between tiers.
//  No protocol changes, no Soul-side changes needed — the tier
//  number in the sentinel handles routing automatically.
//
//  As new modules add payload sections, they claim a const here.
//  This is the single source of truth for tier assignment.
// ============================================================

namespace LilithsMind.Network;

/// <summary>
/// Priority tier for a sync payload section.
/// Lower numbers are sent first and applied earlier.
/// </summary>
public enum SyncTier
{
    /// <summary>
    /// Sent immediately on connect, during the loading screen.
    /// For data the player sees the moment they enter the world.
    /// </summary>
    Critical = 1,

    /// <summary>
    /// Sent immediately after Critical completes.
    /// For data visible at the first crafting station.
    /// </summary>
    High = 2,

    /// <summary>
    /// Sent after a short delay post-connect.
    /// For data the player reaches after settling in.
    /// </summary>
    Normal = 3,

    /// <summary>
    /// Sent in the background, lowest priority.
    /// For cosmetic or late-game data.
    /// </summary>
    Low = 4,
}

/// <summary>
/// Single source of truth for which tier each payload section belongs to.
/// Change a single const here to move a section between tiers — no other
/// files need updating.
///
/// When adding a new module payload section, claim a const here first.
/// </summary>
public static class TierAssignments
{
    // ── LilithsHeart core ────────────────────────────────────
    // Visible the moment the player opens inventory or UI.

    /// <summary>Item display name overrides — visible immediately in inventory.</summary>
    public const SyncTier ItemNames    = SyncTier.Critical;

    /// <summary>Item tooltip overrides — visible immediately on hover.</summary>
    public const SyncTier ItemTooltips = SyncTier.Critical;

    // ── LilithsCookbook ──────────────────────────────────────
    // Visible when the player opens a crafting station.

    /// <summary>Recipe ingredient/output/duration overrides.</summary>
    public const SyncTier RecipeData     = SyncTier.High;

    /// <summary>Station recipe list additions and removals.</summary>
    public const SyncTier StationRecipes = SyncTier.High;

    /// <summary>Player crafting menu recipe additions and removals.</summary>
    public const SyncTier PlayerRecipes  = SyncTier.High;

    // ── Future modules ───────────────────────────────────────
    // Claim entries here as modules are built.
    //
    // LilithsGrimoire  — spell/buff names and tooltips  → Normal
    // LilithsArchitects — blueprint requirements         → Normal
    // LilithsAdversaries — unit names and tooltips       → Normal
    // LilithsMachinations — quest text                   → Low
    // LilithsVision — icon override names                → Low
}