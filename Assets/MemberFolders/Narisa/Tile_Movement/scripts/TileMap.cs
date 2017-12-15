using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TileMap : MonoBehaviour
{

    public GameObject selectedUnit;  //player unit

    public TileType[] tileTypes;  //array of different tile types. In this case: walkable tile and unwalkable tiles

    int[,] tiles;  //array of tiles
    Node[,] graph;  //Node = tile

    //Map Size//
    int mapSizeX = 10;
    int mapSizeY = 10;

    void Start()
    {
        // Setup the selectedUnit's variable
        selectedUnit.GetComponent<Unit>().tileX = (int)selectedUnit.transform.position.x;
        selectedUnit.GetComponent<Unit>().tileY = (int)selectedUnit.transform.position.y;
        selectedUnit.GetComponent<Unit>().map = this;

        //Map generation - data, pathfinding, visuals
        GenerateMapData();
        GeneratePathfindingGraph();
        GenerateMapVisual();
    }

    //Generatin the map
    void GenerateMapData()
    {
        // Allocate our map tiles
        tiles = new int[mapSizeX, mapSizeY];

        int x, y;

        // Initialize our map tiles to be tile 0 (aka walkable tile)
        for (x = 0; x < mapSizeX; x++)
        {
            for (y = 0; y < mapSizeX; y++)
            {
                tiles[x, y] = 0;
            }
        }

        // Jellyfish forest (unwalkable tile locations)
        tiles[4, 4] = 1;
        tiles[5, 4] = 1;
        tiles[6, 4] = 1;
        tiles[7, 4] = 1;
        tiles[8, 4] = 1;

        tiles[4, 5] = 1;
        tiles[4, 6] = 1;
        tiles[8, 5] = 1;
        tiles[8, 6] = 1;

        //Additional environmental obstacles
        tiles[1,8] = 1;
        tiles[4,2] = 1;
        tiles[3,1] = 1;
        tiles[2,0] = 1;

    }

    //Function regarding movement cost - at this time it will only cost 1 movement point to move across each tile
    public float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY)
    {

        TileType tt = tileTypes[tiles[targetX, targetY]];

        if (UnitCanEnterTile(targetX, targetY) == false)
            return Mathf.Infinity;

        float cost = tt.movementCost;

        if (sourceX != targetX && sourceY != targetY)
        {
            // We are moving diagonally! which will cost a barely noticable movement cost
            // YAAAS
            cost += 0.001f;
        }

        return cost;

    }

    //Pathfinding function
    void GeneratePathfindingGraph()
    {
        // Initialize the array
        graph = new Node[mapSizeX, mapSizeY];

        // Initialize a Node for each spot in the array
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                graph[x, y] = new Node();
                graph[x, y].x = x;
                graph[x, y].y = y;
            }
        }

        // Now that all the nodes exist, calculate their neighbours
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                // This is the 8-way connection version (allows diagonal movement) which we need for the hexagonal grid system
              
                // Try left (to the left, to the left..?)
                if (x > 0)
                {
                    graph[x, y].neighbours.Add(graph[x - 1, y]);
                    if (y > 0)
                        graph[x, y].neighbours.Add(graph[x - 1, y - 1]);
                    if (y < mapSizeY - 1)
                        graph[x, y].neighbours.Add(graph[x - 1, y + 1]);
                }

                // Try Right
                if (x < mapSizeX - 1)
                {
                    graph[x, y].neighbours.Add(graph[x + 1, y]);
                    if (y > 0)
                        graph[x, y].neighbours.Add(graph[x + 1, y - 1]);
                    if (y < mapSizeY - 1)
                        graph[x, y].neighbours.Add(graph[x + 1, y + 1]);
                }

                // Try straight up and down
                if (y > 0)
                    graph[x, y].neighbours.Add(graph[x, y - 1]);
                if (y < mapSizeY - 1)
                    graph[x, y].neighbours.Add(graph[x, y + 1]);
            }
        }
    }

    //Map visuals as a square grid
    void GenerateMapVisual()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeX; y++)
            {
                TileType tt = tileTypes[tiles[x, y]];
                GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);

                ClickableTile ct = go.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;
            }
        }
    }
    
    //Converts the tile coordinates to the "game world" coordinates, I believe, I *may* have forgot what this function did in particular
    public Vector3 TileCoordToWorldCoord(int x, int y)
    {
        return new Vector3(x, y, 0);
    }

    public bool UnitCanEnterTile(int x, int y)
    {
        // is the tile walkabe?

        return tileTypes[tiles[x, y]].isWalkable;
    }

    //
    public void GeneratePathTo(int x, int y)
    {
        // Clear out our unit's old path.
        selectedUnit.GetComponent<Unit>().currentPath = null;

        if (UnitCanEnterTile(x, y) == false)
        {
            // We probably clicked on a unwalkable tile, so quit
            return;
        }

        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

        // the list of tiles (nodes) we haven't checked yet.
        List<Node> unvisited = new List<Node>();

        Node source = graph[
                            selectedUnit.GetComponent<Unit>().tileX,
                            selectedUnit.GetComponent<Unit>().tileY
                            ];

        Node target = graph[
                            x,
                            y
                            ];

        dist[source] = 0;
        prev[source] = null;

        // Initialize everything to have INFINITY distance, since I don't know any better right now. Also, it's possible that some nodes CAN'T be reached from the source,
        // which would make INFINITY a reasonable value
        foreach (Node v in graph)
        {
            if (v != source)
            {
                dist[v] = Mathf.Infinity;
                prev[v] = null;
            }

            unvisited.Add(v);
        }

        while (unvisited.Count > 0)
        {
            // "u" is going to be the unvisited node with the smallest distance.
            Node u = null;

            foreach (Node possibleU in unvisited)
            {
                if (u == null || dist[possibleU] < dist[u])
                {
                    u = possibleU;
                }
            }

            if (u == target)
            {
                break;  // Exit the while loop!
            }

            unvisited.Remove(u);

            foreach (Node v in u.neighbours)
            {
                float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
                if (alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }

        // If we get there, then either we've found the shortest route to our target, or there is no route at ALL to our target.

        if (prev[target] == null)
        {
            // No route between our target and the source
            return;
        }

        List<Node> currentPath = new List<Node>();

        Node curr = target;

        // Step through the "prev" chain and add it to our path
        while (curr != null)
        {
            currentPath.Add(curr);
            curr = prev[curr];
        }

        // Right now, currentPath describes a route from out target to our source
        // So we need to invert it!

        currentPath.Reverse();

        selectedUnit.GetComponent<Unit>().currentPath = currentPath;
    }

}
