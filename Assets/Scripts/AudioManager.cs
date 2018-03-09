using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager Instance;


	[FMODUnity.EventRef]
	public string tankMove ="event:/Units/Tank/Tank Move";
	FMOD.Studio.EventInstance TankMoveEv;




	// Use this for initialization
	void Start () {
	
		TankMoveEv = FMODUnity.RuntimeManager.CreateInstance(tankMove);

	}
	
	// Update is called once per frame
	void Update () {


	}

	public void TankMove () 
	{
		//Write a reference to this script as "AudioManager.Instance.TankMove ();"
		TankMoveEv.start ();
		if (UnitScript.Instance.distanceRemain == 0)
		{
			TankMoveEv.stop ();
		}
	}
}
