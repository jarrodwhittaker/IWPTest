using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour {
    public Vector3 moveDestination;

    void Awake() {
        moveDestination = transform.position;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Ask Greg about this or search it up by self//
    public virtual void TurnUpdate() {
    }
}
