using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbildschirm : MonoBehaviour {
    public Camera mainCamera;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("HI");
            RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);

            if (hit.collider != null)
            {
                print("collided");
                switch (hit.collider.gameObject.name)
                {
                    case ("Start"):
                        SceneManager.LoadScene("Leveluebersicht");
                        break;
                    case ("SpielVerlassen"):
                        break;
                    case ("Spielanleitung"):
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
