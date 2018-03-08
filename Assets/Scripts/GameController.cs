using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance;


    public UnitScript activeUnit;
    public UnitScript targetUnit;

    public RaycastHit hit;

    public Text AP;
    public bool p1;
    public GameObject player1;
    public bool p2;
    public GameObject player2;
    public Text turn;
    public Button swapTurn;

    


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
        turn.text = "Player's Turn";
        swapTurn.onClick.AddListener(EndTurn);

    }

    public void OnUnitClicked(UnitScript unit)
    {
        Debug.Log(unit.gameObject.name);

        if (unit.isPlayer != true)
        {
            targetUnit = unit;
            Debug.Log(unit.gameObject.name + " is the enemy");
        }
        else
        {
            activeUnit = unit;
            targetUnit = null;
            Debug.Log(unit.gameObject.name + " is your troop");
        }
        // To be worked on, having the target refresh after a certain amount of time.
    }

    public void EndTurn()
    {
        
        if (turn.text == "Player's Turn")
        {
            activeUnit = null;
            targetUnit = null;
            turn.text = "Enemy's Turn";
            UnTag();
        }
        else if (turn.text == "Enemy's Turn")
        {
            activeUnit = null;
            targetUnit = null;
            turn.text = "Player's Turn";
            UnTag();
        }
    }

    public void UnTag()
    {
        //GameObject.FindGameObjectsWithTag("Tagged");
        
    }
	
	// Update is called once per frame
	void Update () {

        //// When click occurs, create a raycast.
        //// Check if it hit anything
        //// If so, see if what was hit had a unit script.
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        UnitScript uscript = hit.transform.gameObject.GetComponent<UnitScript>();
        //        Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        //    }
        //}



        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
