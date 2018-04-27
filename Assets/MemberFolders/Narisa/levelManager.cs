using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class levelManager : MonoBehaviour {

    void Start()
    {
        //this script tells Fungus via the Call Method function which scenes to call once it reaches the end of each dialogue
        //the names need to match in the script and scene file within Unity
        //note to self: fix the load scene commands to load correct names (e.g = tutorial is now tutorialDialogue)
    }

    void Update()  //exit function
    {
        /* if (Input.GetKey("escape"))
             Application.Quit();*/
    }

    public void startGame() //Tells it to load the main upon starting
    {
        //SceneManager.LoadScene("tutorial");
    }

    // Play Starting Dialogues //

    public void BeginTutorial() //load tutorial scene
    {
        //SceneManager.LoadScene("tutorial");
        SceneManager.LoadScene("Level1Earth");
        AudioManager.Instance.StopAllMusic();
        int music_rng = Random.Range(0, 1);
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

    public void BeginLevel1() //load level one
    {
        SceneManager.LoadScene("Level2Kagruyama");
        AudioManager.Instance.StopAllMusic();
        int music_rng = Random.Range(0, 1);
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

    public void BeginLevel2()
    {
        SceneManager.LoadScene("Level3Clayton303");
        AudioManager.Instance.StopAllMusic();
        int music_rng = Random.Range(0, 1);
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

    public void BeginLevel3()
    {
        SceneManager.LoadScene("Level4Hasslehoff101");
        AudioManager.Instance.StopAllMusic();
        int music_rng = Random.Range(0, 1);
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

    public void BeginLevel4()
    {
        SceneManager.LoadScene("Level5Samjarcamarisa");
        AudioManager.Instance.StopAllMusic();
        AudioManager.Instance.MusicGL5_Start();
    }

    //  These will start the next level dialogues after the end level dialogues end  //
    // e.g. At the end of Level 1 dialogue, this script will kick in to load starting dialogue for level 2//

    public void startLevel2Dialogue() // End of Level 1 > Load Level 2
    {
        SceneManager.LoadScene("level2Dialogue");
        AudioManager.Instance.StopAllMusic();
        AudioManager.Instance.MusicNarrative_Start();
    }

    public void startLevel3Dialogue() // End of Level 2 > Load Level 3
    {
        SceneManager.LoadScene("level3Dialogue");
        AudioManager.Instance.StopAllMusic();
        AudioManager.Instance.MusicNarrative_Start();
    }

    public void startLevel4Dialogue() // End of Level 3 > Load Level 4
    {
        SceneManager.LoadScene("level4Dialogue");
        AudioManager.Instance.StopAllMusic();
        AudioManager.Instance.MusicNarrative_Start();
    }

    public void ReturntoMainMenu() // End of Level 4 > Return to Main menu
    {
        SceneManager.LoadScene("Menu");
        AudioManager.Instance.StopAllMusic();
        AudioManager.Instance.MusicMenu_Start();
    }

}
