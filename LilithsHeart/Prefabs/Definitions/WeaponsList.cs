// ============================================================
//  WeaponsList — Part 1 of 2 — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/WeaponsList.cs
//
//  [CHANGED] Migrated from bare PrefabGUID + [PrefabName] attribute fields
//            to PrefabDef records. Field names match the prefab string exactly.
//            Names sourced from [PrefabName] attributes; null where absent
//            (misc/shattered/template variants). All nullable fields shown explicitly.
//
//  Parts: 1 — Swords, Axes, Maces, Spears, Reapers, Slashers
//         2 — Crossbows, Longbows, Claws, Daggers, Greatswords,
//             Pistols, Twinblades, Whips, Fishing Poles
//
//  [PERFORMANCE] Static readonly PrefabDef fields — initialised once at
//                class load, zero per-frame cost. Stack-allocated structs,
//                no heap pressure.
// ============================================================

using Stunlock.Core;

namespace LilithsHeart.Prefabs.Definitions;

public static partial class WeaponsList
{
    // ── Swords ────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Weapon_Sword_T01_Bone = new()
    {
        Name    = "BoneSword",
        Guid    = new(-2085919458),
        Prefab  = "Item_Weapon_Sword_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_T02_Bone_Reinforced = new()
    {
        Name    = "ReinforcedBoneSword",
        Guid    = new(-796306296),
        Prefab  = "Item_Weapon_Sword_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_T03_Copper = new()
    {
        Name    = "CopperSword",
        Guid    = new(-2037272000),
        Prefab  = "Item_Weapon_Sword_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_T04_Copper_Reinforced = new()
    {
        Name    = "MercilessCopperSword",
        Guid    = new(-1219959051),
        Prefab  = "Item_Weapon_Sword_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_T05_Iron = new()
    {
        Name    = "IronSword",
        Guid    = new(-903587404),
        Prefab  = "Item_Weapon_Sword_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronSword",
        Guid    = new(-435501075),
        Prefab  = "Item_Weapon_Sword_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_Legendary_T06 = new()
    {
        Name    = "LegendaryIronSword",
        Guid    = new(1637216050),
        Prefab  = "Item_Weapon_Sword_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_T07_DarkSilver = new()
    {
        Name    = "DarkSilverSword",
        Guid    = new(-1455388114),
        Prefab  = "Item_Weapon_Sword_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_T08_Sanguine = new()
    {
        Name    = "SanguineSword",
        Guid    = new(-774462329),
        Prefab  = "Item_Weapon_Sword_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineSword",
        Guid    = new(195858450),
        Prefab  = "Item_Weapon_Sword_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_Unique_T08_Variation01 = new()
    {
        Name    = "TheGravecaller",
        Guid    = new(2106567892),
        Prefab  = "Item_Weapon_Sword_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_T09_ShadowMatter = new()
    {
        Name    = "ShadowSword",
        Guid    = new(-1215982687),
        Prefab  = "Item_Weapon_Sword_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Sword_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(1564801426),  Prefab = "Item_Weapon_Sword_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Sword_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(1908755405),  Prefab = "Item_Weapon_Sword_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Sword_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(220001518),   Prefab = "Item_Weapon_Sword_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Sword_Legendary_T08_Shattered = new() { Name = null, Guid = new(1048769481),  Prefab = "Item_Weapon_Sword_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Sword_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-830893351),  Prefab = "Item_Weapon_Sword_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Sword_Legendary_T06_Shattered = new() { Name = null, Guid = new(-1421775051), Prefab = "Item_Weapon_Sword_Legendary_T06_Shattered",         NameKey = null, DescKey = null };

    // ── Axes ──────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Weapon_Axe_T01_Bone = new()
    {
        Name    = "BoneAxe",
        Guid    = new(-1958888844),
        Prefab  = "Item_Weapon_Axe_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T02_Bone_Reinforced = new()
    {
        Name    = "ReinforcedBoneAxe",
        Guid    = new(-1391446205),
        Prefab  = "Item_Weapon_Axe_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T02_WoodCutter = new()
    {
        Name    = "LumberjacksAxe",
        Guid    = new(1541522788),
        Prefab  = "Item_Weapon_Axe_T02_WoodCutter",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T03_Copper = new()
    {
        Name    = "CopperAxe",
        Guid    = new(518802008),
        Prefab  = "Item_Weapon_Axe_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T04_Copper_Reinforced = new()
    {
        Name    = "MercilessCopperAxe",
        Guid    = new(-491969324),
        Prefab  = "Item_Weapon_Axe_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T05_Iron = new()
    {
        Name    = "IronAxe",
        Guid    = new(-1579575933),
        Prefab  = "Item_Weapon_Axe_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronAxe",
        Guid    = new(198951695),
        Prefab  = "Item_Weapon_Axe_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_Legendary_T06 = new()
    {
        Name    = "LegendaryIronAxe",
        Guid    = new(1259464735),
        Prefab  = "Item_Weapon_Axe_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T07_DarkSilver = new()
    {
        Name    = "DarkSilverAxe",
        Guid    = new(-1130238142),
        Prefab  = "Item_Weapon_Axe_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T08_Sanguine = new()
    {
        Name    = "SanguineAxe",
        Guid    = new(-2044057823),
        Prefab  = "Item_Weapon_Axe_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineAxe",
        Guid    = new(-102830349),
        Prefab  = "Item_Weapon_Axe_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_Unique_T08_Variation01 = new()
    {
        Name    = "TheRedTwins",
        Guid    = new(1239564213),
        Prefab  = "Item_Weapon_Axe_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_T09_ShadowMatter = new()
    {
        Name    = "ShadowAxe",
        Guid    = new(2100090213),
        Prefab  = "Item_Weapon_Axe_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Axe_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(163122449),   Prefab = "Item_Weapon_Axe_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Axe_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(1570017693),  Prefab = "Item_Weapon_Axe_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Axe_Legendary_T06_Shattered = new() { Name = null, Guid = new(-2147445292), Prefab = "Item_Weapon_Axe_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Axe_Legendary_T08_Shattered = new() { Name = null, Guid = new(442700150),   Prefab = "Item_Weapon_Axe_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Axe_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-1024626758), Prefab = "Item_Weapon_Axe_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Axe_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(2099198078),  Prefab = "Item_Weapon_Axe_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };

    // ── Maces ─────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Weapon_Mace_T01_Bone = new()
    {
        Name    = "BoneMace",
        Guid    = new(1588258447),
        Prefab  = "Item_Weapon_Mace_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T02_Bone_Reinforced = new()
    {
        Name    = "ReinforcedBoneMace",
        Guid    = new(-1998017941),
        Prefab  = "Item_Weapon_Mace_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T02_Miners = new()
    {
        Name    = "MinersMace",
        Guid    = new(-687294429),
        Prefab  = "Item_Weapon_Mace_T02_Miners",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T03_Copper = new()
    {
        Name    = "CopperMace",
        Guid    = new(-331345186),
        Prefab  = "Item_Weapon_Mace_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T04_Copper_Reinforced = new()
    {
        Name    = "MercilessCopperMace",
        Guid    = new(343324920),
        Prefab  = "Item_Weapon_Mace_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T05_Iron = new()
    {
        Name    = "IronMace",
        Guid    = new(-1714012261),
        Prefab  = "Item_Weapon_Mace_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronMace",
        Guid    = new(-276593802),
        Prefab  = "Item_Weapon_Mace_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_Legendary_T06 = new()
    {
        Name    = "LegendaryIronMace",
        Guid    = new(1177597629),
        Prefab  = "Item_Weapon_Mace_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T07_DarkSilver = new()
    {
        Name    = "DarkSilverMace",
        Guid    = new(-184713893),
        Prefab  = "Item_Weapon_Mace_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T08_Sanguine = new()
    {
        Name    = "SanguineMace",
        Guid    = new(-126076280),
        Prefab  = "Item_Weapon_Mace_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineMace",
        Guid    = new(1994084762),
        Prefab  = "Item_Weapon_Mace_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_Unique_T08_Variation01 = new()
    {
        Name    = "HandOfWinter",
        Guid    = new(675187526),
        Prefab  = "Item_Weapon_Mace_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_T09_ShadowMatter = new()
    {
        Name    = "ShadowMace",
        Guid    = new(160471982),
        Prefab  = "Item_Weapon_Mace_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Mace_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(264593098),   Prefab = "Item_Weapon_Mace_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Mace_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(-2048346225), Prefab = "Item_Weapon_Mace_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Mace_Legendary_T06_Shattered = new() { Name = null, Guid = new(1963988265),  Prefab = "Item_Weapon_Mace_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Mace_Legendary_T08_Shattered = new() { Name = null, Guid = new(-1810734832), Prefab = "Item_Weapon_Mace_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Mace_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-1845443712), Prefab = "Item_Weapon_Mace_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Mace_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(-915028618),  Prefab = "Item_Weapon_Mace_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };

    // ── Spears ────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Weapon_Spear_T01_Bone = new()
    {
        Name    = "BoneSpear",
        Guid    = new(2038011836),
        Prefab  = "Item_Weapon_Spear_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_T02_Bone_Reinforced = new()
    {
        Name    = "ReinforcedBoneSpear",
        Guid    = new(1244180446),
        Prefab  = "Item_Weapon_Spear_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_T03_Copper = new()
    {
        Name    = "CopperSpear",
        Guid    = new(1370755976),
        Prefab  = "Item_Weapon_Spear_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_T04_Copper_Reinforced = new()
    {
        Name    = "MercilessCopperSpear",
        Guid    = new(790210443),
        Prefab  = "Item_Weapon_Spear_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_T05_Iron = new()
    {
        Name    = "IronSpear",
        Guid    = new(1853029976),
        Prefab  = "Item_Weapon_Spear_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronSpear",
        Guid    = new(1065194820),
        Prefab  = "Item_Weapon_Spear_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_Legendary_T06 = new()
    {
        Name    = "LegendaryIronSpear",
        Guid    = new(2001389164),
        Prefab  = "Item_Weapon_Spear_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_T07_DarkSilver = new()
    {
        Name    = "DarkSilverSpear",
        Guid    = new(-352704566),
        Prefab  = "Item_Weapon_Spear_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_T08_Sanguine = new()
    {
        Name    = "SanguineSpear",
        Guid    = new(-850142339),
        Prefab  = "Item_Weapon_Spear_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineSpear",
        Guid    = new(-1931117134),
        Prefab  = "Item_Weapon_Spear_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_Unique_T08_Variation01 = new()
    {
        Name    = "TheThousandStorms",
        Guid    = new(-1674680373),
        Prefab  = "Item_Weapon_Spear_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_T09_ShadowMatter = new()
    {
        Name    = "ShadowSpear",
        Guid    = new(1307774440),
        Prefab  = "Item_Weapon_Spear_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Spear_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(-1854790299), Prefab = "Item_Weapon_Spear_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Spear_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(912809090),   Prefab = "Item_Weapon_Spear_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Spear_Legendary_T06_Shattered = new() { Name = null, Guid = new(2142983740),  Prefab = "Item_Weapon_Spear_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Spear_Legendary_T08_Shattered = new() { Name = null, Guid = new(1717016192),  Prefab = "Item_Weapon_Spear_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Spear_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-958110636),  Prefab = "Item_Weapon_Spear_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Spear_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(124616797),   Prefab = "Item_Weapon_Spear_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };

    // ── Reapers ───────────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Weapon_Reaper_T01_Bone = new()
    {
        Name    = "BoneReaper",
        Guid    = new(-152327780),
        Prefab  = "Item_Weapon_Reaper_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T02_Bone_Reinforced = new()
    {
        Name    = "ReinforcedBoneReaper",
        Guid    = new(1402953369),
        Prefab  = "Item_Weapon_Reaper_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T03_Copper = new()
    {
        Name    = "CopperReaper",
        Guid    = new(1522792650),
        Prefab  = "Item_Weapon_Reaper_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T04_Copper_Reinforced = new()
    {
        Name    = "MercilessCopperReaper",
        Guid    = new(1048518929),
        Prefab  = "Item_Weapon_Reaper_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T05_Iron = new()
    {
        Name    = "IronReaper",
        Guid    = new(-2081286944),
        Prefab  = "Item_Weapon_Reaper_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronReaper",
        Guid    = new(1778128946),
        Prefab  = "Item_Weapon_Reaper_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_Legendary_T06 = new()
    {
        Name    = "LegendaryIronReaper",
        Guid    = new(-922125625),
        Prefab  = "Item_Weapon_Reaper_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T06_Iron_UndeadGeneral = new()
    {
        Name    = "GeneralsSoulReaper",
        Guid    = new(1887724512),
        Prefab  = "Item_Weapon_Reaper_T06_Iron_UndeadGeneral",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T07_DarkSilver = new()
    {
        Name    = "DarkSilverReaper",
        Guid    = new(6711686),
        Prefab  = "Item_Weapon_Reaper_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T08_Sanguine = new()
    {
        Name    = "SanguineReaper",
        Guid    = new(-2053917766),
        Prefab  = "Item_Weapon_Reaper_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineReaper",
        Guid    = new(-105026635),
        Prefab  = "Item_Weapon_Reaper_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_Unique_T08_Variation01 = new()
    {
        Name    = "MortirasLament",
        Guid    = new(-859437190),
        Prefab  = "Item_Weapon_Reaper_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_T09_ShadowMatter = new()
    {
        Name    = "ShadowReaper",
        Guid    = new(-465491217),
        Prefab  = "Item_Weapon_Reaper_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Reaper_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(-576626587),  Prefab = "Item_Weapon_Reaper_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Reaper_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(-383870009),  Prefab = "Item_Weapon_Reaper_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Reaper_Legendary_T06_Shattered = new() { Name = null, Guid = new(-413259500),  Prefab = "Item_Weapon_Reaper_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Reaper_Legendary_T08_Shattered = new() { Name = null, Guid = new(886814985),   Prefab = "Item_Weapon_Reaper_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Reaper_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-2136716453), Prefab = "Item_Weapon_Reaper_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Reaper_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(1801132968),  Prefab = "Item_Weapon_Reaper_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };

    // ── Slashers ──────────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Weapon_Slashers_T01_Bone = new()
    {
        Name    = "BoneSlashers",
        Guid    = new(-588909332),
        Prefab  = "Item_Weapon_Slashers_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_T02_Bone_Reinforced = new()
    {
        Name    = "ReinforcedBoneSlashers",
        Guid    = new(926722036),
        Prefab  = "Item_Weapon_Slashers_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_T03_Copper = new()
    {
        Name    = "CopperSlashers",
        Guid    = new(1499160417),
        Prefab  = "Item_Weapon_Slashers_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_T04_Copper_Reinforced = new()
    {
        Name    = "MercilessCopperSlashers",
        Guid    = new(-1042299347),
        Prefab  = "Item_Weapon_Slashers_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_T05_Iron = new()
    {
        Name    = "IronSlashers",
        Guid    = new(-314614708),
        Prefab  = "Item_Weapon_Slashers_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronSlashers",
        Guid    = new(866934844),
        Prefab  = "Item_Weapon_Slashers_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_Legendary_T06 = new()
    {
        Name    = "LegendaryIronSlashers",
        Guid    = new(1930526079),
        Prefab  = "Item_Weapon_Slashers_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_T07_DarkSilver = new()
    {
        Name    = "DarkSilverSlashers",
        Guid    = new(633666898),
        Prefab  = "Item_Weapon_Slashers_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_T08_Sanguine = new()
    {
        Name    = "SanguineSlashers",
        Guid    = new(1322545846),
        Prefab  = "Item_Weapon_Slashers_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineSlashers",
        Guid    = new(821410795),
        Prefab  = "Item_Weapon_Slashers_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_Unique_T08_Variation01 = new()
    {
        Name    = "CloudDancers",
        Guid    = new(-2068145306),
        Prefab  = "Item_Weapon_Slashers_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_Unique_T08_Variation02 = new()
    {
        Name    = "WingsOfTheFallen",
        Guid    = new(1570363331),
        Prefab  = "Item_Weapon_Slashers_Unique_T08_Variation02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_T09_ShadowMatter = new()
    {
        Name    = "ShadowSlashers",
        Guid    = new(506082542),
        Prefab  = "Item_Weapon_Slashers_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Weapon_Slashers_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(658426701),   Prefab = "Item_Weapon_Slashers_Legendary_NameGenerator_T06",      NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Slashers_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(1954207008),  Prefab = "Item_Weapon_Slashers_Unique_T08_Variation01_Shattered",  NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Slashers_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(810808231),   Prefab = "Item_Weapon_Slashers_Legendary_NameGenerator_T08",      NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Slashers_Legendary_T06_Shattered = new() { Name = null, Guid = new(3759455),      Prefab = "Item_Weapon_Slashers_Legendary_T06_Shattered",          NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Slashers_Legendary_T08_Shattered = new() { Name = null, Guid = new(1271087499),  Prefab = "Item_Weapon_Slashers_Legendary_T08_Shattered",          NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Slashers_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-1390536751), Prefab = "Item_Weapon_Slashers_Legendary_T08_Trader_Template",    NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Slashers_Unique_T08_Variation02_Shattered = new() { Name = null, Guid = new(-1930402723), Prefab = "Item_Weapon_Slashers_Unique_T08_Variation02_Shattered", NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Crossbow_T01_Bone = new()
    {
        Name    = "BoneCrossbow",
        Guid    = new(-20041991),
        Prefab  = "Item_Weapon_Crossbow_T01_Bone",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_T02_Bone_Reinforced = new()
    {
        Name    = "ReinforcedBoneCrossbow",
        Guid    = new(898159697),
        Prefab  = "Item_Weapon_Crossbow_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_T03_Copper = new()
    {
        Name    = "CopperCrossbow",
        Guid    = new(-1277074895),
        Prefab  = "Item_Weapon_Crossbow_T03_Copper",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_T04_Copper_Reinforced = new()
    {
        Name    = "MercilessCopperCrossbow",
        Guid    = new(-1636801169),
        Prefab  = "Item_Weapon_Crossbow_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_T05_Iron = new()
    {
        Name    = "IronCrossbow",
        Guid    = new(836066667),
        Prefab  = "Item_Weapon_Crossbow_T05_Iron",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronCrossbow",
        Guid    = new(1221976097),
        Prefab  = "Item_Weapon_Crossbow_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_Legendary_T06 = new()
    {
        Name    = "LegendaryIronCrossbow",
        Guid    = new(-517906196),
        Prefab  = "Item_Weapon_Crossbow_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_T07_DarkSilver = new()
    {
        Name    = "DarkSilverCrossbow",
        Guid    = new(-814739263),
        Prefab  = "Item_Weapon_Crossbow_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_T08_Sanguine = new()
    {
        Name    = "SanguineCrossbow",
        Guid    = new(1389040540),
        Prefab  = "Item_Weapon_Crossbow_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineCrossbow",
        Guid    = new(935392085),
        Prefab  = "Item_Weapon_Crossbow_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_Unique_T08_Variation01 = new()
    {
        Name    = "TheSirensWail",
        Guid    = new(-1401104184),
        Prefab  = "Item_Weapon_Crossbow_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_T09_ShadowMatter = new()
    {
        Name    = "ShadowCrossbow",
        Guid    = new(1957540013),
        Prefab  = "Item_Weapon_Crossbow_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Crossbow_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(1958482379),  Prefab = "Item_Weapon_Crossbow_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Crossbow_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(1716435762),  Prefab = "Item_Weapon_Crossbow_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Crossbow_Legendary_T06_Shattered = new() { Name = null, Guid = new(572026243),   Prefab = "Item_Weapon_Crossbow_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Crossbow_Legendary_T08_Shattered = new() { Name = null, Guid = new(2061238391),  Prefab = "Item_Weapon_Crossbow_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Crossbow_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(517296275),   Prefab = "Item_Weapon_Crossbow_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Crossbow_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(781586362),   Prefab = "Item_Weapon_Crossbow_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
 
    // ── Longbows ──────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Weapon_Longbow_T03_Copper = new()
    {
        Name    = "CopperLongbow",
        Guid    = new(532033005),
        Prefab  = "Item_Weapon_Longbow_T03_Copper",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_T04_Copper_Reinforced = new()
    {
        Name    = "MercilessCopperLongbow",
        Guid    = new(352247730),
        Prefab  = "Item_Weapon_Longbow_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_T05_Iron = new()
    {
        Name    = "IronLongbow",
        Guid    = new(-1993708658),
        Prefab  = "Item_Weapon_Longbow_T05_Iron",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronLongbow",
        Guid    = new(1951565953),
        Prefab  = "Item_Weapon_Longbow_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_Legendary_T06 = new()
    {
        Name    = "LegendaryIronLongbow",
        Guid    = new(-1003309553),
        Prefab  = "Item_Weapon_Longbow_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_T07_DarkSilver = new()
    {
        Name    = "DarkSilverLongbow",
        Guid    = new(-1830162796),
        Prefab  = "Item_Weapon_Longbow_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_T08_Sanguine = new()
    {
        Name    = "SanguineLongbow",
        Guid    = new(1860352606),
        Prefab  = "Item_Weapon_Longbow_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineLongbow",
        Guid    = new(1177453385),
        Prefab  = "Item_Weapon_Longbow_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_Unique_T08_Variation01 = new()
    {
        Name    = "Oaksong",
        Guid    = new(-557203874),
        Prefab  = "Item_Weapon_Longbow_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_T09_ShadowMatter = new()
    {
        Name    = "ShadowLongbow",
        Guid    = new(1283345494),
        Prefab  = "Item_Weapon_Longbow_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Longbow_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(-726074700), Prefab = "Item_Weapon_Longbow_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Longbow_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(288292636),  Prefab = "Item_Weapon_Longbow_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Longbow_Legendary_T06_Shattered = new() { Name = null, Guid = new(649637190),  Prefab = "Item_Weapon_Longbow_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Longbow_Legendary_T08_Shattered = new() { Name = null, Guid = new(285875674),  Prefab = "Item_Weapon_Longbow_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Longbow_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(19130904),   Prefab = "Item_Weapon_Longbow_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Longbow_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(1102277512), Prefab = "Item_Weapon_Longbow_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
 
    // ── Claws ─────────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Weapon_Claws_T05_Iron = new()
    {
        Name    = "IronClaws",
        Guid    = new(-1333849822),
        Prefab  = "Item_Weapon_Claws_T05_Iron",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Claws_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronClaws",
        Guid    = new(1748886117),
        Prefab  = "Item_Weapon_Claws_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Claws_Legendary_T06 = new()
    {
        Name    = "LegendaryIronClaws",
        Guid    = new(-2060572315),
        Prefab  = "Item_Weapon_Claws_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Claws_T07_DarkSilver = new()
    {
        Name    = "DarkSilverClaws",
        Guid    = new(-1470260175),
        Prefab  = "Item_Weapon_Claws_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Claws_T08_Sanguine = new()
    {
        Name    = "SanguineClaws",
        Guid    = new(-1777908217),
        Prefab  = "Item_Weapon_Claws_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Claws_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineClaws",
        Guid    = new(-27238530),
        Prefab  = "Item_Weapon_Claws_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Claws_Unique_T08_Variation01 = new()
    {
        Name    = "TalonsOfTheLichBeast",
        Guid    = new(-996999913),
        Prefab  = "Item_Weapon_Claws_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Claws_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(-444900575),  Prefab = "Item_Weapon_Claws_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Claws_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(-1774269887), Prefab = "Item_Weapon_Claws_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Claws_Legendary_T06_Shattered = new() { Name = null, Guid = new(-1746159915), Prefab = "Item_Weapon_Claws_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Claws_Legendary_T08_Shattered = new() { Name = null, Guid = new(-655493979),  Prefab = "Item_Weapon_Claws_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Claws_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(1401940772),  Prefab = "Item_Weapon_Claws_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Claws_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(-1024379681), Prefab = "Item_Weapon_Claws_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
 
    // ── Daggers ───────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Weapon_Daggers_T05_Iron = new()
    {
        Name    = "IronDaggers",
        Guid    = new(1296724931),
        Prefab  = "Item_Weapon_Daggers_T05_Iron",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Daggers_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronDaggers",
        Guid    = new(703783407),
        Prefab  = "Item_Weapon_Daggers_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Daggers_Legendary_T06 = new()
    {
        Name    = "LegendaryIronDaggers",
        Guid    = new(-1276458869),
        Prefab  = "Item_Weapon_Daggers_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Daggers_T07_DarkSilver = new()
    {
        Name    = "DarkSilverDaggers",
        Guid    = new(-211034148),
        Prefab  = "Item_Weapon_Daggers_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Daggers_T08_Sanguine = new()
    {
        Name    = "SanguineDaggers",
        Guid    = new(1031107636),
        Prefab  = "Item_Weapon_Daggers_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Daggers_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineDaggers",
        Guid    = new(140761255),
        Prefab  = "Item_Weapon_Daggers_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Daggers_Unique_T08_Variation01 = new()
    {
        Name    = "TheWraithblades",
        Guid    = new(-1873605364),
        Prefab  = "Item_Weapon_Daggers_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Daggers_T09_ShadowMatter = new()
    {
        Name    = "ShadowDaggers",
        Guid    = new(-1961050884),
        Prefab  = "Item_Weapon_Daggers_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Daggers_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(-816018167),  Prefab = "Item_Weapon_Daggers_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Daggers_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(-1566606969), Prefab = "Item_Weapon_Daggers_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Daggers_Legendary_T06_Shattered = new() { Name = null, Guid = new(-1075670534), Prefab = "Item_Weapon_Daggers_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Daggers_Legendary_T08_Shattered = new() { Name = null, Guid = new(-2137269775), Prefab = "Item_Weapon_Daggers_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Daggers_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(1719144622),  Prefab = "Item_Weapon_Daggers_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Daggers_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(-1233207977), Prefab = "Item_Weapon_Daggers_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
 
    // ── Greatswords ───────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Weapon_GreatSword_T05_Iron = new()
    {
        Name    = "IronGreatsword",
        Guid    = new(-768054337),
        Prefab  = "Item_Weapon_GreatSword_T05_Iron",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_GreatSword_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronGreatsword",
        Guid    = new(82781195),
        Prefab  = "Item_Weapon_GreatSword_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_GreatSword_Legendary_T06 = new()
    {
        Name    = "LegendaryIronGreatsword",
        Guid    = new(869276797),
        Prefab  = "Item_Weapon_GreatSword_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_GreatSword_T07_DarkSilver = new()
    {
        Name    = "DarkSilverGreatsword",
        Guid    = new(674704033),
        Prefab  = "Item_Weapon_GreatSword_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_GreatSword_T08_Sanguine = new()
    {
        Name    = "SanguineGreatsword",
        Guid    = new(147836723),
        Prefab  = "Item_Weapon_GreatSword_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_GreatSword_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineGreatsword",
        Guid    = new(-1173681254),
        Prefab  = "Item_Weapon_GreatSword_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_GreatSword_Unique_T08_Variation01 = new()
    {
        Name    = "Apocalypse",
        Guid    = new(820408138),
        Prefab  = "Item_Weapon_GreatSword_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_GreatSword_T09_ShadowMatter = new()
    {
        Name    = "ShadowGreatsword",
        Guid    = new(1322254792),
        Prefab  = "Item_Weapon_GreatSword_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_GreatSword_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(-437176953),  Prefab = "Item_Weapon_GreatSword_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_GreatSword_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(-256643998),  Prefab = "Item_Weapon_GreatSword_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_GreatSword_Legendary_T06_Shattered = new() { Name = null, Guid = new(747911021),   Prefab = "Item_Weapon_GreatSword_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_GreatSword_Legendary_T08_Shattered = new() { Name = null, Guid = new(-1638796801), Prefab = "Item_Weapon_GreatSword_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_GreatSword_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-1743584975), Prefab = "Item_Weapon_GreatSword_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_GreatSword_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(1272855317),  Prefab = "Item_Weapon_GreatSword_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
 
    // ── Pistols ───────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Weapon_Pistols_T05_Iron = new()
    {
        Name    = "IronPistols",
        Guid    = new(769603740),
        Prefab  = "Item_Weapon_Pistols_T05_Iron",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Pistols_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronPistols",
        Guid    = new(1850870666),
        Prefab  = "Item_Weapon_Pistols_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Pistols_Legendary_T06 = new()
    {
        Name    = "LegendaryIronPistols",
        Guid    = new(14297698),
        Prefab  = "Item_Weapon_Pistols_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Pistols_T07_DarkSilver = new()
    {
        Name    = "DarkSilverPistols",
        Guid    = new(674407758),
        Prefab  = "Item_Weapon_Pistols_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Pistols_T08_Sanguine = new()
    {
        Name    = "SanguinePistols",
        Guid    = new(1071656850),
        Prefab  = "Item_Weapon_Pistols_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Pistols_Legendary_T08 = new()
    {
        Name    = "LegendarySanguinePistols",
        Guid    = new(-944318126),
        Prefab  = "Item_Weapon_Pistols_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Pistols_Unique_T08_Variation01 = new()
    {
        Name    = "TheEndbringers",
        Guid    = new(1759077469),
        Prefab  = "Item_Weapon_Pistols_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Pistols_T09_ShadowMatter = new()
    {
        Name    = "ShadowPistols",
        Guid    = new(-1265586439),
        Prefab  = "Item_Weapon_Pistols_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Pistols_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(1333624152),  Prefab = "Item_Weapon_Pistols_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Pistols_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(-1843989041), Prefab = "Item_Weapon_Pistols_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Pistols_Legendary_T06_Shattered = new() { Name = null, Guid = new(-1038642372), Prefab = "Item_Weapon_Pistols_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Pistols_Legendary_T08_Shattered = new() { Name = null, Guid = new(1040125618),  Prefab = "Item_Weapon_Pistols_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Pistols_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-1502177717), Prefab = "Item_Weapon_Pistols_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Pistols_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(1630030026),  Prefab = "Item_Weapon_Pistols_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
 
    // ── Twinblades ────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_T05_Iron = new()
    {
        Name    = "IronTwinblades",
        Guid    = new(-1122389049),
        Prefab  = "Item_Weapon_TwinBlades_T05_Iron",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronTwinblades",
        Guid    = new(-1651990235),
        Prefab  = "Item_Weapon_TwinBlades_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_Legendary_T06 = new()
    {
        Name    = "LegendaryIronTwinblades",
        Guid    = new(-1634108038),
        Prefab  = "Item_Weapon_TwinBlades_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_T07_DarkSilver = new()
    {
        Name    = "DarkSilverTwinblades",
        Guid    = new(-1595292245),
        Prefab  = "Item_Weapon_TwinBlades_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_T08_Sanguine = new()
    {
        Name    = "SanguineTwinblades",
        Guid    = new(-297349982),
        Prefab  = "Item_Weapon_TwinBlades_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineTwinblades",
        Guid    = new(152014105),
        Prefab  = "Item_Weapon_TwinBlades_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_Unique_T08_Variation01 = new()
    {
        Name    = "TheFateDancers",
        Guid    = new(601169005),
        Prefab  = "Item_Weapon_TwinBlades_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_T09_ShadowMatter = new()
    {
        Name    = "ShadowTwinblades",
        Guid    = new(-699863795),
        Prefab  = "Item_Weapon_TwinBlades_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_TwinBlades_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(1835208468),  Prefab = "Item_Weapon_TwinBlades_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_TwinBlades_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(2023500574),  Prefab = "Item_Weapon_TwinBlades_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_TwinBlades_Legendary_T06_Shattered = new() { Name = null, Guid = new(1579758125),  Prefab = "Item_Weapon_TwinBlades_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_TwinBlades_Legendary_T08_Shattered = new() { Name = null, Guid = new(1479621167),  Prefab = "Item_Weapon_TwinBlades_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_TwinBlades_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(-228881628),  Prefab = "Item_Weapon_TwinBlades_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_TwinBlades_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(-1397287045), Prefab = "Item_Weapon_TwinBlades_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
 
    // ── Whips ─────────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Weapon_Whip_T05_Iron = new()
    {
        Name    = "IronWhip",
        Guid    = new(-847062445),
        Prefab  = "Item_Weapon_Whip_T05_Iron",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Whip_T06_Iron_Reinforced = new()
    {
        Name    = "MercilessIronWhip",
        Guid    = new(1393113320),
        Prefab  = "Item_Weapon_Whip_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Whip_Legendary_T06 = new()
    {
        Name    = "LegendaryIronWhip",
        Guid    = new(1705984031),
        Prefab  = "Item_Weapon_Whip_Legendary_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Whip_T07_DarkSilver = new()
    {
        Name    = "DarkSilverWhip",
        Guid    = new(-960205578),
        Prefab  = "Item_Weapon_Whip_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Whip_T08_Sanguine = new()
    {
        Name    = "SanguineWhip",
        Guid    = new(-655095317),
        Prefab  = "Item_Weapon_Whip_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Whip_Legendary_T08 = new()
    {
        Name    = "LegendarySanguineWhip",
        Guid    = new(429323760),
        Prefab  = "Item_Weapon_Whip_Legendary_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Whip_Unique_T08_Variation01 = new()
    {
        Name    = "TheMorningStar",
        Guid    = new(-671246832),
        Prefab  = "Item_Weapon_Whip_Unique_T08_Variation01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Whip_T09_ShadowMatter = new()
    {
        Name    = "ShadowWhip",
        Guid    = new(567413754),
        Prefab  = "Item_Weapon_Whip_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_Whip_Legendary_NameGenerator_T06 = new() { Name = null, Guid = new(-882837429),  Prefab = "Item_Weapon_Whip_Legendary_NameGenerator_T06",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Whip_Legendary_NameGenerator_T08 = new() { Name = null, Guid = new(1838862498),  Prefab = "Item_Weapon_Whip_Legendary_NameGenerator_T08",     NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Whip_Legendary_T06_Shattered = new() { Name = null, Guid = new(-1222824286), Prefab = "Item_Weapon_Whip_Legendary_T06_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Whip_Legendary_T08_Shattered = new() { Name = null, Guid = new(1490846791),  Prefab = "Item_Weapon_Whip_Legendary_T08_Shattered",         NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Whip_Legendary_T08_Trader_Template = new() { Name = null, Guid = new(1340494453),  Prefab = "Item_Weapon_Whip_Legendary_T08_Trader_Template",   NameKey = null, DescKey = null };
    public static readonly PrefabDef Item_Weapon_Whip_Unique_T08_Variation01_Shattered = new() { Name = null, Guid = new(950358400),   Prefab = "Item_Weapon_Whip_Unique_T08_Variation01_Shattered", NameKey = null, DescKey = null };
 
    // ── Fishing Poles ─────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Weapon_FishingPole_T01 = new()
    {
        Name    = "FishingPole",
        Guid    = new(1302850112),
        Prefab  = "Item_Weapon_FishingPole_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Weapon_FishingPole_Debug = new()
    {
        Name    = null,
        Guid    = new(-1766408331),
        Prefab  = "Item_Weapon_FishingPole_Debug",
        NameKey = null,
        DescKey = null,
    };
}