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
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}




}
