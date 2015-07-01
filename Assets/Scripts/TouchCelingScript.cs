using UnityEngine;
using System.Collections;

public class TouchCelingScript : MonoBehaviour {
	public Vector2 Force;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	}

	void OnTriggerEnter2D(Collider2D coll){
		var rb = coll.GetComponent<Rigidbody2D>();
		if (rb.tag == "Player") {
			Debug.Log("Bounce!");
			rb.velocity = -rb.velocity.y/2 *Vector2.up;
		}
	}
}
