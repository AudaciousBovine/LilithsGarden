using System.Text.Json;
using System.Text.Json.Serialization;
using ProjectM;
using Unity.Entities;
using LilithsHeart.Config;
using LilithsHeart.Foundation;
using LilithsHeart.Services;
using LilithsCookbook.Config;
using LilithsCookbook.Data;

namespace LilithsCookbook.Systems;

// ============================================================
//  CookbookBuilder — LilithsCookbook
//
//  Generates JSON config files from ECS data and writes
//  example files for admins.
//
//  [CHANGED] Renamed from CookbookGenerator → CookbookBuilder
//            to match the Builder suffix naming convention.
//
//  [CHANGED] RecipeEntry → RecipeEntryData, StationEntry →
//            StationEntryData following naming convention.
//
//  [CHANGED] RecipeRequirement, RecipeOutput, RecipeRepairCost,
//            RecipeUnitOutput consolidated into CookbookItemData.
//            ECS buffer types (RecipeRequirementBuffer etc.) are
//            unchanged — those are V Rising game types, not ours.
//
//  [PERFORMANCE] GenerateAllRecipesIfRequested() runs once at
//                startup only when explicitly enabled in config.
//                No per-frame cost.
// ============================================================

public static class CookbookBuilder
{
    private const string LOG_SOURCE = "LilithsCookbook.CookbookBuilder";

    public static readonly string RecipesDir  = HeartPathIndex.DataDir("Recipes");
    public static readonly string StationsDir = HeartPathIndex.DataDir("Stations");

    static readonly string ExampleRecipesPath  = Path.Combine(RecipesDir,  "example-recipes.json");
    static readonly string ExampleStationsPath = Path.Combine(StationsDir, "example-stations.json");
    static readonly string AllRecipesPath      = Path.Combine(RecipesDir,  "all-recipes.json");

