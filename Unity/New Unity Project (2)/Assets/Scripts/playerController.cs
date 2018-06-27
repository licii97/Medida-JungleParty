using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	
	public float movespeed;
	public GameObject Scroll;
	private Rigidbody2D rb2d;
	private Scrolling scrolling;
	public static playerController Instance;
	private int right= 0;
    public List<GameObject> levelDoneScreen = new List<GameObject>(); 


	void Awake(){
		Instance = this;
	}
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
        levelDoneScreen.Add(GameObject.Find("levelDone"));
        levelDoneScreen.Add(GameObject.Find("pfeil"));
        foreach (GameObject o in levelDoneScreen)
        {
            o.SetActive(false);
        }
}

	void FixedUpdate () {
		float move = Input.GetAxis ("Vertical");	//Up and Down
		Vector2 direction = new Vector2 (0,move);
		rb2d.AddForce(direction * movespeed);
	}
	
	void OnCollisionEnter2D (Collision2D col)   {
		
		scrolling = Scroll.GetComponent<Scrolling>();

		if(col.gameObject.tag == "Right"){
			scrolling.speedUp();
			right++;
			Destroy (col.gameObject);
		}
		else if(col.gameObject.tag == "Wrong"){
			scrolling.speedDown();
			Destroy (col.gameObject);
		}
	}
	public int getRight(){
		return right;
	} 

    public List<GameObject> getLevelDoneScreen()
    {
        return levelDoneScreen;
    }
}
