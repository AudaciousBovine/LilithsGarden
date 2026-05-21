using ProjectM;
using Stunlock.Core;
using Stunlock.Localization;
using Unity.Collections;
using LilithsSoul.Foundation;

// ============================================================
//  LocalizationInjector — LilithsSoul
//
//  Service that injects display name and tooltip overrides from
//  a received ServerSyncPayload into V Rising's live localization
//  table: Stunlock.Localization.Localization._LocalizedStrings.
//
//  How V Rising localization works:
//  ──────────────────────────────────
//  The game stores all display strings in a static dictionary:
//      Localization._LocalizedStrings: Dictionary<AssetGuid, string>
//
//  Every item, NPC, recipe etc. has an AssetGuid for its name.
//  The UI calls Localization.Get(AssetGuid) to resolve display text.
//  We write directly into _LocalizedStrings to override any entry.
//
//  AssetGuid lookup strategy:
//  ───────────────────────────
//  The server sends overrides keyed by prefab name (e.g. "Item_BloodEssence_T01").
//  At world ready we build two lookups from PrefabCollectionSystem:
//    • _nameToAssetGuid   — prefab name → display name AssetGuid
//                           sourced from PrefabData.AssetGuid
//    • _nameToTooltipGuid — prefab name → tooltip AssetGuid
//                           sourced from ItemData.LocalizedDescription
//
//  AssetGuid construction:
//  ───────────────────────
//  [CHANGED] No longer uses System.Guid.ToByteArray().
//  ToByteArray() returns mixed-endian bytes on Windows — the first
//  three GUID components are little-endian, byte-swapping the int
//  values relative to what Localization._LocalizedStrings uses.
//  We now parse the raw hex string directly as four big-endian Int32s.
//
//  Tooltip lookup:
//  ───────────────
//  [CHANGED] No longer uses a "_Description" suffix heuristic.
//  Tooltip AssetGuids have no naming relationship to prefab names.
//  We read ItemData.LocalizedDescription directly from each prefab
//  entity — the only reliable source.
//
//  [PERFORMANCE] Both lookup tables built once at world ready.
//                Display name lookup: O(n) over _PrefabDataLookup.
//                Tooltip lookup: O(n) over _PrefabGuidToEntityMap
//                with Has<ItemData>() short-circuit — most prefabs
//                are not items so the inner work is rarely reached.
//                Injection is O(1) per entry — direct dictionary write.
//                ClearPrevious calls LoadDefaultLanguage() once per server switch.
// ============================================================

namespace LilithsSoul.Services;

public static class LocalizationInjector
{
    private const string LOG_SOURCE = "LilithsSoul.LocalizationInjector";

    // Built once at world ready from PrefabCollectionSystem.
    // Key: prefab asset name string (e.g. "Item_BloodEssence_T01").
    // Value: AssetGuid for the display name in Localization._LocalizedStrings.
    static readonly Dictionary<string, AssetGuid> _nameToAssetGuid = new();

    // [ADDED] Tooltip lookup — sourced from ItemData.LocalizedDescription.
    // Key: prefab asset name string.
    // Value: AssetGuid for the tooltip string in Localization._LocalizedStrings.
    static readonly Dictionary<string, AssetGuid> _nameToTooltipGuid = new();

    // Track all injected keys so we can cleanly remove them on server switch.
    static readonly HashSet<AssetGuid> _injectedGuids = new();

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Builds the prefab name → AssetGuid lookup tables for both display names
    /// and tooltips. Called from SyncReceiver.NotifyWorldReady() once
    /// PrefabCollectionSystem is available.
    /// [PERFORMANCE] O(n) over all prefabs, run once at world ready.
    /// </summary>
    public static void BuildLookupTable()
    {
        _nameToAssetGuid.Clear();
        _nameToTooltipGuid.Clear();

        try
        {
            var world = Soul.ClientWorld;
            if (world == null)
            {
                SoulLogger.Warning(LOG_SOURCE,
                    "Client world not available — cannot build AssetGuid lookup.");
                return;
            }

            var prefabSystem = world.GetExistingSystemManaged<PrefabCollectionSystem>();
            if (prefabSystem == null)
            {
                SoulLogger.Warning(LOG_SOURCE,
                    "PrefabCollectionSystem not found — cannot build AssetGuid lookup.");
                return;
            }

            // ── Display name lookup ──────────────────────────────────────
            // Source: PrefabData.AssetGuid from _PrefabDataLookup.

            var lookup = prefabSystem._PrefabDataLookup;
            var keys   = lookup.GetKeyArray(Allocator.Temp);
            var vals   = lookup.GetValueArray(Allocator.Temp);

            try
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    var prefabData = vals[i];
                    string name    = prefabData.AssetName.Value;

                    if (string.IsNullOrEmpty(name)) continue;

                    var guidStr = prefabData.AssetGuid.ToString();
                    if (string.IsNullOrEmpty(guidStr)) continue;

                    // [CHANGED] Parse AssetGuid from the raw hex string as four
                    //           big-endian Int32s. System.Guid.ToByteArray() uses
                    //           mixed-endian layout on Windows which byte-swaps the
                    //           first three components, producing wrong int values
                    //           that don't match Localization._LocalizedStrings keys.
                    _nameToAssetGuid[name] = GuidFromHexString(guidStr);
                }
            }
            finally
            {
                keys.Dispose();
                vals.Dispose();
            }

            SoulLogger.Info(LOG_SOURCE,
                $"Display name AssetGuid lookup built with {_nameToAssetGuid.Count} entries.");

