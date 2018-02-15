using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public enum RangeType
    {
        Tank, Jet, Mech, Bunker, Flak, Pak
    }

    public bool isClicked;
    public float newLocation;
    public float currentLocation;
    public float visionRange;
    public float APCount;
    
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
