using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScript : MonoBehaviour {

    //public Vector3 mousePos;
    //public Vector2 mousePos2D;
    //public Vector3 mousePosWorld;
    //public RaycastHit2D hit;
    public Camera mainCamera;
    public GameObject collidedTextObject;
    public string collidedTextObjectName;
    public int endGameCounter = 60;

    // Use this for initialization
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (endGameCounter == 0){
            print("Spiel vorbei");
        }

        // 0 = linke Maustaste
        if (Input.GetMouseButtonDown(0)){
            RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);

            if (hit.collider != null){
                print("Name: " + hit.collider.gameObject.name);
                print("Tag: " + hit.collider.gameObject.tag);

                if (hit.collider.gameObject.tag == "text"){
                    SaveTextObject(hit.collider.gameObject);
                }

                if (hit.collider.gameObject.tag == "bild"){
                    if (GetNameOfObject(hit.collider.gameObject) == collidedTextObjectName){
                        Destroy(hit.collider.gameObject);
                        Destroy(collidedTextObject);
                        endGameCounter -= 2;
                    }
                }
            }
            
        }
    }

    void SaveTextObject(GameObject collidedObject )
    {
        collidedTextObject = collidedObject;
        string[] objectName = collidedTextObject.name.Split(' ');
        collidedTextObjectName = objectName[0];
    }

    string GetNameOfObject (GameObject collidedObject)
    {
        string[] name = collidedObject.name.Split(' ');
        return name[0];
    }

    RaycastHit2D GetHitFromMousePosition(Vector3 mousePos)
    {
        Vector3 mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
        Vector2 mousePos2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        return hit;
    }
}




