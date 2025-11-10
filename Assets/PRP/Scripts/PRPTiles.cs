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
    
    public Dictionary<Vector3Int,PRPTileData> TilemapData = new Dictionary<Vector3Int,PRPTileData>();

    void OnValidate()
    {
        if (tilemap == null)
        {
            tilemap = GetComponent<Tilemap>();
        }

        if (tileLibrary == null)
        {
            Debug.LogError("PRP Tile Library Not Assigned in Inspector!");
        }
    }
    
    void Awake()
    {
        var bounds = tilemap.cellBounds;
        // Check each of all positions within the bounds of the given tilemap
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
            TilemapData[pos] = new PRPTileData(pos, tileAssociation.Attributes);
        }
    }

    /// <summary>
    /// Returns the logical data of a tile based on position within tilemap.
    /// Intended to be used for input, UI interactions.
    /// </summary>
    /// <param name="pos">Vector 3 integer position of tile within tilemap.</param>
    /// <returns>The logical data of the tile at pos.</returns>
    public PRPTileData GetTileData(Vector3Int pos)
    {
        return TilemapData[pos];
    }
}
