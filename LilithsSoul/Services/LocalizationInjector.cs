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
//  At world ready we build a lookup from PrefabCollectionSystem._PrefabDataLookup
//  mapping prefab name → AssetGuid. This mirrors Bloodcraft's LocalizationService.
//
//  AssetGuid construction:
//  ───────────────────────
//  AssetGuid takes four ints (a, b, c, d). We parse the GUID string from
//  PrefabData.AssetGuid into a System.Guid, extract its 16 bytes, and split
//  them into four Int32s via BitConverter.
//
//  [PERFORMANCE] Lookup table built once at world ready — O(n) over all prefabs.
//                Injection is O(1) per entry — direct dictionary write.
//                ClearPrevious calls LoadDefaultLanguage() once per server switch.
// ============================================================

namespace LilithsSoul.Services;

public static class LocalizationInjector
{
    private const string LOG_SOURCE = "LilithsSoul.LocalizationInjector";

    // Built once at world ready from PrefabCollectionSystem.
    // Key: prefab asset name string.
    // Value: AssetGuid used in Localization._LocalizedStrings.
    static readonly Dictionary<string, AssetGuid> _nameToAssetGuid = new();

    // Track injected keys so we can cleanly remove them on server switch.
    static readonly HashSet<AssetGuid> _injectedGuids = new();

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Builds the prefab name → AssetGuid lookup table.
    /// Called from SyncReceiver.NotifyWorldReady() once
    /// PrefabCollectionSystem is available.
    /// [PERFORMANCE] O(n) over all prefabs, run once at world ready.
    /// </summary>
    public static void BuildLookupTable()
    {
        _nameToAssetGuid.Clear();

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

                    // Parse the GUID string into a System.Guid, then split
                    // its 16 bytes into the four ints AssetGuid expects.
                    if (!System.Guid.TryParse(prefabData.AssetGuid.ToString(),
                            out var systemGuid)) continue;

                    var bytes     = systemGuid.ToByteArray();
                    var assetGuid = new AssetGuid(
                        BitConverter.ToInt32(bytes, 0),
                        BitConverter.ToInt32(bytes, 4),
                        BitConverter.ToInt32(bytes, 8),
                        BitConverter.ToInt32(bytes, 12));

                    _nameToAssetGuid[name] = assetGuid;
                }
            }
            finally
            {
                keys.Dispose();
                vals.Dispose();
            }

            SoulLogger.Info(LOG_SOURCE,
                $"AssetGuid lookup table built with {_nameToAssetGuid.Count} entries.");
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
            // Tooltip keys use a "_Description" suffix — best-effort heuristic.
            // Only inject if the key already exists; no phantom entries.
            if (!_nameToAssetGuid.TryGetValue(prefabName + "_Description",
                    out var tooltipGuid)) continue;

            if (!table.ContainsKey(tooltipGuid)) continue;

            table[tooltipGuid] = tooltip;
            _injectedGuids.Add(tooltipGuid);
            tooltipCount++;
        }

        SoulLogger.Info(LOG_SOURCE,
            $"Injected {nameCount} display name(s) and {tooltipCount} tooltip(s) " +
            $"from server '{payload.ServerIdentity}'.");
    }

    // ── Internal ─────────────────────────────────────────────

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