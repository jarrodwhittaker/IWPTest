using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour {

    hexTile[] rangeVicinity;

    public static GameController Instance;

    public UnitScript baseee;
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
    public Text Winning;
    public Button Replay;
    public Button Menu;
    public Text Losing;
    public string win = "You win!";
    public string lose = "Aww shucks! Better Luck Next Time!";
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
        Winning.text = win;
        Replay.enabled = true;
        Menu.enabled = true;
    }

    public void ILost()
    {
        Losing.text = lose;
        Replay.enabled = true;
        Menu.enabled = true;
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
            if (noOfUnits <= 0)
            {
                ILost();
            }
        }
        else
        {
            noOfEnemies -= 1;
            enemiesLeft.text = "Enemies Left: " + noOfEnemies;
        }
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

            UnitScript[] players = FindObjectsOfType<UnitScript>();

            foreach(UnitScript player in players)
            {
                if(player.isPlayer == true)
                {
                    player.currentattackrange = player.AttackRange;
                }
            }

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

        if(Input.GetKey("p"))
        {

        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }


    public void OnUnitClicked(UnitScript unit)
    {
        if(rangeVicinity != null)
        {
            if(rangeVicinity.Length > 0)
            {
                foreach(hexTile tile in rangeVicinity)
                {
                    Material material = tile.GetComponent<MeshRenderer>().material;
                    material.color = Color.white;
                }
            }
        }

        rangeVicinity = new hexTile[0];

        Debug.Log(unit.gameObject.name);

        if(unit.isPlayer != true)
        {
            targetUnit = unit;

            if(activeUnit != null)
            {
                OnEnemyClicked(unit);
            }

            Debug.Log(unit.gameObject.name + " is the enemy");
        }

        else
        {
            activeUnit = unit;
            targetUnit = null;
            Debug.Log(unit.gameObject.name + " is your troop");

            int range = activeUnit.currentattackrange;

            if(range > UnitScript.currentPool)
            {
                range = UnitScript.currentPool;
            }

            rangeVicinity = hexAid.DefineHood(activeUnit.myTile, range, activeUnit.canImpassable);
            Debug.Log(rangeVicinity.Length);
            foreach(hexTile tile in rangeVicinity)
            {
                Material material = tile.GetComponent<MeshRenderer>().material;
                material.color = Color.grey;
            }

        }
        // To be worked on, having the target refresh after a certain amount of time.
    }

    // Called by tile that was clicked.
    public void OnTileClicked(hexTile _tileClicked)
    {
        if(rangeVicinity != null)
        {
            if(rangeVicinity.Contains(_tileClicked))
            {
                int cost = hexAid.DefinePath(activeUnit.myTile, _tileClicked, activeUnit.canImpassable).Length - 1;
                activeUnit.currentattackrange -= cost;
                UnitScript.currentPool -= cost;

                Debug.Log("Cost: " + hexAid.DefinePath(activeUnit.myTile, _tileClicked, activeUnit.canImpassable).Length);


                AP.text = "Action Points Left: " + UnitScript.currentPool.ToString();
                activeUnit.target = _tileClicked.transform.position;
                activeUnit.myTile = _tileClicked;
            }

            if(rangeVicinity != null)
            {
                if(rangeVicinity.Length > 0)
                {
                    foreach(hexTile tile in rangeVicinity)
                    {
                        Material material = tile.GetComponent<MeshRenderer>().material;
                        material.color = Color.white;
                    }

                    rangeVicinity = null;
                }
            }
        }
    }

    public void OnEnemyClicked(UnitScript _enemy)
    {
        activeUnit.currentattackrange = 0;
        UnitScript.currentPool = 0;

        AP.text = "Action Points Left: " + UnitScript.currentPool.ToString();
        activeUnit.PerformAttack(_enemy);
    }
}
