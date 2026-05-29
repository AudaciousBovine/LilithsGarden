// ============================================================
//  StationsIndex — LilithsMind
//  LilithsMind/Prefabs/Definitions/StationsIndex.cs
//
//  [CHANGED] Migrated from bare PrefabGUID + [PrefabName] attribute fields
//            to PrefabDef records. Field names match the prefab string exactly.
//            Names sourced from [PrefabName] attributes; null where absent
//            (special/unused stations). All nullable fields shown explicitly.
//
//  [PERFORMANCE] Static readonly PrefabDef fields — initialised once at
//                class load, zero per-frame cost. Stack-allocated structs,
//                no heap pressure.
// ============================================================

namespace LilithsMind.Prefabs.Definitions;

public static class StationsIndex
{
    // ── Crafting Stations ─────────────────────────────────────────────────────

    public static readonly PrefabDef CraftingStation_Player = new()
    {
        Name    = "PlayerCrafting",
        GuidHash = 1420623103,
    };

    public static readonly PrefabDef TM_CraftingStation_SimpleCraftingBench = new()
    {
        Name    = "SimpleWorkbench",
        GuidHash = -1107784271,
        Prefab  = "TM_CraftingStation_SimpleCraftingBench",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_WoodworkingBench = new()
    {
        Name    = "WoodworkingBench",
        GuidHash = -332123372,
        Prefab  = "TM_CraftingStation_WoodworkingBench",
        NameKey = "22738d88-d6a3-4692-9ab9-799da92185a1",
        DescKey = "daff14dd-41a5-4821-9013-368a7fd2b3cc",
    };

    public static readonly PrefabDef TM_CraftingStation_Leatherworking = new()
    {
        Name    = "LeatherworkingStation",
        GuidHash = 1779320855,
        Prefab  = "TM_CraftingStation_Leatherworking",
        NameKey = "0a6e7bcb-67ea-41f3-b139-b01c91fb12fd",
        DescKey = "df896ffb-e1aa-47b9-93ae-f7cef28114f2",
    };

    public static readonly PrefabDef TM_CraftingStation_ArtisanTable = new()
    {
        Name    = "ArtisanTable",
        GuidHash = -1718710437,
        Prefab  = "TM_CraftingStation_ArtisanTable",
        NameKey = "8a8bdb9a-1f67-4062-8fcd-99d80e9b217f",
        DescKey = "66382f79-31ac-4590-be7b-f5b8dd5f8514",
    };

    public static readonly PrefabDef TM_CraftingStation_JewelcraftingTable = new()
    {
        Name    = "JewelcraftingTable",
        GuidHash = 508953830,
        Prefab  = "TM_CraftingStation_JewelcraftingTable",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_TailorBench = new()
    {
        Name    = "TailoringBench",
        GuidHash = -952755594,
        Prefab  = "TM_CraftingStation_TailorBench",
        NameKey = "1320cca5-cb66-495b-987f-c187b2af3078",
        DescKey = "d9a46f8c-101c-4dfd-98ec-8d8be3d7c0d7",
    };

    public static readonly PrefabDef TM_CraftingStation_AlchemyLab_Small = new()
    {
        Name    = "AlchemyTable",
        GuidHash = 181938440,
        Prefab  = "TM_CraftingStation_AlchemyLab_Small",
        NameKey = "d881d6cb-dd44-44b3-a75b-eb438b20f50a",
        DescKey = "ed6dfb2f-19c3-4286-bffc-407e2eb93700",
    };

    public static readonly PrefabDef TM_CraftingStation_Smithy = new()
    {
        Name    = "Smithy",
        GuidHash = -1840926436,
        Prefab  = "TM_CraftingStation_Smithy",
        NameKey = "51ae4d65-4a02-42cd-9bb7-2af131a41740",
        DescKey = "85660508-81e1-4bed-9388-7174fc43a912",
    };

    public static readonly PrefabDef TM_CraftingStation_Anvil = new()
    {
        Name    = "Anvil",
        GuidHash = -437790980,
        Prefab  = "TM_CraftingStation_Anvil",
        NameKey = "35732835-3ae0-4f7e-8adb-1a7ba1e1b3d3",
        DescKey = "63a3e364-126b-44d7-ac55-5fd4f0c4b27a",
    };

    // ── Refinement Stations ───────────────────────────────────────────────────

    public static readonly PrefabDef TM_RefinementStation_Sawmill_Small = new()
    {
        Name    = "Sawmill",
        GuidHash = 1094077710,
        Prefab  = "TM_RefinementStation_Sawmill_Small",
        NameKey = "a5597738-8a46-4a12-b8ed-e4e6c47765d6",
        DescKey = "ca5889b8-2494-4e71-9a7f-576612acae1b",
    };

    public static readonly PrefabDef TM_RefinementStation_Sawmill_Large = new()
    {
        Name    = "AdvancedSawmill",
        GuidHash = -163562336,
        Prefab  = "TM_RefinementStation_Sawmill_Large",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_RefinementStation_StonecuttingTable_Small = new()
    {
        Name    = "Grinder",
        GuidHash = -600683642,
        Prefab  = "TM_RefinementStation_StonecuttingTable_Small",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_RefinementStation_StonecuttingTable_Large = new()
    {
        Name    = "AdvancedGrinder",
        GuidHash = -178579946,
        Prefab  = "TM_RefinementStation_StonecuttingTable_Large",
        NameKey = "c6505c74-d41b-4b9c-b576-b1ccccd8b3f4",
        DescKey = "cd97f772-1adb-4a2e-825e-64c47c9f0c25",
    };

    public static readonly PrefabDef TM_RefinementStation_Furnace_Small = new()
    {
        Name    = "Furnace",
        GuidHash = -1150411622,
        Prefab  = "TM_RefinementStation_Furnace_Small",
        NameKey = "80482750-5fae-476c-8a53-995c2f441079",
        DescKey = "49bcd550-ce3d-4cd6-96f5-ad291f625a1b",
    };

    public static readonly PrefabDef TM_RefinementStation_Furnace_Large = new()
    {
        Name    = "AdvancedFurnace",
        GuidHash = -222851985,
        Prefab  = "TM_RefinementStation_Furnace_Large",
        NameKey = "4765269a-729d-42d0-abc0-257dcbc6d571",
        DescKey = "49bcd550-ce3d-4cd6-96f5-ad291f625a1b",
    };

    public static readonly PrefabDef TM_RefinementStation_BloodPress_Small = new()
    {
        Name    = "BloodPress",
        GuidHash = -300823465,
        Prefab  = "TM_RefinementStation_BloodPress_Small",
        NameKey = "2239d338-d177-4ada-b398-44df090e53df",
        DescKey = "8551294a-378c-4e7e-a59f-61b7d96190e2",
    };

    public static readonly PrefabDef TM_RefinementStation_BloodPress_Large = new()
    {
        Name    = "AdvancedBloodPress",
        GuidHash = -684391635,
        Prefab  = "TM_RefinementStation_BloodPress_Large",
        NameKey = "7e6d6f7e-11ca-4f8f-80c8-febc3dcf1495",
        DescKey = "8551294a-378c-4e7e-a59f-61b7d96190e2",
    };

    public static readonly PrefabDef TM_RefinementStation_Tannery_Small = new()
    {
        Name    = "Tannery",
        GuidHash = -635885386,
        Prefab  = "TM_RefinementStation_Tannery_Small",
        NameKey = "ac86b4a2-2e71-43b6-ae2f-e3167ca40a3a",
        DescKey = "95a56ff0-82de-4179-97e9-507f03aabc6f",
    };

    public static readonly PrefabDef TM_RefinementStation_Tannery_Large = new()
    {
        Name    = "AdvancedTannery",
        GuidHash = -1422196107,
        Prefab  = "TM_RefinementStation_Tannery_Large",
        NameKey = "3621246b-27de-4d18-afd9-3bc61c820c9c",
        DescKey = "95a56ff0-82de-4179-97e9-507f03aabc6f",
    };

    public static readonly PrefabDef TM_RefinementStation_Loom_Small = new()
    {
        Name    = "Loom",
        GuidHash = -16328955,
        Prefab  = "TM_RefinementStation_Loom_Small",
        NameKey = "0afc804a-911d-47db-9a40-1ceb0f005b58",
        DescKey = "a01587fd-77c0-4176-9506-02db7fbfa7fd,
    };

    public static readonly PrefabDef TM_RefinementStation_Loom_Large = new()
    {
        Name    = "AdvancedLoom",
        GuidHash = 1299929048,
        Prefab  = "TM_RefinementStation_Loom_Large",
        NameKey = "99249987-9a39-4ec9-a274-0f663089dc0e",
        DescKey = "a01587fd-77c0-4176-9506-02db7fbfa7fd",
    };

    public static readonly PrefabDef TM_RefinementStation_PaperPress_Small = new()
    {
        Name    = "PaperPress",
        GuidHash = -1628971842,
        Prefab  = "TM_RefinementStation_PaperPress_Small",
        NameKey = "eb8e5147-888e-48e7-8d3d-226f371f8ecf",
        DescKey = "af389db5-8d87-4afe-bbf7-eed7993a2cc7",
    };

    public static readonly PrefabDef TM_RefinementStation_GemCutting = new()
    {
        Name    = "GemCuttingTable",
        GuidHash = -21483617,
        Prefab  = "TM_RefinementStation_GemCutting",
        NameKey = "0999e4d8-d1cc-4b11-b526-c9070359623f",
        DescKey = "e88b6e8d-beea-41a1-bc2a-892c2ecd291b",
    };

    public static readonly PrefabDef TM_RefinementStation_Fabricator = new()
    {
        Name    = "Fabricator",
        GuidHash = -465055967,
        Prefab  = "TM_RefinementStation_Fabricator",
        NameKey = "c0ad9200-6fc5-4beb-ae18-081ade98bbd4",
        DescKey = "0f213dba-7d3c-4234-ab13-f4bfbf550643",
    };

    public static readonly PrefabDef TM_SalvageStation_Table = new()
    {
        Name    = "Devourer",
        GuidHash = -1719849142,
        Prefab  = "TM_SalvageStation_Table",
        NameKey = "f8f95026-76a6-4c22-ac08-875b37497179",
        DescKey = "8aa65119-c9e0-4b76-b760-620ccaffab06",
    };

    // ── Unit Stations ─────────────────────────────────────────────────────────

    public static readonly PrefabDef TM_UnitStation_VerminNest = new()
    {
        Name    = "VerminNest",
        GuidHash = 150776081,
        Prefab  = "TM_UnitStation_VerminNest",
        NameKey = "5645f080-1cc8-4fc2-8eae-db41b307abc7",
        DescKey = "3f395b11-d68f-437c-ba2e-e00d27abcb10",
    };

    public static readonly PrefabDef TM_UnitStation_Tomb = new()
    {
        Name    = "Tomb",
        GuidHash = 1127059420,
        Prefab  = "TM_UnitStation_Tomb",
        NameKey = "60cbcdf1-08c8-437e-b0db-ced20815ab36",
        DescKey = "0a51b002-b826-4055-9d5e-b67c1983bfd8",
    };

    public static readonly PrefabDef TM_UnitStation_NetherGate = new()
    {
        Name    = "StygianSummoningCircle",
        GuidHash = -218354895,
        Prefab  = "TM_UnitStation_NetherGate",
        NameKey = "2222808f-b335-4277-9dd8-b41d896f6696",
        DescKey = "88aa48b1-4694-41f5-8068-d1b193be4838",
    };

    // ── Special Stations — Do Not Use ─────────────────────────────────────────

    public static readonly PrefabDef TM_CraftingStation_AncestralForge = new()
    {
        Name    = null,
        GuidHash = 48521126,
        Prefab  = "TM_CraftingStation_AncestralForge",
        NameKey = "b3a5426c-2969-496d-a2ef-ed78d7eadb83",
        DescKey = "1486f7c0-cf11-46f4-89b6-8bb73ccacf0f",
    };

    public static readonly PrefabDef TM_CraftingStation_BloodMixer = new()
    {
        Name    = null,
        GuidHash = -969931747,
        Prefab  = "TM_CraftingStation_BloodMixer",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_FusionForge = new()
    {
        Name    = null,
        GuidHash = -1286344051,
        Prefab  = "TM_CraftingStation_FusionForge",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_Stables = new()
    {
        Name    = null,
        GuidHash = 472278220,
        Prefab  = "TM_CraftingStation_Stables",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_RefinementStation_TeslaLightningRod = new()
    {
        Name    = null,
        GuidHash = 1311814093,
        Prefab  = "TM_RefinementStation_TeslaLightningRod",
        NameKey = null,
        DescKey = null,
    };

    // ── Unused — Do Not Use ───────────────────────────────────────────────────

    public static readonly PrefabDef TM_CraftingStation_Altar_Frost = new()
    {
        Name    = null,
        GuidHash = -609878016,
        Prefab  = "TM_CraftingStation_Altar_Frost",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_Altar_Spectral = new()
    {
        Name    = null,
        GuidHash = -64110296,
        Prefab  = "TM_CraftingStation_Altar_Spectral",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_Altar_Unholy = new()
    {
        Name    = null,
        GuidHash = -676962218,
        Prefab  = "TM_CraftingStation_Altar_Unholy",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_ArtisansCorner = new()
    {
        Name    = null,
        GuidHash = 1121480632,
        Prefab  = "TM_CraftingStation_ArtisansCorner",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_BloodBank = new()
    {
        Name    = null,
        GuidHash = -452732692,
        Prefab  = "TM_CraftingStation_BloodBank",
        NameKey = null,
        DescKey = null,
    };

    public static readonly PrefabDef TM_CraftingStation_MetalworkStation = new()
    {
        Name    = null,
        GuidHash = 2014944075,
        Prefab  = "TM_CraftingStation_MetalworkStation",
        NameKey = null,
        DescKey = null,
    };
}
