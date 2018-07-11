using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScript : MonoBehaviour {

    public Camera mainCamera;
    public GameObject collidedTextObject;
    public string collidedTextObjectName;
    public int endGameCounter = 60;
    // Vokabeln in je Blatt in drei verschiedene Listen einsortieren 
    public List<GameObject> firstLeave = new List<GameObject>();
    public List<GameObject> secondLeave = new List<GameObject>();
    public List<GameObject> thirdLeave = new List<GameObject>();
    public List<GameObject> helpPage = new List<GameObject>();
    public List<GameObject> pausePage = new List<GameObject>();
    public List<GameObject> gameDonePage = new List<GameObject>();
    public List<GameObject> textHighlights = new List<GameObject>();
    public List<GameObject> feedback = new List<GameObject>();
    public ManageLevel manageLevel; 

    void Start() {
        SetLeavesActive();
        InstantiateLists();

    }

    // Update is called once per frame
    void Update()
    {
        if (endGameCounter == 0)
        {
            foreach (GameObject o in gameDonePage)
            {
                o.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0))
            {   
                RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);
                if (hit.collider.gameObject.name == "levelBack")
                {	
                    SceneManager.LoadScene("Leveluebersicht");
                }
            }
        }

        else if (endGameCounter == 40)
        {
            foreach (GameObject o in secondLeave)
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
            Destroy(GameObject.Find("leave 2"));
            //GameObject.Find("leave 2").SetActive(false);
        }

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);
            foreach (GameObject o in feedback) { o.SetActive(false); }

            if (hit.collider != null) {
                if (hit.collider.gameObject.name == "exit")
                {
                    SceneManager.LoadScene("Leveluebersicht");
                }
                //print("Name: " + hit.collider.gameObject.name);
                //print("Tag: " + hit.collider.gameObject.tag);
                if (hit.collider.gameObject.tag == "text") {
                    dishighlightLastObject();
                    SaveTextObject(hit.collider.gameObject);
                    highlightSavedObject();
                }

                if (hit.collider.gameObject.tag == "bild") {
                    if (GetNameOfObject(hit.collider.gameObject) == collidedTextObjectName) {
                        feedback[0].SetActive(true);
                        Destroy(hit.collider.gameObject);
                        Destroy(collidedTextObject);
                        Destroy(GetHighlightedObject());
                        endGameCounter -= 2;
                    }
                    else { feedback[1].SetActive(true); }
                }
                

                if (hit.collider.gameObject.tag == "help")
                {
                    foreach (GameObject o in helpPage)
                    {
                        o.SetActive(true);
                    }
                }
                if (hit.collider.gameObject.tag == "anleitungBack")
                {
                    foreach (GameObject o in helpPage)
                    {
                        o.SetActive(false);
                    }
                }

                if (hit.collider.gameObject.tag == "pause")
                {
                    foreach (GameObject o in pausePage)
                    {
                        o.SetActive(true);
                    }
                }
                if (hit.collider.gameObject.name == "pauseBack")
                {
                    foreach (GameObject o in pausePage)
                    {
                        o.SetActive(false);
                    }
                }
            }

        }
    }

    GameObject GetHighlightedObject()
    {
        string[] objectName = collidedTextObject.name.Split(' ');
        int index = Convert.ToInt32(objectName[1]);
        return textHighlights[index - 1];
    }
    void highlightSavedObject()
    {
        print("highlighting startet");
        string[] objectName = collidedTextObject.name.Split(' ');
        int index = Convert.ToInt32(objectName[1]);
        print("index: " + index);
        textHighlights[index-1].SetActive(true);
        print("highlightObj aus liste: " + textHighlights[index-1]);
    }

    void dishighlightLastObject()
    {
        if (collidedTextObject == null) {
            print("dishighlight return");
            return; }
        string[] objectName = collidedTextObject.name.Split(' ');
        int index = Convert.ToInt32(objectName[1]);
        textHighlights[index-1].SetActive(false);
    }
    void SaveTextObject(GameObject collidedObject)
    {
        collidedTextObject = collidedObject;
        print("collidedTextObject: " + collidedTextObject);
        string[] objectName = collidedTextObject.name.Split(' ');
        collidedTextObjectName = objectName[0];
    }

    string GetNameOfObject(GameObject collidedObject)
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
        feedback.Add(GameObject.Find("richtig"));
        feedback.Add(GameObject.Find("falsch"));

        foreach (GameObject o in feedback) { o.SetActive(false); }

        textHighlights.Add(GameObject.Find("apple"));
        textHighlights.Add(GameObject.Find("salad"));
        textHighlights.Add(GameObject.Find("salt"));
        textHighlights.Add(GameObject.Find("milk"));
        textHighlights.Add(GameObject.Find("bread"));
        textHighlights.Add(GameObject.Find("fork"));
        textHighlights.Add(GameObject.Find("grapes"));
        textHighlights.Add(GameObject.Find("pineapple"));
        textHighlights.Add(GameObject.Find("onion"));
        textHighlights.Add(GameObject.Find("cherry"));
        textHighlights.Add(GameObject.Find("glass"));
        textHighlights.Add(GameObject.Find("pepper"));
        textHighlights.Add(GameObject.Find("butter"));
        textHighlights.Add(GameObject.Find("melon"));
        textHighlights.Add(GameObject.Find("noodles"));
        textHighlights.Add(GameObject.Find("sausage"));
        textHighlights.Add(GameObject.Find("orange"));
        textHighlights.Add(GameObject.Find("plate"));
        textHighlights.Add(GameObject.Find("potato"));
        textHighlights.Add(GameObject.Find("cucumber"));
        textHighlights.Add(GameObject.Find("tomato"));
        textHighlights.Add(GameObject.Find("cheese"));
        textHighlights.Add(GameObject.Find("carrot"));
        textHighlights.Add(GameObject.Find("strawberry"));
        textHighlights.Add(GameObject.Find("banana"));
        textHighlights.Add(GameObject.Find("lemon"));
        textHighlights.Add(GameObject.Find("spoon"));
        textHighlights.Add(GameObject.Find("knife"));
        textHighlights.Add(GameObject.Find("cake"));
        textHighlights.Add(GameObject.Find("cup"));

        foreach (GameObject o in textHighlights) { o.SetActive(false); }

        helpPage.Add(GameObject.Find("anleitung"));
        helpPage.Add(GameObject.Find("anleitungBack"));

        foreach (GameObject o in helpPage) { o.SetActive(false); }

        pausePage.Add(GameObject.Find("pausePage"));
        pausePage.Add(GameObject.Find("pauseBack"));

        foreach (GameObject o in pausePage) { o.SetActive(false); }

        gameDonePage.Add(GameObject.Find("levelDone"));
        gameDonePage.Add(GameObject.Find("levelBack"));

        foreach (GameObject o in gameDonePage) { o.SetActive(false); }

        // Vokabeln zu Listen adden
        //List1 
        firstLeave.Add(GameObject.Find("apple 1"));
        firstLeave.Add(GameObject.Find("salad 2"));
        firstLeave.Add(GameObject.Find("salt 3"));
        firstLeave.Add(GameObject.Find("milk 4"));
        firstLeave.Add(GameObject.Find("bread 5"));
        firstLeave.Add(GameObject.Find("fork 6"));
        firstLeave.Add(GameObject.Find("grapes 7"));
        firstLeave.Add(GameObject.Find("pineapple 8"));
        firstLeave.Add(GameObject.Find("onion 9"));
        firstLeave.Add(GameObject.Find("cherry 10"));

        foreach (GameObject o in firstLeave) { o.SetActive(true); }

        //List2
        secondLeave.Add(GameObject.Find("glass 11"));
        secondLeave.Add(GameObject.Find("pepper 12"));
        secondLeave.Add(GameObject.Find("butter 13"));
        secondLeave.Add(GameObject.Find("melon 14"));
        secondLeave.Add(GameObject.Find("noodles 15"));
        secondLeave.Add(GameObject.Find("sausage 16"));
        secondLeave.Add(GameObject.Find("orange 17"));
        secondLeave.Add(GameObject.Find("plate 18"));
        secondLeave.Add(GameObject.Find("potato 19"));
        secondLeave.Add(GameObject.Find("cucumber 20"));

        //ELemente aus Liste inaktiv setzen 
        foreach (GameObject o in secondLeave) { o.SetActive(false); }

        //List3
        thirdLeave.Add(GameObject.Find("tomato 21"));
        thirdLeave.Add(GameObject.Find("cheese 22"));
        thirdLeave.Add(GameObject.Find("carrot 23"));
        thirdLeave.Add(GameObject.Find("strawberry 24"));
        thirdLeave.Add(GameObject.Find("banana 25"));
        thirdLeave.Add(GameObject.Find("lemon 26"));
        thirdLeave.Add(GameObject.Find("spoon 27"));
        thirdLeave.Add(GameObject.Find("knife 28"));
        thirdLeave.Add(GameObject.Find("cake 29"));
        thirdLeave.Add(GameObject.Find("cup 30"));

        //ELemente aus Liste inaktiv setzen 
        foreach (GameObject o in thirdLeave) { o.SetActive(false); }
    }
}