    static readonly JsonSerializerOptions _writeOptions = new()
    {
        WriteIndented          = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    // ── Initialization (no ECS — safe to call from Plugin.Load) ─────────────

    /// <summary>
    /// Creates config directories and writes example files if they don't exist.
    /// Call this from CookbookPlugin.Load() before Heart is ready.
    /// </summary>
    public static void Initialize()
    {
        Directory.CreateDirectory(RecipesDir);
        Directory.CreateDirectory(StationsDir);

        if (!File.Exists(ExampleRecipesPath))
            WriteExampleRecipes();

        if (!File.Exists(ExampleStationsPath))
            WriteExampleStations();
    }

    // ── ECS generation (call after Heart.OnInitialized) ──────────────────────

    /// <summary>
    /// If GenerateAllRecipes is enabled in CookbookConfig, iterates all entries in
    /// GameDataSystem.RecipeHashLookupMap, serializes their current vanilla state to
    /// all-recipes.json, then disables the setting so it does not run on next boot.
    /// </summary>
    public static void GenerateAllRecipesIfRequested()
    {
        if (!CookbookConfig.GenerateAllRecipes) return;

        HeartLogger.Info(LOG_SOURCE, "GenerateAllRecipes is enabled — generating all-recipes.json...");

        try
        {
            var recipeMap = Heart.GameDataSystem.RecipeHashLookupMap;
            var entries   = new Dictionary<string, RecipeEntryData>(recipeMap.Count());
            var prefabMap = Heart.PrefabCollectionSystem._PrefabGuidToEntityMap;

            foreach (var kvp in recipeMap)
            {
                var recipeData = kvp.Value;

                if (!PrefabNameResolver.TryResolveName(kvp.Key, out string recipeName))
                    recipeName = kvp.Key.GuidHash.ToString();

                var entry = new RecipeEntryData { ChangesEnabled = false };

                entry.CraftDuration        = recipeData.CraftDuration;
                entry.AlwaysUnlocked       = recipeData.AlwaysUnlocked;
                entry.HideInStation        = recipeData.HideInStation;
                entry.IgnoreServerSettings = recipeData.IgnoreServerSettings;
                entry.HudSortingOrder      = recipeData.HudSortingOrder;

                if (!prefabMap.TryGetValue(kvp.Key, out Entity entity))
                {
                    entries[recipeName] = entry;
                    continue;
                }

                // RecipeRequirementBuffer — V Rising ECS type, not renamed.
                if (entity.TryGetBuffer<RecipeRequirementBuffer>(out var reqBuffer) && reqBuffer.Length > 0)
                {
                    entry.Requirements = new List<CookbookItemData>(reqBuffer.Length);
                    for (int i = 0; i < reqBuffer.Length; i++)
                    {
                        var req = reqBuffer[i];
                        PrefabNameResolver.TryResolveName(req.Guid, out string itemName);
                        entry.Requirements.Add(new CookbookItemData
                        {
                            Item   = string.IsNullOrEmpty(itemName) ? req.Guid._Value.ToString() : itemName,
                            Amount = req.Amount
                        });
                    }
                }

                // RecipeOutputBuffer — V Rising ECS type, not renamed.
                if (entity.TryGetBuffer<RecipeOutputBuffer>(out var outBuffer) && outBuffer.Length > 0)
                {
                    entry.Outputs = new List<CookbookItemData>(outBuffer.Length);
                    for (int i = 0; i < outBuffer.Length; i++)
                    {
                        var output = outBuffer[i];
                        PrefabNameResolver.TryResolveName(output.Guid, out string itemName);
                        entry.Outputs.Add(new CookbookItemData
                        {
                            Item   = string.IsNullOrEmpty(itemName) ? output.Guid._Value.ToString() : itemName,
                            Amount = output.Amount
                        });
                    }
                }

                // ItemRepairBuffer — V Rising ECS type, not renamed.
                if (entity.TryGetBuffer<ItemRepairBuffer>(out var repairBuffer) && repairBuffer.Length > 0)
                {
                    entry.UseRepairCosts = true;
                    entry.RepairCosts    = new List<CookbookItemData>(repairBuffer.Length);
                    for (int i = 0; i < repairBuffer.Length; i++)
                    {
                        var cost = repairBuffer[i];
                        PrefabNameResolver.TryResolveName(cost.Guid, out string itemName);
                        entry.RepairCosts.Add(new CookbookItemData
                        {
                            Item   = string.IsNullOrEmpty(itemName) ? cost.Guid._Value.ToString() : itemName,
                            Amount = cost.Stacks
                        });
                    }
                }

                // RecipeOutputUnitBuffer — V Rising ECS type, not renamed.
                if (entity.TryGetBuffer<RecipeOutputUnitBuffer>(out var unitBuffer) && unitBuffer.Length > 0)
                {
                    entry.UnitOutputs = new List<CookbookItemData>(unitBuffer.Length);
                    for (int i = 0; i < unitBuffer.Length; i++)
                    {
                        var unit = unitBuffer[i];
                        PrefabNameResolver.TryResolveName(unit.Guid, out string unitName);
                        entry.UnitOutputs.Add(new CookbookItemData
                        {
                            Item   = string.IsNullOrEmpty(unitName) ? unit.Guid._Value.ToString() : unitName,
                            Amount = unit.Stacks
                        });
                    }
                }

                // RecipeLinkBuffer — V Rising ECS type, not renamed.
                if (entity.TryGetBuffer<RecipeLinkBuffer>(out var linkBuffer) && linkBuffer.Length > 0)
                {
                    entry.RecipeLinks = new List<string>(linkBuffer.Length);
                    for (int i = 0; i < linkBuffer.Length; i++)
                    {
                        var link = linkBuffer[i];
                        PrefabNameResolver.TryResolveName(link.Guid, out string linkName);
                        entry.RecipeLinks.Add(
                            string.IsNullOrEmpty(linkName) ? link.Guid._Value.ToString() : linkName
                        );
                    }
                }

                entries[recipeName] = entry;
            }

            var data = new CookbookRecipeData { Recipes = entries };
            WriteJson(AllRecipesPath, data);
            HeartLogger.Info(LOG_SOURCE, $"all-recipes.json written with {entries.Count} entries.");
        }
        catch (Exception ex)
        {
            HeartLogger.Error(LOG_SOURCE, $"Failed to generate all-recipes.json: {ex.Message}");
        }
        finally
        {
            CookbookConfig.DisableGenerateAllRecipes();
        }
    }

    // ── Example file writers ──────────────────────────────────────────────────

    static void WriteExampleRecipes()
    {
        var data = new CookbookRecipeData
        {
            Recipes = new Dictionary<string, RecipeEntryData>
            {
                ["Recipe_Weapon_Sword_T01_Bone"] = new RecipeEntryData
                {
                    ChangesEnabled = true,
                    Requirements = new List<CookbookItemData>
                    {
                        new() { Item = "Item_BloodEssence_T01", Amount = 1 }
                    }
                }
            }
        };

        WriteJson(ExampleRecipesPath, data);
        HeartLogger.Info(LOG_SOURCE, "Generated example-recipes.json.");
    }

    static void WriteExampleStations()
    {
        var data = new CookbookStationData
        {
            Stations = new Dictionary<string, StationEntryData>
            {
                ["TM_Blacksmith_Stations_Standard"] = new StationEntryData
                {
                    ChangesEnabled = false,
                    AddRecipes     = new List<string> { "Recipe_Weapon_Sword_T04_Copper_Reinforced" },
                    RemoveRecipes  = new List<string>()
                }
            }
        };

        WriteJson(ExampleStationsPath, data);
        HeartLogger.Info(LOG_SOURCE, "Generated example-stations.json.");
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    static void WriteJson<T>(string path, T data)
    {
        try
        {
            var json = JsonSerializer.Serialize(data, _writeOptions);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            HeartLogger.Error(LOG_SOURCE, $"Failed to write {Path.GetFileName(path)}: {ex.Message}");
        }
    }
}