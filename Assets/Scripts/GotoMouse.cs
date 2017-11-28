using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoMouse : MonoBehaviour {

    public GameObject projectile;
    public float speed = 1.5f;
    private Vector3 target;

    public bool isClicked;
    public bool isEnemy;
    void Start()
    {
        target = transform.position;
        isClicked = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
