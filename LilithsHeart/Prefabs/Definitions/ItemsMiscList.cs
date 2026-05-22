// ============================================================
//  ItemsMiscList — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/ItemsMiscList.cs
//
//  [CHANGED] Migrated from bare PrefabGUID fields to PrefabDef records.
//            Field names match the prefab string exactly. Names sourced
//            from original comments where present; null elsewhere.
//            All nullable fields shown explicitly.
//
//  [PERFORMANCE] Static readonly PrefabDef fields — initialised once at
//                class load, zero per-frame cost. Stack-allocated structs,
//                no heap pressure.
// ============================================================

using Stunlock.Core;

namespace LilithsHeart.Prefabs.Definitions;

public static class ItemsMiscList
{
    // ── Fake Items — UI Only ──────────────────────────────────────────────────

    public static readonly PrefabDef FakeItem_AnyFish = new()
    {
        Name    = null,
        Guid    = new(300582272),
        Prefab  = "FakeItem_AnyFish",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_AnyFlower = new()
    {
        Name    = null,
        Guid    = new(-2101941878),
        Prefab  = "FakeItem_AnyFlower",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_AnyGem = new()
    {
        Name    = null,
        Guid    = new(1128027535),
        Prefab  = "FakeItem_AnyGem",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_AnyGem_T01 = new()
    {
        Name    = null,
        Guid    = new(-2039337521),
        Prefab  = "FakeItem_AnyGem_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_AnyGem_T02 = new()
    {
        Name    = null,
        Guid    = new(-2099422426),
        Prefab  = "FakeItem_AnyGem_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_BloodTracking = new()
    {
        Name    = null,
        Guid    = new(-170922187),
        Prefab  = "FakeItem_BloodTracking",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_BloodSnapper = new()
    {
        Name    = null,
        Guid    = new(526090146),
        Prefab  = "FakeItem_FeedPrisoner_BloodSnapper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_Corrupted = new()
    {
        Name    = null,
        Guid    = new(714743556),
        Prefab  = "FakeItem_FeedPrisoner_Corrupted",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_FatGoby = new()
    {
        Name    = null,
        Guid    = new(-811840389),
        Prefab  = "FakeItem_FeedPrisoner_FatGoby",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_FierceStinger = new()
    {
        Name    = null,
        Guid    = new(-114411609),
        Prefab  = "FakeItem_FeedPrisoner_FierceStinger",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_GoldenRiverBass = new()
    {
        Name    = null,
        Guid    = new(-684874624),
        Prefab  = "FakeItem_FeedPrisoner_GoldenRiverBass",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_IrradiantGruel = new()
    {
        Name    = null,
        Guid    = new(-1798608844),
        Prefab  = "FakeItem_FeedPrisoner_IrradiantGruel",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_RainbowTrout = new()
    {
        Name    = null,
        Guid    = new(1814558673),
        Prefab  = "FakeItem_FeedPrisoner_RainbowTrout",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_Rat = new()
    {
        Name    = null,
        Guid    = new(1110550218),
        Prefab  = "FakeItem_FeedPrisoner_Rat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_SageFish = new()
    {
        Name    = null,
        Guid    = new(172410251),
        Prefab  = "FakeItem_FeedPrisoner_SageFish",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_SwampDweller = new()
    {
        Name    = null,
        Guid    = new(-314251399),
        Prefab  = "FakeItem_FeedPrisoner_SwampDweller",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FeedPrisoner_TwilightSnapper = new()
    {
        Name    = null,
        Guid    = new(-1205777419),
        Prefab  = "FakeItem_FeedPrisoner_TwilightSnapper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_FlawlessGem_T03 = new()
    {
        Name    = null,
        Guid    = new(1613130430),
        Prefab  = "FakeItem_FlawlessGem_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_Prisoner_ExtractedBloodPotion = new()
    {
        Name    = null,
        Guid    = new(-1871776321),
        Prefab  = "FakeItem_Prisoner_ExtractedBloodPotion",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_Prisoner_ExtractedBloodwine = new()
    {
        Name    = null,
        Guid    = new(-1624770558),
        Prefab  = "FakeItem_Prisoner_ExtractedBloodwine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_Prisoner_ExtractEssence = new()
    {
        Name    = null,
        Guid    = new(-911541799),
        Prefab  = "FakeItem_Prisoner_ExtractEssence",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef FakeItem_RegularGem_T02 = new()
    {
        Name    = null,
        Guid    = new(-36717533),
        Prefab  = "FakeItem_RegularGem_T02",
        NameKey = null,
        DescKey = null,
    };

    // ── Dummy Items ───────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Dummy_Banshee = new()
    {
        Name    = null,
        Guid    = new(-1513937321),
        Prefab  = "Item_Dummy_Banshee",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_Ghoul = new()
    {
        Name    = null,
        Guid    = new(2042311455),
        Prefab  = "Item_Dummy_Ghoul",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_GiantRat = new()
    {
        Name    = null,
        Guid    = new(213967097),
        Prefab  = "Item_Dummy_GiantRat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_Mosquito = new()
    {
        Name    = null,
        Guid    = new(961990006),
        Prefab  = "Item_Dummy_Mosquito",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_Mutant = new()
    {
        Name    = null,
        Guid    = new(-338333923),
        Prefab  = "Item_Dummy_Mutant",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_Necromancer = new()
    {
        Name    = null,
        Guid    = new(1252366498),
        Prefab  = "Item_Dummy_Necromancer",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T01_BloodSoul = new()
    {
        Name    = null,
        Guid    = new(1395316286),
        Prefab  = "Item_Dummy_NetherDemon_T01_BloodSoul",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T01_Knowledge = new()
    {
        Name    = null,
        Guid    = new(215017089),
        Prefab  = "Item_Dummy_NetherDemon_T01_Knowledge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T01_Minerals = new()
    {
        Name    = null,
        Guid    = new(-2141642225),
        Prefab  = "Item_Dummy_NetherDemon_T01_Minerals",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T01_Seeds = new()
    {
        Name    = null,
        Guid    = new(-112151309),
        Prefab  = "Item_Dummy_NetherDemon_T01_Seeds",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T01_Weapons = new()
    {
        Name    = null,
        Guid    = new(886819019),
        Prefab  = "Item_Dummy_NetherDemon_T01_Weapons",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T02_Alchemy = new()
    {
        Name    = null,
        Guid    = new(34841965),
        Prefab  = "Item_Dummy_NetherDemon_T02_Alchemy",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T02_BloodSoul = new()
    {
        Name    = null,
        Guid    = new(-107137497),
        Prefab  = "Item_Dummy_NetherDemon_T02_BloodSoul",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T02_Knowledge = new()
    {
        Name    = null,
        Guid    = new(1452779821),
        Prefab  = "Item_Dummy_NetherDemon_T02_Knowledge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T02_Minerals = new()
    {
        Name    = null,
        Guid    = new(-364321170),
        Prefab  = "Item_Dummy_NetherDemon_T02_Minerals",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_NetherDemon_T02_Weapons = new()
    {
        Name    = null,
        Guid    = new(-1199531707),
        Prefab  = "Item_Dummy_NetherDemon_T02_Weapons",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_PutridRat = new()
    {
        Name    = null,
        Guid    = new(927039475),
        Prefab  = "Item_Dummy_PutridRat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_Rat = new()
    {
        Name    = null,
        Guid    = new(2029158532),
        Prefab  = "Item_Dummy_Rat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_Silkworm = new()
    {
        Name    = null,
        Guid    = new(930747930),
        Prefab  = "Item_Dummy_Silkworm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_Skeleton = new()
    {
        Name    = null,
        Guid    = new(-836889492),
        Prefab  = "Item_Dummy_Skeleton",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Dummy_Spiderling = new()
    {
        Name    = null,
        Guid    = new(2015299972),
        Prefab  = "Item_Dummy_Spiderling",
        NameKey = null,
        DescKey = null,
    };

    // ── Stygian Shard ─────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_NetherShard_T03 = new()
    {
        Name    = "PrimalStygianShard",
        Guid    = new(28358550),
        Prefab  = "Item_NetherShard_T03",
        NameKey = null,
        DescKey = null,
    };

    // ── Unused / Miscellaneous ────────────────────────────────────────────────

    public static readonly PrefabDef Item_Ingredient_IronBody = new()
    {
        Name    = null,
        Guid    = new(988417522),
        Prefab  = "Item_Ingredient_IronBody",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Kit_Base = new()
    {
        Name    = null,
        Guid    = new(1413130999),
        Prefab  = "Item_Ingredient_Kit_Base",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Kit_Blacksmith_T02 = new()
    {
        Name    = null,
        Guid    = new(-167936394),
        Prefab  = "Item_Ingredient_Kit_Blacksmith_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Kit_Blacksmith_T03 = new()
    {
        Name    = null,
        Guid    = new(-580716317),
        Prefab  = "Item_Ingredient_Kit_Blacksmith_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Kit_Blacksmith_T04 = new()
    {
        Name    = null,
        Guid    = new(-1838793646),
        Prefab  = "Item_Ingredient_Kit_Blacksmith_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Kit_Magic_T04 = new()
    {
        Name    = null,
        Guid    = new(1488205677),
        Prefab  = "Item_Ingredient_Kit_Magic_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Kit_Tailoring_T04 = new()
    {
        Name    = null,
        Guid    = new(828271620),
        Prefab  = "Item_Ingredient_Kit_Tailoring_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_CastleUpkeep_Fake = new()
    {
        Name    = null,
        Guid    = new(421203343),
        Prefab  = "Item_Ingredient_CastleUpkeep_Fake",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Chitin = new()
    {
        Name    = null,
        Guid    = new(-953253466),
        Prefab  = "Item_Ingredient_Chitin",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_ClayMold = new()
    {
        Name    = null,
        Guid    = new(-1257026088),
        Prefab  = "Item_Ingredient_ClayMold",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Gemstone = new()
    {
        Name    = null,
        Guid    = new(2115367516),
        Prefab  = "Item_Ingredient_Gemstone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_MapZone_Fish = new()
    {
        Name    = null,
        Guid    = new(193249843),
        Prefab  = "Item_Ingredient_MapZone_Fish",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_MapZone_GemVein_T02 = new()
    {
        Name    = null,
        Guid    = new(889298519),
        Prefab  = "Item_Ingredient_MapZone_GemVein_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_MapZone_GemVein_T03 = new()
    {
        Name    = null,
        Guid    = new(301051123),
        Prefab  = "Item_Ingredient_MapZone_GemVein_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_MapZone_Plants = new()
    {
        Name    = null,
        Guid    = new(968796494),
        Prefab  = "Item_Ingredient_MapZone_Plants",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_MapZone_Potions = new()
    {
        Name    = null,
        Guid    = new(-1617671082),
        Prefab  = "Item_Ingredient_MapZone_Potions",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_MapZone_Tesla = new()
    {
        Name    = null,
        Guid    = new(-77555820),
        Prefab  = "Item_Ingredient_MapZone_Tesla",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_MapZone_Vendor = new()
    {
        Name    = null,
        Guid    = new(-696770536),
        Prefab  = "Item_Ingredient_MapZone_Vendor",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Mineral_GoldOre = new()
    {
        Name    = null,
        Guid    = new(660533034),
        Prefab  = "Item_Ingredient_Mineral_GoldOre",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Plant_RadiantFiber = new()
    {
        Name    = null,
        Guid    = new(-182923609),
        Prefab  = "Item_Ingredient_Plant_RadiantFiber",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Plant_Thistle = new()
    {
        Name    = null,
        Guid    = new(-598100816),
        Prefab  = "Item_Ingredient_Plant_Thistle",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Resonator = new()
    {
        Name    = null,
        Guid    = new(-1629804427),
        Prefab  = "Item_Ingredient_Resonator",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Thread_Imperial = new()
    {
        Name    = null,
        Guid    = new(-898917584),
        Prefab  = "Item_Ingredient_Thread_Imperial",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Witchdust = new()
    {
        Name    = null,
        Guid    = new(-223452038),
        Prefab  = "Item_Ingredient_Witchdust",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Vampiricdust = new()
    {
        Name    = null,
        Guid    = new(805157024),
        Prefab  = "Item_Ingredient_Vampiricdust",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Coal = new()
    {
        Name    = null,
        Guid    = new(-1932461974),
        Prefab  = "Item_Ingredient_Coal",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Crystal = new()
    {
        Name    = null,
        Guid    = new(-257494203),
        Prefab  = "Item_Ingredient_Crystal",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Fish_TheFish = new()
    {
        Name    = null,
        Guid    = new(176401052),
        Prefab  = "Item_Ingredient_Fish_TheFish",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_DemonFragment = new()
    {
        Name    = null,
        Guid    = new(-77477508),
        Prefab  = "Item_Ingredient_DemonFragment",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Scales = new()
    {
        Name    = null,
        Guid    = new(-1199259626),
        Prefab  = "Item_Ingredient_Scales",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Gem_Base = new()
    {
        Name    = null,
        Guid    = new(-656822228),
        Prefab  = "Item_Ingredient_Gem_Base",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Document = new()
    {
        Name    = null,
        Guid    = new(1334469825),
        Prefab  = "Item_Ingredient_Document",
        NameKey = null,
        DescKey = null,
    };

    // ── Perfect Gems ──────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Ingredient_Gem_Amethyst_T04 = new()
    {
        Name    = "PerfectAmethyst",
        Guid    = new(-106283194),
        Prefab  = "Item_Ingredient_Gem_Amethyst_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Gem_Emerald_T04 = new()
    {
        Name    = "PerfectEmerald",
        Guid    = new(1354115931),
        Prefab  = "Item_Ingredient_Gem_Emerald_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Gem_Miststone_T04 = new()
    {
        Name    = "PerfectMiststone",
        Guid    = new(750542699),
        Prefab  = "Item_Ingredient_Gem_Miststone_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Gem_Ruby_T04 = new()
    {
        Name    = "PerfectRuby",
        Guid    = new(188653143),
        Prefab  = "Item_Ingredient_Gem_Ruby_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Gem_Sapphire_T04 = new()
    {
        Name    = "PerfectSapphire",
        Guid    = new(-2020212226),
        Prefab  = "Item_Ingredient_Gem_Sapphire_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Gem_Topaz_T04 = new()
    {
        Name    = "PerfectTopaz",
        Guid    = new(-1983566585),
        Prefab  = "Item_Ingredient_Gem_Topaz_T04",
        NameKey = null,
        DescKey = null,
    };

    // ── Relics ────────────────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Building_Relic_Behemoth = new()
    {
        Name    = null,
        Guid    = new(1247086852),
        Prefab  = "Item_Building_Relic_Behemoth",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Building_Relic_Manticore = new()
    {
        Name    = null,
        Guid    = new(-222860772),
        Prefab  = "Item_Building_Relic_Manticore",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Building_Relic_Monster = new()
    {
        Name    = null,
        Guid    = new(-1619308732),
        Prefab  = "Item_Building_Relic_Monster",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Building_Relic_Paladin = new()
    {
        Name    = null,
        Guid    = new(2019195024),
        Prefab  = "Item_Building_Relic_Paladin",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Building_Plants_Thistle_Seed = new()
    {
        Name    = null,
        Guid    = new(-1370210913),
        Prefab  = "Item_Building_Plants_Thistle_Seed",
        NameKey = null,
        DescKey = null,
    };
}