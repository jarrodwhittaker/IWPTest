using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance;

    public UnitScript activeUnit;
    public UnitScript targetUnit;

    public bool p1;
    public GameObject player1;
    public bool p2;
    public GameObject player2;
    public Text Turn;
    public Button endTurn;

    //Instance variable equals game object
    // Sets Instance
    private void Awake()
    {
        {
            Instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        //p1 will be the first to move
        p1 = true;
        // p2 will be restricted from moving
        p2 = false;
        Turn.text = "Player 1's Turn";
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.mousePosition.y);
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < (Screen.height -40))
       
        {
            GameController.Instance.p1 = !GameController.Instance.p1;
            GameController.Instance.p2 = !GameController.Instance.p2;
        }
        //if it's player 1's turn, disable the movement of player 2 and display text.
        if (p1 != true)
        {
            Turn.text = "Player 2's Turn";
            p1 = false;
            p2 = true;
        }
        else
        {
            Turn.text = "Player 1's Turn";
            p1 = true;
            p2 = false;
        }

        //if it's player 2's turn, disable the movement of player 1 and display text.
        if (p2 != true)
        {
            Turn.text = "Player 1's Turn";
            p2 = false;
            p1 = true;
        }
        else
        {
            Turn.text = "Player 2's Turn";
            p2 = true;
            p1 = false;
        }
	}
}
