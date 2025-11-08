using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "PRPVisualLookup", menuName = "PRP/VisualLookup")]
public class PRPVisualLookup : ScriptableObject
{
    [System.Serializable]
    public class VisualRule
    {
        public string baseName;
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
            visualRuleLookup.Add((rule.baseName, rule.attributeKey), rule.tileAsset);
        }
    }

    public bool TryGetTile(string baseName, string attributeKey, out TileBase tile)
    {
        return visualRuleLookup.TryGetValue((baseName, attributeKey), out tile);
    }
}
