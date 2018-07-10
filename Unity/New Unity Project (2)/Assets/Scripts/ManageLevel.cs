using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageLevel : MonoBehaviour {
    public Camera mainCamera;
    public List<GameObject> layerOne = new List<GameObject>();
    int anzahlLevel; 
  


    // Use this for initialization
    void Start () {
        anzahlLevel = PlayerPrefs.GetInt("anzahlLevel", 0);
        layerOne.Add(GameObject.Find("Insel1"));
        layerOne.Add(GameObject.Find("Weg1"));
        layerOne.Add(GameObject.Find("Insel2"));
        layerOne.Add(GameObject.Find("Weg2"));
        layerOne.Add(GameObject.Find("Insel3"));    
        layerOne.Add(GameObject.Find("Weg3"));

        foreach (GameObject o in layerOne)
        {
            o.SetActive(false);
        }

        layerOne[0].SetActive(true);
        
    }
	
	// Update is called once per frame
	void Update () {
        for (int i=0; i<=anzahlLevel; i++)
        {
            layerOne[i].SetActive(true); 
        }
        /**switch (anzahlLevel)
        {
            case 1:
                layerOne[1].SetActive(true);
                break;
            case 2:
                layerOne[2].SetActive(true);
                break;
            case 3:
                layerOne[3].SetActive(true);
                break;
            case 4:
                layerOne[4].SetActive(true);
                break;
            case 5:
                layerOne[5].SetActive(true);
                break;            
        }*/

        // 0 = linke Maustaste
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);

            if (hit.collider != null)
            {

                /**if (anzahlLevel5 && hit.collider.gameObject.name == layerOne[anzahlLevel].name)
                {
                    anzahlLevel++;
                }*/

                switch (hit.collider.gameObject.name)
                {
                    case ("Insel1"):
                        PlayerPrefs.SetInt("anzahlLevel", 1);
                        print("anzahlLevel im update" + PlayerPrefs.GetInt("anzahlLevel", 10000));
                        SceneManager.LoadScene("scene00");
                        break;
                    case ("Weg1"):
                        PlayerPrefs.SetInt("anzahlLevel", 2);
                        print("anzahlLevel im update" + PlayerPrefs.GetInt("anzahlLevel", 10000));
                        SceneManager.LoadScene("Fisch_Level");
                        break;
                    case ("Insel2"):
                        PlayerPrefs.SetInt("anzahlLevel", 3);
                        print("anzahlLevel im update" + PlayerPrefs.GetInt("anzahlLevel", 10000));
                        SceneManager.LoadScene("Affe_Wohnung");
                        break;
                    case ("Weg2"):
                        PlayerPrefs.SetInt("anzahlLevel", 4);
                        print("anzahlLevel im update" + PlayerPrefs.GetInt("anzahlLevel", 10000));
                        SceneManager.LoadScene("Fisch_Level");
                        break;
                    case ("Insel3"):
                        PlayerPrefs.SetInt("anzahlLevel", 5);
                        print("anzahlLevel im update" + PlayerPrefs.GetInt("anzahlLevel", 10000));
                        SceneManager.LoadScene("scene00");
                        break;
                    case ("Weg3"):
                        PlayerPrefs.SetInt("anzahlLevel", 6);
                        print("anzahlLevel im update" + PlayerPrefs.GetInt("anzahlLevel", 10000));
                        SceneManager.LoadScene("Fisch_Level");
                        break;
                    case ("Trophae"):
                        SceneManager.LoadScene("Belohnung");
                        break;
                    case ("EndlevelStern"):
                        //SceneManager.LoadScene("Endlevel");
                        break;
                }
            }

        }
    }

    RaycastHit2D GetHitFromMousePosition(Vector3 mousePos)
    {
        Vector3 mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
        Vector2 mousePos2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        return hit;
    }

}
