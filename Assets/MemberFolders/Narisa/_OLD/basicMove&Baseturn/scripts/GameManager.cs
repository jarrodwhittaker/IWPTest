using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject TilePrefab;  //tile prefab for grid
    public int mapSize = 11;   //map size
    List <List<Tile>> map = new List<List<Tile>>();  //References tiles as a 2D list

    public GameObject UserPlayerPrefab;  //player prefab
    List<_Player> players = new List<_Player>(); //List reference for player
    int currentPlayerIndex = 0; //Index of how many players are there currently

    public GameObject AIPlayerPrefab; //AI player prefab

    //stuff//
    void Awake() {
        instance = this;
    }


    // Use this for initialization
    void Start () {
    
        generateMap();  //spawn pseduo hexgrid
        generatePlayers(); //spawn players
	}
	
	// Update is called once per frame
	void Update () {

       players[currentPlayerIndex].TurnUpdate();  //next player turn//

	}

    //Function for the player turns//
    public void nextTurn() {
        if (currentPlayerIndex + 1 < players.Count)
        {
            currentPlayerIndex++;
        }
        else {
            currentPlayerIndex = 0;
        }
    }

    //Move to destination tile//
    public void moveCurrentPlayer(Tile destTile) {
        players[currentPlayerIndex].moveDestination = destTile.transform.position + 1.5f * Vector3.up;
    }


    //generating the map//
    void generateMap() {
        map = new List<List<Tile>>();
      		for (int i = 0; i < mapSize; i++) {
        		List <Tile> row = new List<Tile>();
        	for (int j = 0; j < mapSize; j++) {
        			Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
                tile.gridPos = new Vector2(i, j);
                row.Add (tile);
        			}
        			map.Add(row);
        		}
    }

    //Spawns the player(s) at the designated coordinates (x,y,z) //
    void generatePlayers() {
        UserPlayer player;

        player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(0 - Mathf.Floor(mapSize / 2), 1.5f, -0 + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();

        players.Add(player);

      //  player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3((mapSize-1) - Mathf.Floor(mapSize / 2), 1.5f, -(mapSize - 1) + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();

        //players.Add(player);

        AIPlayer aiplayer = ((GameObject)Instantiate(AIPlayerPrefab, new Vector3(6 - Mathf.Floor(mapSize / 2), 1.5f, -4 + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<AIPlayer>();
        players.Add(aiplayer);
    }
}
