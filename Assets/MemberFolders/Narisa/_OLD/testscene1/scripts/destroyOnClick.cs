using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnClick : MonoBehaviour {

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
