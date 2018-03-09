using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager Instance;


	[FMODUnity.EventRef]
	public string tankMoveP ="event:/Units/Tank/Tank Move";
	FMOD.Studio.EventInstance TankMoveEv;



    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
	
		TankMoveEv = FMODUnity.RuntimeManager.CreateInstance(tankMoveP);

	}
	
	// Update is called once per frame
	void Update () {


	}

	public void TankMove () 
	{
		//Write a reference to this script as "AudioManager.Instance.TankMove ();"
		TankMoveEv.start ();
        

    }
    public void TankStop()
    {
        TankMoveEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Debug.Log("Tank stops making sound");
     
    }
}
