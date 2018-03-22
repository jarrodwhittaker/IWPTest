using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
    public Text unitsLeft;
    public Text enemiesLeft;
    public Canvas Winning;
    public Canvas Losing;

    public int noOfEnemies;
    public int noOfUnits;
    


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
        Winning.enabled = false;
        Losing.enabled = false;
        //p1 will be the first to move
        p1 = true;
        // p2 will be restricted from moving
        p2 = false;
        turn.text = "Player's Turn";
        swapTurn.onClick.AddListener(EndTurn);
        unitsLeft.text = "Units Left: " + noOfUnits;
        enemiesLeft.text = "Enemies Left: " + noOfEnemies;
    }

    public void IWon()
    {
        //if() ;
    }

    public void GoingUp(bool isPlayer)
    {
        // Have the tally of enemies and units go up at the beginning of the game to the amount in the level.
        Debug.Log("Hello");
        if (isPlayer)
        {
            noOfUnits += 1;
            unitsLeft.text = "Units Left: " + noOfUnits;
        }
        else
        {
            noOfEnemies += 1;
            enemiesLeft.text = "Enemies Left: " + noOfEnemies;
        }
    }

    public void GoingDown(bool isPlayer)
    {
        // Have the tally of enemies and units go up at the beginning of the game to the amount in the level.
        Debug.Log("Point down");
        if (isPlayer)
        {
            noOfUnits -= 1;
            unitsLeft.text = "Units Left: " + noOfUnits;
        }
        else
        {
            noOfEnemies -= 1;
            enemiesLeft.text = "Enemies Left: " + noOfEnemies;
        }
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
            UnitScript.StartTurn();
            StartCoroutine(P2Turn());
            p2 = true;
            p1 = false;
        }
        else if (turn.text == "Enemy's Turn")
        {
            activeUnit = null;
            targetUnit = null;
            turn.text = "Player's Turn";
            UnitScript.StartTurn();

            p1 = true;
            p2 = false;
        }
    }

    public IEnumerator P2Turn()
    {
        // find all enemies and sort them based on their type
        List<UnitScript> allEnemies = FindObjectsOfType<UnitScript>().Where(unit => unit.isPlayer == false).OrderBy(unit => unit.unitType).ToList();

        // loop over all of the enemies
        foreach (UnitScript enemy in allEnemies)
        {
            Debug.Log(enemy.gameObject.name);

            // find all of the player units
            List<UnitScript> allPlayers = FindObjectsOfType<UnitScript>().Where(unit => unit.isPlayer == true).ToList();

            // loop over all of the player units and attacks each one
            foreach (UnitScript playerUnit in allPlayers)
            {
                enemy.PerformAttack(playerUnit);
                yield return new WaitForSeconds(2f);
            }
        }

        yield return null;
    }

    public void FindThePlayers()
    {
        // wanting to check all units within the range
        // Detects whether the bool isPlayer is true or false
        // if the closest unit has isPlayer, attack them.
        //FindSceneObjectsOfType
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
