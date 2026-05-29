// ============================================================
//  SyncTierEnum — LilithsHeart
//  LilithsHeart/Network/SyncTierEnum.cs
//
//  Priority tiers for the sync payload delivery system.
//  Lower numeric value = higher priority = sent first.
//
//  Tier assignment rationale:
//  ───────────────────────────
//  Critical   — ItemAppearanceOverrides (display names, tooltips,
//               icons). Must arrive before the inventory UI builds
//               or the player sees vanilla names briefly.
//               Smallest data volume — typically under 5KB.
//
//  High       — RecipeOverrides + StationRecipeOverrides.
//               Crafting UI is visible shortly after login.
//               Medium data volume.
//
//  Normal     — PlayerRecipesToAdd + PlayerRecipesToRemove.
//               Player recipe unlocks are less time-sensitive —
//               a brief delay before they appear is acceptable.
//
//  Low        — Reserved for future modules: quest names/text
//               (LilithsMachinations), spell names/tooltips
//               (LilithsGrimoire). Background apply acceptable.
//
//  Background — Reserved for large data sets with no urgency:
//               horse breeding tables (LilithsMenagerie),
//               bounty data (LilithsBounty), treasury config
//               (LilithsTreasury). Sent last, applied lazily.
//
//  [PERFORMANCE] Tiers are processed in ascending numeric order
//                by SyncSender. Critical arrives and is applied
//                by Soul before High chunks even begin sending.
//                Each tier is independent — Soul applies each
//                on its own end sentinel without waiting for
//                later tiers to arrive.
// ============================================================

namespace LilithsHeart.Network;

public enum SyncTierEnum
{
    Critical   = 0,
    High       = 1,
    Normal     = 2,
    Low        = 3,
    Background = 4,
}