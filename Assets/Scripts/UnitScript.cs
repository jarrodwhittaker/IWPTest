using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {
    public enum UnitType {
        Tank, Jet, Mech, Bunker, Flak, Pak
    };

    public Vector3 target;
    public Vector3 currentPos;

    public Animator anim;

    public UnitType unitType = UnitType.Jet;
    public bool isPlayer;
    public bool canMove;
    public int basePool = 5;
    public float speed = 1.5f;
    public int currentPool;
    public float attackRange = 10;
    public float visionRange = 15;
    public List <UnitType> effectiveAgainst;
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
        distanceRemain =  Vector3.Distance(currentPos, target);
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

    public void takeDamage()
    {
        anim.SetTrigger("Death");
        
    }

    public void deathComplete()
    {
        Destroy(gameObject);
    }

    public void shield()
    {
        anim.SetTrigger("Shield");
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

        

        if (distanceRemain > 0.1)
        {
            return;
        }

        if (currentPool <= 0)
        {
            return;
        }

        if (ignoreNextClick)
        {
            ignoreNextClick = false;
            return;
        }

        if (GameController.Instance.activeUnit == this)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < (Screen.height - 50))
            {
                if (GameController.Instance.targetUnit != null) 
                {
                    anim.SetTrigger("Attack");
                    Debug.Log("Bang");
                    if (effectiveAgainst.Contains(GameController.Instance.targetUnit.unitType))
                    {
                        
                        // have the enemy unit explode and play their death animation.
                        GameController.Instance.targetUnit.takeDamage();
                    }
                    else
                    {
                        GameController.Instance.targetUnit.shield();
                    }
                }
                
                else
                {
                   
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.z = transform.position.z;
                    anim.SetTrigger("Move");
                    currentPool =- 1;
                }
            }

        }
        

    }
}
