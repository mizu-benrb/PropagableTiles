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
    public TileBase Tile;
    public Vector3Int GridPosition;
    public List<IEntity> Entities = new List<IEntity>();
    public List<IPRPTileAttribute> Attributes;
    
    public PRPTileData(Vector3Int gridPosition)
    {
        this.GridPosition = gridPosition;
    }
    
    public PRPTileData(Vector3Int gridPosition, List<IPRPTileAttribute> attributes)
    {
        this.GridPosition = gridPosition;
        this.Attributes = attributes;
    }
    
    public PRPTileData(Vector3Int gridPosition, List<IPRPTileAttribute> attributes, List<IEntity> entities)
    {
        this.GridPosition = gridPosition;
        this.Attributes = attributes;
        this.Entities = entities;
    }
}
