using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {

	public static bool hasShown = false;

	// Use this for initialization
	void Start () {
		if (!hasShown) {
			Time.timeScale = 0;
		}
		else {
			GetComponent<SpriteRenderer>().enabled=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
