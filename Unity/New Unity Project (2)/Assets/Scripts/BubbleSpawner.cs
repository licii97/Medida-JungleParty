using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

	public float rate;

	private Vector3 spawn;
	private float lastspawn = 0;

	public GameObject[] bubbles;
    public int randomrange;
	public GameObject scroll;
    public GameObject otherspawner1;
    public GameObject otherspawner2;
    private BubbleSpawner spawn1;
    private BubbleSpawner spawn2;
    public string spawned = "";
    private Scrolling scrolling;
	private Quaternion rotation;
	private float speed = 0;

    // Use this for initialization
    void Start () {
		spawn = transform.position;
		rotation = new Quaternion(0,0,0,0);
		scrolling = scroll.GetComponent<Scrolling>();
        spawn1 = otherspawner1.GetComponent<BubbleSpawner>();
        spawn2 = otherspawner2.GetComponent<BubbleSpawner>();
    }

    // Update is called once per frame
    void Update() {
        int random;
        speed = scrolling.scrollSpeed;
        bool i = true;
        while (i == true) {
            random = Random.Range(0, randomrange);
            if (spawn1.spawned == spawn2.spawned && spawn1.spawned == bubbles[random].tag)
            {
            }
            else {
                if (Time.time > lastspawn + rate / speed)
                {
                    Instantiate(bubbles[random], spawn, rotation);
                    spawned = bubbles[random].tag;
                    lastspawn = Time.time;

                }
                else
                {
                    i = false;
                }
            }
        }
    }

}
