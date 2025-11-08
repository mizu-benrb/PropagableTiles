using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Updates every tile in a given PRPTiles component every time tick.
/// Invoked by a PRPTimeTicker
/// </summary>
[RequireComponent(typeof(PRPTiles))]
public class PRPTileUpdater : MonoBehaviour
{
    [SerializeField] private PRPTiles tilemap;
    
    // Future avenue: Store, operate only on active tiles
    
    /// <summary>
    /// Updates every tile in the referenced PRPTiles asset.
    /// Future avenue: Do the work in this function in parallel via Jobs
    /// </summary>
    private void UpdateTilemap()
    {
        foreach (var tile in tilemap.TilemapData)
        {
            foreach (var attr in tile.Value.attributes)
            {
                attr.OnTick(tile.Value);
                
                //  Invoke visual updater functions here
            }
        }
    }

    private void AddTileAttribute(PRPTileData tileData, PRPTileAttribute attribute)
    {   
        tileData.attributes.Add(attribute);
        attribute.OnApply(tileData);
        
        // Invoke visual updater functions here
    }
}
