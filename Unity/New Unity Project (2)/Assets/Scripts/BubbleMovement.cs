using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour {

	public GameObject scroll;
	private Scrolling scrolling;
	private float speed = 0;
	private Rigidbody2D rb2d;
	public float move;

	// Use this for initialization
	void Start () {
		scrolling = scroll.GetComponent<Scrolling>();
		speed = scrolling.scrollSpeed;
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*float newpos = Time.time * speed;
		transform.position = pos + Vector2.left * newpos;*/	
		float movspeed = speed * move;	
		rb2d.AddForce(Vector2.left * movspeed);
	}
}
