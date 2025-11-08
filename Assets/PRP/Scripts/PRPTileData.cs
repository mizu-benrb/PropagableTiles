using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Data container for all tiles in Propagable Tiles.
/// </summary>
/// <remarks>
/// This class stores the attributes which drive smarter, more dynamic tilemap behavior.
/// </remarks>
[System.Serializable]
public class PRPTileData
{
    public string baseType;
    public TileBase tile;
    public Vector3Int gridPosition;
    public List<IEntity> Entities = new List<IEntity>();
    public List<PRPTileAttribute> attributes;
    
    public PRPTileData(Vector3Int gridPosition)
    {
        this.gridPosition = gridPosition;
    }
    
    public PRPTileData(Vector3Int gridPosition, List<PRPTileAttribute> attributes)
    {
        this.gridPosition = gridPosition;
        this.attributes = attributes;
    }
    
    public PRPTileData(Vector3Int gridPosition, List<PRPTileAttribute> attributes, List<IEntity> entities)
    {
        this.gridPosition = gridPosition;
        this.attributes = attributes;
        this.Entities = entities;
    }
}
