using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {
    public enum UnitType {
        Tank, Jet, Mech, Bunker, Flak, Pak
    };

    public bool isPlayer;
    public bool canMove;
    public int basePool = 20;
    public int currentPool;
    public float attackRange = 10;
    public float visionRange = 15;
    public UnitType troops = UnitType.Mech;
    //For Sam's audio in FMOD
    public float distanceRemain;

	// Use this for initialization
    // When game begins it sets everything
    // Player begins the game
    // 
	void Start () {
        
        currentPool = basePool;
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
