using UnityEngine;
using UnityEngine.Networking;
using LilithsSoul.Config;
using LilithsSoul.Foundation;

// ============================================================
//  IconDownloader — LilithsSoul
//  LilithsSoul/Services/IconDownloader.cs
//
//  Handles async download of icon images from HTTPS URLs
//  advertised by the server in ItemAppearanceOverrides.Icon.
//
//  Download behaviour:
//  ───────────────────
//  1. Check if the filename already exists in IconsDir — if so,
//     skip the download entirely (cache hit).
//  2. If not cached, start a UnityWebRequest coroutine to fetch
//     the image bytes from the URL.
//  3. On success, save the PNG bytes to IconsDir/<filename>.png
//     so future connects resolve from disk without re-downloading.
//  4. Create a Texture2D and Sprite from the downloaded bytes
//     and invoke the provided callback so IconPatcher can apply it.
//
//  Filename derivation:
//  ─────────────────────
//  The filename is taken from the last segment of the URL path,
//  stripped of extension, then saved as <name>.png regardless of
//  the original extension. This keeps the Icons/ folder consistent
//  (PNG only) and matches how IconPatcher resolves filenames.
//
//  Example:
//    URL:  "https://example.com/icons/vitae.png"
//    Saved: BepInEx/config/LilithsSoul/Icons/vitae.png
//    Key:  "vitae"
//
//  [PERFORMANCE] Downloads are async — they do not block the main
//                thread or delay payload application. IconPatcher
//                applies the sprite via callback when ready.
//                Cache check is a File.Exists call — O(1).
//                One download per unique URL, per client install.
// ============================================================

namespace LilithsSoul.Services;

public static class IconDownloader
{
    private const string LOG_SOURCE = "LilithsSoul.IconDownloader";

    // ── Public API ───────────────────────────────────────────

    /// <summary>
    /// Attempts to resolve a URL to a sprite. Checks the Icons/ cache
    /// first — if the file exists, creates and returns the sprite
    /// immediately via callback. If not, downloads asynchronously
    /// and invokes the callback on completion.
    /// </summary>
    public static void FetchOrLoad(string url, Action<Sprite> onComplete)
    {
        if (string.IsNullOrWhiteSpace(url)) return;

        var fileName = DeriveFileName(url);
        var filePath = Path.Combine(SoulPathIndex.IconsDir, fileName + ".png");

        if (File.Exists(filePath))
        {
            SoulLogger.Debug(LOG_SOURCE,
                $"Cache hit for '{fileName}' — loading from disk.");

            var sprite = LoadSpriteFromDisk(filePath, fileName);
            if (sprite != null) onComplete(sprite);
            return;
        }

        SoulLogger.Info(LOG_SOURCE,
            $"Downloading icon '{fileName}' from '{url}'...");

        // Kick off async download — runs as a coroutine on the
        // main Unity thread via Soul's MonoBehaviour host.
        SoulCoroutineHost.Run(DownloadCoroutine(url, filePath, fileName, onComplete));
    }

    // ── Internal ─────────────────────────────────────────────

    static System.Collections.IEnumerator DownloadCoroutine(
        string url,
        string savePath,
        string fileName,
        Action<Sprite> onComplete)
    {
        var request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Failed to download '{fileName}': {request.error}");
            yield break;
        }

        var texture = DownloadHandlerTexture.GetContent(request);
        if (texture == null)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Downloaded texture for '{fileName}' is null.");
            yield break;
        }

        // Save to disk as PNG for future cache hits.
        try
        {
            Directory.CreateDirectory(SoulPathIndex.IconsDir);
            File.WriteAllBytes(savePath, texture.EncodeToPNG());
            SoulLogger.Info(LOG_SOURCE,
                $"Saved '{fileName}' to Icons/ cache.");
        }
        catch (Exception ex)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Could not save '{fileName}' to disk: {ex.Message}");
        }

        var sprite = TextureToSprite(texture, fileName);
        if (sprite != null) onComplete(sprite);
    }

    /// <summary>
    /// Loads a PNG from disk into a Sprite.
    /// Returns null and logs a warning if the file is malformed.
    /// </summary>
    static Sprite? LoadSpriteFromDisk(string filePath, string fileName)
    {
        try
        {
            var bytes   = File.ReadAllBytes(filePath);
            var texture = new Texture2D(2, 2);

            if (!texture.LoadImage(bytes))
            {
                SoulLogger.Warning(LOG_SOURCE,
                    $"Failed to decode PNG for '{fileName}'.");
                return null;
            }

            return TextureToSprite(texture, fileName);
        }
        catch (Exception ex)
        {
            SoulLogger.Warning(LOG_SOURCE,
                $"Failed to load '{fileName}' from disk: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Creates a Sprite from a Texture2D using the full texture rect.
    /// </summary>
    static Sprite TextureToSprite(Texture2D texture, string name)
    {
        var sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit: 100f);

        sprite.name = name;
        return sprite;
    }

    /// <summary>
    /// Derives a filename key from a URL by taking the last path segment
    /// and stripping the extension.
    /// e.g. "https://example.com/icons/vitae.png" → "vitae"
    /// </summary>
    static string DeriveFileName(string url)
    {
        try
        {
            var uri      = new Uri(url);
            var segment  = uri.Segments[^1];
            return Path.GetFileNameWithoutExtension(segment);
        }
        catch
        {
            // Fallback — sanitize the raw URL into something usable.
            return string.Concat(url
                .Where(c => char.IsLetterOrDigit(c) || c == '-' || c == '_')
                .Take(32));
        }
    }
}