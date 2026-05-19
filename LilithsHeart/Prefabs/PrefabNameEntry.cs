// [CHANGED] Extracted from PrefabNameResolver.cs into its own file.
//           PrefabNameEntry is used by both PrefabNameExporter and PrefabNameResolver —
//           it belongs in neither exclusively. Its own file makes the sharing explicit
//           and keeps both class files free of unrelated type definitions.

namespace LilithsHeart.Prefabs;

public class PrefabNameEntry
{
    /// <summary>
    /// The exact C# field name from the prefab registry class.
    /// This matches the game's internal prefab name and is always
    /// authoritative from code — never overwritten from disk.
    /// </summary>
    public string OriginalName { get; set; } = string.Empty;

    /// <summary>
    /// Optional admin-defined alias for this prefab.
    /// Set via the [PrefabName("...")] attribute in registry classes,
    /// or manually edited in the generated Names/*.json files.
    /// Takes priority over OriginalName in all lookups and generated output.
    /// </summary>
    public string NewName { get; set; } = string.Empty;
}