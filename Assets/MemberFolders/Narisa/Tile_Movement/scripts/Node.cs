using UnityEngine;
using System.Collections.Generic;

public class Node
{
    public List<Node> neighbours;  //list of neighboring tiles
    public int x;
    public int y;

    public Node()
    {
        neighbours = new List<Node>();  //new list of neighbor tiles
    }

    public float DistanceTo(Node n)
    {
        
        return Vector2.Distance(
            new Vector2(x, y),
            new Vector2(n.x, n.y)
            );
    }

}
