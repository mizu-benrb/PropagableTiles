using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "PRP/PRPTileLibrary")]
public class PRPTileLibrary : ScriptableObject
{
    [SerializeField] private List<PRPTileAssociation> associations;
    public Dictionary<TileBase, PRPTileAssociation> lookup;

    // On enable, ensure each association given actually has a TileBase assigned.
    void OnEnable()
    {
        lookup = new Dictionary<TileBase, PRPTileAssociation>();
        foreach (var association in associations)
        {
            if (association.Tile != null)
                lookup[association.Tile] = association;
        }
    }
    
    /// <summary>
    /// Looks up given tile and returns relevant data attributes
    /// </summary>
    /// <param name="tile">A TileBase, typically from a tile palette</param>
    /// <returns>If lookup is successful, a list of attributes. Otherwise, null.</returns>
    public PRPTileAssociation GetAssociation(TileBase tile)
    {
        lookup.TryGetValue(tile, out var result);
        return result;
    }
}
