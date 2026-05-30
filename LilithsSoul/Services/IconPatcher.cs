using System.Reflection;
using ProjectM;
using Stunlock.Core;
using UnityEngine;
using LilithsMind.Network;
using LilithsMind.Prefabs;
using LilithsSoul.Config;
using LilithsSoul.Foundation;

// ============================================================
//  IconPatcher — LilithsSoul
//  LilithsSoul/Services/IconPatcher.cs
//
//  Resolves icon override values from ItemAppearanceOverrides
//  and applies them to ManagedItemData.Icon so the inventory
//  UI renders the correct sprite for each overridden item.
//
//  Resolution order (per icon value string):
//  ──────────────────────────────────────────
//  1. Local PNG — filename (with or without .png extension).
//     Resolved from recursive scan of Icons/ folder, matched by
//     filename without extension. First alphabetical match wins.
//  2. In-game sprite — matches sprite.name in Resources pool.
//  3. HTTPS URL — delegated to IconDownloader, applied via callback.
//
//  PrefabGUID resolution:
//  ───────────────────────
//  Built internally from LilithsMind definitions via reflection —
//  same pattern as LocalizationInjector. No PrefabNameResolver needed.
//
//  [PERFORMANCE] BuildSpriteMaps() runs once at world ready.
//                FindObjectsOfTypeAll and reflection are O(n), once only.
//                Apply() is O(n) over overrides with O(1) dict lookups.
//                URL downloads are fully async — no frame blocking.
// ============================================================

namespace LilithsSoul.Services;

public static class IconPatcher
{
    private const string LOG_SOURCE      = "LilithsSoul.IconPatcher";
    private const string PrefabNamespace = "LilithsMind.Prefabs.Definitions";

    static readonly Dictionary<string, PrefabGUID> _nameToPrefabGuid
        = new(StringComparer.OrdinalIgnoreCase);

    static readonly Dictionary<string, string> _localFiles
        = new(StringComparer.OrdinalIgnoreCase);

    static readonly Dictionary<string, Sprite> _gameSprites
        = new(StringComparer.OrdinalIgnoreCase);

    static readonly Dictionary<int, Sprite?> _previousIcons = new();

    // ── Public API ───────────────────────────────────────────

    public static void BuildSpriteMaps()
    {
        BuildPrefabGuidMap();
        BuildLocalFileMap();
        BuildGameSpriteMap();
    }

    public static void Apply(ServerSyncPayload payload)
    {
        if (Soul.ClientWorld == null)
        {
            SoulLogger.Warning(LOG_SOURCE, "Client world not ready — cannot apply icon overrides.");
            return;
        }

        var registry = Soul.ClientWorld
            .GetExistingSystemManaged<ManagedDataSystem>()
            ?.ManagedDataRegistry;

        if (registry == null)
        {
            SoulLogger.Warning(LOG_SOURCE, "ManagedDataRegistry not available — cannot apply icon overrides.");
            return;
        }

        int applied = 0;
        int skipped = 0;

        foreach (var (prefabName, appearance) in payload.ItemAppearanceOverrides)
        {
            if (appearance.Icon is null) continue;

            if (!_nameToPrefabGuid.TryGetValue(prefabName, out var prefabGuid))
            {
                SoulLogger.Warning(LOG_SOURCE, $"No PrefabGUID for '{prefabName}' — skipping icon.");
                skipped++;
                continue;
            }

            var itemData = registry.GetOrDefault<ManagedItemData>(prefabGuid);
            if (itemData == null)
            {
                SoulLogger.Warning(LOG_SOURCE, $"No ManagedItemData for '{prefabName}' — skipping icon.");
                skipped++;
                continue;
            }

            _previousIcons.TryAdd(prefabGuid.GuidHash, itemData.Icon);

            var iconValue = appearance.Icon;

            // 1. HTTPS URL
            if (iconValue.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                var capturedItemData = itemData;
                IconDownloader.FetchOrLoad(iconValue, sprite =>
                {
                    capturedItemData.Icon = sprite;
                    SoulLogger.Info(LOG_SOURCE, $"Applied downloaded icon '{sprite.name}' to '{prefabName}'.");
                });
                applied++;
                continue;
            }

            var key = iconValue.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                ? iconValue[..^4]
                : iconValue;

            // 2. Local PNG
            if (_localFiles.TryGetValue(key, out var filePath))
            {
                var sprite = LoadSpriteFromDisk(filePath, key);
                if (sprite != null)
                {
                    itemData.Icon = sprite;
                    SoulLogger.Debug(LOG_SOURCE, $"Applied local icon '{key}' to '{prefabName}'.");
                    applied++;
                    continue;
                }
            }

            // 3. In-game sprite
            if (_gameSprites.TryGetValue(iconValue, out var gameSprite))
            {
                itemData.Icon = gameSprite;
                SoulLogger.Debug(LOG_SOURCE, $"Applied in-game sprite '{iconValue}' to '{prefabName}'.");
                applied++;
                continue;
            }

            SoulLogger.Warning(LOG_SOURCE, $"Could not resolve icon '{iconValue}' for '{prefabName}'.");
            skipped++;
        }

        SoulLogger.Info(LOG_SOURCE, $"Icon patching complete — {applied} applied, {skipped} skipped.");
    }

