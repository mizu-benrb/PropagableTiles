using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "PRP/PRPTileAssociation")]
public class PRPTileAssociation: ScriptableObject
{
    public TileBase Tile;
    [SerializeReference] public List<PRPTileAttribute> Attributes = new List<PRPTileAttribute>();
}
