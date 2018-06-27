using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

	public float rate;

	private Vector3 spawn;
	private float lastspawn = 0;

	public GameObject[] bubbles;
	public GameObject scroll;
	private Scrolling scrolling;
	private Quaternion rotation;
	private float speed = 0;
	
	// Use this for initialization
	void Start () {
		spawn = transform.position;
		rotation = new Quaternion(0,0,0,0);
		scrolling = scroll.GetComponent<Scrolling>();
	}
	
	// Update is called once per frame
	void Update () {
		int random;
		speed = scrolling.scrollSpeed;

		if(Time.time > lastspawn + rate/speed){
			random = Random.Range(0,2);
			Instantiate(bubbles[random], spawn, rotation);
			lastspawn = Time.time;
		}
		
	}
}
