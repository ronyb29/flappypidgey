using UnityEngine;
using System.Collections;

public class BirdMovementCS : MonoBehaviour {

	public Vector2 FlapForce;
	public float fwdSpeed;
	public bool GodMode = false;
	public float FlapCD = .5f;
	public float MaxVerticalVel=10;

	float currFlapCD=0;
	bool hasflapped = false;
	public static bool isdead { get; private set;}
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren <Animator> ();
		isdead = false;
		hasflapped = true;
		currFlapCD = FlapCD;
	}

	// Update is called once per frame
	void Update () {
		var shouldFlap = Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Q) || Input.GetMouseButtonDown (0);

		if (!SplashScript.hasShown && shouldFlap) {
			SplashScript.hasShown=true;
			GameObject.Find("SplashScreen").GetComponent<SpriteRenderer>().enabled=false;
			Time.timeScale=1f;
		}

		if (currFlapCD <= 0 && shouldFlap) {
			if (isdead) {
				Application.LoadLevel(Application.loadedLevel);
			}

			hasflapped = true;
			currFlapCD = FlapCD;
		} else {
			currFlapCD -= Time.deltaTime;
		}
	}

	void FixedUpdate(){
		if (isdead) {
			return;
		}

		if (hasflapped) {
			hasflapped = false;
			animator.SetTrigger ("doFlap");
			GetComponent<Rigidbody2D>().AddForce( - GetComponent<Rigidbody2D>().velocity.y*Vector2.up);
			GetComponent<Rigidbody2D>().AddForce (FlapForce);

		}

		var vel = GetComponent<Rigidbody2D>().velocity;
		vel.x = fwdSpeed;
		if (vel.y>0) 
			vel.y = Mathf.Clamp (vel.y, 0, MaxVerticalVel);
		GetComponent<Rigidbody2D>().velocity = vel;

		float angle = Mathf.Lerp (45f, -75f, -GetComponent<Rigidbody2D>().velocity.y/MaxVerticalVel);
		transform.rotation = Quaternion.Euler (0, 0,angle);

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (GodMode) {
			return;
		}
		animator.SetTrigger ("death");
		isdead = true;
	}

}
