using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScript : MonoBehaviour {

    public Vector3 mousePos;
    public Camera mainCamera;
    public Vector2 mousePos2D;
    public Vector3 mousePosWorld;
    public RaycastHit2D hit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //wurde die linke Maustaste gedrückt?
        // 0 = linke Maustaste
        if (Input.GetMouseButtonDown(0))
        {
            print("Maustaste wurde gedrückt");

            //Mausposition auslesen
            mousePos = Input.mousePosition;
            print(mousePos);
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            mousePos2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
            hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                print("getroffen");
                print("Name: " + hit.collider.gameObject.name);
            }
            else
            {
                print("daneben :P");
            }
        }
    }
}



