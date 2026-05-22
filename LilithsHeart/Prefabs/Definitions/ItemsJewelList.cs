// ============================================================
//  ItemsJewelList — Part 1 of 2 — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/ItemsJewelList.cs
//
//  [CHANGED] Migrated from bare PrefabGUID fields to PrefabDef records.
//            Field names match the prefab string exactly. No comments or
//            [PrefabName] attributes were present — Name is null throughout
//            until looked up from game data. All nullable fields shown explicitly.
//
//  Parts: 1 — Blood, Chaos, Frost jewels
//         2 — Illusion, Storm, Unholy jewels + Template
//
//  [PERFORMANCE] Static readonly PrefabDef fields — initialised once at
//                class load, zero per-frame cost. Stack-allocated structs,
//                no heap pressure.
// ============================================================

using Stunlock.Core;

namespace LilithsHeart.Prefabs.Definitions;

public static partial class ItemsJewelList
{
    // ── Blood Jewels ──────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Jewel_Blood_T01 = new()
    {
        Name    = null,
        Guid    = new(-113436752),
        Prefab  = "Item_Jewel_Blood_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02 = new()
    {
        Name    = null,
        Guid    = new(-996555621),
        Prefab  = "Item_Jewel_Blood_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02_BloodFountain = new()
    {
        Name    = null,
        Guid    = new(-1624411159),
        Prefab  = "Item_Jewel_Blood_T02_BloodFountain",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02_BloodRage = new()
    {
        Name    = null,
        Guid    = new(343217159),
        Prefab  = "Item_Jewel_Blood_T02_BloodRage",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02_BloodRite = new()
    {
        Name    = null,
        Guid    = new(-2059886133),
        Prefab  = "Item_Jewel_Blood_T02_BloodRite",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02_CarrionSwarm = new()
    {
        Name    = null,
        Guid    = new(-585346267),
        Prefab  = "Item_Jewel_Blood_T02_CarrionSwarm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02_SanguineCoil = new()
    {
        Name    = null,
        Guid    = new(75934448),
        Prefab  = "Item_Jewel_Blood_T02_SanguineCoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02_Shadowbolt = new()
    {
        Name    = null,
        Guid    = new(918613164),
        Prefab  = "Item_Jewel_Blood_T02_Shadowbolt",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02_VampiricCurse = new()
    {
        Name    = null,
        Guid    = new(-1337809256),
        Prefab  = "Item_Jewel_Blood_T02_VampiricCurse",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T02_VeilOfBlood = new()
    {
        Name    = null,
        Guid    = new(-431964258),
        Prefab  = "Item_Jewel_Blood_T02_VeilOfBlood",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03 = new()
    {
        Name    = null,
        Guid    = new(-41686151),
        Prefab  = "Item_Jewel_Blood_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03_BloodFountain = new()
    {
        Name    = null,
        Guid    = new(-312598876),
        Prefab  = "Item_Jewel_Blood_T03_BloodFountain",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03_BloodRage = new()
    {
        Name    = null,
        Guid    = new(-1952560879),
        Prefab  = "Item_Jewel_Blood_T03_BloodRage",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03_BloodRite = new()
    {
        Name    = null,
        Guid    = new(1881059081),
        Prefab  = "Item_Jewel_Blood_T03_BloodRite",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03_CarrionSwarm = new()
    {
        Name    = null,
        Guid    = new(519281449),
        Prefab  = "Item_Jewel_Blood_T03_CarrionSwarm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03_SanguineCoil = new()
    {
        Name    = null,
        Guid    = new(1785926321),
        Prefab  = "Item_Jewel_Blood_T03_SanguineCoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03_Shadowbolt = new()
    {
        Name    = null,
        Guid    = new(738473666),
        Prefab  = "Item_Jewel_Blood_T03_Shadowbolt",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03_VampiricCurse = new()
    {
        Name    = null,
        Guid    = new(-2137054310),
        Prefab  = "Item_Jewel_Blood_T03_VampiricCurse",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T03_VeilOfBlood = new()
    {
        Name    = null,
        Guid    = new(-1302801575),
        Prefab  = "Item_Jewel_Blood_T03_VeilOfBlood",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04 = new()
    {
        Name    = null,
        Guid    = new(271061481),
        Prefab  = "Item_Jewel_Blood_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04_BloodFountain = new()
    {
        Name    = null,
        Guid    = new(1755478077),
        Prefab  = "Item_Jewel_Blood_T04_BloodFountain",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04_BloodRage = new()
    {
        Name    = null,
        Guid    = new(662891042),
        Prefab  = "Item_Jewel_Blood_T04_BloodRage",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04_BloodRite = new()
    {
        Name    = null,
        Guid    = new(1799289635),
        Prefab  = "Item_Jewel_Blood_T04_BloodRite",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04_CarrionSwarm = new()
    {
        Name    = null,
        Guid    = new(1499979825),
        Prefab  = "Item_Jewel_Blood_T04_CarrionSwarm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04_SanguineCoil = new()
    {
        Name    = null,
        Guid    = new(-562511117),
        Prefab  = "Item_Jewel_Blood_T04_SanguineCoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04_Shadowbolt = new()
    {
        Name    = null,
        Guid    = new(1279283644),
        Prefab  = "Item_Jewel_Blood_T04_Shadowbolt",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04_VampiricCurse = new()
    {
        Name    = null,
        Guid    = new(-1844141622),
        Prefab  = "Item_Jewel_Blood_T04_VampiricCurse",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Blood_T04_VeilOfBlood = new()
    {
        Name    = null,
        Guid    = new(1692133021),
        Prefab  = "Item_Jewel_Blood_T04_VeilOfBlood",
        NameKey = null,
        DescKey = null,
    };

    // ── Chaos Jewels ──────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Jewel_Chaos_T01 = new()
    {
        Name    = null,
        Guid    = new(2130810069),
        Prefab  = "Item_Jewel_Chaos_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T02 = new()
    {
        Name    = null,
        Guid    = new(1083105737),
        Prefab  = "Item_Jewel_Chaos_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T02_Aftershock = new()
    {
        Name    = null,
        Guid    = new(1035334240),
        Prefab  = "Item_Jewel_Chaos_T02_Aftershock",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T02_ChaosBarrier = new()
    {
        Name    = null,
        Guid    = new(1112619884),
        Prefab  = "Item_Jewel_Chaos_T02_ChaosBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T02_ChaosVolley = new()
    {
        Name    = null,
        Guid    = new(1243967840),
        Prefab  = "Item_Jewel_Chaos_T02_ChaosVolley",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T02_PowerSurge = new()
    {
        Name    = null,
        Guid    = new(1168555540),
        Prefab  = "Item_Jewel_Chaos_T02_PowerSurge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T02_RainOfChaos = new()
    {
        Name    = null,
        Guid    = new(-1674555897),
        Prefab  = "Item_Jewel_Chaos_T02_RainOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T02_VeilOfChaos = new()
    {
        Name    = null,
        Guid    = new(-2133879652),
        Prefab  = "Item_Jewel_Chaos_T02_VeilOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T02_Void = new()
    {
        Name    = null,
        Guid    = new(157004582),
        Prefab  = "Item_Jewel_Chaos_T02_Void",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T03 = new()
    {
        Name    = null,
        Guid    = new(-1601295908),
        Prefab  = "Item_Jewel_Chaos_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T03_Aftershock = new()
    {
        Name    = null,
        Guid    = new(685024499),
        Prefab  = "Item_Jewel_Chaos_T03_Aftershock",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T03_ChaosBarrier = new()
    {
        Name    = null,
        Guid    = new(-209873380),
        Prefab  = "Item_Jewel_Chaos_T03_ChaosBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T03_ChaosVolley = new()
    {
        Name    = null,
        Guid    = new(-1111771702),
        Prefab  = "Item_Jewel_Chaos_T03_ChaosVolley",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T03_PowerSurge = new()
    {
        Name    = null,
        Guid    = new(-1090887222),
        Prefab  = "Item_Jewel_Chaos_T03_PowerSurge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T03_RainOfChaos = new()
    {
        Name    = null,
        Guid    = new(-322544495),
        Prefab  = "Item_Jewel_Chaos_T03_RainOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T03_VeilOfChaos = new()
    {
        Name    = null,
        Guid    = new(1613948207),
        Prefab  = "Item_Jewel_Chaos_T03_VeilOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T03_Void = new()
    {
        Name    = null,
        Guid    = new(-2054797612),
        Prefab  = "Item_Jewel_Chaos_T03_Void",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T04 = new()
    {
        Name    = null,
        Guid    = new(-1796954295),
        Prefab  = "Item_Jewel_Chaos_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T04_Aftershock = new()
    {
        Name    = null,
        Guid    = new(-651841188),
        Prefab  = "Item_Jewel_Chaos_T04_Aftershock",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T04_ChaosBarrier = new()
    {
        Name    = null,
        Guid    = new(-374243736),
        Prefab  = "Item_Jewel_Chaos_T04_ChaosBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T04_ChaosVolley = new()
    {
        Name    = null,
        Guid    = new(818069106),
        Prefab  = "Item_Jewel_Chaos_T04_ChaosVolley",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T04_PowerSurge = new()
    {
        Name    = null,
        Guid    = new(-1166627007),
        Prefab  = "Item_Jewel_Chaos_T04_PowerSurge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T04_RainOfChaos = new()
    {
        Name    = null,
        Guid    = new(-443169356),
        Prefab  = "Item_Jewel_Chaos_T04_RainOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T04_VeilOfChaos = new()
    {
        Name    = null,
        Guid    = new(155899991),
        Prefab  = "Item_Jewel_Chaos_T04_VeilOfChaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Chaos_T04_Void = new()
    {
        Name    = null,
        Guid    = new(666089763),
        Prefab  = "Item_Jewel_Chaos_T04_Void",
        NameKey = null,
        DescKey = null,
    };

    // ── Frost Jewels ──────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Jewel_Frost_T01 = new()
    {
        Name    = null,
        Guid    = new(1908312304),
        Prefab  = "Item_Jewel_Frost_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T02 = new()
    {
        Name    = null,
        Guid    = new(1030854657),
        Prefab  = "Item_Jewel_Frost_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T02_ColdSnap = new()
    {
        Name    = null,
        Guid    = new(-441408420),
        Prefab  = "Item_Jewel_Frost_T02_ColdSnap",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T02_CrystalLance = new()
    {
        Name    = null,
        Guid    = new(-390381611),
        Prefab  = "Item_Jewel_Frost_T02_CrystalLance",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T02_FrostBarrier = new()
    {
        Name    = null,
        Guid    = new(2134082866),
        Prefab  = "Item_Jewel_Frost_T02_FrostBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T02_FrostBat = new()
    {
        Name    = null,
        Guid    = new(-309124704),
        Prefab  = "Item_Jewel_Frost_T02_FrostBat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T02_FrostCone = new()
    {
        Name    = null,
        Guid    = new(-269336230),
        Prefab  = "Item_Jewel_Frost_T02_FrostCone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T02_IceNova = new()
    {
        Name    = null,
        Guid    = new(-535477182),
        Prefab  = "Item_Jewel_Frost_T02_IceNova",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T02_VeilOfFrost = new()
    {
        Name    = null,
        Guid    = new(-710738056),
        Prefab  = "Item_Jewel_Frost_T02_VeilOfFrost",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T03 = new()
    {
        Name    = null,
        Guid    = new(223899244),
        Prefab  = "Item_Jewel_Frost_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T03_ColdSnap = new()
    {
        Name    = null,
        Guid    = new(55473000),
        Prefab  = "Item_Jewel_Frost_T03_ColdSnap",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T03_CrystalLance = new()
    {
        Name    = null,
        Guid    = new(594180030),
        Prefab  = "Item_Jewel_Frost_T03_CrystalLance",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T03_FrostBarrier = new()
    {
        Name    = null,
        Guid    = new(1381699867),
        Prefab  = "Item_Jewel_Frost_T03_FrostBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T03_FrostBat = new()
    {
        Name    = null,
        Guid    = new(-1530254765),
        Prefab  = "Item_Jewel_Frost_T03_FrostBat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T03_FrostCone = new()
    {
        Name    = null,
        Guid    = new(-16130732),
        Prefab  = "Item_Jewel_Frost_T03_FrostCone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T03_IceNova = new()
    {
        Name    = null,
        Guid    = new(1123463900),
        Prefab  = "Item_Jewel_Frost_T03_IceNova",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T03_VeilOfFrost = new()
    {
        Name    = null,
        Guid    = new(-1190496962),
        Prefab  = "Item_Jewel_Frost_T03_VeilOfFrost",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T04 = new()
    {
        Name    = null,
        Guid    = new(-147757377),
        Prefab  = "Item_Jewel_Frost_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T04_ColdSnap = new()
    {
        Name    = null,
        Guid    = new(-930352575),
        Prefab  = "Item_Jewel_Frost_T04_ColdSnap",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T04_CrystalLance = new()
    {
        Name    = null,
        Guid    = new(-2117279191),
        Prefab  = "Item_Jewel_Frost_T04_CrystalLance",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T04_FrostBarrier = new()
    {
        Name    = null,
        Guid    = new(-483235215),
        Prefab  = "Item_Jewel_Frost_T04_FrostBarrier",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T04_FrostBat = new()
    {
        Name    = null,
        Guid    = new(1793042384),
        Prefab  = "Item_Jewel_Frost_T04_FrostBat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T04_FrostCone = new()
    {
        Name    = null,
        Guid    = new(320961855),
        Prefab  = "Item_Jewel_Frost_T04_FrostCone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T04_IceNova = new()
    {
        Name    = null,
        Guid    = new(1947940084),
        Prefab  = "Item_Jewel_Frost_T04_IceNova",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Jewel_Frost_T04_VeilOfFrost = new()
    {
        Name    = null,
        Guid    = new(1729390800),
        Prefab  = "Item_Jewel_Frost_T04_VeilOfFrost",
        NameKey = null,
        DescKey = null,
    };
    // ── Illusion Jewels ───────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Jewel_Illusion_T01 = new()
    {
        Name    = null,
        Guid    = new(1387124262),
        Prefab  = "Item_Jewel_Illusion_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T02 = new()
    {
        Name    = null,
        Guid    = new(437696083),
        Prefab  = "Item_Jewel_Illusion_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T02_Curse = new()
    {
        Name    = null,
        Guid    = new(-1255119436),
        Prefab  = "Item_Jewel_Illusion_T02_Curse",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T02_MistTrance = new()
    {
        Name    = null,
        Guid    = new(101601247),
        Prefab  = "Item_Jewel_Illusion_T02_MistTrance",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T02_Mosquito = new()
    {
        Name    = null,
        Guid    = new(-928330249),
        Prefab  = "Item_Jewel_Illusion_T02_Mosquito",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T02_PhantomAegis = new()
    {
        Name    = null,
        Guid    = new(1123282909),
        Prefab  = "Item_Jewel_Illusion_T02_PhantomAegis",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T02_SpectralWolf = new()
    {
        Name    = null,
        Guid    = new(1520619383),
        Prefab  = "Item_Jewel_Illusion_T02_SpectralWolf",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T02_VeilOfIllusion = new()
    {
        Name    = null,
        Guid    = new(606339127),
        Prefab  = "Item_Jewel_Illusion_T02_VeilOfIllusion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T02_WraithSpear = new()
    {
        Name    = null,
        Guid    = new(665418354),
        Prefab  = "Item_Jewel_Illusion_T02_WraithSpear",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T03 = new()
    {
        Name    = null,
        Guid    = new(1540217782),
        Prefab  = "Item_Jewel_Illusion_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T03_Curse = new()
    {
        Name    = null,
        Guid    = new(-1952374182),
        Prefab  = "Item_Jewel_Illusion_T03_Curse",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T03_MistTrance = new()
    {
        Name    = null,
        Guid    = new(-1513121786),
        Prefab  = "Item_Jewel_Illusion_T03_MistTrance",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T03_Mosquito = new()
    {
        Name    = null,
        Guid    = new(-826325611),
        Prefab  = "Item_Jewel_Illusion_T03_Mosquito",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T03_PhantomAegis = new()
    {
        Name    = null,
        Guid    = new(870884715),
        Prefab  = "Item_Jewel_Illusion_T03_PhantomAegis",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T03_SpectralWolf = new()
    {
        Name    = null,
        Guid    = new(455494178),
        Prefab  = "Item_Jewel_Illusion_T03_SpectralWolf",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T03_VeilOfIllusion = new()
    {
        Name    = null,
        Guid    = new(-1206629745),
        Prefab  = "Item_Jewel_Illusion_T03_VeilOfIllusion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T03_WraithSpear = new()
    {
        Name    = null,
        Guid    = new(998259069),
        Prefab  = "Item_Jewel_Illusion_T03_WraithSpear",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T04 = new()
    {
        Name    = null,
        Guid    = new(97169184),
        Prefab  = "Item_Jewel_Illusion_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T04_Curse = new()
    {
        Name    = null,
        Guid    = new(130269272),
        Prefab  = "Item_Jewel_Illusion_T04_Curse",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T04_MistTrance = new()
    {
        Name    = null,
        Guid    = new(2075997018),
        Prefab  = "Item_Jewel_Illusion_T04_MistTrance",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T04_Mosquito = new()
    {
        Name    = null,
        Guid    = new(902426262),
        Prefab  = "Item_Jewel_Illusion_T04_Mosquito",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T04_PhantomAegis = new()
    {
        Name    = null,
        Guid    = new(-1766731531),
        Prefab  = "Item_Jewel_Illusion_T04_PhantomAegis",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T04_SpectralWolf = new()
    {
        Name    = null,
        Guid    = new(-1444759832),
        Prefab  = "Item_Jewel_Illusion_T04_SpectralWolf",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T04_VeilOfIllusion = new()
    {
        Name    = null,
        Guid    = new(-941913536),
        Prefab  = "Item_Jewel_Illusion_T04_VeilOfIllusion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Illusion_T04_WraithSpear = new()
    {
        Name    = null,
        Guid    = new(-455117097),
        Prefab  = "Item_Jewel_Illusion_T04_WraithSpear",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Storm Jewels ──────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Jewel_Storm_T01 = new()
    {
        Name    = null,
        Guid    = new(-560146452),
        Prefab  = "Item_Jewel_Storm_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T02 = new()
    {
        Name    = null,
        Guid    = new(876293388),
        Prefab  = "Item_Jewel_Storm_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T02_BallLightning = new()
    {
        Name    = null,
        Guid    = new(-1703746731),
        Prefab  = "Item_Jewel_Storm_T02_BallLightning",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T02_Cyclone = new()
    {
        Name    = null,
        Guid    = new(994654794),
        Prefab  = "Item_Jewel_Storm_T02_Cyclone",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T02_Discharge = new()
    {
        Name    = null,
        Guid    = new(-313733383),
        Prefab  = "Item_Jewel_Storm_T02_Discharge",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T02_LightningTendrils = new()
    {
        Name    = null,
        Guid    = new(90716564),
        Prefab  = "Item_Jewel_Storm_T02_LightningTendrils",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T02_LightningWall = new()
    {
        Name    = null,
        Guid    = new(394140527),
        Prefab  = "Item_Jewel_Storm_T02_LightningWall",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T02_PolarityShift = new()
    {
        Name    = null,
        Guid    = new(-944716649),
        Prefab  = "Item_Jewel_Storm_T02_PolarityShift",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T02_VeilOfStorm = new()
    {
        Name    = null,
        Guid    = new(-1416449755),
        Prefab  = "Item_Jewel_Storm_T02_VeilOfStorm",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T03 = new()
    {
        Name    = null,
        Guid    = new(189228039),
        Prefab  = "Item_Jewel_Storm_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T03_BallLightning = new()
    {
        Name    = null,
        Guid    = new(973763812),
        Prefab  = "Item_Jewel_Storm_T03_BallLightning",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T03_Cyclone = new()
    {
        Name    = null,
        Guid    = new(-341717525),
        Prefab  = "Item_Jewel_Storm_T03_Cyclone",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T03_Discharge = new()
    {
        Name    = null,
        Guid    = new(1533847605),
        Prefab  = "Item_Jewel_Storm_T03_Discharge",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T03_LightningTendrils = new()
    {
        Name    = null,
        Guid    = new(-703021474),
        Prefab  = "Item_Jewel_Storm_T03_LightningTendrils",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T03_LightningWall = new()
    {
        Name    = null,
        Guid    = new(-2134499162),
        Prefab  = "Item_Jewel_Storm_T03_LightningWall",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T03_PolarityShift = new()
    {
        Name    = null,
        Guid    = new(-844537086),
        Prefab  = "Item_Jewel_Storm_T03_PolarityShift",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T03_VeilOfStorm = new()
    {
        Name    = null,
        Guid    = new(182214837),
        Prefab  = "Item_Jewel_Storm_T03_VeilOfStorm",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T04 = new()
    {
        Name    = null,
        Guid    = new(2023809276),
        Prefab  = "Item_Jewel_Storm_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T04_BallLightning = new()
    {
        Name    = null,
        Guid    = new(-1927784576),
        Prefab  = "Item_Jewel_Storm_T04_BallLightning",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T04_Cyclone = new()
    {
        Name    = null,
        Guid    = new(-1697520941),
        Prefab  = "Item_Jewel_Storm_T04_Cyclone",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T04_Discharge = new()
    {
        Name    = null,
        Guid    = new(1448686547),
        Prefab  = "Item_Jewel_Storm_T04_Discharge",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T04_LightningTendrils = new()
    {
        Name    = null,
        Guid    = new(1909654697),
        Prefab  = "Item_Jewel_Storm_T04_LightningTendrils",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T04_LightningWall = new()
    {
        Name    = null,
        Guid    = new(-464466648),
        Prefab  = "Item_Jewel_Storm_T04_LightningWall",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T04_PolarityShift = new()
    {
        Name    = null,
        Guid    = new(-189270614),
        Prefab  = "Item_Jewel_Storm_T04_PolarityShift",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Storm_T04_VeilOfStorm = new()
    {
        Name    = null,
        Guid    = new(-556391992),
        Prefab  = "Item_Jewel_Storm_T04_VeilOfStorm",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Template ──────────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Jewel_Template = new()
    {
        Name    = null,
        Guid    = new(1075994038),
        Prefab  = "Item_Jewel_Template",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Unholy Jewels ─────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Jewel_Unholy_T01 = new()
    {
        Name    = null,
        Guid    = new(803445709),
        Prefab  = "Item_Jewel_Unholy_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T02 = new()
    {
        Name    = null,
        Guid    = new(-860388090),
        Prefab  = "Item_Jewel_Unholy_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T02_ChainsOfDeath = new()
    {
        Name    = null,
        Guid    = new(-178249605),
        Prefab  = "Item_Jewel_Unholy_T02_ChainsOfDeath",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T02_CorpseExplosion = new()
    {
        Name    = null,
        Guid    = new(977816262),
        Prefab  = "Item_Jewel_Unholy_T02_CorpseExplosion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T02_CorruptedSkull = new()
    {
        Name    = null,
        Guid    = new(-1183600395),
        Prefab  = "Item_Jewel_Unholy_T02_CorruptedSkull",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T02_DeathKnight = new()
    {
        Name    = null,
        Guid    = new(-173571027),
        Prefab  = "Item_Jewel_Unholy_T02_DeathKnight",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T02_Soulburn = new()
    {
        Name    = null,
        Guid    = new(1277476884),
        Prefab  = "Item_Jewel_Unholy_T02_Soulburn",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T02_VeilOfBones = new()
    {
        Name    = null,
        Guid    = new(-1347054873),
        Prefab  = "Item_Jewel_Unholy_T02_VeilOfBones",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T02_WardOfTheDamned = new()
    {
        Name    = null,
        Guid    = new(-593608743),
        Prefab  = "Item_Jewel_Unholy_T02_WardOfTheDamned",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T03 = new()
    {
        Name    = null,
        Guid    = new(-647547545),
        Prefab  = "Item_Jewel_Unholy_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T03_ChainsOfDeath = new()
    {
        Name    = null,
        Guid    = new(1042817390),
        Prefab  = "Item_Jewel_Unholy_T03_ChainsOfDeath",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T03_CorpseExplosion = new()
    {
        Name    = null,
        Guid    = new(-1123608041),
        Prefab  = "Item_Jewel_Unholy_T03_CorpseExplosion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T03_CorruptedSkull = new()
    {
        Name    = null,
        Guid    = new(-1508992859),
        Prefab  = "Item_Jewel_Unholy_T03_CorruptedSkull",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T03_DeathKnight = new()
    {
        Name    = null,
        Guid    = new(-318118264),
        Prefab  = "Item_Jewel_Unholy_T03_DeathKnight",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T03_Soulburn = new()
    {
        Name    = null,
        Guid    = new(282707515),
        Prefab  = "Item_Jewel_Unholy_T03_Soulburn",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T03_VeilOfBones = new()
    {
        Name    = null,
        Guid    = new(-1913987811),
        Prefab  = "Item_Jewel_Unholy_T03_VeilOfBones",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T03_WardOfTheDamned = new()
    {
        Name    = null,
        Guid    = new(665184248),
        Prefab  = "Item_Jewel_Unholy_T03_WardOfTheDamned",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T04 = new()
    {
        Name    = null,
        Guid    = new(1412786604),
        Prefab  = "Item_Jewel_Unholy_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T04_ChainsOfDeath = new()
    {
        Name    = null,
        Guid    = new(-2100613085),
        Prefab  = "Item_Jewel_Unholy_T04_ChainsOfDeath",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T04_CorpseExplosion = new()
    {
        Name    = null,
        Guid    = new(-749764415),
        Prefab  = "Item_Jewel_Unholy_T04_CorpseExplosion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T04_CorruptedSkull = new()
    {
        Name    = null,
        Guid    = new(140526202),
        Prefab  = "Item_Jewel_Unholy_T04_CorruptedSkull",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T04_DeathKnight = new()
    {
        Name    = null,
        Guid    = new(-340571020),
        Prefab  = "Item_Jewel_Unholy_T04_DeathKnight",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T04_Soulburn = new()
    {
        Name    = null,
        Guid    = new(897635802),
        Prefab  = "Item_Jewel_Unholy_T04_Soulburn",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T04_VeilOfBones = new()
    {
        Name    = null,
        Guid    = new(-1180115034),
        Prefab  = "Item_Jewel_Unholy_T04_VeilOfBones",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Jewel_Unholy_T04_WardOfTheDamned = new()
    {
        Name    = null,
        Guid    = new(1479677538),
        Prefab  = "Item_Jewel_Unholy_T04_WardOfTheDamned",
        NameKey = null,
        DescKey = null,
    };
}