using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManagerScript : MonoBehaviour {

    public Camera mainCamera;
    public GameObject collidedTextObject;
    public string collidedTextObjectName;
    public int endGameCounter = 59;
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

    void Start () {
        SetLeavesActive();
        InstantiateLists();
    }

    void Update () {
        print(endGameCounter);
        if (endGameCounter == 2)
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
        }

        else if (endGameCounter == 20)
        {
            foreach (GameObject o in thirdLeave)
            {
                o.SetActive(true);
            }
            Destroy(GameObject.Find("leave 2"));
        }

        if (Input.GetMouseButtonDown(0))
        {
            //print("MAYDAY! mouse down!! i repeat: MOUSE DOWN!!!");
            RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);
            foreach (GameObject o in feedback) { o.SetActive(false); }

            if (hit.collider != null)
            {
                //print("Name: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "text")
                {
                    dishighlightLastObject();
                    SaveTextObject(hit.collider.gameObject);
                    highlightSavedObject();
                }

                if (hit.collider.gameObject.tag == "bild")
                {
                    if (GetNameOfObject(hit.collider.gameObject) == collidedTextObjectName)
                    {
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
                    //print("pauseBack");
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
        string[] objectName = collidedTextObject.name.Split(' ');
        int index = Convert.ToInt32(objectName[1]);
        textHighlights[index - 1].SetActive(true);
    }

    void dishighlightLastObject()
    {
        if (collidedTextObject == null)
        {
            return;
        }
        string[] objectName = collidedTextObject.name.Split(' ');
        int index = Convert.ToInt32(objectName[1]);
        textHighlights[index - 1].SetActive(false);
    }
    void SaveTextObject(GameObject collidedObject)
    {
        collidedTextObject = collidedObject;
        //print("collidedTextObject: " + collidedTextObject);
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

        textHighlights.Add(GameObject.Find("hat"));
        textHighlights.Add(GameObject.Find("bedsheet"));
        textHighlights.Add(GameObject.Find("door"));
        textHighlights.Add(GameObject.Find("sink"));
        textHighlights.Add(GameObject.Find("mirror"));
        textHighlights.Add(GameObject.Find("socks"));
        textHighlights.Add(GameObject.Find("couch"));
        textHighlights.Add(GameObject.Find("trousers"));
        textHighlights.Add(GameObject.Find("bathtub"));
        textHighlights.Add(GameObject.Find("jacket"));
        textHighlights.Add(GameObject.Find("blanket"));
        textHighlights.Add(GameObject.Find("coat"));
        textHighlights.Add(GameObject.Find("chair"));
        textHighlights.Add(GameObject.Find("oven"));
        textHighlights.Add(GameObject.Find("underwear"));
        textHighlights.Add(GameObject.Find("dress"));
        textHighlights.Add(GameObject.Find("pillow"));
        textHighlights.Add(GameObject.Find("shoes"));
        textHighlights.Add(GameObject.Find("closet"));
        textHighlights.Add(GameObject.Find("toilette"));
        textHighlights.Add(GameObject.Find("basement"));
        textHighlights.Add(GameObject.Find("table"));
        textHighlights.Add(GameObject.Find("carpet"));
        textHighlights.Add(GameObject.Find("lamp"));
        textHighlights.Add(GameObject.Find("pullover"));
        textHighlights.Add(GameObject.Find("scarf"));
        textHighlights.Add(GameObject.Find("skirt"));
        textHighlights.Add(GameObject.Find("window"));
        textHighlights.Add(GameObject.Find("cupboard"));

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
        firstLeave.Add(GameObject.Find("hat 1"));
        firstLeave.Add(GameObject.Find("bedsheet 2"));
        firstLeave.Add(GameObject.Find("door 3"));
        firstLeave.Add(GameObject.Find("sink 4"));
        firstLeave.Add(GameObject.Find("mirror 5"));
        firstLeave.Add(GameObject.Find("socks 6"));
        firstLeave.Add(GameObject.Find("couch 7"));
        firstLeave.Add(GameObject.Find("trousers 8"));
        firstLeave.Add(GameObject.Find("bathtub 9"));
        firstLeave.Add(GameObject.Find("jacket 10"));

        foreach (GameObject o in firstLeave) { o.SetActive(true); }

        //List2
        secondLeave.Add(GameObject.Find("blanket 11"));
        secondLeave.Add(GameObject.Find("coat 12"));
        secondLeave.Add(GameObject.Find("chair 13"));
        secondLeave.Add(GameObject.Find("oven 14"));
        secondLeave.Add(GameObject.Find("underwear 15"));
        secondLeave.Add(GameObject.Find("dress 16"));
        secondLeave.Add(GameObject.Find("pillow 17"));
        secondLeave.Add(GameObject.Find("shoes 18"));
        secondLeave.Add(GameObject.Find("closet 19"));
        secondLeave.Add(GameObject.Find("toilette 20"));

        //ELemente aus Liste inaktiv setzen 
        foreach (GameObject o in secondLeave) { o.SetActive(false); }

        //List3
        thirdLeave.Add(GameObject.Find("basement 21"));
        thirdLeave.Add(GameObject.Find("table 22"));
        thirdLeave.Add(GameObject.Find("carpet 23"));
        thirdLeave.Add(GameObject.Find("lamp 24"));
        thirdLeave.Add(GameObject.Find("pullover 25"));
        thirdLeave.Add(GameObject.Find("scarf 26"));
        thirdLeave.Add(GameObject.Find("skirt 27"));
        thirdLeave.Add(GameObject.Find("window 28"));
        thirdLeave.Add(GameObject.Find("cupboard 29"));

        //ELemente aus Liste inaktiv setzen 
        foreach (GameObject o in thirdLeave) { o.SetActive(false); }
    }
}
