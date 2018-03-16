﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitScript : MonoBehaviour {
    public enum UnitType {
        Tank, Jet, Mech, Bunker, Flak, Pak
    };

    public Vector3 target;

    public static UnitScript Instance;

    public Animator anim;

    

    public UnitType unitType = UnitType.Jet;
    public bool isPlayer;
    public bool canMove;
    public static int basePool = 5;
    public float speed = 1.5f;
    public static int currentPool = basePool;
    public float attackRange = 2;
    public float visionRange = 5;
    public List <UnitType> effectiveAgainst;
    //For Sam's audio in FMOD
    public float distanceRemain;

    // troy
    public bool iAmMoving;

    private bool ignoreNextClick = false;

	// Use this for initialization
    // When game begins it sets everything
    // Player begins the game
    // No units are to be selected by now
    // 
	void Start () {
        StartTurn();

        target = transform.position;
        // Communicate with other scripts at the beginning for info
        GameController.Instance.GoingUp(isPlayer);

    }

    public static void StartTurn()
    {
        // 
        currentPool = basePool;
        GameController.Instance.AP.text = "Action Points: " + currentPool;
    }

    void OnMouseDown()
    {
        GameController.Instance.OnUnitClicked(this);
        ignoreNextClick = true;
    }

    public void TakeDamage()
    {
        anim.SetTrigger("Death");
        Debug.Log("Animate");
        //Sam plays damage/destruction sfx here
        Invoke("DeathComplete", 1f);
//        DeathComplete();
    }

    public void DeathComplete()
    {
        GameController.Instance.GoingDown(isPlayer);
        Destroy(gameObject);
        
    }

    public void Shield()
    {
        anim.SetTrigger("Shield");
    }

    /*public void UnitRally()
    {
        // Tell the GameController to increase number of units by 1
        
    }

    public void EnemyRally()
    {
        // Tell the GameController to increase enemies left by 1
        
    }*/

    // Update is called once per frame
    void Update () {
        
        if (GameController.Instance.p2 == true)
        {


            // The AI should do their procedure in here
            // Attack all enemies once within their attack range
            // Can't attack through walls/objects

            return;

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
        distanceRemain = Vector3.Distance(transform.position, target);

        //if (GameController.Instance.activeUnit == this)
        {
            GameController.Instance.AP.text = "Action Points: " + currentPool;
        }

        if (distanceRemain > 0.1)
        {
            Debug.Log("I am returning");
            return;
        }

        else if (distanceRemain <= 0 && iAmMoving) // we check that we are actually taking action)
        {
            Debug.Log(distanceRemain);
            anim.SetTrigger("Idle");
            Debug.Log("Halt!");
            // Sam stops movement sfx pieces here
            if (unitType == UnitType.Tank)
            {
                AudioManager.Instance.TankStop();
                Debug.Log("Tank stops making sound");
			}
			else if (unitType == UnitType.Jet)
			{
				AudioManager.Instance.JetStop();
				Debug.Log("Jet stops making sound");
			}
            iAmMoving = false;
        }
        


        if (currentPool <= 0)
        {
            currentPool = 0;
            return;
        }

        if (ignoreNextClick)
        {
            ignoreNextClick = false;
            return;
        }

        if (GameController.Instance.activeUnit == this)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < (Screen.height - 50) )
            {
                if (GameController.Instance.targetUnit != null) 
                {
                    anim.SetTrigger("Attack");

					//play the firing sound effect
					if (unitType == UnitType.Jet)
					{
						AudioManager.Instance.JetFire();
						//Debug.Log("Jet pew pew");
					}
					else if (unitType == UnitType.Tank)
					{
						AudioManager.Instance.TankFire();
						Debug.Log("Tank pew pew");
					}

                    currentPool = 0;
                    Debug.Log("Bang");
                    
                    if (effectiveAgainst.Contains(GameController.Instance.targetUnit.unitType))
                    {
						// have the enemy unit explode and play their death animation.
                        GameController.Instance.targetUnit.TakeDamage();
                    }
                    else
                    {
                        GameController.Instance.targetUnit.Shield();
                        // Shield sound here, have it fade out.
                    }
                }
                
                else
                {
                   
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.z = transform.position.z;
                    anim.SetTrigger("Move");
                    iAmMoving = true;
                    Debug.Log("Zoom");
                    // Sam writes the movement pieces here
                    if (unitType == UnitType.Tank) {
                        AudioManager.Instance.TankMove();
                        Debug.Log("Tank does the move");
					}
					else if (unitType == UnitType.Jet) {
						AudioManager.Instance.JetMove();
						Debug.Log("Jet does the move");
					}
                    currentPool -= 1;
                }
            }

        }

    }
}
