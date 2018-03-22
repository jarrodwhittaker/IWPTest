using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pod : MonoBehaviour
{
    public static pod singleton;

    #region------- MOUSE
    Vector2 mouseCooldown = new Vector2(0, 0.3f);
    RaycastHit hit;
    #endregion

    #region------- KEYBOARD
    public float viewSpeed;
    #endregion
    
    // Executed on object load.
    void Awake()
    {
        singleton = this;
    }

    // Executed ahead of first update.
    void Start()
    {

	}
	
	// Executed once each frame.
	void Update()
    {
        Keyboard();
        Mouse();
	}

    // Operates keyboard input.
    void Keyboard()
    {
        // Up on "W" press.
        if(Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * viewSpeed, Space.World);
        }

        // Down on "S" press.
        if(Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * viewSpeed, Space.World);
        }
        
        // Left on "A" press.
        if(Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * viewSpeed, Space.World);
        }

        // Right on "D" press.
        if(Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * viewSpeed, Space.World);
        }
    }

    #region --------------------------- MOUSE

    // Operates mouse input.
    void Mouse()
    {
        // Check for left mouse click.
        if(Input.GetMouseButton(0) && mouseCooldown.x <= 0 && MouseRay())
        {
            MouseLeft();

            // Apply mouse cooldown.
            mouseCooldown.x = mouseCooldown.y;
        }

        // Check for right mouse click.
        if(Input.GetMouseButton(1) && mouseCooldown.x <= 0 && MouseRay())
        {
            MouseRight();

            // Apply mouse cooldown.
            mouseCooldown.x = mouseCooldown.y;
        }

        // Reduce mouse cooldown.
        else
        {
            mouseCooldown.x -= Time.deltaTime;
        }
    }

    // Action on left click.
    void MouseLeft()
    {
        // Define tile as origin if hit.
        if(hit.collider.GetComponent<hexTile>())
        {
            deity.singleton.DefineOrigin(hit.collider.GetComponent<hexTile>());
        }
        
        Debug.Log("Left mouse selection: " + hit.collider.name + ".");
    }

    // Action on right click.
    void MouseRight()
    {
        // Define tile as destination if hit.
        if(hit.collider.GetComponent<hexTile>())
        {
            deity.singleton.DefineDestination(hit.collider.GetComponent<hexTile>());
        }

        Debug.Log("Right mouse selection: " + hit.collider.name + ".");
    }

    // Operates mouse ray.
    bool MouseRay()
    {
        // Generate ray based on input position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Return result.
        return Physics.Raycast(ray, out hit, Mathf.Infinity);
    }

    #endregion
}