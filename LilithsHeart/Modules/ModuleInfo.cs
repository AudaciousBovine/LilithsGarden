// [CHANGED] Moved from Registry/ → Modules/.
//           Namespace updated: LilithsHeart.Registry → LilithsHeart.Modules.

namespace LilithsHeart.Modules;

/// <summary>
/// Metadata describing a registered LilithsHeart module.
/// Passed to HeartRegistry.Register() in each module's Plugin.Load().
/// </summary>
public class ModuleInfo
{
    /// <summary>
    /// Unique reverse-domain ID matching the BepInPlugin GUID.
    /// e.g. "audaciousbovine.lilithsbounty"
    /// </summary>
    public string ModuleId { get; set; } = string.Empty;

    /// <summary>Human-readable name. e.g. "LilithsBounty"</summary>
    public string ModuleName { get; set; } = string.Empty;

    /// <summary>Semantic version string. e.g. "0.1.0"</summary>
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Optional capability tags this module exposes.
    /// Other modules can query these for feature discovery.
    /// e.g. "drop-tables", "currency", "quests"
    /// </summary>
    public string[] Capabilities { get; set; } = Array.Empty<string>();
}