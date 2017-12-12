using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileType
{

    public string name;  //name the tile in the inspector
    public GameObject tileVisualPrefab;  //visual representation of the tile (e.g. green = grass, brown = dirt)

    public bool isWalkable = true; //is it walkable?
    public float movementCost = 1;  //how much the tile cost, currently it costs one 

}
