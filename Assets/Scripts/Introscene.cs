﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Introscene : MonoBehaviour {

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changeLevel()
	{
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		AudioManager.Instance.StopAllMusic();
		//AudioManager.Instance.MusicMenu_Start();
	}




}
