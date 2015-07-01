using UnityEngine;
using System.Collections;

public class floorMover : MonoBehaviour {
	GameObject player;
	public float Coeficient=.9f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {
			Debug.LogError("playernot found");
		}
	}
	// Update is called once per frame
	void Update () {
		float vel = player.rigidbody2D.velocity.x * Coeficient;

		if(!BirdMovementCS.isdead)
			transform.position += Vector3.right * vel * Time.deltaTime;
	}
}
