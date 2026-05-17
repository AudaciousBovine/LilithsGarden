using System.Text.Json;
using Stunlock.Core;

namespace LilithsHeart.Systems;

public static class PrefabNameResolver
{
    private const string LOG_SOURCE = "LilithsHeart.PrefabNameResolver";

    public static readonly PrefabGUID Empty = new PrefabGUID(0);

    static readonly Dictionary<string, PrefabGUID> _newNameToGuid = new();
    static readonly Dictionary<string, PrefabGUID> _originalNameToGuid = new();

    // [CHANGED] Updated config directory to LilithsGarden/Names/
    //           for a cleaner shared config folder structure across the suite.
    static readonly string ConfigDir = Path.Combine(
        BepInEx.Paths.ConfigPath,
        "LilithsGarden",
        "Names"
    );

    public static void Initialize()
    {
        if (!Directory.Exists(ConfigDir))
        {
            LilithsLogger.Warning(LOG_SOURCE, $"Names directory not found at '{ConfigDir}', skipping prefab name loading.");
            return;
        }

        var files = Directory.GetFiles(ConfigDir, "*.json");

        if (files.Length == 0)
        {
            LilithsLogger.Warning(LOG_SOURCE, "No JSON files found in Names directory, skipping prefab name loading.");
            return;
        }

        foreach (var file in files)
            LoadPrefabNames(file);

        LilithsLogger.Info(LOG_SOURCE, $"Initialized with {_newNameToGuid.Count} entries from {files.Length} file(s).");
    }

    static void LoadPrefabNames(string filePath)
    {
        if (!File.Exists(filePath))
        {
            LilithsLogger.Warning(LOG_SOURCE, $"'{Path.GetFileName(filePath)}' not found, skipping.");
            return;
        }

        try
        {
            var json = File.ReadAllText(filePath);
            var entries = JsonSerializer.Deserialize<Dictionary<string, PrefabNameEntry>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (entries == null) return;

            foreach (var (guidStr, entry) in entries)
            {
                if (!int.TryParse(guidStr, out int guidValue)) continue;

                var guid = new PrefabGUID(guidValue);

                if (!string.IsNullOrEmpty(entry.OriginalName))
                    _originalNameToGuid[entry.OriginalName] = guid;

                // [CHANGED] NewNames must be PascalCase with no spaces.
                //           e.g. "BloodEssence" not "Blood Essence"
                if (!string.IsNullOrEmpty(entry.NewName))
                    _newNameToGuid[entry.NewName] = guid;
            }

            LilithsLogger.Info(LOG_SOURCE, $"Loaded '{Path.GetFileName(filePath)}'.");
        }
        catch (Exception e)
        {
            LilithsLogger.Error(LOG_SOURCE, $"Failed to load '{Path.GetFileName(filePath)}': {e.Message}");
        }
    }

    /// <summary>
    /// Attempts to resolve a name or GUID string to a PrefabGUID.
    /// Resolution order:
    ///   1. NewName (PascalCase admin-friendly name, e.g. "BloodEssence")
    ///   2. OriginalName (exact game prefab name, e.g. "Item_BloodEssence_T01")
    ///   3. Raw GUID integer string (e.g. "862477668")
    /// Returns false and PrefabGUID.Empty if all three lookups fail.
    /// </summary>
    public static bool TryResolve(string name, out PrefabGUID guid)
    {
        // 1. NewName lookup
        if (_newNameToGuid.TryGetValue(name, out guid))
            return true;

        // 2. OriginalName lookup
        if (_originalNameToGuid.TryGetValue(name, out guid))
            return true;

        // 3. Raw GUID integer lookup
        // [ADDED] Allows configs and code to reference prefabs by raw integer
        //         string without needing a name entry in the JSON files.
        if (int.TryParse(name, out int guidValue))
        {
            guid = new PrefabGUID(guidValue);
            return true;
        }

        guid = Empty;
        LilithsLogger.Warning(LOG_SOURCE, $"Could not resolve: '{name}'");
        return false;
    }
}

public class PrefabNameEntry
{
    // OriginalName: exact game prefab name e.g. "Item_BloodEssence_T01"
    public string OriginalName { get; set; } = string.Empty;

    // NewName: PascalCase admin-friendly name e.g. "BloodEssence"
    // [CHANGED] No spaces allowed — use PascalCase convention.
    public string NewName { get; set; } = string.Empty;
}