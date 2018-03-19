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
	public string tankShieldP ="event:/Units/Tank/Tank Shield";
	FMOD.Studio.EventInstance TankShieldEv;

	//Jet Events
	public string jetMoveP ="event:/Units/Jet/Jet Move";
	FMOD.Studio.EventInstance JetMoveEv;
	public string jetFireP ="event:/Units/Jet/Jet Fire";
	FMOD.Studio.EventInstance JetFireEv;
	public string jetShieldP ="event:/Units/Jet/Jet Shield";
	FMOD.Studio.EventInstance JetShieldEv;

	//Mech Events
	public string mechMoveP ="event:/Units/Mech/MechMove";
	FMOD.Studio.EventInstance MechMoveEv;
	public string mechFireP="event:/Units/Mech/MechFire";
	FMOD.Studio.EventInstance MechFireEv;
	public string mechShieldP="event:/Units/Mech/MechShield";
	FMOD.Studio.EventInstance MechShieldEv;

	//Drone Events
	public string droneMoveP ="event:/Units/Drone/DroneMove";
	FMOD.Studio.EventInstance DroneMoveEv;
	public string droneFireP="event:/Units/Drone/DroneFire";
	FMOD.Studio.EventInstance DroneFireEv;
	public string droneShieldP="event:/Units/Drone/DroneShield";
	FMOD.Studio.EventInstance DroneShieldEv;

	//Pak Events
	public string pakFireP ="event:/Units/Pak/Pak Fire";
	FMOD.Studio.EventInstance PakFireEv;
	public string pakDefP ="event:/Units/Pak/PakDefence";
	FMOD.Studio.EventInstance PakDefenceEv;

	//Flak Events
	public string flakFireP ="event:/Units/Flak/Flak Fire";
	FMOD.Studio.EventInstance FlakFireEv;
	public string flakDefP ="event:/Units/Flak/FlakDefence";
	FMOD.Studio.EventInstance FlakDefenceEv;

	//Bunker Events
	public string bunkerFireP ="event:/Units/Bunker/BunkerFire";
	FMOD.Studio.EventInstance BunkerFireEv;
	public string bunkerDefP ="event:/Units/Bunker/BunkerDefence";
	FMOD.Studio.EventInstance BunkerDefenceEv;

	//Generic Events

	public string destroyedP ="event:/Units/Destroyed";
	FMOD.Studio.EventInstance DestroyEv;

 
	private void Awake()
    {
        Instance = this;
    }
    

	// Use this for initialization
    void Start () {
		//Tank instance creation
		TankMoveEv = FMODUnity.RuntimeManager.CreateInstance(tankMoveP);
		TankFireEv = FMODUnity.RuntimeManager.CreateInstance(tankFireP);
		TankShieldEv = FMODUnity.RuntimeManager.CreateInstance(tankShieldP);

		//Jet instance creation
		JetMoveEv = FMODUnity.RuntimeManager.CreateInstance(jetMoveP);
		JetFireEv = FMODUnity.RuntimeManager.CreateInstance(jetFireP);
		JetShieldEv = FMODUnity.RuntimeManager.CreateInstance(jetShieldP);

		//Mech instance creation
		MechMoveEv = FMODUnity.RuntimeManager.CreateInstance(mechMoveP);
		MechFireEv = FMODUnity.RuntimeManager.CreateInstance(mechFireP);
		MechShieldEv = FMODUnity.RuntimeManager.CreateInstance(mechShieldP);

		//Drone instance creation
		DroneMoveEv = FMODUnity.RuntimeManager.CreateInstance(droneMoveP);
		DroneFireEv = FMODUnity.RuntimeManager.CreateInstance(droneFireP);
		DroneShieldEv = FMODUnity.RuntimeManager.CreateInstance(droneShieldP);

		//Pak instance creation
		PakFireEv = FMODUnity.RuntimeManager.CreateInstance(pakFireP);
		PakDefenceEv = FMODUnity.RuntimeManager.CreateInstance(pakDefP);

		//Flak instance creation
		FlakFireEv = FMODUnity.RuntimeManager.CreateInstance(flakFireP);
		FlakDefenceEv = FMODUnity.RuntimeManager.CreateInstance(flakDefP);

		//Bunker instance creation
		BunkerFireEv = FMODUnity.RuntimeManager.CreateInstance(bunkerFireP);
		BunkerDefenceEv = FMODUnity.RuntimeManager.CreateInstance(bunkerDefP);

		//Generic instance creation
		DestroyEv = FMODUnity.RuntimeManager.CreateInstance(destroyedP);

	}
	
	// Update is called once per frame
	void Update () {


	}

	//Tank SFX Functions

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
	public void TankShield()
	{
		TankShieldEv.start ();
	}



	//Jet SFX Functions

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
	public void JetShield()
	{
		JetShieldEv.start ();
	}



	//Mech SFX Functions

	public void MechMove()
	{
		MechMoveEv.start();
	}

	public void MechStop()
	{
		MechMoveEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	public void MechFire()
	{
		MechFireEv.start();
	}
		
	public void MechShield()
	{
		MechShieldEv.start();
	}



	//Drone SFX Functions

	public void DroneMove()
	{
		DroneMoveEv.start();
	}

	public void DroneStop()
	{
		DroneMoveEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	public void DroneFire()
	{
		DroneFireEv.start();
	}

	public void DroneShield()
	{
		DroneShieldEv.start();
	}



	//Pak SFX Functions

	public void PakFire()
	{
		PakFireEv.start ();
	}
	public void PakDefence()
	{
		PakDefenceEv.start ();
	}

	//Flak SFX Functions

	public void FlakFire()
	{
		FlakFireEv.start ();
	}
	public void FlakDefence()
	{
		FlakDefenceEv.start ();
	}

	//Bunker SFX Functions

	public void BunkerFire()
	{
		BunkerFireEv.start ();
	}
	public void BunkerDefence()
	{
		BunkerDefenceEv.start ();
	}

	//Generic SFX Functions

	public void Destroyed()
	{
		DestroyEv.start();
	}
}
