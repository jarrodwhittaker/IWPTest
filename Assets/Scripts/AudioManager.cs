using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager Instance;


	[FMODUnity.EventRef]

	//Attacking Units

	//Tank Events
	public string tankMoveP ="event:/Units/Tank/Tank Move";
	FMOD.Studio.EventInstance TankMoveEv;
	public string tankFireP ="event:/Units/Tank/Tank Fire";
	FMOD.Studio.EventInstance TankFireEv;
	public string tankShieldP ="event:/Units/Tank/Tank Shield";
	FMOD.Studio.EventInstance TankShieldEv;
	public string tankDesP ="event:/Units/Tank/Tank Des";
	FMOD.Studio.EventInstance TankDesEv;


	//Jet Events
	public string jetMoveP ="event:/Units/Jet/Jet Move";
	FMOD.Studio.EventInstance JetMoveEv;
	public string jetFireP ="event:/Units/Jet/Jet Fire";
	FMOD.Studio.EventInstance JetFireEv;
	public string jetShieldP ="event:/Units/Jet/Jet Shield";
	FMOD.Studio.EventInstance JetShieldEv;
	public string jetDesP ="event:/Units/Jet/Jet Des";
	FMOD.Studio.EventInstance JetDesEv;

	//Mech Events
	public string mechMoveP ="event:/Units/Mech/MechMove";
	FMOD.Studio.EventInstance MechMoveEv;
	public string mechFireP="event:/Units/Mech/MechFire";
	FMOD.Studio.EventInstance MechFireEv;
	public string mechShieldP="event:/Units/Mech/MechShield";
	FMOD.Studio.EventInstance MechShieldEv;
	public string mechDesP ="event:/Units/Mech/MechDes";
	FMOD.Studio.EventInstance MechDesEv;

	//Drone Events
	public string droneMoveP ="event:/Units/Drone/DroneMove";
	FMOD.Studio.EventInstance DroneMoveEv;
	public string droneFireP="event:/Units/Drone/DroneFire";
	FMOD.Studio.EventInstance DroneFireEv;
	public string droneShieldP="event:/Units/Drone/DroneShield";
	FMOD.Studio.EventInstance DroneShieldEv;

	//Defensive Units

	//Lvl1
	//Pak Events
	public string pakFireP1 ="event:/Units/Pak/L1/Pak Fire";
	FMOD.Studio.EventInstance PakFireEv1;
	public string pakDefP1 ="event:/Units/Pak/L1/PakDefence";
	FMOD.Studio.EventInstance PakDefenceEv1;
	public string pakDesP1 ="event:/Units/Pak/L1/PakDes";
	FMOD.Studio.EventInstance PakDesEv1;

	//Flak Events
	public string flakFireP1 ="event:/Units/Flak/L1/Flak Fire";
	FMOD.Studio.EventInstance FlakFireEv1;
	public string flakDefP1 ="event:/Units/Flak/L1/FlakDefence";
	FMOD.Studio.EventInstance FlakDefenceEv1;
	public string flakDesP1 ="event:/Units/Flak/L1/FlakDes";
	FMOD.Studio.EventInstance FlakDesEv1;

	//Bunker Events
	public string bunkerFireP1 ="event:/Units/Bunker/L1/BunkerFire";
	FMOD.Studio.EventInstance BunkerFireEv1;
	public string bunkerDefP1 ="event:/Units/Bunker/L1/BunkerDefence";
	FMOD.Studio.EventInstance BunkerDefenceEv1;
	public string bunkerDesP1 ="event:/Units/Bunker/L1/BunkerDes";
	FMOD.Studio.EventInstance BunkerDesEv1;

	//Lvl2
	//Pak Events
	public string pakFireP2 ="event:/Units/Pak/L2/Pak Fire";
	FMOD.Studio.EventInstance PakFireEv2;
	public string pakDefP2 ="event:/Units/Pak/L2/PakDefence";
	FMOD.Studio.EventInstance PakDefenceEv2;
	public string pakDesP2 ="event:/Units/Pak/L2/PakDes";
	FMOD.Studio.EventInstance PakDesEv2;

	//Flak Events
	public string flakFireP2 ="event:/Units/Flak/L2/Flak Fire";
	FMOD.Studio.EventInstance FlakFireEv2;
	public string flakDefP2 ="event:/Units/Flak/L2/FlakDefence";
	FMOD.Studio.EventInstance FlakDefenceEv2;
	public string flakDesP2 ="event:/Units/Flak/L2/FlakDes";
	FMOD.Studio.EventInstance FlakDesEv2;

	//Bunker Events
	public string bunkerFireP2 ="event:/Units/Bunker/L2/BunkerFire";
	FMOD.Studio.EventInstance BunkerFireEv2;
	public string bunkerDefP2 ="event:/Units/Bunker/L2/BunkerDefence";
	FMOD.Studio.EventInstance BunkerDefenceEv2;
	public string bunkerDesP2 ="event:/Units/Bunker/L2/BunkerDes";
	FMOD.Studio.EventInstance BunkerDesEv2;

	//Lvl3
	//Pak Events
	public string pakFireP3 ="event:/Units/Pak/L3/Pak Fire";
	FMOD.Studio.EventInstance PakFireEv3;
	public string pakDefP3 ="event:/Units/Pak/L3/PakDefence";
	FMOD.Studio.EventInstance PakDefenceEv3;
	public string pakDesP3 ="event:/Units/Pak/L3/PakDes";
	FMOD.Studio.EventInstance PakDesEv3;

	//Flak Events
	public string flakFireP3 ="event:/Units/Flak/L3/Flak Fire";
	FMOD.Studio.EventInstance FlakFireEv3;
	public string flakDefP3 ="event:/Units/Flak/L3/FlakDefence";
	FMOD.Studio.EventInstance FlakDefenceEv3;
	public string flakDesP3 ="event:/Units/Flak/L3/FlakDes";
	FMOD.Studio.EventInstance FlakDesEv3;

	//Bunker Events
	public string bunkerFireP3 ="event:/Units/Bunker/L3/BunkerFire";
	FMOD.Studio.EventInstance BunkerFireEv3;
	public string bunkerDefP3 ="event:/Units/Bunker/L3/BunkerDefence";
	FMOD.Studio.EventInstance BunkerDefenceEv3;
	public string bunkerDesP3 ="event:/Units/Bunker/L3/BunkerDes";
	FMOD.Studio.EventInstance BunkerDesEv3;

	//Lvl4
	//Pak Events
	public string pakFireP4 ="event:/Units/Pak/L4/Pak Fire";
	FMOD.Studio.EventInstance PakFireEv4;
	public string pakDefP4 ="event:/Units/Pak/L4/PakDefence";
	FMOD.Studio.EventInstance PakDefenceEv4;
	public string pakDesP4 ="event:/Units/Pak/L4/PakDes";
	FMOD.Studio.EventInstance PakDesEv4;

	//Flak Events
	public string flakFireP4 ="event:/Units/Flak/L4/Flak Fire";
	FMOD.Studio.EventInstance FlakFireEv4;
	public string flakDefP4 ="event:/Units/Flak/L4/FlakDefence";
	FMOD.Studio.EventInstance FlakDefenceEv4;
	public string flakDesP4 ="event:/Units/Flak/L4/FlakDes";
	FMOD.Studio.EventInstance FlakDesEv4;

	//Bunker Events
	public string bunkerFireP4 ="event:/Units/Bunker/L4/BunkerFire";
	FMOD.Studio.EventInstance BunkerFireEv4;
	public string bunkerDefP4 ="event:/Units/Bunker/L4/BunkerDefence";
	FMOD.Studio.EventInstance BunkerDefenceEv4;
	public string bunkerDesP4 ="event:/Units/Bunker/L4/BunkerDes";
	FMOD.Studio.EventInstance BunkerDesEv4;

	//Lvl5
	//Pak Events
	public string pakFireP5 ="event:/Units/Pak/L5/Pak Fire";
	FMOD.Studio.EventInstance PakFireEv5;
	public string pakDefP5 ="event:/Units/Pak/L5/PakDefence";
	FMOD.Studio.EventInstance PakDefenceEv5;
	public string pakDesP5 ="event:/Units/Pak/L5/PakDes";
	FMOD.Studio.EventInstance PakDesEv5;

	//Flak Events
	public string flakFireP5 ="event:/Units/Flak/L5/Flak Fire";
	FMOD.Studio.EventInstance FlakFireEv5;
	public string flakDefP5 ="event:/Units/Flak/L5/FlakDefence";
	FMOD.Studio.EventInstance FlakDefenceEv5;
	public string flakDesP5 ="event:/Units/Flak/L5/FlakDes";
	FMOD.Studio.EventInstance FlakDesEv5;

	//Bunker Events
	public string bunkerFireP5 ="event:/Units/Bunker/L5/BunkerFire";
	FMOD.Studio.EventInstance BunkerFireEv5;
	public string bunkerDefP5 ="event:/Units/Bunker/L5/BunkerDefence";
	FMOD.Studio.EventInstance BunkerDefenceEv5;
	public string bunkerDesP5 ="event:/Units/Bunker/L5/BunkerDes";
	FMOD.Studio.EventInstance BunkerDesEv5;

 	//Music Events
	public string musicGame1P ="event:/Music/Music_Game1";
	FMOD.Studio.EventInstance Music_Game1;
	public string musicGame2P ="event:/Music/Music_Game2";
	FMOD.Studio.EventInstance Music_Game2;
	public string musicGameL5P ="event:/Music/Music_GameLvl5";
	FMOD.Studio.EventInstance Music_GameLvl5;
	public string musicLoseP ="event:/Music/Music_Lose";
	FMOD.Studio.EventInstance Music_Lose;
	public string musicWinP ="event:/Music/Music_Win";
	FMOD.Studio.EventInstance Music_Win;
	public string musicMenuP ="event:/Music/Music_Menu";
	FMOD.Studio.EventInstance Music_Menu;
	public string musicNarrativeP ="event:/Music/Music_Narrative";
	FMOD.Studio.EventInstance Music_Narrative;


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
		TankDesEv = FMODUnity.RuntimeManager.CreateInstance(tankDesP);

		//Jet instance creation
		JetMoveEv = FMODUnity.RuntimeManager.CreateInstance(jetMoveP);
		JetFireEv = FMODUnity.RuntimeManager.CreateInstance(jetFireP);
		JetShieldEv = FMODUnity.RuntimeManager.CreateInstance(jetShieldP);
		JetDesEv = FMODUnity.RuntimeManager.CreateInstance(jetDesP);

		//Mech instance creation
		MechMoveEv = FMODUnity.RuntimeManager.CreateInstance(mechMoveP);
		MechFireEv = FMODUnity.RuntimeManager.CreateInstance(mechFireP);
		MechShieldEv = FMODUnity.RuntimeManager.CreateInstance(mechShieldP);
		MechDesEv = FMODUnity.RuntimeManager.CreateInstance(mechDesP);

		//Drone instance creation
		DroneMoveEv = FMODUnity.RuntimeManager.CreateInstance(droneMoveP);
		DroneFireEv = FMODUnity.RuntimeManager.CreateInstance(droneFireP);
		DroneShieldEv = FMODUnity.RuntimeManager.CreateInstance(droneShieldP);

		//Lvl1
		//Pak instance creation
		PakFireEv1 = FMODUnity.RuntimeManager.CreateInstance(pakFireP1);
		PakDefenceEv1 = FMODUnity.RuntimeManager.CreateInstance(pakDefP1);
		PakDesEv1 = FMODUnity.RuntimeManager.CreateInstance(pakDesP1);

		//Flak instance creation
		FlakFireEv1 = FMODUnity.RuntimeManager.CreateInstance(flakFireP1);
		FlakDefenceEv1 = FMODUnity.RuntimeManager.CreateInstance(flakDefP1);
		FlakDesEv1 = FMODUnity.RuntimeManager.CreateInstance(flakDesP1);

		//Bunker instance creation
		BunkerFireEv1 = FMODUnity.RuntimeManager.CreateInstance(bunkerFireP1);
		BunkerDefenceEv1 = FMODUnity.RuntimeManager.CreateInstance(bunkerDefP1);
		BunkerDesEv1 = FMODUnity.RuntimeManager.CreateInstance(bunkerDesP1);

		//Lvl2
		//Pak instance creation
		PakFireEv2 = FMODUnity.RuntimeManager.CreateInstance(pakFireP2);
		PakDefenceEv2 = FMODUnity.RuntimeManager.CreateInstance(pakDefP2);
		PakDesEv2 = FMODUnity.RuntimeManager.CreateInstance(pakDesP2);

		//Flak instance creation
		FlakFireEv2 = FMODUnity.RuntimeManager.CreateInstance(flakFireP2);
		FlakDefenceEv2 = FMODUnity.RuntimeManager.CreateInstance(flakDefP2);
		FlakDesEv2 = FMODUnity.RuntimeManager.CreateInstance(flakDesP2);

		//Bunker instance creation
		BunkerFireEv2 = FMODUnity.RuntimeManager.CreateInstance(bunkerFireP2);
		BunkerDefenceEv2 = FMODUnity.RuntimeManager.CreateInstance(bunkerDefP2);
		BunkerDesEv2 = FMODUnity.RuntimeManager.CreateInstance(bunkerDesP2);

		//Lvl3
		//Pak instance creation
		PakFireEv3 = FMODUnity.RuntimeManager.CreateInstance(pakFireP3);
		PakDefenceEv3 = FMODUnity.RuntimeManager.CreateInstance(pakDefP3);
		PakDesEv3 = FMODUnity.RuntimeManager.CreateInstance(pakDesP3);

		//Flak instance creation
		FlakFireEv3 = FMODUnity.RuntimeManager.CreateInstance(flakFireP3);
		FlakDefenceEv3 = FMODUnity.RuntimeManager.CreateInstance(flakDefP3);
		FlakDesEv3 = FMODUnity.RuntimeManager.CreateInstance(flakDesP3);

		//Bunker instance creation
		BunkerFireEv3 = FMODUnity.RuntimeManager.CreateInstance(bunkerFireP3);
		BunkerDefenceEv3 = FMODUnity.RuntimeManager.CreateInstance(bunkerDefP3);
		BunkerDesEv3 = FMODUnity.RuntimeManager.CreateInstance(bunkerDesP3);

		//Lvl4
		//Pak instance creation
		PakFireEv4 = FMODUnity.RuntimeManager.CreateInstance(pakFireP4);
		PakDefenceEv4 = FMODUnity.RuntimeManager.CreateInstance(pakDefP4);
		PakDesEv4 = FMODUnity.RuntimeManager.CreateInstance(pakDesP4);

		//Flak instance creation
		FlakFireEv4 = FMODUnity.RuntimeManager.CreateInstance(flakFireP4);
		FlakDefenceEv4 = FMODUnity.RuntimeManager.CreateInstance(flakDefP4);
		FlakDesEv4 = FMODUnity.RuntimeManager.CreateInstance(flakDesP4);

		//Bunker instance creation
		BunkerFireEv4 = FMODUnity.RuntimeManager.CreateInstance(bunkerFireP4);
		BunkerDefenceEv4 = FMODUnity.RuntimeManager.CreateInstance(bunkerDefP4);
		BunkerDesEv4 = FMODUnity.RuntimeManager.CreateInstance(bunkerDesP4);

		//Lvl5
		//Pak instance creation
		PakFireEv5 = FMODUnity.RuntimeManager.CreateInstance(pakFireP5);
		PakDefenceEv5 = FMODUnity.RuntimeManager.CreateInstance(pakDefP5);
		PakDesEv5 = FMODUnity.RuntimeManager.CreateInstance(pakDesP5);

		//Flak instance creation
		FlakFireEv5 = FMODUnity.RuntimeManager.CreateInstance(flakFireP5);
		FlakDefenceEv5 = FMODUnity.RuntimeManager.CreateInstance(flakDefP5);
		FlakDesEv5 = FMODUnity.RuntimeManager.CreateInstance(flakDesP5);

		//Bunker instance creation
		BunkerFireEv5 = FMODUnity.RuntimeManager.CreateInstance(bunkerFireP5);
		BunkerDefenceEv5 = FMODUnity.RuntimeManager.CreateInstance(bunkerDefP5);
		BunkerDesEv5 = FMODUnity.RuntimeManager.CreateInstance(bunkerDesP5);

		//Music instance creation
		Music_Game1 = FMODUnity.RuntimeManager.CreateInstance(musicGame1P);
		Music_Game2 = FMODUnity.RuntimeManager.CreateInstance(musicGame2P);
		Music_GameLvl5 = FMODUnity.RuntimeManager.CreateInstance(musicGameL5P);
		Music_Lose = FMODUnity.RuntimeManager.CreateInstance(musicLoseP);
		Music_Win = FMODUnity.RuntimeManager.CreateInstance(musicWinP);
		Music_Menu = FMODUnity.RuntimeManager.CreateInstance(musicMenuP);
		Music_Narrative = FMODUnity.RuntimeManager.CreateInstance(musicNarrativeP);
	}
	
	// Update is called once per frame
	void Update () {


	}


	//Attacking Units
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
	public void TankDes()
	{
		TankDesEv.start();
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
	public void JetDes()
	{
		JetDesEv.start();
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
	public void MechDes()
	{
		MechDesEv.start();
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


	//Defensive Units

	//Lvl1

	//Pak SFX Functions

	public void PakFire1()
	{
		PakFireEv1.start ();
	}
	public void PakDefence1()
	{
		PakDefenceEv1.start ();
	}
	public void PakDes1()
	{
		PakDesEv1.start();
	}


	//Flak SFX Functions

	public void FlakFire1()	
	{
		FlakFireEv1.start ();
	}
	public void FlakDefence1()
	{
		FlakDefenceEv1.start ();
	}
	public void FlakDes1()
	{
		FlakDesEv1.start();
	}

	//Bunker SFX Functions

	public void BunkerFire1()
	{
		BunkerFireEv1.start ();
	}
	public void BunkerDefence1()
	{
		BunkerDefenceEv1.start ();
	}
	public void BunkerDes1()
	{
		BunkerDesEv1.start();
	}

	//Lvl2

	//Pak SFX Functions

	public void PakFire2()
	{
		PakFireEv2.start ();
	}
	public void PakDefence2()
	{
		PakDefenceEv2.start ();
	}
	public void PakDes2()
	{
		PakDesEv2.start();
	}


	//Flak SFX Functions

	public void FlakFire2()	
	{
		FlakFireEv2.start ();
	}
	public void FlakDefence2()
	{
		FlakDefenceEv2.start ();
	}
	public void FlakDes2()
	{
		FlakDesEv2.start();
	}

	//Bunker SFX Functions

	public void BunkerFire2()
	{
		BunkerFireEv2.start ();
	}
	public void BunkerDefence2()
	{
		BunkerDefenceEv2.start ();
	}
	public void BunkerDes2()
	{
		BunkerDesEv2.start();
	}

	//Lvl3

	//Pak SFX Functions

	public void PakFire3()
	{
		PakFireEv3.start ();
	}
	public void PakDefence3()
	{
		PakDefenceEv3.start ();
	}
	public void PakDes3()
	{
		PakDesEv3.start();
	}


	//Flak SFX Functions

	public void FlakFire3()	
	{
		FlakFireEv3.start ();
	}
	public void FlakDefence3()
	{
		FlakDefenceEv3.start ();
	}
	public void FlakDes3()
	{
		FlakDesEv3.start();
	}

	//Bunker SFX Functions

	public void BunkerFire3()
	{
		BunkerFireEv3.start ();
	}
	public void BunkerDefence3()
	{
		BunkerDefenceEv3.start ();
	}
	public void BunkerDes3()
	{
		BunkerDesEv3.start();
	}

	//Lvl4

	//Pak SFX Functions

	public void PakFire4()
	{
		PakFireEv4.start ();
	}
	public void PakDefence4()
	{
		PakDefenceEv4.start ();
	}
	public void PakDes4()
	{
		PakDesEv4.start();
	}


	//Flak SFX Functions

	public void FlakFire4()	
	{
		FlakFireEv4.start ();
	}
	public void FlakDefence4()
	{
		FlakDefenceEv4.start ();
	}
	public void FlakDes4()
	{
		FlakDesEv4.start();
	}

	//Bunker SFX Functions

	public void BunkerFire4()
	{
		BunkerFireEv4.start ();
	}
	public void BunkerDefence4()
	{
		BunkerDefenceEv4.start ();
	}
	public void BunkerDes4()
	{
		BunkerDesEv4.start();
	}

	//Lvl5

	//Pak SFX Functions

	public void PakFire5()
	{
		PakFireEv5.start ();
	}
	public void PakDefence5()
	{
		PakDefenceEv5.start ();
	}
	public void PakDes5()
	{
		PakDesEv5.start();
	}


	//Flak SFX Functions

	public void FlakFire5()	
	{
		FlakFireEv5.start ();
	}
	public void FlakDefence5()
	{
		FlakDefenceEv5.start ();
	}
	public void FlakDes5()
	{
		FlakDesEv5.start();
	}

	//Bunker SFX Functions

	public void BunkerFire5()
	{
		BunkerFireEv5.start ();
	}
	public void BunkerDefence5()
	{
		BunkerDefenceEv5.start ();
	}
	public void BunkerDes5()
	{
		BunkerDesEv5.start();
	}

	//Music Functions

	public void StopAllMusic()
	{
		Music_Game1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		Music_Game2.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		Music_GameLvl5.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		Music_Lose.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		Music_Win.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		Music_Menu.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		Music_Narrative.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	//Start Music Functions

	public void MusicG1_Start()
	{
		Music_Game1.start();
	}

	public void MusicG2_Start()
	{
		Music_Game2.start();
	}

	public void MusicGL5_Start()
	{
		Music_GameLvl5.start();
	}

	public void MusicLose_Start()
	{
		Music_Lose.start();
	}

	public void MusicWin_Start()
	{
		Music_Win.start();
	}

	public void MusicMenu_Start()
	{
		Music_Menu.start();
	}

	public void MusicNarrative_Start()
	{
		Music_Narrative.start();
	}

	//Stop Music Functions

	public void MusicG1_Stop()
	{
		Music_Game1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void MusicG2_Stop()
	{
		Music_Game2.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void MusicGL5_Stop()
	{
		Music_GameLvl5.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void MusicLose_Stop()
	{
		Music_Lose.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void MusicWin_Stop()
	{
		Music_Win.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void MusicMenu_Stop()
	{
		Music_Menu.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	public void MusicNarrative_Stop()
	{
		Music_Narrative.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}
		
}
