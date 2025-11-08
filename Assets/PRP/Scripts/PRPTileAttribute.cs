using UnityEngine;

/// <summary>
/// Describes necessary functions for an attribute of a PRP Tile.
/// </summary>
/// <remarks>
/// This interface defines the operations for dynamic tile attribute behavior.
/// Implementations should only affect, touch data within the attribute or parent tile data.
/// </remarks>
[System.Serializable]
public abstract class PRPTileAttribute: ScriptableObject
{
    public string attributeName;
    
    public abstract void OnApply(PRPTileData tileData);
    public abstract void OnRemove(PRPTileData tileData);
    public abstract void OnTick(PRPTileData tileData);
}
