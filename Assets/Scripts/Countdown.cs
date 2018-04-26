using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {

    public List<GameObject> NumberSprites;

	// Use this for initialization
	void Start ()
    {

	}


    public void SetCountdownValue(int newValue)
    {


        foreach (GameObject sprite in NumberSprites)
        {
            sprite.SetActive(false);            
        }

        //NumberSprites[newValue] = NumberSprites[NumberSprites.Count];

        NumberSprites[newValue].SetActive(true);
    }


	// Update is called once per frame
	void Update ()
    {
		
	}
}
