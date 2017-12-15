using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance;

    public bool p1;
    public GameObject player1;
    public bool p2;
    public GameObject player2;
    public Text Turn;
    public Button endTurn;

	// Use this for initialization
	void Start () {
        //p1 will be the first to move
        p1 = true;
        // p2 will be restricted from moving
        p2 = false;
        Turn.text = "Player 1 Turn";
	}
	
	// Update is called once per frame
	void Update () {
        //if it's player 1's turn, disable the movement of player 2 and display text.
        if (p1 == true)
        {
            Turn.text = "Player 1 Turn";
            p2 = false;
        }
        //if it's player 2's turn, disable the movement of player 1 and display text.
        else if (p2 == true)
        {
            Turn.text = "Player 2 Turn";
            p1 = false;
        }
	}
}
