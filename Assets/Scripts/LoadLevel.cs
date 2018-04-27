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
		AudioManager.Instance.StopAllMusic();
		int music_rng = Random.Range(0,1);
		switch (music_rng)
		{
		case 0:
			AudioManager.Instance.MusicG1_Start();
			break;
		case 1:
			AudioManager.Instance.MusicG2_Start();
			break;
		}
    }

    public void TheMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		AudioManager.Instance.StopAllMusic();
		AudioManager.Instance.MusicMenu_Start();
    }
    public void RefreshScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reloading");
    }
	public void Tutorial()
	{
		SceneManager.LoadScene("tutorialDialogue", LoadSceneMode.Single);
		AudioManager.Instance.StopAllMusic();
		AudioManager.Instance.MusicNarrative_Start();
	}

    public void SelectLevel()
    {
        SceneManager.LoadScene("Select Level", LoadSceneMode.Single);
    }
    public void TheSettings()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
    public void GetMeOuttaHere()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1Earth", LoadSceneMode.Single);
		AudioManager.Instance.StopAllMusic();
		int music_rng = Random.Range(0,1);
		switch (music_rng)
		{
		case 0:
			AudioManager.Instance.MusicG1_Start();
			break;
		case 1:
			AudioManager.Instance.MusicG2_Start();
			break;
		}
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2Kagruyama", LoadSceneMode.Single);
		AudioManager.Instance.StopAllMusic();
		int music_rng = Random.Range(0,1);
		switch (music_rng)
		{
		case 0:
			AudioManager.Instance.MusicG1_Start();
			break;
		case 1:
			AudioManager.Instance.MusicG2_Start();
			break;
		}
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3Clayton303", LoadSceneMode.Single);
		AudioManager.Instance.StopAllMusic();
		int music_rng = Random.Range(0,1);
		switch (music_rng)
		{
		case 0:
			AudioManager.Instance.MusicG1_Start();
			break;
		case 1:
			AudioManager.Instance.MusicG2_Start();
			break;
		}
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level4Hasselhoff", LoadSceneMode.Single);
		AudioManager.Instance.StopAllMusic();
		int music_rng = Random.Range(0,1);
		switch (music_rng)
		{
		case 0:
			AudioManager.Instance.MusicG1_Start();
			break;
		case 1:
			AudioManager.Instance.MusicG2_Start();
			break;
		}
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level5Samjarcamarisa", LoadSceneMode.Single);
		AudioManager.Instance.StopAllMusic();
		AudioManager.Instance.MusicGL5_Start();
    }

    public void Dialogue2()
    {
        SceneManager.LoadScene("level1Dialogue", LoadSceneMode.Single);
    }

    public void Dialogue3()
    {
        SceneManager.LoadScene("level2Dialogue", LoadSceneMode.Single);
    }

    public void Dialogue4()
    {
        SceneManager.LoadScene("level3Dialogue", LoadSceneMode.Single);
    }

    public void Dialogue5()
    {
        SceneManager.LoadScene("level4Dialogue", LoadSceneMode.Single);
    }

    public void Dialogue6()
    {
        SceneManager.LoadScene("level5Dialogue", LoadSceneMode.Single);
    }
}
