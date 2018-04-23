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

    //  These will start the next level dialogues after the end level dialogues end  //
    // e.g. At the end of Level 1 dialogue, this script will kick in to load starting dialogue for level 2//

    /*

      public void EndLevel1() // End of Level 1 > Load Level 2
      {
          SceneManager.LoadScene("startLv2Dialogue");
      }

      public void EndLevel2() // End of Level 2 > Load Level 3
      {
          SceneManager.LoadScene("startLv3Dialogue");
      }

      public void EndLevel3() // End of Level 3 > Load Level 4
      {
          SceneManager.LoadScene("startLv4Dialogue");
      }

      public void EndLevel4() // End of Level 4 > Return to Main menu
      {
          SceneManager.LoadScene("returnMainMenu");
      } 

       */

}
