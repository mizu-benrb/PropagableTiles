using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Represents the logic/data for PRP tilemap.
/// </summary>
public class PRPTiles : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private PRPTileLibrary tileLibrary;
    
    private Dictionary<Vector3Int,PRPTileData> _tilemapData = new Dictionary<Vector3Int,PRPTileData>(); 
    
    void Awake()
    {
        var bounds = tilemap.cellBounds;
        // Check each all positions within the bounds of the given tilemap
        foreach (var pos in bounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if (tile == null) // No tile? Skip iteration.
                continue;
            var tileAssociation = tileLibrary.GetAssociation(tile);
            if (tileAssociation == null) // No tile association? Skip iteration, flag in console
            {
                print("No tile association for tile " + tile.name + "at position " + pos + " !");
                continue;
            }
            _tilemapData[pos] = new PRPTileData(pos, tileAssociation.Attributes);
        }
    }
}
