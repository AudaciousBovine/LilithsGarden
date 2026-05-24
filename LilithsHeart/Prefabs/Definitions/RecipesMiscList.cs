// ============================================================
//  RecipesMiscList — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/RecipesMiscList.cs
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

public static class RecipesMiscList
{
    // ── Castle Upkeep ─────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_CastleUpkeep_T01 = new()
    {
        Name    = null,
        Guid    = new(155119506),
        Prefab  = "Recipe_CastleUpkeep_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_CastleUpkeep_T02 = new()
    {
        Name    = null,
        Guid    = new(-1281672171),
        Prefab  = "Recipe_CastleUpkeep_T02",
        NameKey = null,
        DescKey = null,
    };

    // ── Fake / Internal ───────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Fake_DO_NOT_ADD_BloodTracking = new()
    {
        Name    = null,
        Guid    = new(-726644851),
        Prefab  = "Recipe_Fake_DO_NOT_ADD_BloodTracking",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Fake_DO_NOT_ADD_ShardBearerTracking = new()
    {
        Name    = null,
        Guid    = new(-1431813390),
        Prefab  = "Recipe_Fake_DO_NOT_ADD_ShardBearerTracking",
        NameKey = null,
        DescKey = null,
    };

    // ── Fusion Forge ──────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_FusionForge_FuseJewel = new()
    {
        Name    = null,
        Guid    = new(-664369931),
        Prefab  = "Recipe_FusionForge_FuseJewel",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_FusionForge_FuseWeapon = new()
    {
        Name    = null,
        Guid    = new(1716898700),
        Prefab  = "Recipe_FusionForge_FuseWeapon",
        NameKey = null,
        DescKey = null,
    };

    // ── Prisoner Interactions ─────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Misc_ExtractEssencePrisoner = new()
    {
        Name    = null,
        Guid    = new(1716338316),
        Prefab  = "Recipe_Misc_ExtractEssencePrisoner",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_BloodSnapper = new()
    {
        Name    = null,
        Guid    = new(956953141),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_BloodSnapper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_Corrupted = new()
    {
        Name    = null,
        Guid    = new(493259323),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_Corrupted",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_FatGoby = new()
    {
        Name    = null,
        Guid    = new(-2047246570),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_FatGoby",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_FierceStinger = new()
    {
        Name    = null,
        Guid    = new(-37587809),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_FierceStinger",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_GoldenRiverBass = new()
    {
        Name    = null,
        Guid    = new(1816434122),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_GoldenRiverBass",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_RainbowTrout = new()
    {
        Name    = null,
        Guid    = new(-1206171767),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_RainbowTrout",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_SageFish = new()
    {
        Name    = null,
        Guid    = new(1800570390),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_SageFish",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_SwampDweller = new()
    {
        Name    = null,
        Guid    = new(-460272822),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_SwampDweller",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Fish_TwilightSnapper = new()
    {
        Name    = null,
        Guid    = new(-252411567),
        Prefab  = "Recipe_Misc_FeedPrisoner_Fish_TwilightSnapper",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_IrradiantGruel = new()
    {
        Name    = null,
        Guid    = new(-279936313),
        Prefab  = "Recipe_Misc_FeedPrisoner_IrradiantGruel",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Misc_FeedPrisoner_Rat = new()
    {
        Name    = null,
        Guid    = new(1469101010),
        Prefab  = "Recipe_Misc_FeedPrisoner_Rat",
        NameKey = null,
        DescKey = null,
    };

    // ── Soul Shard ────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Soulshard_Extract_TheMonster = new()
    {
        Name    = null,
        Guid    = new(1743327679),
        Prefab  = "Recipe_Soulshard_Extract_TheMonster",
        NameKey = null,
        DescKey = null,
    };

    // ── Unit Spawns ───────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_UnitSpawn_Banshee = new()
    {
        Name    = null,
        Guid    = new(1065325546),
        Prefab  = "Recipe_UnitSpawn_Banshee",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_Ghoul = new()
    {
        Name    = null,
        Guid    = new(1470479508),
        Prefab  = "Recipe_UnitSpawn_Ghoul",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_GiantRat = new()
    {
        Name    = null,
        Guid    = new(-1953870432),
        Prefab  = "Recipe_UnitSpawn_GiantRat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_Mosquito = new()
    {
        Name    = null,
        Guid    = new(-614781206),
        Prefab  = "Recipe_UnitSpawn_Mosquito",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_Mutant = new()
    {
        Name    = null,
        Guid    = new(-591009330),
        Prefab  = "Recipe_UnitSpawn_Mutant",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_NetherDemon_T01_BloodSoul = new()
    {
        Name    = null,
        Guid    = new(286874232),
        Prefab  = "Recipe_UnitSpawn_NetherDemon_T01_BloodSoul",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_NetherDemon_T01_Knowledge = new()
    {
        Name    = null,
        Guid    = new(99503299),
        Prefab  = "Recipe_UnitSpawn_NetherDemon_T01_Knowledge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_NetherDemon_T01_Minerals = new()
    {
        Name    = null,
        Guid    = new(-1050470705),
        Prefab  = "Recipe_UnitSpawn_NetherDemon_T01_Minerals",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_NetherDemon_T01_Seed = new()
    {
        Name    = null,
        Guid    = new(535319065),
        Prefab  = "Recipe_UnitSpawn_NetherDemon_T01_Seed",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_NetherDemon_T02_Alchemy = new()
    {
        Name    = null,
        Guid    = new(-1555052563),
        Prefab  = "Recipe_UnitSpawn_NetherDemon_T02_Alchemy",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_NetherDemon_T02_BloodSoul = new()
    {
        Name    = null,
        Guid    = new(-1679457981),
        Prefab  = "Recipe_UnitSpawn_NetherDemon_T02_BloodSoul",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_NetherDemon_T02_Knowledge = new()
    {
        Name    = null,
        Guid    = new(-1569877264),
        Prefab  = "Recipe_UnitSpawn_NetherDemon_T02_Knowledge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_NetherDemon_T02_Minerals = new()
    {
        Name    = null,
        Guid    = new(329917761),
        Prefab  = "Recipe_UnitSpawn_NetherDemon_T02_Minerals",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_PutridRat = new()
    {
        Name    = null,
        Guid    = new(-753029646),
        Prefab  = "Recipe_UnitSpawn_PutridRat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_Rat = new()
    {
        Name    = null,
        Guid    = new(255936441),
        Prefab  = "Recipe_UnitSpawn_Rat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_Silkworm = new()
    {
        Name    = null,
        Guid    = new(-96946162),
        Prefab  = "Recipe_UnitSpawn_Silkworm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_Skeleton = new()
    {
        Name    = null,
        Guid    = new(365601143),
        Prefab  = "Recipe_UnitSpawn_Skeleton",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_SkeletonPriest = new()
    {
        Name    = null,
        Guid    = new(-2114825141),
        Prefab  = "Recipe_UnitSpawn_SkeletonPriest",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_UnitSpawn_Spiderling = new()
    {
        Name    = null,
        Guid    = new(1172635875),
        Prefab  = "Recipe_UnitSpawn_Spiderling",
        NameKey = null,
        DescKey = null,
    };
}