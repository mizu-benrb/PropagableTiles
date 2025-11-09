using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PRPVisualUpdateManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private PRPVisualLookup visualLookup;

    // Uhhhhh gotta fill this in, probably awake which initializes 
    private Dictionary<Vector3Int, string> currentVisualStateLookup = new();

    public void UpdateVisual(PRPTileData tileData, string attributeKey)
    {
        string baseName = tileData.baseType;
        Vector3Int tilePos = tileData.gridPosition;

        // Future avenue: add priority order!
        if (visualLookup.TryGetTile(baseName, attributeKey, out var tile))
        {
            tilemap.SetTile(tilePos, tile);
        }
    }
}
