using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameManager : MonoBehaviour {

    public UnitScript activeUnit;
    public UnitScript targetUnit;

    //Fog of War will be coded and addressed here, unsure how to start yet.
    //Wanting to have the fog of war affect when outside of troop rrange.
    //Once troop has spotted an enemy, the enemy is no longer lost in FoW if moved out of sight.

    public Text Turn;
    public Text playerWins;
    public Text playerLoses;
    public bool p1;
    public bool p2;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
