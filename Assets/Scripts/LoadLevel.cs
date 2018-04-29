using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {



    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {



    }
    public void TestScene()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level1Earth", LoadSceneMode.Single);
        Debug.Log("Loaded");
    }

    public void TheMenu()
    {
		AudioManager.Instance.StopAllMusic();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void RefreshScene()
    {
		AudioManager.Instance.StopAllMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reloading");
    }
    public void Tutorial()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("tutorialDialogue", LoadSceneMode.Single);
    }

    public void SelectLevel()
    {
		AudioManager.Instance.StopAllMusic();
        SceneManager.LoadScene("Select Level", LoadSceneMode.Single);
    }
    public void TheSettings()
    {
		AudioManager.Instance.StopAllMusic();
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
    public void GetMeOuttaHere()
    {
		AudioManager.Instance.StopAllMusic();
        Application.Quit();
    }

    public void Level1()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level1Earth", LoadSceneMode.Single);
    }

    public void Level2()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level2Kagruyama", LoadSceneMode.Single);
    }

    public void Level3()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level3Clayton303", LoadSceneMode.Single);
    }

    public void Level4()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level4Hasslehoff101", LoadSceneMode.Single);
    }

    public void Level5()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level5Samjarcamarisa", LoadSceneMode.Single);
    }

    public void Dialogue2()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("level1Dialogue", LoadSceneMode.Single);
    }

    public void Dialogue3()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("level2Dialogue", LoadSceneMode.Single);
    }

    public void Dialogue4()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("level3Dialogue", LoadSceneMode.Single);
    }

    public void Dialogue5()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("level4Dialogue", LoadSceneMode.Single);
    }
}