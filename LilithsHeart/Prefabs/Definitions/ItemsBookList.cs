// ============================================================
//  ItemsBookList — Part 1 of 3 — LilithsHeart
//  LilithsHeart/Prefabs/Definitions/ItemsBookList.cs
//
//  [CHANGED] Migrated from bare PrefabGUID fields to PrefabDef records.
//            Field names match the prefab string exactly. No comments or
//            [PrefabName] attributes were present in the source — Name is
//            null throughout until looked up from game data.
//            All nullable fields shown explicitly.
//
//  Parts: 1 — Armor Books (Boots, Chest, Gloves, Legs)
//         2 — Consumable, Floor, MagicSource, Structure Books
//         3 — Weapon Books, Passive T01 & T02
//
//  [PERFORMANCE] Static readonly PrefabDef fields — initialised once at
//                class load, zero per-frame cost. Stack-allocated structs,
//                no heap pressure.
// ============================================================

using Stunlock.Core;

namespace LilithsHeart.Prefabs.Definitions;

public static partial class ItemsBookList
{
    // ── Armor Books — Boots ───────────────────────────────────────────────────

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T04_Brute = new()
    {
        Name    = null,
        Guid    = new(362386181),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T04_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T04_Rogue = new()
    {
        Name    = null,
        Guid    = new(-383004511),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T04_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T04_Scholar = new()
    {
        Name    = null,
        Guid    = new(-1601304786),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T04_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T04_Warrior = new()
    {
        Name    = null,
        Guid    = new(-668460646),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T04_Warrior",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T06_Brute = new()
    {
        Name    = null,
        Guid    = new(1529216919),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T06_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T06_Rogue = new()
    {
        Name    = null,
        Guid    = new(762038154),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T06_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T06_Scholar = new()
    {
        Name    = null,
        Guid    = new(-1147510581),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T06_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T06_Warrior = new()
    {
        Name    = null,
        Guid    = new(-1788912715),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T06_Warrior",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T08_Brute = new()
    {
        Name    = null,
        Guid    = new(-534142437),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T08_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T08_Rogue = new()
    {
        Name    = null,
        Guid    = new(-706178162),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T08_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T08_Scholar = new()
    {
        Name    = null,
        Guid    = new(-1958602686),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T08_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Boots_T08_Warrior = new()
    {
        Name    = null,
        Guid    = new(1192629421),
        Prefab  = "Item_Ingredient_Book_Armor_Boots_T08_Warrior",
        NameKey = null,
        DescKey = null,
    };

    // ── Armor Books — Chest ───────────────────────────────────────────────────

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T04_Brute = new()
    {
        Name    = null,
        Guid    = new(1850873910),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T04_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T04_Rogue = new()
    {
        Name    = null,
        Guid    = new(-849449432),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T04_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T04_Scholar = new()
    {
        Name    = null,
        Guid    = new(2025615662),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T04_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T04_Warrior = new()
    {
        Name    = null,
        Guid    = new(1753801067),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T04_Warrior",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T06_Brute = new()
    {
        Name    = null,
        Guid    = new(626083889),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T06_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T06_Rogue = new()
    {
        Name    = null,
        Guid    = new(-1595316636),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T06_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T06_Scholar = new()
    {
        Name    = null,
        Guid    = new(-2066262923),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T06_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T06_Warrior = new()
    {
        Name    = null,
        Guid    = new(1561721357),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T06_Warrior",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T08_Brute = new()
    {
        Name    = null,
        Guid    = new(-1261118965),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T08_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T08_Rogue = new()
    {
        Name    = null,
        Guid    = new(502133568),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T08_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T08_Scholar = new()
    {
        Name    = null,
        Guid    = new(-1840162782),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T08_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Chest_T08_Warrior = new()
    {
        Name    = null,
        Guid    = new(-1161279574),
        Prefab  = "Item_Ingredient_Book_Armor_Chest_T08_Warrior",
        NameKey = null,
        DescKey = null,
    };

    // ── Armor Books — Gloves ──────────────────────────────────────────────────

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T04_Brute = new()
    {
        Name    = null,
        Guid    = new(-764630320),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T04_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T04_Rogue = new()
    {
        Name    = null,
        Guid    = new(1014370193),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T04_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T04_Scholar = new()
    {
        Name    = null,
        Guid    = new(1840869087),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T04_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T04_Warrior = new()
    {
        Name    = null,
        Guid    = new(-1242910338),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T04_Warrior",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T06_Brute = new()
    {
        Name    = null,
        Guid    = new(-1344118299),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T06_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T06_Rogue = new()
    {
        Name    = null,
        Guid    = new(735880687),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T06_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T06_Scholar = new()
    {
        Name    = null,
        Guid    = new(-46006079),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T06_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T06_Warrior = new()
    {
        Name    = null,
        Guid    = new(-777417289),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T06_Warrior",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T08_Brute = new()
    {
        Name    = null,
        Guid    = new(2020764183),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T08_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T08_Rogue = new()
    {
        Name    = null,
        Guid    = new(1485993952),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T08_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T08_Scholar = new()
    {
        Name    = null,
        Guid    = new(-1512099553),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T08_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Gloves_T08_Warrior = new()
    {
        Name    = null,
        Guid    = new(-196284663),
        Prefab  = "Item_Ingredient_Book_Armor_Gloves_T08_Warrior",
        NameKey = null,
        DescKey = null,
    };

    // ── Armor Books — Legs ────────────────────────────────────────────────────

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T04_Brute = new()
    {
        Name    = null,
        Guid    = new(1172935197),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T04_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T04_Rogue = new()
    {
        Name    = null,
        Guid    = new(1364444719),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T04_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T04_Scholar = new()
    {
        Name    = null,
        Guid    = new(-117205517),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T04_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T04_Warrior = new()
    {
        Name    = null,
        Guid    = new(347441899),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T04_Warrior",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T06_Brute = new()
    {
        Name    = null,
        Guid    = new(1328323768),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T06_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T06_Rogue = new()
    {
        Name    = null,
        Guid    = new(1912738568),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T06_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T06_Scholar = new()
    {
        Name    = null,
        Guid    = new(-595456862),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T06_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T06_Warrior = new()
    {
        Name    = null,
        Guid    = new(-1718233147),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T06_Warrior",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T08_Brute = new()
    {
        Name    = null,
        Guid    = new(-996201260),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T08_Brute",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T08_Rogue = new()
    {
        Name    = null,
        Guid    = new(-1260890289),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T08_Rogue",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T08_Scholar = new()
    {
        Name    = null,
        Guid    = new(-2049321404),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T08_Scholar",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef Item_Ingredient_Book_Armor_Legs_T08_Warrior = new()
    {
        Name    = null,
        Guid    = new(-2104396934),
        Prefab  = "Item_Ingredient_Book_Armor_Legs_T08_Warrior",
        NameKey = null,
        DescKey = null,
    };
    // ── Consumable Books ──────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_BloodRoseBrew_T01 = new()
    {
        Name    = null,
        Guid    = new(-895015382),
        Prefab  = "Item_Ingredient_Book_Consumable_BloodRoseBrew_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_FireResistance_T02 = new()
    {
        Name    = null,
        Guid    = new(2114304481),
        Prefab  = "Item_Ingredient_Book_Consumable_FireResistance_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_GarlicResistance_T02 = new()
    {
        Name    = null,
        Guid    = new(791584738),
        Prefab  = "Item_Ingredient_Book_Consumable_GarlicResistance_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_PhysicalPower_T01 = new()
    {
        Name    = null,
        Guid    = new(1556544548),
        Prefab  = "Item_Ingredient_Book_Consumable_PhysicalPower_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_PhysicalPower_T03 = new()
    {
        Name    = null,
        Guid    = new(-2013887729),
        Prefab  = "Item_Ingredient_Book_Consumable_PhysicalPower_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_SilverBrew_T01 = new()
    {
        Name    = null,
        Guid    = new(-1269116849),
        Prefab  = "Item_Ingredient_Book_Consumable_SilverBrew_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_SpellPower_T01 = new()
    {
        Name    = null,
        Guid    = new(492964298),
        Prefab  = "Item_Ingredient_Book_Consumable_SpellPower_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_SpellPower_T03 = new()
    {
        Name    = null,
        Guid    = new(-1563178470),
        Prefab  = "Item_Ingredient_Book_Consumable_SpellPower_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_SunResistance_T01 = new()
    {
        Name    = null,
        Guid    = new(756555009),
        Prefab  = "Item_Ingredient_Book_Consumable_SunResistance_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Consumable_Wranglers_T02 = new()
    {
        Name    = null,
        Guid    = new(-1242947472),
        Prefab  = "Item_Ingredient_Book_Consumable_Wranglers_T02",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Floor Books ───────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Book_Floor_AlchemyLab = new()
    {
        Name    = null,
        Guid    = new(978074988),
        Prefab  = "Item_Ingredient_Book_Floor_AlchemyLab",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Floor_Forge = new()
    {
        Name    = null,
        Guid    = new(-1233700610),
        Prefab  = "Item_Ingredient_Book_Floor_Forge",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Floor_Jewelcrafting = new()
    {
        Name    = null,
        Guid    = new(626118128),
        Prefab  = "Item_Ingredient_Book_Floor_Jewelcrafting",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Floor_Library = new()
    {
        Name    = null,
        Guid    = new(-946177070),
        Prefab  = "Item_Ingredient_Book_Floor_Library",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Floor_Prison = new()
    {
        Name    = null,
        Guid    = new(1718353003),
        Prefab  = "Item_Ingredient_Book_Floor_Prison",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Floor_Tailor = new()
    {
        Name    = null,
        Guid    = new(-137886670),
        Prefab  = "Item_Ingredient_Book_Floor_Tailor",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Floor_Workshop = new()
    {
        Name    = null,
        Guid    = new(1906638073),
        Prefab  = "Item_Ingredient_Book_Floor_Workshop",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Interior_Planters = new()
    {
        Name    = null,
        Guid    = new(1336896559),
        Prefab  = "Item_Ingredient_Book_Interior_Planters",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Magic Source Books — T04 ──────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T04_Duskwatcher = new()
    {
        Name    = null,
        Guid    = new(-293419350),
        Prefab  = "Item_Ingredient_Book_MagicSource_T04_Duskwatcher",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T04_EmberChain = new()
    {
        Name    = null,
        Guid    = new(-1542642288),
        Prefab  = "Item_Ingredient_Book_MagicSource_T04_EmberChain",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T04_FrozenEye = new()
    {
        Name    = null,
        Guid    = new(-1913800363),
        Prefab  = "Item_Ingredient_Book_MagicSource_T04_FrozenEye",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T04_MistSignet = new()
    {
        Name    = null,
        Guid    = new(1310923765),
        Prefab  = "Item_Ingredient_Book_MagicSource_T04_MistSignet",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T04_RubyRing = new()
    {
        Name    = null,
        Guid    = new(350769859),
        Prefab  = "Item_Ingredient_Book_MagicSource_T04_RubyRing",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T04_SorcererRing = new()
    {
        Name    = null,
        Guid    = new(1458090717),
        Prefab  = "Item_Ingredient_Book_MagicSource_T04_SorcererRing",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Magic Source Books — T06 ──────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T06_AmethystPendant = new()
    {
        Name    = null,
        Guid    = new(587164554),
        Prefab  = "Item_Ingredient_Book_MagicSource_T06_AmethystPendant",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T06_EmeraldNecklace = new()
    {
        Name    = null,
        Guid    = new(-224716062),
        Prefab  = "Item_Ingredient_Book_MagicSource_T06_EmeraldNecklace",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T06_MistStoneNecklace = new()
    {
        Name    = null,
        Guid    = new(759775881),
        Prefab  = "Item_Ingredient_Book_MagicSource_T06_MistStoneNecklace",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T06_RubyPendant = new()
    {
        Name    = null,
        Guid    = new(-1658630722),
        Prefab  = "Item_Ingredient_Book_MagicSource_T06_RubyPendant",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T06_SapphirePendant = new()
    {
        Name    = null,
        Guid    = new(1939500376),
        Prefab  = "Item_Ingredient_Book_MagicSource_T06_SapphirePendant",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T06_TopazAmulet = new()
    {
        Name    = null,
        Guid    = new(1474515294),
        Prefab  = "Item_Ingredient_Book_MagicSource_T06_TopazAmulet",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Magic Source Books — T08 ──────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T08_Beast = new()
    {
        Name    = null,
        Guid    = new(1702347530),
        Prefab  = "Item_Ingredient_Book_MagicSource_T08_Beast",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T08_CrimsonSky = new()
    {
        Name    = null,
        Guid    = new(-1063966176),
        Prefab  = "Item_Ingredient_Book_MagicSource_T08_CrimsonSky",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T08_Delusion = new()
    {
        Name    = null,
        Guid    = new(-1803818846),
        Prefab  = "Item_Ingredient_Book_MagicSource_T08_Delusion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T08_FrozenCrypt = new()
    {
        Name    = null,
        Guid    = new(-749171183),
        Prefab  = "Item_Ingredient_Book_MagicSource_T08_FrozenCrypt",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T08_Madness = new()
    {
        Name    = null,
        Guid    = new(-1424521314),
        Prefab  = "Item_Ingredient_Book_MagicSource_T08_Madness",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_MagicSource_T08_WickedProphet = new()
    {
        Name    = null,
        Guid    = new(860383634),
        Prefab  = "Item_Ingredient_Book_MagicSource_T08_WickedProphet",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Structure Books ───────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_ArtisanTable = new()
    {
        Name    = null,
        Guid    = new(-1221174479),
        Prefab  = "Item_Ingredient_Book_Structure_ArtisanTable",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Braziers_T02 = new()
    {
        Name    = null,
        Guid    = new(742900616),
        Prefab  = "Item_Ingredient_Book_Structure_Braziers_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Braziers_T03 = new()
    {
        Name    = null,
        Guid    = new(835610037),
        Prefab  = "Item_Ingredient_Book_Structure_Braziers_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_CandleStands_T02 = new()
    {
        Name    = null,
        Guid    = new(1341367867),
        Prefab  = "Item_Ingredient_Book_Structure_CandleStands_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Carpets_T01 = new()
    {
        Name    = null,
        Guid    = new(1383064284),
        Prefab  = "Item_Ingredient_Book_Structure_Carpets_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Carpets_T02_Dux = new()
    {
        Name    = null,
        Guid    = new(-96701352),
        Prefab  = "Item_Ingredient_Book_Structure_Carpets_T02_Dux",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Carpets_T03_Distinguished = new()
    {
        Name    = null,
        Guid    = new(-1696677607),
        Prefab  = "Item_Ingredient_Book_Structure_Carpets_T03_Distinguished",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Chairs_Desk_T02 = new()
    {
        Name    = null,
        Guid    = new(389446538),
        Prefab  = "Item_Ingredient_Book_Structure_Chairs_Desk_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Chairs_Red_T02 = new()
    {
        Name    = null,
        Guid    = new(-1929817673),
        Prefab  = "Item_Ingredient_Book_Structure_Chairs_Red_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Curtains_T03_Royal = new()
    {
        Name    = null,
        Guid    = new(285318201),
        Prefab  = "Item_Ingredient_Book_Structure_Curtains_T03_Royal",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Desks_T02 = new()
    {
        Name    = null,
        Guid    = new(-840839363),
        Prefab  = "Item_Ingredient_Book_Structure_Desks_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_DressingTablesFoldingWalls_T03 = new()
    {
        Name    = null,
        Guid    = new(-1676748911),
        Prefab  = "Item_Ingredient_Book_Structure_DressingTablesFoldingWalls_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_EnchantedTorches = new()
    {
        Name    = null,
        Guid    = new(879103343),
        Prefab  = "Item_Ingredient_Book_Structure_EnchantedTorches",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_FenceFountains_T02 = new()
    {
        Name    = null,
        Guid    = new(679755989),
        Prefab  = "Item_Ingredient_Book_Structure_FenceFountains_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Fireplaces_T02 = new()
    {
        Name    = null,
        Guid    = new(-946597284),
        Prefab  = "Item_Ingredient_Book_Structure_Fireplaces_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_FlyingCandles_T03 = new()
    {
        Name    = null,
        Guid    = new(1594270493),
        Prefab  = "Item_Ingredient_Book_Structure_FlyingCandles_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Fountain_T03 = new()
    {
        Name    = null,
        Guid    = new(-1171060793),
        Prefab  = "Item_Ingredient_Book_Structure_Fountain_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_GardenFurniture_T02 = new()
    {
        Name    = null,
        Guid    = new(-1060453249),
        Prefab  = "Item_Ingredient_Book_Structure_GardenFurniture_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_GardenLampPosts_T03 = new()
    {
        Name    = null,
        Guid    = new(776216743),
        Prefab  = "Item_Ingredient_Book_Structure_GardenLampPosts_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_GardenPlanters_T01 = new()
    {
        Name    = null,
        Guid    = new(1307976528),
        Prefab  = "Item_Ingredient_Book_Structure_GardenPlanters_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_GardenPlanters_T02 = new()
    {
        Name    = null,
        Guid    = new(-1383718976),
        Prefab  = "Item_Ingredient_Book_Structure_GardenPlanters_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_GardenPlanters_T03 = new()
    {
        Name    = null,
        Guid    = new(-1645899934),
        Prefab  = "Item_Ingredient_Book_Structure_GardenPlanters_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_HangingLanterns_T02 = new()
    {
        Name    = null,
        Guid    = new(-452767162),
        Prefab  = "Item_Ingredient_Book_Structure_HangingLanterns_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Paintings_T01 = new()
    {
        Name    = null,
        Guid    = new(38319072),
        Prefab  = "Item_Ingredient_Book_Structure_Paintings_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Path_Cobblestone_T02 = new()
    {
        Name    = null,
        Guid    = new(2094602185),
        Prefab  = "Item_Ingredient_Book_Structure_Path_Cobblestone_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Path_Dirt_T01 = new()
    {
        Name    = null,
        Guid    = new(-94650344),
        Prefab  = "Item_Ingredient_Book_Structure_Path_Dirt_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_PillarBanners_T02 = new()
    {
        Name    = null,
        Guid    = new(-1321865795),
        Prefab  = "Item_Ingredient_Book_Structure_PillarBanners_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Sofas_T03 = new()
    {
        Name    = null,
        Guid    = new(2053574378),
        Prefab  = "Item_Ingredient_Book_Structure_Sofas_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_StoneOrnaments_T01 = new()
    {
        Name    = null,
        Guid    = new(-449615886),
        Prefab  = "Item_Ingredient_Book_Structure_StoneOrnaments_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Alchemy_T02 = new()
    {
        Name    = null,
        Guid    = new(11798247),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Alchemy_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Alchemy_T03 = new()
    {
        Name    = null,
        Guid    = new(-67943596),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Alchemy_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Armor_T02 = new()
    {
        Name    = null,
        Guid    = new(207381334),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Armor_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_BloodCase_T02 = new()
    {
        Name    = null,
        Guid    = new(-130369231),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_BloodCase_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_BloodCase_T03 = new()
    {
        Name    = null,
        Guid    = new(489001758),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_BloodCase_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Coins_T02 = new()
    {
        Name    = null,
        Guid    = new(-832387204),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Coins_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Consumable_T02 = new()
    {
        Name    = null,
        Guid    = new(-1624005683),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Consumable_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Consumable_T03 = new()
    {
        Name    = null,
        Guid    = new(824237901),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Consumable_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Fishing_T02 = new()
    {
        Name    = null,
        Guid    = new(-205820651),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Fishing_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Gems_T01 = new()
    {
        Name    = null,
        Guid    = new(1455590675),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Gems_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Gems_T02 = new()
    {
        Name    = null,
        Guid    = new(1150376281),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Gems_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Herbs_T01 = new()
    {
        Name    = null,
        Guid    = new(-853559619),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Herbs_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Herbs_T02 = new()
    {
        Name    = null,
        Guid    = new(473545520),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Herbs_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Jewels_T02 = new()
    {
        Name    = null,
        Guid    = new(-1870194782),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Jewels_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Knowledge_T02 = new()
    {
        Name    = null,
        Guid    = new(-1394295910),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Knowledge_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Knowledge_T03 = new()
    {
        Name    = null,
        Guid    = new(1823379076),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Knowledge_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Minerals_T01 = new()
    {
        Name    = null,
        Guid    = new(-513865346),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Minerals_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Minerals_T02 = new()
    {
        Name    = null,
        Guid    = new(-1061940339),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Minerals_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Pack_Equipment_T02 = new()
    {
        Name    = null,
        Guid    = new(1249076837),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Pack_Equipment_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Pack_T01 = new()
    {
        Name    = null,
        Guid    = new(686122001),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Pack_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Pack_T02 = new()
    {
        Name    = null,
        Guid    = new(1519475093),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Pack_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_T01 = new()
    {
        Name    = null,
        Guid    = new(-651642571),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_T02 = new()
    {
        Name    = null,
        Guid    = new(-999518496),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_T03 = new()
    {
        Name    = null,
        Guid    = new(1691702273),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Tailoring_T02 = new()
    {
        Name    = null,
        Guid    = new(-1304625582),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Tailoring_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Tailoring_T03 = new()
    {
        Name    = null,
        Guid    = new(-63123159),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Tailoring_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Weapons_T02 = new()
    {
        Name    = null,
        Guid    = new(-1564741377),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Weapons_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Woodworking_T01 = new()
    {
        Name    = null,
        Guid    = new(1040245278),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Woodworking_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Storage_Woodworking_T02 = new()
    {
        Name    = null,
        Guid    = new(206151993),
        Prefab  = "Item_Ingredient_Book_Structure_Storage_Woodworking_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Tables_T02 = new()
    {
        Name    = null,
        Guid    = new(-1236809045),
        Prefab  = "Item_Ingredient_Book_Structure_Tables_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Vases_T01 = new()
    {
        Name    = null,
        Guid    = new(1428883363),
        Prefab  = "Item_Ingredient_Book_Structure_Vases_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Wallpaper_Bricks_T01 = new()
    {
        Name    = null,
        Guid    = new(-1957642407),
        Prefab  = "Item_Ingredient_Book_Structure_Wallpaper_Bricks_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Wallpaper_Classical_T03 = new()
    {
        Name    = null,
        Guid    = new(1884115881),
        Prefab  = "Item_Ingredient_Book_Structure_Wallpaper_Classical_T03",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Wallpaper_Cordial_T02 = new()
    {
        Name    = null,
        Guid    = new(-581757157),
        Prefab  = "Item_Ingredient_Book_Structure_Wallpaper_Cordial_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Wallpaper_Prison_T02 = new()
    {
        Name    = null,
        Guid    = new(-2086890414),
        Prefab  = "Item_Ingredient_Book_Structure_Wallpaper_Prison_T02",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Wallpaper_Stone_T01 = new()
    {
        Name    = null,
        Guid    = new(-2017255390),
        Prefab  = "Item_Ingredient_Book_Structure_Wallpaper_Stone_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Wallpaper_WoodPanel_T01 = new()
    {
        Name    = null,
        Guid    = new(-106224889),
        Prefab  = "Item_Ingredient_Book_Structure_Wallpaper_WoodPanel_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Well_T01 = new()
    {
        Name    = null,
        Guid    = new(-1205373095),
        Prefab  = "Item_Ingredient_Book_Structure_Well_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_Windows_T01 = new()
    {
        Name    = null,
        Guid    = new(1905539368),
        Prefab  = "Item_Ingredient_Book_Structure_Windows_T01",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Structure_WorkshopDecoration_T02 = new()
    {
        Name    = null,
        Guid    = new(1413772406),
        Prefab  = "Item_Ingredient_Book_Structure_WorkshopDecoration_T02",
        NameKey = null,
        DescKey = null,
    };
//  Covers: Weapon Books, Passive T01 & T02
// ============================================================
    // ── Weapon Books ──────────────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Axe_T04 = new()
    {
        Name    = null,
        Guid    = new(660670410),
        Prefab  = "Item_Ingredient_Book_Weapon_Axe_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Axe_T06 = new()
    {
        Name    = null,
        Guid    = new(-1596352033),
        Prefab  = "Item_Ingredient_Book_Weapon_Axe_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Axe_T08 = new()
    {
        Name    = null,
        Guid    = new(-1519267007),
        Prefab  = "Item_Ingredient_Book_Weapon_Axe_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Claws_T06 = new()
    {
        Name    = null,
        Guid    = new(574313564),
        Prefab  = "Item_Ingredient_Book_Weapon_Claws_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Claws_T08 = new()
    {
        Name    = null,
        Guid    = new(-213056154),
        Prefab  = "Item_Ingredient_Book_Weapon_Claws_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Crossbow_T04 = new()
    {
        Name    = null,
        Guid    = new(-192381912),
        Prefab  = "Item_Ingredient_Book_Weapon_Crossbow_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Crossbow_T06 = new()
    {
        Name    = null,
        Guid    = new(937375187),
        Prefab  = "Item_Ingredient_Book_Weapon_Crossbow_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Crossbow_T08 = new()
    {
        Name    = null,
        Guid    = new(1856338018),
        Prefab  = "Item_Ingredient_Book_Weapon_Crossbow_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Daggers_T06 = new()
    {
        Name    = null,
        Guid    = new(1253216070),
        Prefab  = "Item_Ingredient_Book_Weapon_Daggers_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Daggers_T08 = new()
    {
        Name    = null,
        Guid    = new(1271236919),
        Prefab  = "Item_Ingredient_Book_Weapon_Daggers_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_GreatSword_T06 = new()
    {
        Name    = null,
        Guid    = new(1126901893),
        Prefab  = "Item_Ingredient_Book_Weapon_GreatSword_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_GreatSword_T08 = new()
    {
        Name    = null,
        Guid    = new(730869315),
        Prefab  = "Item_Ingredient_Book_Weapon_GreatSword_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Longbow_T04 = new()
    {
        Name    = null,
        Guid    = new(460843266),
        Prefab  = "Item_Ingredient_Book_Weapon_Longbow_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Longbow_T06 = new()
    {
        Name    = null,
        Guid    = new(-1793793429),
        Prefab  = "Item_Ingredient_Book_Weapon_Longbow_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Longbow_T08 = new()
    {
        Name    = null,
        Guid    = new(722498174),
        Prefab  = "Item_Ingredient_Book_Weapon_Longbow_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Mace_T04 = new()
    {
        Name    = null,
        Guid    = new(-1003381140),
        Prefab  = "Item_Ingredient_Book_Weapon_Mace_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Mace_T06 = new()
    {
        Name    = null,
        Guid    = new(1526542305),
        Prefab  = "Item_Ingredient_Book_Weapon_Mace_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Mace_T08 = new()
    {
        Name    = null,
        Guid    = new(-567468235),
        Prefab  = "Item_Ingredient_Book_Weapon_Mace_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Pistols_T06 = new()
    {
        Name    = null,
        Guid    = new(1370998844),
        Prefab  = "Item_Ingredient_Book_Weapon_Pistols_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Pistols_T08 = new()
    {
        Name    = null,
        Guid    = new(-349470582),
        Prefab  = "Item_Ingredient_Book_Weapon_Pistols_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Reaper_T06 = new()
    {
        Name    = null,
        Guid    = new(-977419819),
        Prefab  = "Item_Ingredient_Book_Weapon_Reaper_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Reaper_T08 = new()
    {
        Name    = null,
        Guid    = new(1350548439),
        Prefab  = "Item_Ingredient_Book_Weapon_Reaper_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Slashers_T06 = new()
    {
        Name    = null,
        Guid    = new(1942009728),
        Prefab  = "Item_Ingredient_Book_Weapon_Slashers_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Slashers_T08 = new()
    {
        Name    = null,
        Guid    = new(615301463),
        Prefab  = "Item_Ingredient_Book_Weapon_Slashers_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Spear_T04 = new()
    {
        Name    = null,
        Guid    = new(-1690985210),
        Prefab  = "Item_Ingredient_Book_Weapon_Spear_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Spear_T06 = new()
    {
        Name    = null,
        Guid    = new(-1783670291),
        Prefab  = "Item_Ingredient_Book_Weapon_Spear_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Spear_T08 = new()
    {
        Name    = null,
        Guid    = new(-1396190808),
        Prefab  = "Item_Ingredient_Book_Weapon_Spear_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Sword_T04 = new()
    {
        Name    = null,
        Guid    = new(-1455124124),
        Prefab  = "Item_Ingredient_Book_Weapon_Sword_T04",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Sword_T06 = new()
    {
        Name    = null,
        Guid    = new(1427084419),
        Prefab  = "Item_Ingredient_Book_Weapon_Sword_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Sword_T08 = new()
    {
        Name    = null,
        Guid    = new(1075465533),
        Prefab  = "Item_Ingredient_Book_Weapon_Sword_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_TwinBlades_T06 = new()
    {
        Name    = null,
        Guid    = new(-457986654),
        Prefab  = "Item_Ingredient_Book_Weapon_TwinBlades_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_TwinBlades_T08 = new()
    {
        Name    = null,
        Guid    = new(1200302278),
        Prefab  = "Item_Ingredient_Book_Weapon_TwinBlades_T08",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Whip_T06 = new()
    {
        Name    = null,
        Guid    = new(710159072),
        Prefab  = "Item_Ingredient_Book_Weapon_Whip_T06",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Book_Weapon_Whip_T08 = new()
    {
        Name    = null,
        Guid    = new(-1033721040),
        Prefab  = "Item_Ingredient_Book_Weapon_Whip_T08",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Passive Books — T01 ───────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_ArcaneAnimator = new()
    {
        Name    = null,
        Guid    = new(806031638),
        Prefab  = "Item_Ingredient_Passive_T01_ArcaneAnimator",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_BloodSpray = new()
    {
        Name    = null,
        Guid    = new(1561531999),
        Prefab  = "Item_Ingredient_Passive_T01_BloodSpray",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_BloodTypeEfficiency = new()
    {
        Name    = null,
        Guid    = new(-1012087769),
        Prefab  = "Item_Ingredient_Passive_T01_BloodTypeEfficiency",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_ChaosKindling = new()
    {
        Name    = null,
        Guid    = new(-744023422),
        Prefab  = "Item_Ingredient_Passive_T01_ChaosKindling",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_ChillWeave = new()
    {
        Name    = null,
        Guid    = new(1314569175),
        Prefab  = "Item_Ingredient_Passive_T01_ChillWeave",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_ColdSoul = new()
    {
        Name    = null,
        Guid    = new(759629166),
        Prefab  = "Item_Ingredient_Passive_T01_ColdSoul",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_EnhancedConductivity = new()
    {
        Name    = null,
        Guid    = new(-295674777),
        Prefab  = "Item_Ingredient_Passive_T01_EnhancedConductivity",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_FlowingSorcery = new()
    {
        Name    = null,
        Guid    = new(1532551951),
        Prefab  = "Item_Ingredient_Passive_T01_FlowingSorcery",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_LightningFastStrikes = new()
    {
        Name    = null,
        Guid    = new(177536500),
        Prefab  = "Item_Ingredient_Passive_T01_LightningFastStrikes",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_RenewingFlames = new()
    {
        Name    = null,
        Guid    = new(201124833),
        Prefab  = "Item_Ingredient_Passive_T01_RenewingFlames",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_SoulDrinker = new()
    {
        Name    = null,
        Guid    = new(-1150810012),
        Prefab  = "Item_Ingredient_Passive_T01_SoulDrinker",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T01_SpiritualInfusion = new()
    {
        Name    = null,
        Guid    = new(-1645974345),
        Prefab  = "Item_Ingredient_Passive_T01_SpiritualInfusion",
        NameKey = null,
        DescKey = null,
    };
 
    // ── Passive Books — T02 ───────────────────────────────────────────────────
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_Bastion = new()
    {
        Name    = null,
        Guid    = new(583764996),
        Prefab  = "Item_Ingredient_Passive_T02_Bastion",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_DarkEnchantment = new()
    {
        Name    = null,
        Guid    = new(-1289785922),
        Prefab  = "Item_Ingredient_Passive_T02_DarkEnchantment",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_EmbraceMayhem = new()
    {
        Name    = null,
        Guid    = new(-1305686817),
        Prefab  = "Item_Ingredient_Passive_T02_EmbraceMayhem",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_FeralHaste = new()
    {
        Name    = null,
        Guid    = new(1725419936),
        Prefab  = "Item_Ingredient_Passive_T02_FeralHaste",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_HungerForPower = new()
    {
        Name    = null,
        Guid    = new(-1361596609),
        Prefab  = "Item_Ingredient_Passive_T02_HungerForPower",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_LethalStrikes = new()
    {
        Name    = null,
        Guid    = new(765693103),
        Prefab  = "Item_Ingredient_Passive_T02_LethalStrikes",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_Overpower = new()
    {
        Name    = null,
        Guid    = new(-1402113736),
        Prefab  = "Item_Ingredient_Passive_T02_Overpower",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_Rampage = new()
    {
        Name    = null,
        Guid    = new(1913822231),
        Prefab  = "Item_Ingredient_Passive_T02_Rampage",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_RavenousStrikes = new()
    {
        Name    = null,
        Guid    = new(1703128595),
        Prefab  = "Item_Ingredient_Passive_T02_RavenousStrikes",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_TurbulentVelocity = new()
    {
        Name    = null,
        Guid    = new(-1381982890),
        Prefab  = "Item_Ingredient_Passive_T02_TurbulentVelocity",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_VBloodSlayer = new()
    {
        Name    = null,
        Guid    = new(-1034273124),
        Prefab  = "Item_Ingredient_Passive_T02_VBloodSlayer",
        NameKey = null,
        DescKey = null,
    };
 
    public static readonly PrefabDef Item_Ingredient_Passive_T02_WickedPower = new()
    {
        Name    = null,
        Guid    = new(814603706),
        Prefab  = "Item_Ingredient_Passive_T02_WickedPower",
        NameKey = null,
        DescKey = null,
    };
}