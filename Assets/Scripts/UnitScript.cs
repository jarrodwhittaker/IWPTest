using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {
    public enum UnitType {
        Tank, Jet, Mech, Bunker, Flak, Pak
    };

    private Vector3 target;

    private const UnitType unitType = UnitType.Jet;
    public bool isPlayer;
    public bool canMove;
    public int basePool = 20;
    public float speed = 1.5f;
    public int currentPool;
    public float attackRange = 10;
    public float visionRange = 15;
    public List <UnitType> troops;
    //For Sam's audio in FMOD
    public float distanceRemain;

    private bool ignoreNextClick = false;

	// Use this for initialization
    // When game begins it sets everything
    // Player begins the game
    // No units are to be selected by now
    // 
	void Start () {

        target = transform.position;

        // Communicate with other scripts at the beginning for info
    }
	
    void startTurn ()
    {
        // 
        currentPool = basePool;
        
    }

    void OnMouseDown()
    {
        GameController.Instance.OnUnitClicked(this);
        ignoreNextClick = true;
    }

    // Update is called once per frame
    void Update () {
		if (isPlayer != true)
        {
            // The AI should do their procedure in here
            // Attack all enemies once within their attack range
            // Can't attack through walls/objects

        }
        else
        {
            // Movement and attacking should be portrayed within here
            // Stats may be different depending on player unit
            // Jet can fly over objects, possible different brackets.
            if (unitType == UnitType.Jet)
            {
                // Unnaccessible tiles become disabled

            }
            // Calculate 
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (ignoreNextClick)
        {
            ignoreNextClick = false;
            return;
        }

        if (GameController.Instance.activeUnit == this)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < (Screen.height - 40))
            {
                if (GameController.Instance.targetUnit != null)
                {
                    Debug.Log("Bang");
                }
                else
                {
                   
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.z = transform.position.z;
                }
            }

        }
        

    }
}
