using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "PRP/PRPTileAssociation")]
public class PRPTileAssociation: ScriptableObject
{
    public TileBase Tile;
    public List<IPRPTileAttribute> Attributes = new List<IPRPTileAttribute>();
}
