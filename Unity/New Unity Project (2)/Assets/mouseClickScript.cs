using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClickScript : MonoBehaviour {

    public Vector3 mousePos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //wurde die linke Maustaste gedrückt?
        // 0 = linke Maustaste
        if (Input.GetMouseButtonDown(0))
        {
            print("Maustaste wurde gedrückt");

            //Mausposition auslesen
            mousePos = Input.mousePosition;
            print(mousePos);
        }
	}
}
