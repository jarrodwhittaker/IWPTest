using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Vector2 gridPos = Vector2.zero;   //grid position spawns at (0,0)

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //mouse highlight is set to the color Blue//
    void OnMouseEnter() {

        GetComponent<Renderer>().material.color = Color.blue;

        Debug.Log("my position is(" + gridPos.x + "," + gridPos.y + ")");
    }

    //When the mouse is not over the tiles, it stays white//
    void OnMouseExit() {
        GetComponent<Renderer>().material.color = Color.white;
    }

    //On mouse click, move the player to that tile//
    void OnMouseDown() {
        GameManager.instance.moveCurrentPlayer(this);
    }
}
