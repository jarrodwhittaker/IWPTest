using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoMouse : MonoBehaviour {

    public GameObject projectile;
    public float speed = 1.5f;
    private Vector3 target;

    public bool didClick;
    public bool isEnemy;

    void Start()
    {
        target = transform.position;
        // Player has not been clicked yet.
        didClick = false;
    }

    void Update()
    {
        //Have the player move to where the mouse clicks to.
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            didClick = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // Check if the player has moved with the click.
        // If true, then swap player turns.
        // If false, nothing
        if ((didClick != true) && (GameController.Instance.p1 = true))
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
        }
        // Check if the player has moved with the click.
        // If true, then swap player turns.
        // If false, nothing
        if ((didClick != true) && (GameController.Instance.p2 = true))
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
        }
    }
}
