using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class bgLooperScript : MonoBehaviour {

	public int bgcount;
	RandomNumberGenerator rng;


	// Use this for initialization
	void Start () {
		rng = RandomNumberGenerator.Create ();
		foreach (var go in GameObject.FindGameObjectsWithTag("Obstacle")) {
			SetRandomPos(go.transform);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetRandomPos(Transform b){
		byte[] by = new byte[2];
		rng.GetBytes (by);
		var n = System.BitConverter.ToUInt16 (by,0);
		Debug.Log (n);
		Debug.Log (n/(float)ushort.MaxValue);

		var r = Mathf.Lerp (.47f, 1.1f, n/(float)ushort.MaxValue);
		var p = b.transform.position;
		p.y = r;
		b.transform.position = p;
	}

	void OnTriggerEnter2D(Collider2D coll){
		var boxedcol = ((BoxCollider2D)coll);
		var width = boxedcol.size.x;

		var pos = coll.transform.position;
		pos.x += width * bgcount;

		coll.transform.position = pos;

		if (coll.tag == "Obstacle") {
			SetRandomPos(boxedcol.transform);
		}
	}
}
