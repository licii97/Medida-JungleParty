using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scrolling : MonoBehaviour {

	public float scrollSpeed;
    	public float tileSizex;
	public GameObject Progressbar;
	public float change;
	public static Scrolling Instance;
	private float grace = 0.0f;
	private Progress progress;
    	private Vector2 startPosition;

	void Awake(){
		Instance = this;
	}

    	void Start ()
    	{
        	startPosition = transform.position;
    	}

   	void FixedUpdate ()
  	{
     	 	float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizex);
		if (newPosition < 0.1 && Time.time > grace + 0.5f){
			progress = Progressbar.GetComponent<Progress>();
			progress.LevelProgress();
			grace= Time.time;
		}
		else if (tileSizex/2 -0.1 < newPosition && Time.time > grace + 0.5f)
		{

			if(newPosition < (tileSizex/2 +0.1)){
				progress = Progressbar.GetComponent<Progress>();
				progress.LevelProgress();
				grace= Time.time;	
			}
		
		}
      		transform.position = startPosition + Vector2.left * newPosition;
    	}
	public void speedUp(){

		scrollSpeed = scrollSpeed + change;
	}
	public void speedDown(){

		scrollSpeed = scrollSpeed - change;
	}
}
