using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybubble : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
   


