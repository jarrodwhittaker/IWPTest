using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoMouse : MonoBehaviour {

    public GameObject projectile;
    public float speed = 1.5f;
    private Vector3 target;

    //use to keep an internal tally of who's turn it is
    //test with int
    //internal tracker between sphere and cube.
    public int playerNumber;

    public bool didClick;
    public bool isEnemy;

    void Start()
    {
        target = transform.position;
        // Player has not been clicked yet.
        didClick = false;
        //turn = 0;
    }

    void Update()
    {
        if ((playerNumber == 1 && GameController.Instance.p1 == true) || (playerNumber == 2 && GameController.Instance.p2 == true))
        {
           
            //Have the player move to where the mouse clicks to.
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < (Screen.height - 40))
            {
                Debug.Log(playerNumber);
                Debug.Log(GameController.Instance.p1);
                Debug.Log(GameController.Instance.p2);
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
                didClick = true;
                
            }
        }

        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        /*
        // Check if the player has moved with the click.
        // If true, then swap player turns.
        // If false, nothing
        if ((didClick != true) && (GameController.Instance.p1 == true))
        {
            return;
        }
        // If the player has moved, swap turns.
        // Swapping turns should stop the player 1 from moving.
        else
        {
            GameController.Instance.p1 = false;
            GameController.Instance.p2 = true;
            didClick = false;
            //urn = 1;
        }
        // Check if the player has moved with the click.
        // If true, then swap player turns.
        // If false, nothing
        if ((didClick != true) && (GameController.Instance.p2 == true))
        {
            return;
        }
        // If the player has moved, swap turns.
        // Swapping turns should stop the player 2 from moving.
        else
        {
            GameController.Instance.p2 = false;
            GameController.Instance.p1 = true;
            didClick = false;
            //turn = 0;
        }*/
    }
}
