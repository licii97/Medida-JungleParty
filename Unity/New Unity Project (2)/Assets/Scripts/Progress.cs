using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour {
	public GameObject Player;
	public GameObject Bar;
	private playerController con;
	public float progressrate;
	public float progress=0;
	

	// Use this for initialization
	void Start () {
		updateBar();
	}
	
	// Update is called once per frame
	void Update () {
		// resize Bar
	}
	
	// Update Progress
	public void LevelProgress () {
		con = Player.GetComponent<playerController>();
		if (progress >= 100){
            foreach (GameObject o in con.getLevelDoneScreen())
            {
                o.SetActive(false);
            }


        }
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
}
