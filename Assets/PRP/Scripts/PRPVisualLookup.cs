using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Lookup table linking base tile types, attribute key combos to TileBase assets
/// Used to define the visual asepct of tile transformations
/// </summary>
[CreateAssetMenu(fileName = "PRPVisualLookup", menuName = "PRP/VisualLookup")]
public class PRPVisualLookup : ScriptableObject
{
    // Future avenue: Add priority order
    [System.Serializable]
    public class VisualRule
    {
        public string baseType;
        public string attributeKey;
        public TileBase tileAsset;
    }
    
    [SerializeField] private List<VisualRule> visualRules;
    private Dictionary<(string, string), TileBase> visualRuleLookup;
    
    void OnEnable()
    {
        visualRuleLookup = new Dictionary<(string, string), TileBase>();
        foreach (var rule in visualRules)
        {
            visualRuleLookup.Add((rule.baseType, rule.attributeKey), rule.tileAsset);
        }
    }

    /// <summary>
    /// Tries to get a tile for specified tile base type, attribute combo.
    /// </summary>
    /// <param name="baseType">The base type for a tile.</param>
    /// <param name="attributeKey">The name of a given attribute.</param>
    /// <param name="tile">If successful, the tile asset corresponding to the base type and attribute.</param>
    /// <returns>True if (base, attribute) combo defined as corresponding with tile, false otherwise.</returns>
    public bool TryGetTile(string baseType, string attributeKey, out TileBase tile)
    {
        return visualRuleLookup.TryGetValue((baseType, attributeKey), out tile);
    }
}
