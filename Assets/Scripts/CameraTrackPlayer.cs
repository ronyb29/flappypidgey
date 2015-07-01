using UnityEngine;
using System.Collections;

public class CameraTrackPlayer : MonoBehaviour {
	float offset;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {
			Debug.LogError("playernot found");
		}

		offset = transform.position.x - player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (BirdMovementCS.isdead) {
			return;
		}
		//TODO: hacer que el pajarit se vea con offset hacia un porciento de la pantalla
		var p = transform.position;
		p.x = player.transform.position.x + offset;
		transform.position = p;
	}
}
