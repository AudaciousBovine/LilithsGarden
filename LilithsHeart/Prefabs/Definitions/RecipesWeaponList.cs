// ============================================================
//  RecipesWeaponList — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/RecipesWeaponList.cs
//
//  [CHANGED] Migrated from bare PrefabGUID fields to PrefabDef records.
//            Field names match the prefab string exactly. No comments or
//            [PrefabName] attributes were present — Name is null throughout
//            until looked up from game data. All nullable fields shown explicitly.
//
//  [PERFORMANCE] Static readonly PrefabDef fields — initialised once at
//                class load, zero per-frame cost. Stack-allocated structs,
//                no heap pressure.
// ============================================================

using Stunlock.Core;

namespace LilithsHeart.Prefabs.Definitions;

public static class RecipesWeaponList
{
    // ── Axes ──────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Axe_T01_Bone = new()
    {
        Name    = null,
        Guid    = new(-837028877),
        Prefab  = "Recipe_Weapon_Axe_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Axe_T02_Bone_Reinforced = new()
    {
        Name    = null,
        Guid    = new(1031414138),
        Prefab  = "Recipe_Weapon_Axe_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Axe_T03_Copper = new()
    {
        Name    = null,
        Guid    = new(-1864396632),
        Prefab  = "Recipe_Weapon_Axe_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Axe_T04_Copper_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-411123427),
        Prefab  = "Recipe_Weapon_Axe_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Axe_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(305819079),
        Prefab  = "Recipe_Weapon_Axe_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Axe_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(690858507),
        Prefab  = "Recipe_Weapon_Axe_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Axe_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(-1896566066),
        Prefab  = "Recipe_Weapon_Axe_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Axe_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(-67490827),
        Prefab  = "Recipe_Weapon_Axe_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Axe_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(-998610023),
        Prefab  = "Recipe_Weapon_Axe_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Claws ─────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Claws_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(-1520452495),
        Prefab  = "Recipe_Weapon_Claws_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Claws_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-1690827442),
        Prefab  = "Recipe_Weapon_Claws_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Claws_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(1020521578),
        Prefab  = "Recipe_Weapon_Claws_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Claws_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(-749910443),
        Prefab  = "Recipe_Weapon_Claws_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    // ── Crossbows ─────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T01_Bone = new()
    {
        Name    = null,
        Guid    = new(-1384817143),
        Prefab  = "Recipe_Weapon_Crossbow_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T02_Bone_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-1421664082),
        Prefab  = "Recipe_Weapon_Crossbow_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T03_Copper = new()
    {
        Name    = null,
        Guid    = new(841082368),
        Prefab  = "Recipe_Weapon_Crossbow_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T04_Copper_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-283375796),
        Prefab  = "Recipe_Weapon_Crossbow_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(1268051742),
        Prefab  = "Recipe_Weapon_Crossbow_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(1341382268),
        Prefab  = "Recipe_Weapon_Crossbow_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(-971743976),
        Prefab  = "Recipe_Weapon_Crossbow_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(-1064000514),
        Prefab  = "Recipe_Weapon_Crossbow_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Crossbow_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(-178724798),
        Prefab  = "Recipe_Weapon_Crossbow_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Daggers ───────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Daggers_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(908837210),
        Prefab  = "Recipe_Weapon_Daggers_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Daggers_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-328931595),
        Prefab  = "Recipe_Weapon_Daggers_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Daggers_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(847424089),
        Prefab  = "Recipe_Weapon_Daggers_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Daggers_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(268825874),
        Prefab  = "Recipe_Weapon_Daggers_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    // ── Fishing Pole ──────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_FishingPole_T01 = new()
    {
        Name    = null,
        Guid    = new(319663209),
        Prefab  = "Recipe_Weapon_FishingPole_T01",
        NameKey = null,
        DescKey = null,
    };

    // ── Greatswords ───────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_GreatSword_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(1731901666),
        Prefab  = "Recipe_Weapon_GreatSword_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_GreatSword_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(648459378),
        Prefab  = "Recipe_Weapon_GreatSword_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_GreatSword_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(-2116357114),
        Prefab  = "Recipe_Weapon_GreatSword_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_GreatSword_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(1944286219),
        Prefab  = "Recipe_Weapon_GreatSword_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_GreatSword_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(-1525227854),
        Prefab  = "Recipe_Weapon_GreatSword_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Longbows ──────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Longbow_T03_Copper = new()
    {
        Name    = null,
        Guid    = new(-514405267),
        Prefab  = "Recipe_Weapon_Longbow_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Longbow_T04_Copper_Reinforced = new()
    {
        Name    = null,
        Guid    = new(777859879),
        Prefab  = "Recipe_Weapon_Longbow_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Longbow_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(-80393444),
        Prefab  = "Recipe_Weapon_Longbow_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Longbow_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-149592989),
        Prefab  = "Recipe_Weapon_Longbow_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Longbow_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(-1063439615),
        Prefab  = "Recipe_Weapon_Longbow_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Longbow_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(-603557479),
        Prefab  = "Recipe_Weapon_Longbow_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Longbow_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(1378881717),
        Prefab  = "Recipe_Weapon_Longbow_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Trader Recipes ────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_LumberjackAxe_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(2136704250),
        Prefab  = "Recipe_Weapon_LumberjackAxe_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_MinersMace_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-1476908192),
        Prefab  = "Recipe_Weapon_MinersMace_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    // ── Maces ─────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Mace_T01_Bone = new()
    {
        Name    = null,
        Guid    = new(-1064109772),
        Prefab  = "Recipe_Weapon_Mace_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Mace_T02_Bone_Reinforced = new()
    {
        Name    = null,
        Guid    = new(1377610318),
        Prefab  = "Recipe_Weapon_Mace_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Mace_T03_Copper = new()
    {
        Name    = null,
        Guid    = new(-356991727),
        Prefab  = "Recipe_Weapon_Mace_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Mace_T04_Copper_Reinforced = new()
    {
        Name    = null,
        Guid    = new(897446828),
        Prefab  = "Recipe_Weapon_Mace_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Mace_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(-612459251),
        Prefab  = "Recipe_Weapon_Mace_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Mace_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-1538728965),
        Prefab  = "Recipe_Weapon_Mace_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Mace_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(532951453),
        Prefab  = "Recipe_Weapon_Mace_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Mace_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(-1492594940),
        Prefab  = "Recipe_Weapon_Mace_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Mace_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(-240353582),
        Prefab  = "Recipe_Weapon_Mace_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Pistols ───────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Pistols_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(1314793960),
        Prefab  = "Recipe_Weapon_Pistols_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Pistols_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-1015239074),
        Prefab  = "Recipe_Weapon_Pistols_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Pistols_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(-296690999),
        Prefab  = "Recipe_Weapon_Pistols_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Pistols_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(1058461467),
        Prefab  = "Recipe_Weapon_Pistols_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Pistols_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(-299780538),
        Prefab  = "Recipe_Weapon_Pistols_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Reapers ───────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Reaper_T01_Bone = new()
    {
        Name    = null,
        Guid    = new(1678839668),
        Prefab  = "Recipe_Weapon_Reaper_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Reaper_T02_Bone_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-238493462),
        Prefab  = "Recipe_Weapon_Reaper_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Reaper_T03_Copper = new()
    {
        Name    = null,
        Guid    = new(787254471),
        Prefab  = "Recipe_Weapon_Reaper_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Reaper_T04_Copper_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-681071811),
        Prefab  = "Recipe_Weapon_Reaper_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Reaper_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(1109951557),
        Prefab  = "Recipe_Weapon_Reaper_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Reaper_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(537685806),
        Prefab  = "Recipe_Weapon_Reaper_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Reaper_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(-1112081437),
        Prefab  = "Recipe_Weapon_Reaper_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Reaper_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(-1816552963),
        Prefab  = "Recipe_Weapon_Reaper_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Reaper_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(-884753903),
        Prefab  = "Recipe_Weapon_Reaper_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Slashers ──────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Slashers_T01_Bone = new()
    {
        Name    = null,
        Guid    = new(-1536889801),
        Prefab  = "Recipe_Weapon_Slashers_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Slashers_T02_Bone_Reinforced = new()
    {
        Name    = null,
        Guid    = new(1679813913),
        Prefab  = "Recipe_Weapon_Slashers_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Slashers_T03_Copper = new()
    {
        Name    = null,
        Guid    = new(-1560601100),
        Prefab  = "Recipe_Weapon_Slashers_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Slashers_T04_Copper_Reinforced = new()
    {
        Name    = null,
        Guid    = new(396156173),
        Prefab  = "Recipe_Weapon_Slashers_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Slashers_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(-808348493),
        Prefab  = "Recipe_Weapon_Slashers_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Slashers_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(1469893872),
        Prefab  = "Recipe_Weapon_Slashers_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Slashers_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(-1919160227),
        Prefab  = "Recipe_Weapon_Slashers_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Slashers_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(373339628),
        Prefab  = "Recipe_Weapon_Slashers_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Slashers_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(501702204),
        Prefab  = "Recipe_Weapon_Slashers_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Spears ────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Spear_T01_Bone = new()
    {
        Name    = null,
        Guid    = new(1394854694),
        Prefab  = "Recipe_Weapon_Spear_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Spear_T02_Bone_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-1328539101),
        Prefab  = "Recipe_Weapon_Spear_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Spear_T03_Copper = new()
    {
        Name    = null,
        Guid    = new(-791471134),
        Prefab  = "Recipe_Weapon_Spear_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Spear_T04_Copper_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-118222260),
        Prefab  = "Recipe_Weapon_Spear_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Spear_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(239811022),
        Prefab  = "Recipe_Weapon_Spear_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Spear_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-499925914),
        Prefab  = "Recipe_Weapon_Spear_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Spear_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(-194303255),
        Prefab  = "Recipe_Weapon_Spear_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Spear_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(-314047482),
        Prefab  = "Recipe_Weapon_Spear_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Spear_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(-190896313),
        Prefab  = "Recipe_Weapon_Spear_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Swords ────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Sword_T01_Bone = new()
    {
        Name    = null,
        Guid    = new(-2125590443),
        Prefab  = "Recipe_Weapon_Sword_T01_Bone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Sword_T02_Bone_Reinforced = new()
    {
        Name    = null,
        Guid    = new(1742703328),
        Prefab  = "Recipe_Weapon_Sword_T02_Bone_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Sword_T03_Copper = new()
    {
        Name    = null,
        Guid    = new(-267802321),
        Prefab  = "Recipe_Weapon_Sword_T03_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Sword_T04_Copper_Reinforced = new()
    {
        Name    = null,
        Guid    = new(774557022),
        Prefab  = "Recipe_Weapon_Sword_T04_Copper_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Sword_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(-2098625697),
        Prefab  = "Recipe_Weapon_Sword_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Sword_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(-1052674868),
        Prefab  = "Recipe_Weapon_Sword_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Sword_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(374085302),
        Prefab  = "Recipe_Weapon_Sword_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Sword_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(895742048),
        Prefab  = "Recipe_Weapon_Sword_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Sword_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(1363919271),
        Prefab  = "Recipe_Weapon_Sword_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };

    // ── Twinblades ────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_TwinBlades_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(-496801516),
        Prefab  = "Recipe_Weapon_TwinBlades_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_TwinBlades_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(1687058710),
        Prefab  = "Recipe_Weapon_TwinBlades_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_TwinBlades_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(895579931),
        Prefab  = "Recipe_Weapon_TwinBlades_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_TwinBlades_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(1259720344),
        Prefab  = "Recipe_Weapon_TwinBlades_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    // ── Whips ─────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Weapon_Whip_T05_Iron = new()
    {
        Name    = null,
        Guid    = new(688528978),
        Prefab  = "Recipe_Weapon_Whip_T05_Iron",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Whip_T06_Iron_Reinforced = new()
    {
        Name    = null,
        Guid    = new(465080212),
        Prefab  = "Recipe_Weapon_Whip_T06_Iron_Reinforced",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Whip_T07_DarkSilver = new()
    {
        Name    = null,
        Guid    = new(1507781061),
        Prefab  = "Recipe_Weapon_Whip_T07_DarkSilver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Whip_T08_Sanguine = new()
    {
        Name    = null,
        Guid    = new(-1968497565),
        Prefab  = "Recipe_Weapon_Whip_T08_Sanguine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Weapon_Whip_T09_ShadowMatter = new()
    {
        Name    = null,
        Guid    = new(-941901707),
        Prefab  = "Recipe_Weapon_Whip_T09_ShadowMatter",
        NameKey = null,
        DescKey = null,
    };
}