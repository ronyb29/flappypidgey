using UnityEngine;
using System.Collections;

public class ScorePoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.tag);
		if (col.tag == "Player") {
			ScoreKeeper.AddPoints(1);
		}
	}
}
