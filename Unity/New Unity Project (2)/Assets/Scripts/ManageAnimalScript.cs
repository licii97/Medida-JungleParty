using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageAnimalScript : MonoBehaviour
{

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

    void Start()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);
            foreach (GameObject o in feedback) { o.SetActive(false); }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "exit")
                {
                    SceneManager.LoadScene("Leveluebersicht");
                }
                //print("Name: " + hit.collider.gameObject.name);
                //print("Tag: " + hit.collider.gameObject.tag);
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
        textHighlights[index - 1].SetActive(true);
        print("highlightObj aus liste: " + textHighlights[index - 1]);
    }

    void dishighlightLastObject()
    {
        if (collidedTextObject == null)
        {
            print("dishighlight return");
            return;
        }
        string[] objectName = collidedTextObject.name.Split(' ');
        int index = Convert.ToInt32(objectName[1]);
        textHighlights[index - 1].SetActive(false);
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

        textHighlights.Add(GameObject.Find("monkey"));
        textHighlights.Add(GameObject.Find("fish"));
        textHighlights.Add(GameObject.Find("elephant"));
        textHighlights.Add(GameObject.Find("dog"));
        textHighlights.Add(GameObject.Find("cat"));
        textHighlights.Add(GameObject.Find("horse"));
        textHighlights.Add(GameObject.Find("bear"));
        textHighlights.Add(GameObject.Find("giraffe"));
        textHighlights.Add(GameObject.Find("panda"));
        textHighlights.Add(GameObject.Find("crocodile"));
        textHighlights.Add(GameObject.Find("hippo"));
        textHighlights.Add(GameObject.Find("bird"));
        textHighlights.Add(GameObject.Find("turtle"));
        textHighlights.Add(GameObject.Find("pig"));
        textHighlights.Add(GameObject.Find("chicken"));
        textHighlights.Add(GameObject.Find("spider"));
        textHighlights.Add(GameObject.Find("fly"));
        textHighlights.Add(GameObject.Find("rabbit"));
        textHighlights.Add(GameObject.Find("lion"));
        textHighlights.Add(GameObject.Find("donkey"));
        textHighlights.Add(GameObject.Find("jellyfish"));
        textHighlights.Add(GameObject.Find("shark"));
        textHighlights.Add(GameObject.Find("crab"));
        textHighlights.Add(GameObject.Find("tiger"));
        textHighlights.Add(GameObject.Find("dolphin"));
        textHighlights.Add(GameObject.Find("penguin"));
        textHighlights.Add(GameObject.Find("mouse"));
        textHighlights.Add(GameObject.Find("cow"));
        textHighlights.Add(GameObject.Find("sheep"));
        textHighlights.Add(GameObject.Find("duck"));

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
        firstLeave.Add(GameObject.Find("monkey 1"));
        firstLeave.Add(GameObject.Find("fish 2"));
        firstLeave.Add(GameObject.Find("elephant 3"));
        firstLeave.Add(GameObject.Find("dog 4"));
        firstLeave.Add(GameObject.Find("cat 5"));
        firstLeave.Add(GameObject.Find("horse 6"));
        firstLeave.Add(GameObject.Find("bear 7"));
        firstLeave.Add(GameObject.Find("giraffe 8"));
        firstLeave.Add(GameObject.Find("panda 9"));
        firstLeave.Add(GameObject.Find("crocodile 10"));

        foreach (GameObject o in firstLeave) { o.SetActive(true); }

        //List2
        secondLeave.Add(GameObject.Find("hippo 11"));
        secondLeave.Add(GameObject.Find("bird 12"));
        secondLeave.Add(GameObject.Find("turtle 13"));
        secondLeave.Add(GameObject.Find("pig 14"));
        secondLeave.Add(GameObject.Find("chicken 15"));
        secondLeave.Add(GameObject.Find("spider 16"));
        secondLeave.Add(GameObject.Find("fly 17"));
        secondLeave.Add(GameObject.Find("rabbit 18"));
        secondLeave.Add(GameObject.Find("lion 19"));
        secondLeave.Add(GameObject.Find("donkey 20"));

        //ELemente aus Liste inaktiv setzen 
        foreach (GameObject o in secondLeave) { o.SetActive(false); }

        //List3
        thirdLeave.Add(GameObject.Find("jellyfish 21"));
        thirdLeave.Add(GameObject.Find("shark 22"));
        thirdLeave.Add(GameObject.Find("crab 23"));
        thirdLeave.Add(GameObject.Find("tiger 24"));
        thirdLeave.Add(GameObject.Find("dolphin 25"));
        thirdLeave.Add(GameObject.Find("penguin 26"));
        thirdLeave.Add(GameObject.Find("mouse 27"));
        thirdLeave.Add(GameObject.Find("cow 28"));
        thirdLeave.Add(GameObject.Find("sheep 29"));
        thirdLeave.Add(GameObject.Find("duck 30"));

        //ELemente aus Liste inaktiv setzen 
        foreach (GameObject o in thirdLeave) { o.SetActive(false); }
    }
}





