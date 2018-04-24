using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

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
    public Button Pause;
    public Canvas Pausing;
    public Text Losing;
    public string win = "You win!";
    public string lose = "Aww shucks! Better Luck Next Time!";
    public int noOfEnemies;
    public int noOfUnits;

    public Text NoPoints;
    public Text Announcement;

    public Button Leave;
    
    public Canvas really;
    public Button yesreally;
    public Button noreally;

    public static bool GameOver = false;


    //Instance variable equals game object
    // Sets Instance
    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        GameOver = false;

        //p1 will be the first to move
        p1 = true;
        // p2 will be restricted from moving
        p2 = false;
        turn.text = "Player's Turn";
        swapTurn.onClick.AddListener(EndTurn);
        unitsLeft.text = "" + noOfUnits;
        enemiesLeft.text = "" + noOfEnemies;
        Replay.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Pausing.gameObject.SetActive(false);
        NoPoints.text = "";
        really.gameObject.SetActive(false);
        BigPlayerTurn();

        
    }

    public void SceneSong()
    {
        SceneManager.GetActiveScene();
    }

    public void IWon()
    {
        GameOver = true;

        Winning.text = win;
        Replay.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        swapTurn.gameObject.SetActive(false);
        Debug.Log("We did it");
    }

    public void ILost()
    {
        GameOver = true;

        Losing.text = lose;
        Replay.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        swapTurn.gameObject.SetActive(false);
        Debug.Log("Dang");
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        Pausing.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        swapTurn.gameObject.SetActive(false);
        Leave.gameObject.SetActive(true);
    }

    public void AreYouSure()
    {
        really.gameObject.SetActive(true);
        Pausing.gameObject.SetActive(false);
        yesreally.gameObject.SetActive(true);
        noreally.gameObject.SetActive(true);
    }

    public void Regret()
    {
        really.gameObject.SetActive(false);
        Pausing.gameObject.SetActive(true);
        yesreally.gameObject.SetActive(false);
        noreally.gameObject.SetActive(false);
    }

    public void GameResume()
    {
        
        Time.timeScale = 1;
        Pausing.gameObject.SetActive(false);
        Pause.gameObject.SetActive(true);
        swapTurn.gameObject.SetActive(true);


    }

    public void BigPlayerTurn()
    {
        Announcement.text = "Player's Turn";
        Invoke("Vanish", 2f);
    }
    
    public void BigEnemyTurn()
    {
        Announcement.text = "Enemy Turn";
        Invoke("Vanish", 2f);
    }

    public void Vanish()
    {
        Announcement.text = "";
    }

    public void GoingUp(bool isPlayer)
    {
        // Have the tally of enemies and units go up at the beginning of the game to the amount in the level.
        Debug.Log("Hello");
        if (isPlayer)
        {
            noOfUnits += 1;
            unitsLeft.text = "" + noOfUnits;
        }

        else
        {
            noOfEnemies += 1;
            enemiesLeft.text = "" + noOfEnemies;
        }
    }

    public void GoingDown(bool isPlayer)
    {
        // Have the tally of enemies and units go up at the beginning of the game to the amount in the level.
        Debug.Log("Point down");
        if (isPlayer)
        {
            noOfUnits -= 1;
            unitsLeft.text = "" + noOfUnits;
            if (noOfUnits <= 0)
            {
                ILost();
            }
        }
        else
        {
            noOfEnemies -= 1;
            enemiesLeft.text = "" + noOfEnemies;
        }
    }


    public void EndTurn()
    {
        
        if (turn.text == "Player's Turn")
        {
            swapTurn.interactable = false;
            activeUnit = null;
            targetUnit = null;
            turn.text = "Enemy's Turn";
            UnitScript.StartTurn();
            StartCoroutine(P2Turn());
            p2 = true;
            p1 = false;
            NoPoints.text = "";
            BigEnemyTurn();
        }

        else if (turn.text == "Enemy's Turn")
        {
            swapTurn.interactable = true;
            activeUnit = null;
            targetUnit = null;
            turn.text = "Player's Turn";
            UnitScript.StartTurn();
            NoPoints.text = "";
            BigPlayerTurn();
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
        bool didAnyAttack = false;
        foreach (UnitScript enemy in allEnemies)
        {
            Debug.Log(enemy.gameObject.name);

            // find all of the player units
            List<UnitScript> allPlayers = FindObjectsOfType<UnitScript>().Where(unit => unit.isPlayer == true).ToList();

            // loop over all of the player units and attacks each one
            foreach (UnitScript playerUnit in allPlayers)
            {
                if (enemy.PerformAttack(playerUnit))
                {
                    yield return new WaitForSeconds(0.5f);
                    didAnyAttack = true;
                }
            }
        }

        if (!didAnyAttack)
            yield return new WaitForSeconds(0.5f);

        EndTurn();
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
            IWon();
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }


    public void OnUnitClicked(UnitScript unit)
    {
        // Remove the current vicinity.
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
        }    

        // Definw new vicinity.
        rangeVicinity = new hexTile[0];

        if(unit.isPlayer == true)
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

            foreach(hexTile tile in rangeVicinity)
            {
                Material material = tile.GetComponent<MeshRenderer>().material;

                if(tile.myUnit == null)
                {

                    material.color = Color.grey;
                }

                else
                {
                    material.color = (tile.myUnit.isPlayer == true) ? Color.blue : Color.red;
                }
            }

        }


        // Check if enemy
        else if(unit.isPlayer == false)
        {
            targetUnit = unit;
            OnEnemyClicked(targetUnit);

            Debug.Log(unit.gameObject.name + " is the enemy");
        }

        // To be worked on, having the target refresh after a certain amount of time.
    }

    public void OnEnemyClicked(UnitScript _enemy)
    {
        Debug.Log("EnemyClicked()");

        if(UnitScript.currentPool > 0)
        {
            // Check which is lower.
            int attackPool = (UnitScript.currentPool < activeUnit.currentattackrange) ? UnitScript.currentPool : activeUnit.currentattackrange; 
            
            hexTile[] attackVicinity = hexAid.DefineHood(activeUnit.myTile, attackPool, true);

            if(attackVicinity.Contains(_enemy.myTile))
            {
                activeUnit.PerformAttack(_enemy);
                activeUnit.currentattackrange = 0;
                UnitScript.currentPool = 0;
                AP.text = UnitScript.currentPool.ToString();
            }
        }
    }


    // Called by tile that was clicked.
    public void OnTileClicked(hexTile _tileClicked)
    {
        if(rangeVicinity != null)
        {
            if(rangeVicinity.Contains(_tileClicked))
            {
                activeUnit.myTile.NullUnit();
                _tileClicked.myUnit = activeUnit;

                int cost = hexAid.DefinePath(activeUnit.myTile, _tileClicked, activeUnit.canImpassable).Length - 1;
                activeUnit.currentattackrange -= cost;
                UnitScript.currentPool -= cost;
                AP.text = UnitScript.currentPool.ToString();
                activeUnit.target = _tileClicked.transform.position;
                activeUnit.myTile = _tileClicked;
                activeUnit.iAmMoving = true;


                if (activeUnit.unitType == UnitScript.UnitType.Tank)
                {
                    AudioManager.Instance.TankMove();
                    Debug.Log("Tank does the move");
                }
                else if (activeUnit.unitType == UnitScript.UnitType.Jet)
                {
                    AudioManager.Instance.JetMove();
                    Debug.Log("Jet does the move");
                }
                else if (activeUnit.unitType == UnitScript.UnitType.Mech)
                {
                    AudioManager.Instance.MechMove();
                    Debug.Log("Mech does the move");
                }
                /*else if (activeUnit.unitType == UnitScript.UnitType.Drone)			---- Commented out until a drone UnitType is completed
{
AudioManager.Instance.DroneMove();
Debug.Log("Drone does the move");
}*/
            }

            if (rangeVicinity.Length > 0)
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
