// ============================================================
//  PrefabDef — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/PrefabDef.cs
//
//  Universal prefab definition record.
//
//  Design decisions:
//  ─────────────────
//  • Single universal struct for all prefab categories (items, spells,
//    units, stations, etc.). Per-category typed defs would add expressive
//    power but also maintenance overhead across fourteen modules before
//    we've established a demonstrated need. Split only if a category
//    requires fields that don't belong on all others.
//
//  • Field order is optimised for manual readability, not struct layout.
//    Name first — it's what a human reads when scanning the file.
//    Guid and Prefab follow as the two fields always known at definition
//    time. NameKey and DescKey trail because they're filled incrementally.
//
//  • Name, NameKey, and DescKey are nullable (string?) to represent
//    genuine incompleteness. An empty string would mask whether a field
//    is "not yet filled" vs "intentionally blank". Nulls make partial
//    entries self-documenting and allow consuming code to guard cleanly:
//        if (def.NameKey is not null) { ... }
//
//  • Guid and Prefab are non-nullable — every entry must have these.
//    They are the two fields derivable from game data without manual work.
//
//  • readonly record struct gives value semantics and a free Equals /
//    GetHashCode / ToString implementation. Stack-allocated — no heap
//    pressure from holding thousands of entries in static fields.
//
//  Population strategy:
//  ─────────────────────
//  Entries exist in three states of completeness:
//
//    Stub     — Guid + Prefab only. Migrated from Unsorted.cs.
//    Partial  — Guid + Prefab + Name. Human name added during triage.
//    Complete — All five fields filled. Prioritise for modules that need
//               localization (LilithsVision, display name overrides).
//
//  Fill NameKey / DescKey incrementally, starting with items that a
//  module actively needs. There is no requirement to complete the full
//  catalogue before any module is usable.
//
//  [PERFORMANCE] readonly record struct is stack-allocated. Holding
//                thousands of these as static readonly fields in category
//                classes (Items, Spells, etc.) carries zero heap cost.
//                Field access is direct memory read — O(1), no lookup.
// ============================================================

using Stunlock.Core;

namespace LilithsHeart.Prefabs.Definitions;

/// <summary>
/// Universal definition record for a V Rising prefab.
/// Covers all categories — items, spells, units, stations, and more.
/// </summary>
public readonly record struct PrefabDef
{
    /// <summary>
    /// Human-readable name for this prefab.
    /// Used in config files, logging, and admin commands.
    /// Null until manually filled.
    /// </summary>
    public string?    Name    { get; init; }

    /// <summary>
    /// The integer GUID that identifies this prefab in the ECS at runtime.
    /// Always known. Use this for all EntityManager and PrefabGuidToEntityMap lookups.
    /// </summary>
    public PrefabGUID Guid    { get; init; }

    /// <summary>
    /// The internal asset name as defined by Stunlock (e.g. "Item_BloodEssence_T01").
    /// Always known. Useful for debugging, cross-referencing, and generator output.
    /// </summary>
    public string     Prefab  { get; init; }

    /// <summary>
    /// Localization GUID for the display name shown in-game.
    /// Null until manually filled. Check before use:
    ///     if (def.NameKey is not null) { ... }
    /// </summary>
    public string?    NameKey { get; init; }

    /// <summary>
    /// Localization GUID for the item description / tooltip shown in-game.
    /// Null until manually filled. Check before use:
    ///     if (def.DescKey is not null) { ... }
    /// </summary>
    public string?    DescKey { get; init; }
}