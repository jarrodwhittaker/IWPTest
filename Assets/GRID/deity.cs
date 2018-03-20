using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deity : MonoBehaviour
{
    public static deity singleton;

    #region------- PATH
    public hexTile origin { get; private set; }
    public hexTile destination { get; private set; }
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
		
	}

    // Accessed to define origin tile.
    public void DefineOrigin(hexTile _origin)
    {
        origin = _origin;
        Material material = origin.GetComponent<Renderer>().material;

        material.color = Color.cyan;
        Debug.Log(origin.myKey.axial);
    }

    // Accessed to define destination tile.
    public void DefineDestination(hexTile _destination)
    {
        destination = _destination;
        Material material = destination.GetComponent<Renderer>().material;

        material.color = Color.green;
        Debug.Log(destination.myKey.axial);
    }
}
