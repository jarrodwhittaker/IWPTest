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
    }

     public void BeginLevel1() //load level one
     {
         SceneManager.LoadScene("Level2Kagruyama");
     }

     public void BeginLevel2()
     {
         SceneManager.LoadScene("Level3Clayton303"); 
     }

     public void BeginLevel3()
     {
         SceneManager.LoadScene("Level4Hasslehoff101");
     }

     public void BeginLevel4()
     {
         SceneManager.LoadScene("Level5Samjarcamarisa");
     }

    //  Play End Level Dialogues //


  /*

    public void EndLevel1() //load level one
    {
        SceneManager.LoadScene("");
    }

    public void EndLevel2()
    {
        SceneManager.LoadScene("");
    }

    public void EndLevel3()
    {
        SceneManager.LoadScene("");
    }

    public void EndLevel4()
    {
        SceneManager.LoadScene("");
    } 
    
     */

}
