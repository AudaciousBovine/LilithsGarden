// ============================================================
//  RecipesResourceList — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/RecipesResourceList.cs
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

public static class RecipesResourceList
{
    // ── Refined Resources ─────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Ingredient_BatLeather = new()
    {
        Name    = null,
        Guid    = new(878778315),
        Prefab  = "Recipe_Ingredient_BatLeather",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_BatteryCharged = new()
    {
        Name    = null,
        Guid    = new(-40415372),
        Prefab  = "Recipe_Ingredient_BatteryCharged",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_BatteryCharged_10x = new()
    {
        Name    = null,
        Guid    = new(1499185347),
        Prefab  = "Recipe_Ingredient_BatteryCharged_10x",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Canister = new()
    {
        Name    = null,
        Guid    = new(-1219663401),
        Prefab  = "Recipe_Ingredient_Canister",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CarpetRoll = new()
    {
        Name    = null,
        Guid    = new(-76978559),
        Prefab  = "Recipe_Ingredient_CarpetRoll",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CastleKey_T01 = new()
    {
        Name    = null,
        Guid    = new(-1158613345),
        Prefab  = "Recipe_Ingredient_CastleKey_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CastleKey_T02 = new()
    {
        Name    = null,
        Guid    = new(-1538704240),
        Prefab  = "Recipe_Ingredient_CastleKey_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CastleKey_T03 = new()
    {
        Name    = null,
        Guid    = new(690675608),
        Prefab  = "Recipe_Ingredient_CastleKey_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CastleKey_T04 = new()
    {
        Name    = null,
        Guid    = new(1627186216),
        Prefab  = "Recipe_Ingredient_CastleKey_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_ClayMold = new()
    {
        Name    = null,
        Guid    = new(-1039804369),
        Prefab  = "Recipe_Ingredient_ClayMold",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Cloth01 = new()
    {
        Name    = null,
        Guid    = new(-535699316),
        Prefab  = "Recipe_Ingredient_Cloth01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Cloth02 = new()
    {
        Name    = null,
        Guid    = new(691688637),
        Prefab  = "Recipe_Ingredient_Cloth02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Cloth03 = new()
    {
        Name    = null,
        Guid    = new(-18607093),
        Prefab  = "Recipe_Ingredient_Cloth03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CoarseThread = new()
    {
        Name    = null,
        Guid    = new(217985609),
        Prefab  = "Recipe_Ingredient_CoarseThread",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Coin_Copper = new()
    {
        Name    = null,
        Guid    = new(1611921852),
        Prefab  = "Recipe_Ingredient_Coin_Copper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Coin_Royal = new()
    {
        Name    = null,
        Guid    = new(1679369423),
        Prefab  = "Recipe_Ingredient_Coin_Royal",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Coin_Silver = new()
    {
        Name    = null,
        Guid    = new(1987529758),
        Prefab  = "Recipe_Ingredient_Coin_Silver",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CopperBar = new()
    {
        Name    = null,
        Guid    = new(43160202),
        Prefab  = "Recipe_Ingredient_CopperBar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CopperWires = new()
    {
        Name    = null,
        Guid    = new(-2031309726),
        Prefab  = "Recipe_Ingredient_CopperWires",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_CottonYarn = new()
    {
        Name    = null,
        Guid    = new(-1463059104),
        Prefab  = "Recipe_Ingredient_CottonYarn",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_DarkSilverBar = new()
    {
        Name    = null,
        Guid    = new(1763037087),
        Prefab  = "Recipe_Ingredient_DarkSilverBar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Emberglass = new()
    {
        Name    = null,
        Guid    = new(1907177885),
        Prefab  = "Recipe_Ingredient_Emberglass",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fake_Gems_T02 = new()
    {
        Name    = null,
        Guid    = new(1333711523),
        Prefab  = "Recipe_Ingredient_Fake_Gems_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fake_Gems_T03 = new()
    {
        Name    = null,
        Guid    = new(1197952732),
        Prefab  = "Recipe_Ingredient_Fake_Gems_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_FakeFish = new()
    {
        Name    = null,
        Guid    = new(-1690732149),
        Prefab  = "Recipe_Ingredient_FakeFish",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_FakeGemDust = new()
    {
        Name    = null,
        Guid    = new(-1105418306),
        Prefab  = "Recipe_Ingredient_FakeGemDust",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_FakePollen = new()
    {
        Name    = null,
        Guid    = new(-2095604835),
        Prefab  = "Recipe_Ingredient_FakePollen",
        NameKey = null,
        DescKey = null,
    };

    // ── Fish Byproduct Recipes ────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Ingredient_Fish_T01_FatGoby_Fishoil = new()
    {
        Name    = null,
        Guid    = new(1456918437),
        Prefab  = "Recipe_Ingredient_Fish_T01_FatGoby_Fishoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fish_T01_FierceStinger_Fishoil = new()
    {
        Name    = null,
        Guid    = new(310077690),
        Prefab  = "Recipe_Ingredient_Fish_T01_FierceStinger_Fishoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fish_T01_RainbowTrout_Fishoil = new()
    {
        Name    = null,
        Guid    = new(-1998323031),
        Prefab  = "Recipe_Ingredient_Fish_T01_RainbowTrout_Fishoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fish_T02_BloodSnapper_Fishoil = new()
    {
        Name    = null,
        Guid    = new(2073670444),
        Prefab  = "Recipe_Ingredient_Fish_T02_BloodSnapper_Fishoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fish_T02_SageFish_Fishoil = new()
    {
        Name    = null,
        Guid    = new(2034067759),
        Prefab  = "Recipe_Ingredient_Fish_T02_SageFish_Fishoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fish_T02_TwilightSnapper_Fishoil = new()
    {
        Name    = null,
        Guid    = new(-1158638582),
        Prefab  = "Recipe_Ingredient_Fish_T02_TwilightSnapper_Fishoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fish_T03_CorruptedFish_Sap = new()
    {
        Name    = null,
        Guid    = new(2001831411),
        Prefab  = "Recipe_Ingredient_Fish_T03_CorruptedFish_Sap",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fish_T03_GoldenRiverBass_Fishoil = new()
    {
        Name    = null,
        Guid    = new(-579466337),
        Prefab  = "Recipe_Ingredient_Fish_T03_GoldenRiverBass_Fishoil",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Fish_T03_SwampDweller_Fishoil = new()
    {
        Name    = null,
        Guid    = new(-914403055),
        Prefab  = "Recipe_Ingredient_Fish_T03_SwampDweller_Fishoil",
        NameKey = null,
        DescKey = null,
    };

    // ── Gem Refinement Recipes ────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Ingredient_Gem_Amethyst_T01 = new()
    {
        Name    = null,
        Guid    = new(794513497),
        Prefab  = "Recipe_Ingredient_Gem_Amethyst_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Amethyst_T02 = new()
    {
        Name    = null,
        Guid    = new(1267772432),
        Prefab  = "Recipe_Ingredient_Gem_Amethyst_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Amethyst_T03 = new()
    {
        Name    = null,
        Guid    = new(-1305847600),
        Prefab  = "Recipe_Ingredient_Gem_Amethyst_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Amethyst_T04 = new()
    {
        Name    = null,
        Guid    = new(-259193408),
        Prefab  = "Recipe_Ingredient_Gem_Amethyst_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Emerald_T01 = new()
    {
        Name    = null,
        Guid    = new(-818431229),
        Prefab  = "Recipe_Ingredient_Gem_Emerald_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Emerald_T02 = new()
    {
        Name    = null,
        Guid    = new(2145878785),
        Prefab  = "Recipe_Ingredient_Gem_Emerald_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Emerald_T03 = new()
    {
        Name    = null,
        Guid    = new(-49650299),
        Prefab  = "Recipe_Ingredient_Gem_Emerald_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Emerald_T04 = new()
    {
        Name    = null,
        Guid    = new(824127202),
        Prefab  = "Recipe_Ingredient_Gem_Emerald_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Miststone_T01 = new()
    {
        Name    = null,
        Guid    = new(1511000106),
        Prefab  = "Recipe_Ingredient_Gem_Miststone_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Miststone_T02 = new()
    {
        Name    = null,
        Guid    = new(-1803835046),
        Prefab  = "Recipe_Ingredient_Gem_Miststone_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Miststone_T03 = new()
    {
        Name    = null,
        Guid    = new(-793702579),
        Prefab  = "Recipe_Ingredient_Gem_Miststone_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Miststone_T04 = new()
    {
        Name    = null,
        Guid    = new(191342827),
        Prefab  = "Recipe_Ingredient_Gem_Miststone_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Ruby_T01 = new()
    {
        Name    = null,
        Guid    = new(510709307),
        Prefab  = "Recipe_Ingredient_Gem_Ruby_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Ruby_T02 = new()
    {
        Name    = null,
        Guid    = new(1574438607),
        Prefab  = "Recipe_Ingredient_Gem_Ruby_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Ruby_T03 = new()
    {
        Name    = null,
        Guid    = new(494499358),
        Prefab  = "Recipe_Ingredient_Gem_Ruby_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Ruby_T04 = new()
    {
        Name    = null,
        Guid    = new(438072551),
        Prefab  = "Recipe_Ingredient_Gem_Ruby_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Sapphire_T01 = new()
    {
        Name    = null,
        Guid    = new(224077013),
        Prefab  = "Recipe_Ingredient_Gem_Sapphire_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Sapphire_T02 = new()
    {
        Name    = null,
        Guid    = new(-1411717403),
        Prefab  = "Recipe_Ingredient_Gem_Sapphire_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Sapphire_T03 = new()
    {
        Name    = null,
        Guid    = new(-830475571),
        Prefab  = "Recipe_Ingredient_Gem_Sapphire_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Sapphire_T04 = new()
    {
        Name    = null,
        Guid    = new(-97850613),
        Prefab  = "Recipe_Ingredient_Gem_Sapphire_T04",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Topaz_T01 = new()
    {
        Name    = null,
        Guid    = new(-671939022),
        Prefab  = "Recipe_Ingredient_Gem_Topaz_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Topaz_T02 = new()
    {
        Name    = null,
        Guid    = new(-900164684),
        Prefab  = "Recipe_Ingredient_Gem_Topaz_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Topaz_T03 = new()
    {
        Name    = null,
        Guid    = new(-680521717),
        Prefab  = "Recipe_Ingredient_Gem_Topaz_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gem_Topaz_T04 = new()
    {
        Name    = null,
        Guid    = new(-597461125),
        Prefab  = "Recipe_Ingredient_Gem_Topaz_T04",
        NameKey = null,
        DescKey = null,
    };

    // ── Remaining Refined Resources ───────────────────────────────────────────

    public static readonly PrefabDef Recipe_Ingredient_GhostYarn = new()
    {
        Name    = null,
        Guid    = new(-312139320),
        Prefab  = "Recipe_Ingredient_GhostYarn",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Glass = new()
    {
        Name    = null,
        Guid    = new(-1035277730),
        Prefab  = "Recipe_Ingredient_Glass",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_GoldBar = new()
    {
        Name    = null,
        Guid    = new(-882942445),
        Prefab  = "Recipe_Ingredient_GoldBar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Gravedust = new()
    {
        Name    = null,
        Guid    = new(-621968576),
        Prefab  = "Recipe_Ingredient_Gravedust",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_ImperialThread = new()
    {
        Name    = null,
        Guid    = new(-2087869889),
        Prefab  = "Recipe_Ingredient_ImperialThread",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_IronBar = new()
    {
        Name    = null,
        Guid    = new(182584043),
        Prefab  = "Recipe_Ingredient_IronBar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_IronBody = new()
    {
        Name    = null,
        Guid    = new(-1270503528),
        Prefab  = "Recipe_Ingredient_IronBody",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Leather = new()
    {
        Name    = null,
        Guid    = new(1299251205),
        Prefab  = "Recipe_Ingredient_Leather",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_NetherShard_T02 = new()
    {
        Name    = null,
        Guid    = new(830427227),
        Prefab  = "Recipe_Ingredient_NetherShard_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Obsidian_NetherShards = new()
    {
        Name    = null,
        Guid    = new(-1046062818),
        Prefab  = "Recipe_Ingredient_Obsidian_NetherShards",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Obsidian_RadiumAlloy = new()
    {
        Name    = null,
        Guid    = new(-755040396),
        Prefab  = "Recipe_Ingredient_Obsidian_RadiumAlloy",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_OnyxTear = new()
    {
        Name    = null,
        Guid    = new(-1624699880),
        Prefab  = "Recipe_Ingredient_OnyxTear",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_PaintingFrame = new()
    {
        Name    = null,
        Guid    = new(639947458),
        Prefab  = "Recipe_Ingredient_PaintingFrame",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Paper = new()
    {
        Name    = null,
        Guid    = new(1972184798),
        Prefab  = "Recipe_Ingredient_Paper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plank = new()
    {
        Name    = null,
        Guid    = new(-7510953),
        Prefab  = "Recipe_Ingredient_Plank",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plank_CorruptedSap = new()
    {
        Name    = null,
        Guid    = new(1938879259),
        Prefab  = "Recipe_Ingredient_Plank_CorruptedSap",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plank_WoodCurse = new()
    {
        Name    = null,
        Guid    = new(1933452299),
        Prefab  = "Recipe_Ingredient_Plank_WoodCurse",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plank_WoodGloom = new()
    {
        Name    = null,
        Guid    = new(1004035314),
        Prefab  = "Recipe_Ingredient_Plank_WoodGloom",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plank_WoodHallow = new()
    {
        Name    = null,
        Guid    = new(-1161643303),
        Prefab  = "Recipe_Ingredient_Plank_WoodHallow",
        NameKey = null,
        DescKey = null,
    };

    // ── Pollen Recipes ────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Ingredient_Plant_BleedingHeart_Pollen = new()
    {
        Name    = null,
        Guid    = new(-1406676278),
        Prefab  = "Recipe_Ingredient_Plant_BleedingHeart_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_BloodRose_Pollen = new()
    {
        Name    = null,
        Guid    = new(-1262386399),
        Prefab  = "Recipe_Ingredient_Plant_BloodRose_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_CorruptedFlower_Pollen = new()
    {
        Name    = null,
        Guid    = new(312087613),
        Prefab  = "Recipe_Ingredient_Plant_CorruptedFlower_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_Cotton_Pollen = new()
    {
        Name    = null,
        Guid    = new(-318813623),
        Prefab  = "Recipe_Ingredient_Plant_Cotton_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_FireBlossom_Pollen = new()
    {
        Name    = null,
        Guid    = new(1492043256),
        Prefab  = "Recipe_Ingredient_Plant_FireBlossom_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_GhostShroom_Pollen = new()
    {
        Name    = null,
        Guid    = new(981205115),
        Prefab  = "Recipe_Ingredient_Plant_GhostShroom_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_HellsClarion_Pollen = new()
    {
        Name    = null,
        Guid    = new(-807387227),
        Prefab  = "Recipe_Ingredient_Plant_HellsClarion_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_MourningLily_Pollen = new()
    {
        Name    = null,
        Guid    = new(1987128673),
        Prefab  = "Recipe_Ingredient_Plant_MourningLily_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_PlagueBrier_Pollen = new()
    {
        Name    = null,
        Guid    = new(-1209065169),
        Prefab  = "Recipe_Ingredient_Plant_PlagueBrier_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_SnowFlower_Pollen = new()
    {
        Name    = null,
        Guid    = new(-1444512478),
        Prefab  = "Recipe_Ingredient_Plant_SnowFlower_Pollen",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Plant_SunFlower_Pollen = new()
    {
        Name    = null,
        Guid    = new(-731341444),
        Prefab  = "Recipe_Ingredient_Plant_SunFlower_Pollen",
        NameKey = null,
        DescKey = null,
    };

    // ── Remaining Components ──────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Ingredient_PowerCore = new()
    {
        Name    = null,
        Guid    = new(1399845400),
        Prefab  = "Recipe_Ingredient_PowerCore",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_PristineLeather = new()
    {
        Name    = null,
        Guid    = new(3903463),
        Prefab  = "Recipe_Ingredient_PristineLeather",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_RadiumAlloy = new()
    {
        Name    = null,
        Guid    = new(1802509122),
        Prefab  = "Recipe_Ingredient_RadiumAlloy",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_ReinforcedPlank = new()
    {
        Name    = null,
        Guid    = new(-1038174753),
        Prefab  = "Recipe_Ingredient_ReinforcedPlank",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Schematic = new()
    {
        Name    = null,
        Guid    = new(1665157021),
        Prefab  = "Recipe_Ingredient_Schematic",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Scourgestone = new()
    {
        Name    = null,
        Guid    = new(667958797),
        Prefab  = "Recipe_Ingredient_Scourgestone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Scroll = new()
    {
        Name    = null,
        Guid    = new(-1639279845),
        Prefab  = "Recipe_Ingredient_Scroll",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_SculpturedWood = new()
    {
        Name    = null,
        Guid    = new(222408145),
        Prefab  = "Recipe_Ingredient_SculpturedWood",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_ShadowWeave = new()
    {
        Name    = null,
        Guid    = new(-279454572),
        Prefab  = "Recipe_Ingredient_ShadowWeave",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Silk = new()
    {
        Name    = null,
        Guid    = new(-1803829778),
        Prefab  = "Recipe_Ingredient_Silk",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_SilverBar = new()
    {
        Name    = null,
        Guid    = new(-1633898285),
        Prefab  = "Recipe_Ingredient_SilverBar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Spectraldust = new()
    {
        Name    = null,
        Guid    = new(-329288568),
        Prefab  = "Recipe_Ingredient_Spectraldust",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_StoneBody = new()
    {
        Name    = null,
        Guid    = new(1356454823),
        Prefab  = "Recipe_Ingredient_StoneBody",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_StoneBrick = new()
    {
        Name    = null,
        Guid    = new(484814347),
        Prefab  = "Recipe_Ingredient_StoneBrick",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Sulfur = new()
    {
        Name    = null,
        Guid    = new(-1718362434),
        Prefab  = "Recipe_Ingredient_Sulfur",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_ThickLeather = new()
    {
        Name    = null,
        Guid    = new(1265153742),
        Prefab  = "Recipe_Ingredient_ThickLeather",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Vampiricdust = new()
    {
        Name    = null,
        Guid    = new(311920560),
        Prefab  = "Recipe_Ingredient_Vampiricdust",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_Whetstone = new()
    {
        Name    = null,
        Guid    = new(-1490920585),
        Prefab  = "Recipe_Ingredient_Whetstone",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Ingredient_WoolThread = new()
    {
        Name    = null,
        Guid    = new(-387502181),
        Prefab  = "Recipe_Ingredient_WoolThread",
        NameKey = null,
        DescKey = null,
    };

    // ── Gem Crafting & Trader Recipes ─────────────────────────────────────────

    public static readonly PrefabDef Recipe_Gem_Amethyst_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-1101407057),
        Prefab  = "Recipe_Gem_Amethyst_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Amethyst_T02 = new()
    {
        Name    = null,
        Guid    = new(-439001894),
        Prefab  = "Recipe_Gem_Amethyst_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Amethyst_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(434649116),
        Prefab  = "Recipe_Gem_Amethyst_T02_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Amethyst_T03 = new()
    {
        Name    = null,
        Guid    = new(1447381920),
        Prefab  = "Recipe_Gem_Amethyst_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Amethyst_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(-85930173),
        Prefab  = "Recipe_Gem_Amethyst_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Emerald_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(777459323),
        Prefab  = "Recipe_Gem_Emerald_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Emerald_T02 = new()
    {
        Name    = null,
        Guid    = new(301294529),
        Prefab  = "Recipe_Gem_Emerald_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Emerald_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(194379742),
        Prefab  = "Recipe_Gem_Emerald_T02_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Emerald_T03 = new()
    {
        Name    = null,
        Guid    = new(349993374),
        Prefab  = "Recipe_Gem_Emerald_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Emerald_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(-71067907),
        Prefab  = "Recipe_Gem_Emerald_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_MistStone_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-1882174403),
        Prefab  = "Recipe_Gem_MistStone_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_MistStone_T02 = new()
    {
        Name    = null,
        Guid    = new(1692364442),
        Prefab  = "Recipe_Gem_MistStone_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_MistStone_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(1550840254),
        Prefab  = "Recipe_Gem_MistStone_T02_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_MistStone_T03 = new()
    {
        Name    = null,
        Guid    = new(-1932461468),
        Prefab  = "Recipe_Gem_MistStone_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_MistStone_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(2025196283),
        Prefab  = "Recipe_Gem_MistStone_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Ruby_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(2003589362),
        Prefab  = "Recipe_Gem_Ruby_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Ruby_T02 = new()
    {
        Name    = null,
        Guid    = new(1058500365),
        Prefab  = "Recipe_Gem_Ruby_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Ruby_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(11460503),
        Prefab  = "Recipe_Gem_Ruby_T02_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Ruby_T03 = new()
    {
        Name    = null,
        Guid    = new(640226225),
        Prefab  = "Recipe_Gem_Ruby_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Ruby_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(-484624052),
        Prefab  = "Recipe_Gem_Ruby_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Sapphire_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(1469919230),
        Prefab  = "Recipe_Gem_Sapphire_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Sapphire_T02 = new()
    {
        Name    = null,
        Guid    = new(1944880503),
        Prefab  = "Recipe_Gem_Sapphire_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Sapphire_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(231142834),
        Prefab  = "Recipe_Gem_Sapphire_T02_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Sapphire_T03 = new()
    {
        Name    = null,
        Guid    = new(1627234060),
        Prefab  = "Recipe_Gem_Sapphire_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Sapphire_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(571367805),
        Prefab  = "Recipe_Gem_Sapphire_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Topaz_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(1741718241),
        Prefab  = "Recipe_Gem_Topaz_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Topaz_T02 = new()
    {
        Name    = null,
        Guid    = new(-1954352551),
        Prefab  = "Recipe_Gem_Topaz_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Topaz_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(1903291770),
        Prefab  = "Recipe_Gem_Topaz_T02_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Topaz_T03 = new()
    {
        Name    = null,
        Guid    = new(-755095440),
        Prefab  = "Recipe_Gem_Topaz_T03",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Gem_Topaz_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(595424808),
        Prefab  = "Recipe_Gem_Topaz_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    // ── Blood Essence Recipes ─────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_BloodEssence_PristineHeart = new()
    {
        Name    = null,
        Guid    = new(937701215),
        Prefab  = "Recipe_BloodEssence_PristineHeart",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_BloodEssence_Rat = new()
    {
        Name    = null,
        Guid    = new(-112456787),
        Prefab  = "Recipe_BloodEssence_Rat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_BloodEssence_TaintedHeart = new()
    {
        Name    = null,
        Guid    = new(-1619521520),
        Prefab  = "Recipe_BloodEssence_TaintedHeart",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_BloodEssence_UnsulliedHeart = new()
    {
        Name    = null,
        Guid    = new(-626789771),
        Prefab  = "Recipe_BloodEssence_UnsulliedHeart",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_BloodEssence_Upgrade_T02 = new()
    {
        Name    = null,
        Guid    = new(335190592),
        Prefab  = "Recipe_BloodEssence_Upgrade_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_BloodEssence_Upgrade_T03 = new()
    {
        Name    = null,
        Guid    = new(-2050480946),
        Prefab  = "Recipe_BloodEssence_Upgrade_T03",
        NameKey = null,
        DescKey = null,
    };
}