    public static void ClearPrevious()
    {
        if (_previousIcons.Count == 0) return;
        if (Soul.ClientWorld == null) return;

        var registry = Soul.ClientWorld
            .GetExistingSystemManaged<ManagedDataSystem>()
            ?.ManagedDataRegistry;

        if (registry == null) return;

        foreach (var (guidHash, originalSprite) in _previousIcons)
        {
            var itemData = registry.GetOrDefault<ManagedItemData>(new PrefabGUID(guidHash));
            if (itemData != null)
                itemData.Icon = originalSprite;
        }

        SoulLogger.Debug(LOG_SOURCE, $"Restored {_previousIcons.Count} original icon(s).");
        _previousIcons.Clear();
    }

    // ── Internal ─────────────────────────────────────────────

    static void BuildPrefabGuidMap()
    {
        _nameToPrefabGuid.Clear();

        var mindAssembly    = typeof(PrefabDef).Assembly;
        var definitionTypes = mindAssembly.GetTypes()
            .Where(t => t.IsClass && t.IsAbstract && t.IsSealed && t.Namespace == PrefabNamespace)
            .ToList();

        int count = 0;
        foreach (var type in definitionTypes)
        {
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(PrefabDef)))
            {
                var def  = (PrefabDef)field.GetValue(null)!;
                var guid = new PrefabGUID(def.GuidHash);

                // Prefab is non-nullable string — assign directly.
                _nameToPrefabGuid[def.Prefab] = guid;

                // [CHANGED] Name is nullable string? — guard with IsNullOrEmpty
                // to prevent ArgumentNullException in Dictionary on first boot.
                if (!string.IsNullOrEmpty(def.Name))
                    _nameToPrefabGuid[def.Name] = guid;

                count++;
            }
        }

        SoulLogger.Info(LOG_SOURCE,
            $"PrefabGUID map built — {count} definition(s) from {definitionTypes.Count} class(es).");
    }

    static void BuildLocalFileMap()
    {
        _localFiles.Clear();

        if (!Directory.Exists(SoulPathIndex.IconsDir))
        {
            SoulLogger.Debug(LOG_SOURCE, "Icons/ directory does not exist — no local icons loaded.");
            return;
        }

        foreach (var file in Directory
            .GetFiles(SoulPathIndex.IconsDir, "*.png", SearchOption.AllDirectories)
            .OrderBy(f => f, StringComparer.Ordinal))
        {
            var key = Path.GetFileNameWithoutExtension(file);
            if (!_localFiles.ContainsKey(key))
                _localFiles[key] = file;
        }

        SoulLogger.Info(LOG_SOURCE, $"Local icon map built — {_localFiles.Count} PNG(s) found.");
    }

    static void BuildGameSpriteMap()
    {
        _gameSprites.Clear();

        foreach (var sprite in Resources.FindObjectsOfTypeAll<Sprite>())
        {
            if (sprite == null || string.IsNullOrEmpty(sprite.name)) continue;
            _gameSprites.TryAdd(sprite.name, sprite);
        }

        SoulLogger.Info(LOG_SOURCE, $"Game sprite map built — {_gameSprites.Count} sprite(s) indexed.");
    }

    static Sprite? LoadSpriteFromDisk(string filePath, string name)
    {
        try
        {
            var bytes   = File.ReadAllBytes(filePath);
            var texture = new Texture2D(2, 2);

            if (!texture.LoadImage(bytes))
            {
                SoulLogger.Warning(LOG_SOURCE, $"Failed to decode PNG '{name}'.");
                return null;
            }

            var sprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f),
                pixelsPerUnit: 100f);

            sprite.name = name;
            return sprite;
        }
        catch (Exception ex)
        {
            SoulLogger.Warning(LOG_SOURCE, $"Failed to load '{name}' from disk: {ex.Message}");
            return null;
        }
    }
}