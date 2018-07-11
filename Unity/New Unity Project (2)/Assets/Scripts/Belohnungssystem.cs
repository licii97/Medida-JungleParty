using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Belohnungssystem : MonoBehaviour {
    public Camera mainCamera;
    public List<GameObject> layerOne = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        layerOne.Add(GameObject.Find("Belohnung_0-min"));
        layerOne.Add(GameObject.Find("Belohnung_1-min"));
        layerOne.Add(GameObject.Find("Belohnung_2-min"));
        layerOne.Add(GameObject.Find("Belohnung_3-min"));
        layerOne.Add(GameObject.Find("Belohnung_4-min"));
        layerOne.Add(GameObject.Find("Belohnung_5-min"));

        foreach (GameObject o in layerOne)
        {
            o.SetActive(true); 
        }

        for (int i = 0; i <= PlayerPrefs.GetInt("anzahlLevel", 10000) ; i++)
        {
            layerOne[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);

            /**if (hit.collider.gameObject.name=="exit")
            {
                SceneManager.LoadScene("Leveluebersicht");
            }*/
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
