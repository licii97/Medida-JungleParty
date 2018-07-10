using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (transform.position.y > -6)
        {
            Object.Destroy(gameObject, 0.3f);
        }
    }
}
