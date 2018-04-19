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
        SceneManager.LoadScene("Level1Earth", LoadSceneMode.Single);
        Debug.Log("Loaded");
    }

    public void TheMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void RefreshScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reloading");
    }
	public void Tutorial()
	{
		SceneManager.LoadScene("tutorialDialogue", LoadSceneMode.Single);
	}

    public void SelectLevel()
    {
        SceneManager.LoadScene("Select Level", LoadSceneMode.Single);
    }
    public void TheSettings()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
}
