using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {



	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {

        

    }
    public void TestScene()
    {
        SceneManager.LoadScene("NewLevel", LoadSceneMode.Single);
        Debug.Log("Loaded");
    }

    public void TheMenu()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
    }
    public void RefreshScene()
    {
        SceneManager.LoadScene("NewLevel", LoadSceneMode.Single);
    }
	public void Tutorial()
	{
		SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
	}
}
