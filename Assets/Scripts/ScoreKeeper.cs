using UnityEngine;
using System.Collections;

class ScoreKeeper : MonoBehaviour {

	public static int Score;
	public static int HighScore;

	// Use this for initialization
	void Start () {
		Score = 0;
		HighScore=PlayerPrefs.GetInt ("HighScore",0);
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", HighScore);
	}

	static public void AddPoints(int points){
		Score += points;
		if (Score > HighScore) {
			HighScore = Score;
		}
	}

	// Update is called once per frame
	void Update () {
		guiText.text = string.Format("Score:{0}\nBest:{1}",Score,HighScore) ;
	}
}
