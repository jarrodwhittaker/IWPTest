using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ClickableTile : MonoBehaviour
{

    public int tileX;
    public int tileY;
    public TileMap map;

    void OnMouseUp()
    {
        //Debug.Log("Clicky click");

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        map.GeneratePathTo(tileX, tileY);  //on mouse click, generate path to the selected tile
    }

}