            // ── Tooltip lookup ───────────────────────────────────────────
            // Source: ItemData.LocalizedDescription from _PrefabGuidToEntityMap.
            // [ADDED] Tooltips have no naming relationship to prefab names.
            //         The only reliable source is ItemData.LocalizedDescription
            //         on the prefab entity itself.
            // [PERFORMANCE] Has<ItemData>() short-circuits for non-item prefabs —
            //               most of the ~13k prefabs are not items.

            var prefabMap = prefabSystem._PrefabGuidToEntityMap;

            foreach (var kvp in prefabMap)
            {
                var entity = kvp.Value;
                if (!entity.Has<ItemData>()) continue;

                var itemData = entity.Read<ItemData>();

                if (!prefabSystem._PrefabDataLookup.TryGetValue(kvp.Key, out var pd)) continue;

                string name = pd.AssetName.Value;
                if (string.IsNullOrEmpty(name)) continue;

                // LocalizedDescription is the AssetGuid of the tooltip string directly.
                _nameToTooltipGuid[name] = itemData.LocalizedDescription;
            }

            SoulLogger.Info(LOG_SOURCE,
                $"Tooltip AssetGuid lookup built with {_nameToTooltipGuid.Count} entries.");
        }
        catch (Exception ex)
        {
            SoulLogger.Error(LOG_SOURCE,
                $"Failed to build AssetGuid lookup: {ex.Message}");
        }
    }

    /// <summary>
    /// Injects display name and tooltip overrides from the payload into
    /// Localization._LocalizedStrings. Safe to call multiple times —
    /// previous overrides are cleared before new ones are applied.
    /// </summary>
    public static void Inject(Network.ServerSyncPayload payload)
    {
        if (_nameToAssetGuid.Count == 0)
        {
            SoulLogger.Warning(LOG_SOURCE,
                "AssetGuid lookup table is empty — was BuildLookupTable() called?");
            return;
        }

        ClearPrevious();

        var table = Localization._LocalizedStrings;
        if (table == null)
        {
            SoulLogger.Warning(LOG_SOURCE,
                "Localization._LocalizedStrings is null — not initialized yet.");
            return;
        }

        // [ADDED] Diagnostic log so we can verify counts at injection time.
        SoulLogger.Info(LOG_SOURCE,
            $"Attempting injection — lookup has {_nameToAssetGuid.Count} entries, " +
            $"payload has {payload.DisplayNameOverrides.Count} display name(s).");

        int nameCount    = 0;
        int tooltipCount = 0;

        foreach (var (prefabName, displayName) in payload.DisplayNameOverrides)
        {
            if (!_nameToAssetGuid.TryGetValue(prefabName, out var assetGuid)) continue;

            table[assetGuid] = displayName;
            _injectedGuids.Add(assetGuid);
            nameCount++;
        }

        foreach (var (prefabName, tooltip) in payload.TooltipOverrides)
        {
            // [CHANGED] Use _nameToTooltipGuid sourced from ItemData.LocalizedDescription.
            //           Previous implementation appended "_Description" to the prefab name
            //           as a heuristic — this never matched anything in V Rising's localization
            //           table since tooltip AssetGuids have no naming relationship to prefabs.
            if (!_nameToTooltipGuid.TryGetValue(prefabName, out var tooltipGuid)) continue;

            table[tooltipGuid] = tooltip;
            _injectedGuids.Add(tooltipGuid);
            tooltipCount++;
        }

        SoulLogger.Info(LOG_SOURCE,
            $"Injected {nameCount} display name(s) and {tooltipCount} tooltip(s) " +
            $"from server '{payload.ServerIdentity}'.");
    }

    // ── Internal ─────────────────────────────────────────────

    /// <summary>
    /// Parses a GUID string into an AssetGuid by reading four big-endian Int32s
    /// directly from the hex characters, bypassing System.Guid.ToByteArray().
    /// </summary>
    /// <remarks>
    /// System.Guid.ToByteArray() on Windows returns mixed-endian bytes:
    /// the first three GUID components are little-endian and the last two
    /// are big-endian. This causes the Int32 values to be byte-swapped
    /// relative to what V Rising stores in Localization._LocalizedStrings,
    /// resulting in AssetGuid keys that don't match any entry in the table.
    /// Parsing the raw hex string as four sequential big-endian Int32s
    /// produces values that match the game's internal representation.
    /// </remarks>
    static AssetGuid GuidFromHexString(string guidString)
    {
        // Strip hyphens: "31365e50-5bd7-748b-a8cc-0f535b054411"
        //             →  "31365e505bd7748ba8cc0f535b054411"
        var hex = guidString.Replace("-", "");

        int a = Convert.ToInt32(hex[ 0.. 8], 16);
        int b = Convert.ToInt32(hex[ 8..16], 16);
        int c = Convert.ToInt32(hex[16..24], 16);
        int d = Convert.ToInt32(hex[24..32], 16);

        return new AssetGuid(a, b, c, d);
    }

    static void ClearPrevious()
    {
        if (_injectedGuids.Count == 0) return;

        // Full reload restores all vanilla strings cleanly before
        // applying new overrides. Cost paid once per server switch.
        Localization.LoadDefaultLanguage();

        SoulLogger.Debug(LOG_SOURCE,
            $"Cleared {_injectedGuids.Count} previous override(s) " +
            "via localization reload.");

        _injectedGuids.Clear();
    }
}