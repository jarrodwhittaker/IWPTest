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
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void startGame() //Tells it to load the main upon starting
    {
        // SceneManager.LoadScene("menu");
        SceneManager.LoadScene("tutorial");
    }

    public void BeginTutorial() //load tutorial scene
    {
        //SceneManager.LoadScene("tutorial");
        SceneManager.LoadScene("Level1Earth");
    }

   /* public void BeginLevel1() //load level one
    {
        SceneManager.LoadScene("level1");
    }

    public void BeginLevel2()
    {
        SceneManager.LoadScene("level2"); //load level 2
    }

    public void BeginLevel3()
    {
        SceneManager.LoadScene("level3");
    }

    public void BeginLevel4()
    {
        SceneManager.LoadScene("level4");
    } */
}
