// ============================================================
//  StationRecipeOverrideData — LilithsSoul
//
//  Client-side mirror of LilithsHeart.Network.StationRecipeOverrideData.
//  Deserialize-only.
// ============================================================

namespace LilithsSoul.Network;

public sealed class StationRecipeOverrideData
{
    public List<string> RecipesToAdd    { get; set; } = new();
    public List<string> RecipesToRemove { get; set; } = new();
}