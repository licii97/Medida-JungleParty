using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour {
    public Camera mainCamera; 
	public GameObject Player;
	public GameObject Bar;
	private playerController con;
	public float progressrate;
	public float progress=0;
    public List<GameObject> levelDoneScreen = new List<GameObject>();

	// Use this for initialization
	void Start () {
		updateBar();
        InstantiateLists();
    }

    // Update is called once per frame
    void Update()
    {
        // resize Bar
        if (progress == 100)
        {
            foreach (GameObject o in levelDoneScreen){o.SetActive(true);}

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = GetHitFromMousePosition(Input.mousePosition);
                if (hit.collider.gameObject.name == "pfeil")
                {
                    SceneManager.LoadScene("Leveluebersicht");
                }
            }
            //SceneManager.LoadScene("Leveluebersicht");
          
        }
    }  
	
	// Update Progress
	public void LevelProgress () {
		con = Player.GetComponent<playerController>();
		if (progress >= 100){ }
		if (progress >= 90){
			if (con.getRight() >= 10) {
				progress = 100;
			}
			else{
				
			}
		}
			
		else{
			progress = progress + progressrate;
		}
		updateBar();
	
	}
	public void updateBar(){
		Bar.transform.localScale = new Vector3(progress*0.01f*0.7f, 0.7f, 0.7f);
	}

    void InstantiateLists()
    {
        levelDoneScreen.Add(GameObject.Find("levelDone"));
        levelDoneScreen.Add(GameObject.Find("pfeil"));
        foreach (GameObject o in levelDoneScreen) { o.SetActive(false); }
    }

    RaycastHit2D GetHitFromMousePosition(Vector3 mousePos)
    {
        Vector3 mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
        Vector2 mousePos2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        return hit;
    }
}
