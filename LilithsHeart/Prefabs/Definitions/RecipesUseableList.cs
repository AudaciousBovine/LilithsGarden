// ============================================================
//  RecipesUsableList — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/RecipesUsableList.cs
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

public static class RecipesUsableList
{
    // ── Consumables ───────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Consumable_BarrelDisguise01 = new()
    {
        Name    = null,
        Guid    = new(-108869773),
        Prefab  = "Recipe_Consumable_BarrelDisguise01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_DuskCaller = new()
    {
        Name    = null,
        Guid    = new(232213040),
        Prefab  = "Recipe_Consumable_DuskCaller",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_EMP_T01 = new()
    {
        Name    = null,
        Guid    = new(164757222),
        Prefab  = "Recipe_Consumable_EMP_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_EmptyBottle_T02_Crafting = new()
    {
        Name    = null,
        Guid    = new(-97893307),
        Prefab  = "Recipe_Consumable_EmptyBottle_T02_Crafting",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_EmptyBottle_T02_Refinement = new()
    {
        Name    = null,
        Guid    = new(461575192),
        Prefab  = "Recipe_Consumable_EmptyBottle_T02_Refinement",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Explosives_Major_T02 = new()
    {
        Name    = null,
        Guid    = new(-1848951671),
        Prefab  = "Recipe_Consumable_Explosives_Major_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Explosives_Major_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(-752799345),
        Prefab  = "Recipe_Consumable_Explosives_Major_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Explosives_Minor_T01 = new()
    {
        Name    = null,
        Guid    = new(-854411210),
        Prefab  = "Recipe_Consumable_Explosives_Minor_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Explosives_Minor_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-149394540),
        Prefab  = "Recipe_Consumable_Explosives_Minor_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_FireResistancePotion_T01 = new()
    {
        Name    = null,
        Guid    = new(-1265439368),
        Prefab  = "Recipe_Consumable_FireResistancePotion_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_GarlicResistancePotion_T01 = new()
    {
        Name    = null,
        Guid    = new(1602635578),
        Prefab  = "Recipe_Consumable_GarlicResistancePotion_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_GarlicResistancePotion_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-767965323),
        Prefab  = "Recipe_Consumable_GarlicResistancePotion_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_GarlicResistancePotion_T02 = new()
    {
        Name    = null,
        Guid    = new(600697104),
        Prefab  = "Recipe_Consumable_GarlicResistancePotion_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_GarlicResistancePotion_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(177026075),
        Prefab  = "Recipe_Consumable_GarlicResistancePotion_T02_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_HealingPotion_T01 = new()
    {
        Name    = null,
        Guid    = new(223228069),
        Prefab  = "Recipe_Consumable_HealingPotion_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_HealingPotion_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(1446468348),
        Prefab  = "Recipe_Consumable_HealingPotion_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_HealingPotion_T02 = new()
    {
        Name    = null,
        Guid    = new(-1715555190),
        Prefab  = "Recipe_Consumable_HealingPotion_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_HealingPotion_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(-1089714492),
        Prefab  = "Recipe_Consumable_HealingPotion_T02_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_HolyResistancePotion_T01 = new()
    {
        Name    = null,
        Guid    = new(2121527776),
        Prefab  = "Recipe_Consumable_HolyResistancePotion_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_HolyResistancePotion_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(573978764),
        Prefab  = "Recipe_Consumable_HolyResistancePotion_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_HolyResistancePotion_T02 = new()
    {
        Name    = null,
        Guid    = new(-1672850870),
        Prefab  = "Recipe_Consumable_HolyResistancePotion_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_IrradiantGruel = new()
    {
        Name    = null,
        Guid    = new(-1031042460),
        Prefab  = "Recipe_Consumable_IrradiantGruel",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_PhysicalPowerPotion_T01 = new()
    {
        Name    = null,
        Guid    = new(2007269714),
        Prefab  = "Recipe_Consumable_PhysicalPowerPotion_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_PhysicalPowerPotion_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-1373956725),
        Prefab  = "Recipe_Consumable_PhysicalPowerPotion_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_PhysicalPowerPotion_T02 = new()
    {
        Name    = null,
        Guid    = new(-1336809713),
        Prefab  = "Recipe_Consumable_PhysicalPowerPotion_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_PrisonPotion = new()
    {
        Name    = null,
        Guid    = new(1839006118),
        Prefab  = "Recipe_Consumable_PrisonPotion",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_PrisonPotion_Bloodwine = new()
    {
        Name    = null,
        Guid    = new(1930190516),
        Prefab  = "Recipe_Consumable_PrisonPotion_Bloodwine",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Rat = new()
    {
        Name    = null,
        Guid    = new(-1521588244),
        Prefab  = "Recipe_Consumable_Rat",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Salve_Vermin = new()
    {
        Name    = null,
        Guid    = new(2119570180),
        Prefab  = "Recipe_Consumable_Salve_Vermin",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Siege_StoneGolem_T02 = new()
    {
        Name    = null,
        Guid    = new(-2012301598),
        Prefab  = "Recipe_Consumable_Siege_StoneGolem_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_SilverResistancePotion_T01 = new()
    {
        Name    = null,
        Guid    = new(-1391967609),
        Prefab  = "Recipe_Consumable_SilverResistancePotion_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_SilverResistancePotion_T02 = new()
    {
        Name    = null,
        Guid    = new(-878651797),
        Prefab  = "Recipe_Consumable_SilverResistancePotion_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_SpellPowerPotion_T01 = new()
    {
        Name    = null,
        Guid    = new(1292082146),
        Prefab  = "Recipe_Consumable_SpellPowerPotion_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_SpellPowerPotion_T02 = new()
    {
        Name    = null,
        Guid    = new(-739203329),
        Prefab  = "Recipe_Consumable_SpellPowerPotion_T02",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_SunResistancePotion_T01 = new()
    {
        Name    = null,
        Guid    = new(-339125757),
        Prefab  = "Recipe_Consumable_SunResistancePotion_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Waterskin_Leather_Crafting = new()
    {
        Name    = null,
        Guid    = new(-1609862569),
        Prefab  = "Recipe_Consumable_Waterskin_Leather_Crafting",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Waterskin_Leather_Refinement = new()
    {
        Name    = null,
        Guid    = new(37553703),
        Prefab  = "Recipe_Consumable_Waterskin_Leather_Refinement",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Waterskin_ThickLeather_Crafting = new()
    {
        Name    = null,
        Guid    = new(-457097974),
        Prefab  = "Recipe_Consumable_Waterskin_ThickLeather_Crafting",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_Waterskin_ThickLeather_Refinement = new()
    {
        Name    = null,
        Guid    = new(882503740),
        Prefab  = "Recipe_Consumable_Waterskin_ThickLeather_Refinement",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Consumable_WranglerPotion_T01 = new()
    {
        Name    = null,
        Guid    = new(-1728254159),
        Prefab  = "Recipe_Consumable_WranglerPotion_T01",
        NameKey = null,
        DescKey = null,
    };

    // ── Duel Flag ─────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_DuelFlag = new()
    {
        Name    = null,
        Guid    = new(-728009045),
        Prefab  = "Recipe_DuelFlag",
        NameKey = null,
        DescKey = null,
    };

    // ── Elixirs ───────────────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Elixir_Bat_T01 = new()
    {
        Name    = null,
        Guid    = new(-1617853548),
        Prefab  = "Recipe_Elixir_Bat_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Elixir_Beast_T01 = new()
    {
        Name    = null,
        Guid    = new(-663811339),
        Prefab  = "Recipe_Elixir_Beast_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Elixir_Blasphemous_T01 = new()
    {
        Name    = null,
        Guid    = new(654360877),
        Prefab  = "Recipe_Elixir_Blasphemous_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Elixir_Crow_T01 = new()
    {
        Name    = null,
        Guid    = new(155374920),
        Prefab  = "Recipe_Elixir_Crow_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Elixir_Prowler_T01 = new()
    {
        Name    = null,
        Guid    = new(79253993),
        Prefab  = "Recipe_Elixir_Prowler_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Elixir_Raven_T01 = new()
    {
        Name    = null,
        Guid    = new(-109469679),
        Prefab  = "Recipe_Elixir_Raven_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Elixir_Twisted_T01 = new()
    {
        Name    = null,
        Guid    = new(-2138549072),
        Prefab  = "Recipe_Elixir_Twisted_T01",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Elixir_Werewolf_T01 = new()
    {
        Name    = null,
        Guid    = new(198966224),
        Prefab  = "Recipe_Elixir_Werewolf_T01",
        NameKey = null,
        DescKey = null,
    };

    // ── Weapon Coatings ───────────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_WeaponCoating_Blood = new()
    {
        Name    = null,
        Guid    = new(-1487423952),
        Prefab  = "Recipe_WeaponCoating_Blood",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_WeaponCoating_Chaos = new()
    {
        Name    = null,
        Guid    = new(-338717708),
        Prefab  = "Recipe_WeaponCoating_Chaos",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_WeaponCoating_Frost = new()
    {
        Name    = null,
        Guid    = new(-789668816),
        Prefab  = "Recipe_WeaponCoating_Frost",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_WeaponCoating_Illusion = new()
    {
        Name    = null,
        Guid    = new(405829513),
        Prefab  = "Recipe_WeaponCoating_Illusion",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_WeaponCoating_Storm = new()
    {
        Name    = null,
        Guid    = new(-2034775483),
        Prefab  = "Recipe_WeaponCoating_Storm",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_WeaponCoating_Unholy = new()
    {
        Name    = null,
        Guid    = new(216972181),
        Prefab  = "Recipe_WeaponCoating_Unholy",
        NameKey = null,
        DescKey = null,
    };

    // ── Seed Trader Recipes ───────────────────────────────────────────────────

    public static readonly PrefabDef Recipe_Seed_BloodRose_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(1930056104),
        Prefab  = "Recipe_Seed_BloodRose_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Seed_FireBlossom_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-693582888),
        Prefab  = "Recipe_Seed_FireBlossom_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Seed_GhostShroom_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(-56026974),
        Prefab  = "Recipe_Seed_GhostShroom_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Seed_HellsClarion_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-1079722820),
        Prefab  = "Recipe_Seed_HellsClarion_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Seed_Lotus_T03_Trader = new()
    {
        Name    = null,
        Guid    = new(-1660279142),
        Prefab  = "Recipe_Seed_Lotus_T03_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Seed_MourningLily_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(-1271741418),
        Prefab  = "Recipe_Seed_MourningLily_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Seed_SnowFlower_T01_Trader = new()
    {
        Name    = null,
        Guid    = new(640919389),
        Prefab  = "Recipe_Seed_SnowFlower_T01_Trader",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Recipe_Seed_SunFlower_T02_Trader = new()
    {
        Name    = null,
        Guid    = new(-486247420),
        Prefab  = "Recipe_Seed_SunFlower_T02_Trader",
        NameKey = null,
        DescKey = null,
    };
}