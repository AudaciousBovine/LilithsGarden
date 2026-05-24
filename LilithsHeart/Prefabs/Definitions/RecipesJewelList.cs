// ============================================================
//  RecipesJewelList — Part 1 of 2 — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/RecipesJewelList.cs
//
//  [CHANGED] Migrated from bare PrefabGUID fields to PrefabDef records.
//            Field names match the prefab string exactly. No comments or
//            [PrefabName] attributes were present — Name is null throughout
//            until looked up from game data. All nullable fields shown explicitly.
//
//  Parts: 1 — Blood, Chaos, Frost jewel recipes
//         2 — Illusion, Storm, Unholy jewel recipes
//
//  [PERFORMANCE] Static readonly PrefabDef fields — initialised once at
//                class load, zero per-frame cost. Stack-allocated structs,
//                no heap pressure.
// ============================================================

using Stunlock.Core;

namespace LilithsHeart.Prefabs.Definitions;

public static partial class RecipesJewelList
{
    // ── Blood ─────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Jewel_Blood_T01 = new()
    {
        Name    = null,
        Guid    = new(-445494585),
        Prefab  = "Recipe_Jewel_Blood_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02 = new()
    {
        Name    = null,
        Guid    = new(279714151),
        Prefab  = "Recipe_Jewel_Blood_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02_BloodFountain = new()
    {
        Name    = null,
        Guid    = new(1790399614),
        Prefab  = "Recipe_Jewel_Blood_T02_BloodFountain",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02_BloodRage = new()
    {
        Name    = null,
        Guid    = new(-1730685483),
        Prefab  = "Recipe_Jewel_Blood_T02_BloodRage",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02_BloodRite = new()
    {
        Name    = null,
        Guid    = new(-1673417294),
        Prefab  = "Recipe_Jewel_Blood_T02_BloodRite",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02_CarrionSwarm = new()
    {
        Name    = null,
        Guid    = new(1327091316),
        Prefab  = "Recipe_Jewel_Blood_T02_CarrionSwarm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02_SanguineCoil = new()
    {
        Name    = null,
        Guid    = new(805999157),
        Prefab  = "Recipe_Jewel_Blood_T02_SanguineCoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02_Shadowbolt = new()
    {
        Name    = null,
        Guid    = new(2140352508),
        Prefab  = "Recipe_Jewel_Blood_T02_Shadowbolt",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02_VampiricCurse = new()
    {
        Name    = null,
        Guid    = new(-1221458026),
        Prefab  = "Recipe_Jewel_Blood_T02_VampiricCurse",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T02_VeilOfBlood = new()
    {
        Name    = null,
        Guid    = new(-471735309),
        Prefab  = "Recipe_Jewel_Blood_T02_VeilOfBlood",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03 = new()
    {
        Name    = null,
        Guid    = new(1484442015),
        Prefab  = "Recipe_Jewel_Blood_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03_BloodFountain = new()
    {
        Name    = null,
        Guid    = new(1536138304),
        Prefab  = "Recipe_Jewel_Blood_T03_BloodFountain",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03_BloodRage = new()
    {
        Name    = null,
        Guid    = new(-117709259),
        Prefab  = "Recipe_Jewel_Blood_T03_BloodRage",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03_BloodRite = new()
    {
        Name    = null,
        Guid    = new(1332879261),
        Prefab  = "Recipe_Jewel_Blood_T03_BloodRite",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03_CarrionSwarm = new()
    {
        Name    = null,
        Guid    = new(265064568),
        Prefab  = "Recipe_Jewel_Blood_T03_CarrionSwarm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03_SanguineCoil = new()
    {
        Name    = null,
        Guid    = new(-998540356),
        Prefab  = "Recipe_Jewel_Blood_T03_SanguineCoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03_Shadowbolt = new()
    {
        Name    = null,
        Guid    = new(-132912845),
        Prefab  = "Recipe_Jewel_Blood_T03_Shadowbolt",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03_VampiricCurse = new()
    {
        Name    = null,
        Guid    = new(641872418),
        Prefab  = "Recipe_Jewel_Blood_T03_VampiricCurse",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T03_VeilOfBlood = new()
    {
        Name    = null,
        Guid    = new(-1280075933),
        Prefab  = "Recipe_Jewel_Blood_T03_VeilOfBlood",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04 = new()
    {
        Name    = null,
        Guid    = new(-1589272885),
        Prefab  = "Recipe_Jewel_Blood_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04_BloodFountain = new()
    {
        Name    = null,
        Guid    = new(-1647468496),
        Prefab  = "Recipe_Jewel_Blood_T04_BloodFountain",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04_BloodRage = new()
    {
        Name    = null,
        Guid    = new(1616468375),
        Prefab  = "Recipe_Jewel_Blood_T04_BloodRage",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04_BloodRite = new()
    {
        Name    = null,
        Guid    = new(1349479077),
        Prefab  = "Recipe_Jewel_Blood_T04_BloodRite",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04_CarrionSwarm = new()
    {
        Name    = null,
        Guid    = new(1394410783),
        Prefab  = "Recipe_Jewel_Blood_T04_CarrionSwarm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04_SanguineCoil = new()
    {
        Name    = null,
        Guid    = new(-1824834918),
        Prefab  = "Recipe_Jewel_Blood_T04_SanguineCoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04_Shadowbolt = new()
    {
        Name    = null,
        Guid    = new(-1124531408),
        Prefab  = "Recipe_Jewel_Blood_T04_Shadowbolt",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04_VampiricCurse = new()
    {
        Name    = null,
        Guid    = new(1500294983),
        Prefab  = "Recipe_Jewel_Blood_T04_VampiricCurse",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Blood_T04_VeilOfBlood = new()
    {
        Name    = null,
        Guid    = new(-389291045),
        Prefab  = "Recipe_Jewel_Blood_T04_VeilOfBlood",
        NameKey = null,
        DescKey = null,
    };

    // ── Chaos ─────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Jewel_Chaos_T01 = new()
    {
        Name    = null,
        Guid    = new(-945572632),
        Prefab  = "Recipe_Jewel_Chaos_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T02 = new()
    {
        Name    = null,
        Guid    = new(-845714536),
        Prefab  = "Recipe_Jewel_Chaos_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T02_Aftershock = new()
    {
        Name    = null,
        Guid    = new(-2125962345),
        Prefab  = "Recipe_Jewel_Chaos_T02_Aftershock",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T02_ChaosBarrier = new()
    {
        Name    = null,
        Guid    = new(-1441194655),
        Prefab  = "Recipe_Jewel_Chaos_T02_ChaosBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T02_ChaosVolley = new()
    {
        Name    = null,
        Guid    = new(2130221261),
        Prefab  = "Recipe_Jewel_Chaos_T02_ChaosVolley",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T02_PowerSurge = new()
    {
        Name    = null,
        Guid    = new(-421166152),
        Prefab  = "Recipe_Jewel_Chaos_T02_PowerSurge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T02_RainOfChaos = new()
    {
        Name    = null,
        Guid    = new(-354986500),
        Prefab  = "Recipe_Jewel_Chaos_T02_RainOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T02_VeilOfChaos = new()
    {
        Name    = null,
        Guid    = new(-712982171),
        Prefab  = "Recipe_Jewel_Chaos_T02_VeilOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T02_Void = new()
    {
        Name    = null,
        Guid    = new(1804676837),
        Prefab  = "Recipe_Jewel_Chaos_T02_Void",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T03 = new()
    {
        Name    = null,
        Guid    = new(-455612969),
        Prefab  = "Recipe_Jewel_Chaos_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T03_Aftershock = new()
    {
        Name    = null,
        Guid    = new(19321091),
        Prefab  = "Recipe_Jewel_Chaos_T03_Aftershock",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T03_ChaosBarrier = new()
    {
        Name    = null,
        Guid    = new(-1390850741),
        Prefab  = "Recipe_Jewel_Chaos_T03_ChaosBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T03_ChaosVolley = new()
    {
        Name    = null,
        Guid    = new(1013687480),
        Prefab  = "Recipe_Jewel_Chaos_T03_ChaosVolley",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T03_PowerSurge = new()
    {
        Name    = null,
        Guid    = new(-621123461),
        Prefab  = "Recipe_Jewel_Chaos_T03_PowerSurge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T03_RainOfChaos = new()
    {
        Name    = null,
        Guid    = new(-620902396),
        Prefab  = "Recipe_Jewel_Chaos_T03_RainOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T03_VeilOfChaos = new()
    {
        Name    = null,
        Guid    = new(-871123559),
        Prefab  = "Recipe_Jewel_Chaos_T03_VeilOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T03_Void = new()
    {
        Name    = null,
        Guid    = new(-1993706550),
        Prefab  = "Recipe_Jewel_Chaos_T03_Void",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T04 = new()
    {
        Name    = null,
        Guid    = new(2092747590),
        Prefab  = "Recipe_Jewel_Chaos_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T04_Aftershock = new()
    {
        Name    = null,
        Guid    = new(-1432868001),
        Prefab  = "Recipe_Jewel_Chaos_T04_Aftershock",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T04_ChaosBarrier = new()
    {
        Name    = null,
        Guid    = new(249492436),
        Prefab  = "Recipe_Jewel_Chaos_T04_ChaosBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T04_ChaosVolley = new()
    {
        Name    = null,
        Guid    = new(-1862071851),
        Prefab  = "Recipe_Jewel_Chaos_T04_ChaosVolley",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T04_PowerSurge = new()
    {
        Name    = null,
        Guid    = new(-1231616717),
        Prefab  = "Recipe_Jewel_Chaos_T04_PowerSurge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T04_RainOfChaos = new()
    {
        Name    = null,
        Guid    = new(-255313331),
        Prefab  = "Recipe_Jewel_Chaos_T04_RainOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T04_VeilOfChaos = new()
    {
        Name    = null,
        Guid    = new(-273088264),
        Prefab  = "Recipe_Jewel_Chaos_T04_VeilOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Chaos_T04_Void = new()
    {
        Name    = null,
        Guid    = new(1628679944),
        Prefab  = "Recipe_Jewel_Chaos_T04_Void",
        NameKey = null,
        DescKey = null,
    };

    // ── Frost ─────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Jewel_Frost_T01 = new()
    {
        Name    = null,
        Guid    = new(-184777350),
        Prefab  = "Recipe_Jewel_Frost_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T02 = new()
    {
        Name    = null,
        Guid    = new(-1982816801),
        Prefab  = "Recipe_Jewel_Frost_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T02_ColdSnap = new()
    {
        Name    = null,
        Guid    = new(-1921009561),
        Prefab  = "Recipe_Jewel_Frost_T02_ColdSnap",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T02_CrystalLance = new()
    {
        Name    = null,
        Guid    = new(-295731844),
        Prefab  = "Recipe_Jewel_Frost_T02_CrystalLance",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T02_FrostBarrier = new()
    {
        Name    = null,
        Guid    = new(-722322275),
        Prefab  = "Recipe_Jewel_Frost_T02_FrostBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T02_FrostBat = new()
    {
        Name    = null,
        Guid    = new(-739674375),
        Prefab  = "Recipe_Jewel_Frost_T02_FrostBat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T02_FrostCone = new()
    {
        Name    = null,
        Guid    = new(-1885123423),
        Prefab  = "Recipe_Jewel_Frost_T02_FrostCone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T02_IceNova = new()
    {
        Name    = null,
        Guid    = new(-1743625798),
        Prefab  = "Recipe_Jewel_Frost_T02_IceNova",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T02_VeilOfFrost = new()
    {
        Name    = null,
        Guid    = new(955124009),
        Prefab  = "Recipe_Jewel_Frost_T02_VeilOfFrost",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T03 = new()
    {
        Name    = null,
        Guid    = new(106264515),
        Prefab  = "Recipe_Jewel_Frost_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T03_ColdSnap = new()
    {
        Name    = null,
        Guid    = new(-1863610651),
        Prefab  = "Recipe_Jewel_Frost_T03_ColdSnap",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T03_CrystalLance = new()
    {
        Name    = null,
        Guid    = new(-1334648733),
        Prefab  = "Recipe_Jewel_Frost_T03_CrystalLance",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T03_FrostBarrier = new()
    {
        Name    = null,
        Guid    = new(513866428),
        Prefab  = "Recipe_Jewel_Frost_T03_FrostBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T03_FrostBat = new()
    {
        Name    = null,
        Guid    = new(1589453917),
        Prefab  = "Recipe_Jewel_Frost_T03_FrostBat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T03_FrostCone = new()
    {
        Name    = null,
        Guid    = new(-1217040138),
        Prefab  = "Recipe_Jewel_Frost_T03_FrostCone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T03_IceNova = new()
    {
        Name    = null,
        Guid    = new(995009212),
        Prefab  = "Recipe_Jewel_Frost_T03_IceNova",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T03_VeilOfFrost = new()
    {
        Name    = null,
        Guid    = new(-245144906),
        Prefab  = "Recipe_Jewel_Frost_T03_VeilOfFrost",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T04 = new()
    {
        Name    = null,
        Guid    = new(1220982133),
        Prefab  = "Recipe_Jewel_Frost_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T04_ColdSnap = new()
    {
        Name    = null,
        Guid    = new(1548333309),
        Prefab  = "Recipe_Jewel_Frost_T04_ColdSnap",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T04_CrystalLance = new()
    {
        Name    = null,
        Guid    = new(-366508312),
        Prefab  = "Recipe_Jewel_Frost_T04_CrystalLance",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T04_FrostBarrier = new()
    {
        Name    = null,
        Guid    = new(-1916181867),
        Prefab  = "Recipe_Jewel_Frost_T04_FrostBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T04_FrostBat = new()
    {
        Name    = null,
        Guid    = new(1669439853),
        Prefab  = "Recipe_Jewel_Frost_T04_FrostBat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T04_FrostCone = new()
    {
        Name    = null,
        Guid    = new(-586089909),
        Prefab  = "Recipe_Jewel_Frost_T04_FrostCone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T04_IceNova = new()
    {
        Name    = null,
        Guid    = new(2058110132),
        Prefab  = "Recipe_Jewel_Frost_T04_IceNova",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Jewel_Frost_T04_VeilOfFrost = new()
    {
        Name    = null,
        Guid    = new(-1413146031),
        Prefab  = "Recipe_Jewel_Frost_T04_VeilOfFrost",
        NameKey = null,
        DescKey = null,
    };
    public static readonly PrefabDef Recipe_Jewel_Illusion_T01 = new()
    {
        Name    = null,
        Guid    = new(1885790026),
        Prefab  = "Recipe_Jewel_Illusion_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T02 = new()
    {
        Name    = null,
        Guid    = new(-443627358),
        Prefab  = "Recipe_Jewel_Illusion_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T02_Curse = new()
    {
        Name    = null,
        Guid    = new(-1928857475),
        Prefab  = "Recipe_Jewel_Illusion_T02_Curse",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T02_MistTrance = new()
    {
        Name    = null,
        Guid    = new(-1972338710),
        Prefab  = "Recipe_Jewel_Illusion_T02_MistTrance",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T02_Mosquito = new()
    {
        Name    = null,
        Guid    = new(251557275),
        Prefab  = "Recipe_Jewel_Illusion_T02_Mosquito",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T02_PhantomAegis = new()
    {
        Name    = null,
        Guid    = new(1588865021),
        Prefab  = "Recipe_Jewel_Illusion_T02_PhantomAegis",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T02_SpectralWolf = new()
    {
        Name    = null,
        Guid    = new(-1099144954),
        Prefab  = "Recipe_Jewel_Illusion_T02_SpectralWolf",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T02_VeilOfIllusion = new()
    {
        Name    = null,
        Guid    = new(-899623094),
        Prefab  = "Recipe_Jewel_Illusion_T02_VeilOfIllusion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T02_WraithSpear = new()
    {
        Name    = null,
        Guid    = new(1130803007),
        Prefab  = "Recipe_Jewel_Illusion_T02_WraithSpear",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T03 = new()
    {
        Name    = null,
        Guid    = new(-1638077703),
        Prefab  = "Recipe_Jewel_Illusion_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T03_Curse = new()
    {
        Name    = null,
        Guid    = new(1646432213),
        Prefab  = "Recipe_Jewel_Illusion_T03_Curse",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T03_MistTrance = new()
    {
        Name    = null,
        Guid    = new(593821386),
        Prefab  = "Recipe_Jewel_Illusion_T03_MistTrance",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T03_Mosquito = new()
    {
        Name    = null,
        Guid    = new(1949752494),
        Prefab  = "Recipe_Jewel_Illusion_T03_Mosquito",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T03_PhantomAegis = new()
    {
        Name    = null,
        Guid    = new(-244123374),
        Prefab  = "Recipe_Jewel_Illusion_T03_PhantomAegis",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T03_SpectralWolf = new()
    {
        Name    = null,
        Guid    = new(1192126839),
        Prefab  = "Recipe_Jewel_Illusion_T03_SpectralWolf",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T03_VeilOfIllusion = new()
    {
        Name    = null,
        Guid    = new(832118211),
        Prefab  = "Recipe_Jewel_Illusion_T03_VeilOfIllusion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T03_WraithSpear = new()
    {
        Name    = null,
        Guid    = new(-970138509),
        Prefab  = "Recipe_Jewel_Illusion_T03_WraithSpear",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T04 = new()
    {
        Name    = null,
        Guid    = new(86391798),
        Prefab  = "Recipe_Jewel_Illusion_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T04_Curse = new()
    {
        Name    = null,
        Guid    = new(-1255084741),
        Prefab  = "Recipe_Jewel_Illusion_T04_Curse",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T04_MistTrance = new()
    {
        Name    = null,
        Guid    = new(113014730),
        Prefab  = "Recipe_Jewel_Illusion_T04_MistTrance",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T04_Mosquito = new()
    {
        Name    = null,
        Guid    = new(817310228),
        Prefab  = "Recipe_Jewel_Illusion_T04_Mosquito",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T04_PhantomAegis = new()
    {
        Name    = null,
        Guid    = new(-32531606),
        Prefab  = "Recipe_Jewel_Illusion_T04_PhantomAegis",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T04_SpectralWolf = new()
    {
        Name    = null,
        Guid    = new(253232005),
        Prefab  = "Recipe_Jewel_Illusion_T04_SpectralWolf",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T04_VeilOfIllusion = new()
    {
        Name    = null,
        Guid    = new(941258392),
        Prefab  = "Recipe_Jewel_Illusion_T04_VeilOfIllusion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Illusion_T04_WraithSpear = new()
    {
        Name    = null,
        Guid    = new(1099730006),
        Prefab  = "Recipe_Jewel_Illusion_T04_WraithSpear",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Storm ─────────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T01 = new()
    {
        Name    = null,
        Guid    = new(81501826),
        Prefab  = "Recipe_Jewel_Storm_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T02 = new()
    {
        Name    = null,
        Guid    = new(687440022),
        Prefab  = "Recipe_Jewel_Storm_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T02_BallLightning = new()
    {
        Name    = null,
        Guid    = new(-269714118),
        Prefab  = "Recipe_Jewel_Storm_T02_BallLightning",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T02_Cyclone = new()
    {
        Name    = null,
        Guid    = new(-1385380788),
        Prefab  = "Recipe_Jewel_Storm_T02_Cyclone",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T02_Discharge = new()
    {
        Name    = null,
        Guid    = new(-1829203567),
        Prefab  = "Recipe_Jewel_Storm_T02_Discharge",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T02_LightningTendrils = new()
    {
        Name    = null,
        Guid    = new(1839373951),
        Prefab  = "Recipe_Jewel_Storm_T02_LightningTendrils",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T02_LightningWall = new()
    {
        Name    = null,
        Guid    = new(793838493),
        Prefab  = "Recipe_Jewel_Storm_T02_LightningWall",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T02_PolarityShift = new()
    {
        Name    = null,
        Guid    = new(-1843641524),
        Prefab  = "Recipe_Jewel_Storm_T02_PolarityShift",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T02_VeilOfStorm = new()
    {
        Name    = null,
        Guid    = new(-2021884201),
        Prefab  = "Recipe_Jewel_Storm_T02_VeilOfStorm",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T03 = new()
    {
        Name    = null,
        Guid    = new(-1901900501),
        Prefab  = "Recipe_Jewel_Storm_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T03_BallLightning = new()
    {
        Name    = null,
        Guid    = new(595324174),
        Prefab  = "Recipe_Jewel_Storm_T03_BallLightning",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T03_Cyclone = new()
    {
        Name    = null,
        Guid    = new(-57395936),
        Prefab  = "Recipe_Jewel_Storm_T03_Cyclone",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T03_Discharge = new()
    {
        Name    = null,
        Guid    = new(20833766),
        Prefab  = "Recipe_Jewel_Storm_T03_Discharge",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T03_LightningTendrils = new()
    {
        Name    = null,
        Guid    = new(1717016346),
        Prefab  = "Recipe_Jewel_Storm_T03_LightningTendrils",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T03_LightningWall = new()
    {
        Name    = null,
        Guid    = new(-12176904),
        Prefab  = "Recipe_Jewel_Storm_T03_LightningWall",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T03_PolarityShift = new()
    {
        Name    = null,
        Guid    = new(-697842923),
        Prefab  = "Recipe_Jewel_Storm_T03_PolarityShift",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T03_VeilOfStorm = new()
    {
        Name    = null,
        Guid    = new(-1164864103),
        Prefab  = "Recipe_Jewel_Storm_T03_VeilOfStorm",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T04 = new()
    {
        Name    = null,
        Guid    = new(310567762),
        Prefab  = "Recipe_Jewel_Storm_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T04_BallLightning = new()
    {
        Name    = null,
        Guid    = new(891968939),
        Prefab  = "Recipe_Jewel_Storm_T04_BallLightning",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T04_Cyclone = new()
    {
        Name    = null,
        Guid    = new(-794779743),
        Prefab  = "Recipe_Jewel_Storm_T04_Cyclone",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T04_Discharge = new()
    {
        Name    = null,
        Guid    = new(1385565480),
        Prefab  = "Recipe_Jewel_Storm_T04_Discharge",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T04_LightningTendrils = new()
    {
        Name    = null,
        Guid    = new(-38691585),
        Prefab  = "Recipe_Jewel_Storm_T04_LightningTendrils",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T04_LightningWall = new()
    {
        Name    = null,
        Guid    = new(199150725),
        Prefab  = "Recipe_Jewel_Storm_T04_LightningWall",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T04_PolarityShift = new()
    {
        Name    = null,
        Guid    = new(-636221299),
        Prefab  = "Recipe_Jewel_Storm_T04_PolarityShift",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Storm_T04_VeilOfStorm = new()
    {
        Name    = null,
        Guid    = new(185593335),
        Prefab  = "Recipe_Jewel_Storm_T04_VeilOfStorm",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Unholy ────────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T01 = new()
    {
        Name    = null,
        Guid    = new(-1841149251),
        Prefab  = "Recipe_Jewel_Unholy_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T02 = new()
    {
        Name    = null,
        Guid    = new(1628896277),
        Prefab  = "Recipe_Jewel_Unholy_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T02_ChainsOfDeath = new()
    {
        Name    = null,
        Guid    = new(1098089916),
        Prefab  = "Recipe_Jewel_Unholy_T02_ChainsOfDeath",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T02_CorpseExplosion = new()
    {
        Name    = null,
        Guid    = new(-548400473),
        Prefab  = "Recipe_Jewel_Unholy_T02_CorpseExplosion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T02_CorruptedSkull = new()
    {
        Name    = null,
        Guid    = new(986923658),
        Prefab  = "Recipe_Jewel_Unholy_T02_CorruptedSkull",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T02_DeathKnight = new()
    {
        Name    = null,
        Guid    = new(-338535841),
        Prefab  = "Recipe_Jewel_Unholy_T02_DeathKnight",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T02_Soulburn = new()
    {
        Name    = null,
        Guid    = new(1259976804),
        Prefab  = "Recipe_Jewel_Unholy_T02_Soulburn",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T02_VeilOfBones = new()
    {
        Name    = null,
        Guid    = new(-20844245),
        Prefab  = "Recipe_Jewel_Unholy_T02_VeilOfBones",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T02_WardOfTheDamned = new()
    {
        Name    = null,
        Guid    = new(812735179),
        Prefab  = "Recipe_Jewel_Unholy_T02_WardOfTheDamned",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T03 = new()
    {
        Name    = null,
        Guid    = new(-1441428013),
        Prefab  = "Recipe_Jewel_Unholy_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T03_ChainsOfDeath = new()
    {
        Name    = null,
        Guid    = new(912357966),
        Prefab  = "Recipe_Jewel_Unholy_T03_ChainsOfDeath",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T03_CorpseExplosion = new()
    {
        Name    = null,
        Guid    = new(-476269715),
        Prefab  = "Recipe_Jewel_Unholy_T03_CorpseExplosion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T03_CorruptedSkull = new()
    {
        Name    = null,
        Guid    = new(625989230),
        Prefab  = "Recipe_Jewel_Unholy_T03_CorruptedSkull",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T03_DeathKnight = new()
    {
        Name    = null,
        Guid    = new(-145359715),
        Prefab  = "Recipe_Jewel_Unholy_T03_DeathKnight",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T03_Soulburn = new()
    {
        Name    = null,
        Guid    = new(-1836185186),
        Prefab  = "Recipe_Jewel_Unholy_T03_Soulburn",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T03_VeilOfBones = new()
    {
        Name    = null,
        Guid    = new(-1660160596),
        Prefab  = "Recipe_Jewel_Unholy_T03_VeilOfBones",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T03_WardOfTheDamned = new()
    {
        Name    = null,
        Guid    = new(405933740),
        Prefab  = "Recipe_Jewel_Unholy_T03_WardOfTheDamned",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T04 = new()
    {
        Name    = null,
        Guid    = new(-459320498),
        Prefab  = "Recipe_Jewel_Unholy_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T04_ChainsOfDeath = new()
    {
        Name    = null,
        Guid    = new(495345726),
        Prefab  = "Recipe_Jewel_Unholy_T04_ChainsOfDeath",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T04_CorpseExplosion = new()
    {
        Name    = null,
        Guid    = new(-263798740),
        Prefab  = "Recipe_Jewel_Unholy_T04_CorpseExplosion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T04_CorruptedSkull = new()
    {
        Name    = null,
        Guid    = new(-299276760),
        Prefab  = "Recipe_Jewel_Unholy_T04_CorruptedSkull",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T04_DeathKnight = new()
    {
        Name    = null,
        Guid    = new(-624069541),
        Prefab  = "Recipe_Jewel_Unholy_T04_DeathKnight",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T04_Soulburn = new()
    {
        Name    = null,
        Guid    = new(-530631333),
        Prefab  = "Recipe_Jewel_Unholy_T04_Soulburn",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T04_VeilOfBones = new()
    {
        Name    = null,
        Guid    = new(-1669971047),
        Prefab  = "Recipe_Jewel_Unholy_T04_VeilOfBones",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Recipe_Jewel_Unholy_T04_WardOfTheDamned = new()
    {
        Name    = null,
        Guid    = new(-1026108429),
        Prefab  = "Recipe_Jewel_Unholy_T04_WardOfTheDamned",
        NameKey = null,
        DescKey = null,
    };
}