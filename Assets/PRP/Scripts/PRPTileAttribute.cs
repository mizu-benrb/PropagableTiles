using UnityEngine;

/// <summary>
/// Describes necessary functions for an attribute of a PRP Tile.
/// </summary>
/// <remarks>
/// This interface defines the operations for dynamic tile attribute behavior.
/// Implementations should only affect, touch data within the attribute or parent tile data.
/// </remarks>
public interface IPRPTileAttribute
{
    public void OnApply(PRPTileData tileData);
    public void OnRemove(PRPTileData tileData);
    public void OnTick(PRPTileData tileData);
}
