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
		AudioManager.Instance.StopAllMusic();
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
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level1Earth", LoadSceneMode.Single);
    }

    public void BeginLevel1() //load level one
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level2Kagruyama", LoadSceneMode.Single);
    }

    public void BeginLevel2()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level3Clayton303", LoadSceneMode.Single);
    }

    public void BeginLevel3()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level4Hasslehoff101", LoadSceneMode.Single);
    }

    public void BeginLevel4()
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Level5Samjarcamarisa", LoadSceneMode.Single);
    }

    //  These will start the next level dialogues after the end level dialogues end  //
    // e.g. At the end of Level 1 dialogue, this script will kick in to load starting dialogue for level 2//

    public void startLevel2Dialogue() // End of Level 1 > Load Level 2
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("level2Dialogue", LoadSceneMode.Single);
    }

    public void startLevel3Dialogue() // End of Level 2 > Load Level 3
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("level3Dialogue", LoadSceneMode.Single);
    }

    public void startLevel4Dialogue() // End of Level 3 > Load Level 4
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("level4Dialogue", LoadSceneMode.Single);
    }

    public void ReturntoMainMenu() // End of Level 4 > Return to Main menu
    {
		AudioManager.Instance.StopAllMusic();
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
