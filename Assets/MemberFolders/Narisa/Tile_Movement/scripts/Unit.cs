using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour
{
    
    //tileX & tileY are referring to the map tile positions, not the world coords. This allows for the map to be scaled or off-set. Including allowing the cube to 
    //slip in between tiles (e.g. go in between two tiles diagonally)
    public int tileX;
    public int tileY;

    public TileMap map;

    // Our pathfinding info.  If there is no destination set, destination is then = null
    public List<Node> currentPath = null;

    // How far this unit can move in one turn and movement points before it's turn must end. Now set to be a public variable so it can be changed in the inspector
   public int moveSpeed = 5;
   public float remainingMovement = 5;

    void Update()
    {
        // Draw our debug line showing the pathfinding! You can render it by enabling Gizmo within Unity's game window
        // NOTE: This won't appear in the actual game view...sadly
        if (currentPath != null)
        {
            int currNode = 0;

            while (currNode < currentPath.Count - 1)
            {

                Vector3 start = map.TileCoordToWorldCoord(currentPath[currNode].x, currentPath[currNode].y) +
                    new Vector3(0, 0, -1f);
                Vector3 end = map.TileCoordToWorldCoord(currentPath[currNode + 1].x, currentPath[currNode + 1].y) +
                    new Vector3(0, 0, -1f);

                Debug.DrawLine(start, end, Color.black);

                currNode++;
            }
        }

        // Have we moved our cube close enough to the tile destination that we can
        // move to the next step in our pathfinding?
        if (Vector3.Distance(transform.position, map.TileCoordToWorldCoord(tileX, tileY)) < 0.1f)
            AdvancePathing();

        // Moves towards the map tile smoothly
        transform.position = Vector3.Lerp(transform.position, map.TileCoordToWorldCoord(tileX, tileY), 5f * Time.deltaTime);
    }

    // Advances our pathfinding progress by one tile.
    void AdvancePathing()
    {
        if (currentPath == null)
            return;

        if (remainingMovement <= 0)
            return;

        // Teleport us to our correct "current" position, in case we
        // haven't finished the animation yet.
        transform.position = map.TileCoordToWorldCoord(tileX, tileY);

        // Get cost from current tile to next tile
        remainingMovement -= map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y);

        // Move us to the next tile in the sequence
        tileX = currentPath[1].x;
        tileY = currentPath[1].y;

        // Remove the old "current" tile from the pathfinding list
        currentPath.RemoveAt(0);

        if (currentPath.Count == 1)
        {
            //If there is one tile left in the path and we are standing on it...it is the ultimate destination therefore clear pathfinding info
            currentPath = null;
        }
    }

    // The "End Turn" button calls this.
    public void NextTurn()
    {
        // Make sure to wrap-up any outstanding movement left over.
        while (currentPath != null && remainingMovement > 0)
        {
            AdvancePathing();
        }

        // Reset movement points.
        remainingMovement = moveSpeed;
    }
}
