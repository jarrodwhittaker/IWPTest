using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager Instance;


	[FMODUnity.EventRef]

	//Tank Events
	public string tankMoveP ="event:/Units/Tank/Tank Move";
	FMOD.Studio.EventInstance TankMoveEv;
	public string tankFireP ="event:/Units/Tank/Tank Fire";
	FMOD.Studio.EventInstance TankFireEv;

	//Jet Events
	public string jetMoveP ="event:/Units/Jet/Jet Move";
	FMOD.Studio.EventInstance JetMoveEv;
	public string jetFireP ="event:/Units/Jet/Jet Fire";
	FMOD.Studio.EventInstance JetFireEv;


    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
	
		TankMoveEv = FMODUnity.RuntimeManager.CreateInstance(tankMoveP);
		TankFireEv = FMODUnity.RuntimeManager.CreateInstance(tankFireP);
		JetMoveEv = FMODUnity.RuntimeManager.CreateInstance(jetMoveP);
		JetFireEv = FMODUnity.RuntimeManager.CreateInstance(jetFireP);

	}
	
	// Update is called once per frame
	void Update () {


	}

	//Tank SFX

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
	public void TankFire()
	{
		TankFireEv.start ();
	}

	//Jet SFX

	public void JetMove () 
	{
		JetMoveEv.start ();
	}
	public void JetStop()
	{
		JetMoveEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		Debug.Log("Jet stops making sound");

	}
	public void JetFire()
	{
		JetFireEv.start ();
	}

}
