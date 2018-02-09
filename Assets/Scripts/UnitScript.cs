using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {

    public bool isPlayer;
    public bool canMove;
    public int basePool = 20;
    public int currentPool;
    public float attackRange = 10;
    public float visionRange = 15;
    //public enum
    //For Sam's audio in FMOD
    public float distanceRemain;

	// Use this for initialization
    // When game begins it sets everything
    // Player begins the game
    // 
	void Start () {
        isPlayer = true;
        canMove = true;
        currentPool = basePool;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
