using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	
	public float movespeed;
	public GameObject Scroll;
    public GameObject yay;
    public GameObject nay;
    public GameObject progressbar;
    private Rigidbody2D rb2d;
	private Scrolling scrolling;
    private Progress progress;
	public static playerController Instance;
	private int right= 0;
    private Quaternion rotation;


    void Awake(){
		Instance = this;
	}
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
        rotation = new Quaternion(0, 0, 0, 0);
    }

	void FixedUpdate () {
		float move = Input.GetAxis ("Vertical");	//Up and Down
		Vector2 direction = new Vector2 (0,move);
		rb2d.AddForce(direction * movespeed);
	}
	
	void OnCollisionEnter2D (Collision2D col)   {
		
		scrolling = Scroll.GetComponent<Scrolling>();
        progress = progressbar.GetComponent<Progress>();

		if(col.gameObject.tag == "Right"){
			scrolling.speedUp();
			right++;
            Instantiate(yay, col.transform.position, rotation);
            Destroy (col.gameObject);
		}
		else if(col.gameObject.tag == "Wrong"){
			scrolling.speedDown();
            progress.progress = progress.progress - 2;
            progress.updateBar();
            Instantiate(nay,col.transform.position,rotation);
			Destroy (col.gameObject);
		}
	}
	public int getRight(){
		return right;
	} 
}
