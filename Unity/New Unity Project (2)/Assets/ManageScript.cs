﻿using System.Collections;
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
    // Vokabeln in je Blatt in drei verschiedene Listen einsortieren 
    public List<GameObject> firstLeave = new List<GameObject>();
    public List<GameObject> secondLeave = new List<GameObject>();
    public List<GameObject> thirdLeave = new List<GameObject>();


    // Use this for initialization
    void Start(){
        SetLeavesActive();
        InstantiateLists(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (endGameCounter == 0){
            print("Spiel vorbei");
        }

        else if (endGameCounter == 40){
            foreach(GameObject o in secondLeave)
            {
                o.SetActive(true);
            }

            Destroy(GameObject.Find("leave 1"));
            //GameObject.Find("leave 1").SetActive(false);
        }

        else if (endGameCounter == 20)
        {
            foreach (GameObject o in thirdLeave)
            {
                o.SetActive(true);
            }
            //Destroy(GameObject.Find("leave 2"));
            GameObject.Find("leave 2").SetActive(false);
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

    void SetLeavesActive()
    {
        GameObject.Find("leave 1").SetActive(true);
        GameObject.Find("leave 2").SetActive(true);
        GameObject.Find("leave 3").SetActive(true);
    }

    void InstantiateLists()
    {
        // Vokabeln zu Listen adden
        //List1 
        firstLeave.Add(GameObject.Find("apple 2"));
        firstLeave.Add(GameObject.Find("salad 2"));
        firstLeave.Add(GameObject.Find("salt 2"));
        firstLeave.Add(GameObject.Find("milk 2"));
        firstLeave.Add(GameObject.Find("bread 2"));
        firstLeave.Add(GameObject.Find("fork 2"));
        firstLeave.Add(GameObject.Find("grapes 2"));
        firstLeave.Add(GameObject.Find("pineapple 2"));
        firstLeave.Add(GameObject.Find("onion 2"));
        firstLeave.Add(GameObject.Find("cherry 2"));

        foreach (GameObject o in firstLeave)
        {
            o.SetActive(true);
        }

        //List2
        secondLeave.Add(GameObject.Find("glass 2"));
        secondLeave.Add(GameObject.Find("pepper 2"));
        secondLeave.Add(GameObject.Find("butter 2"));
        secondLeave.Add(GameObject.Find("melon 2"));
        secondLeave.Add(GameObject.Find("noodles 2"));
        secondLeave.Add(GameObject.Find("sausage 2"));
        secondLeave.Add(GameObject.Find("orange 2"));
        secondLeave.Add(GameObject.Find("plate 2"));
        secondLeave.Add(GameObject.Find("potato 2"));
        secondLeave.Add(GameObject.Find("cucumber 2"));

        //ELemente aus Liste inaktiv setzen 
        foreach (GameObject o in secondLeave)
        {
            o.SetActive(false);
        }

        
        //List3
        thirdLeave.Add(GameObject.Find("tomato 2"));
        thirdLeave.Add(GameObject.Find("cheese 2"));
        thirdLeave.Add(GameObject.Find("carrot 2"));
        thirdLeave.Add(GameObject.Find("strawberry 2"));
        thirdLeave.Add(GameObject.Find("lemon 2"));
        thirdLeave.Add(GameObject.Find("spoon 2"));
        thirdLeave.Add(GameObject.Find("knife 2"));
        thirdLeave.Add(GameObject.Find("cake 2"));
        thirdLeave.Add(GameObject.Find("cup 2"));
        thirdLeave.Add(GameObject.Find("banana 2"));

        //ELemente aus Liste inaktiv setzen 
        foreach (GameObject o in thirdLeave)
        {
            o.SetActive(false);
        }
                       
    }
}




