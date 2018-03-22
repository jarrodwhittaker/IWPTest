using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deity : MonoBehaviour
{
    public static deity singleton;

    #region------- PATH
    hexTile[] path;
    public hexTile origin { get; private set; }
    public hexTile destination { get; private set; }

    // Hood properties.
    public int range = 1;
    public bool canImpassable = false;
    hexTile[] vicinity;

    // Tile colour properties.
    public Color colourOrigin = Color.green;
    public Color colourDestination = Color.red;
    public Color colourRange = Color.gray;
    public Color colourPath = Color.blue;
    #endregion

    // Executed on object load.
    void Awake()
    {
        singleton = this;
    }

    // Executed ahead of first update.
    void Start()
    {
		
	}
	
	// Executed once per frame.
	void Update ()
    {
        if(path != null)
        {
            if(path.Length > 0)
            {
                for(int index = 0; index < path.Length - 1; ++index)
                {
                    Debug.DrawLine(path[index].transform.position, path[index + 1].transform.position);
                }
            }
        }
	}

    // Accessed to define origin tile and range.
    public void DefineOrigin(hexTile _origin)
    {
        if(origin != null)
        {
            // Remove extant selection on origin.
            {
                Material material = origin.GetComponent<Renderer>().material;
                material.color = Color.white;
            }

            // Remove extant selection on vicinity.
            foreach(hexTile neighbour in vicinity)
            {
                Material material = neighbour.GetComponent<Renderer>().material;
                material.color = Color.white;
            }
        }

        // Define new origin and vicinity.
        origin = _origin;
        vicinity = hexAid.DefineHood(origin, range, canImpassable);

        // Display origin selection.
        {
            Material material = origin.GetComponent<Renderer>().material;
            material.color = colourOrigin;
        }

        // Display vicinity selection. 
        foreach(hexTile neighbour in vicinity)
        {
            Material material = neighbour.GetComponent<Renderer>().material;
            material.color = colourRange;
        }
    }

    // Accessed to define destination tile.
    public void DefineDestination(hexTile _destination)
    {
        // Remove extant selection on destination.
        if(destination != null)
        {
            Material material = destination.GetComponent<Renderer>().material;
            material.color = Color.white;
        }

        // Define and display new destination selection. 
        {
            destination = _destination;
            Material material = destination.GetComponent<Renderer>().material;

            material.color = colourDestination;
        }

        // Commence path if origin defined.
        if(origin != null)
        {
            path = hexAid.DefinePath(origin, destination, canImpassable);
        }

        else
        {
            Debug.Log("Path not found.");
        }
    }
}
