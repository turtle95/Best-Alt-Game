using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement001 : MonoBehaviour {

	float refWalkSpeed = 10;
	public float walkSpeed = 10;

	Vector3 movement;
	public Rigidbody rb;

	Collider enemCol;
	bool triggered = false;
	float ySensitivity = 0.5f;
	GameObject checkground;
	public CameraController camScript;
	public float turnSpeed = 0.15f;
	public Transform playerModel;


	public float dashDistance = 10;
	public ParticleSystem dashParticles;
	public ParticleSystem dashParticles2;


	public float distToGrounded = 1f;
	public float distToFall = 5f;
	bool flying = false;

	bool noSlow = false;

	public CameraController cScript;


	public float maxFlyHeight = 2.5f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody
		transform.localRotation = Quaternion.Euler (camScript.mouseY * ySensitivity, camScript.mouseX, transform.localRotation.z);
		refWalkSpeed = walkSpeed;
	}
	

	//// Update is called once per frame
	void Update () {

		//...??
		if (triggered && !enemCol) {
			walkSpeed = refWalkSpeed;
			triggered = false;
		}

        //creates a Vector3 out of the input Axis's, also stores a temp version of movement y so that y won't effect the model's rotation
		float tempY = movement.y;
		movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		movement = Camera.main.transform.TransformDirection (movement);

		//rotates the model
		if(!(movement.x == 0) && !(movement.z == 0))
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (new Vector3(movement.x, 0, movement.z)), turnSpeed);

		//sets movement y back to what it was at the start of update
		movement = new Vector3 (movement.x, tempY, movement.z);

		//lets you dash, doesn't effect y movement value though
		if (Input.GetButtonDown ("Jump")) {
			movement = new Vector3 (movement.x * dashDistance, movement.y, movement.z * dashDistance);
			dashParticles.Play ();
			dashParticles2.Play ();
		}
        

		//when you are grounded and not flying, movement y = 0 and noSlow is reset so the slow fall at short distance will work again
		if (Grounded () && !flying) {
			movement.y = 0;
			noSlow = false;
		}

		//when not grounded and not flying, slow fall, if you are far enough up for fast fall or noSlow is turned on then fall fast
		if (!Grounded () && !flying) {
			movement.y = -14f * Time.deltaTime;
			if(!NotFastFall() || noSlow)
				movement.y = -45f * Time.deltaTime;
		}

		//if you are looking down at the right angle and you fire and you are not high enough up to be in a fast fall then shoot yourself upwards
		if (cScript.lookingDown && Input.GetButtonUp ("Fire1") && NotFastFall()) {
			movement.y = -movement.y *7;
			if (movement.y < 1)
				movement.y = 1;
			if (movement.y > maxFlyHeight)
				movement.y = maxFlyHeight;
			Debug.Log (movement.y);
			flying = true;
		}

		//if you are flying then run the flying timer script(pretty much applies gravity to your jump)
		if (flying)
			FlyingTimer ();


		//moves the player by directly setting its velocity
		rb.velocity = (movement * walkSpeed);
	}


	//slowly applies gravity while you are flying upwards, when momentum = 0, turns flying off and turns regular fast fall back on
	void FlyingTimer()
	{
		noSlow = true;
		movement.y -= 1 * Time.deltaTime;
		if (movement.y < 0) 
			flying = false;
	}

	//true when you are too close to use fast fall
	bool NotFastFall(){
		return Physics.Raycast (transform.position, Vector3.down, distToFall);
	}

	//true when you are on the ground
	bool Grounded()
	{
		return Physics.Raycast (transform.position, Vector3.down, distToGrounded);
	}


	void OnTriggerStay(Collider col){
		if (col.CompareTag ("Fog")) {
			walkSpeed = 3;
			enemCol = col;
			triggered = true;
		}


	}

	void OnTriggerExit(Collider col){
		if (col.CompareTag ("Fog")) {
			walkSpeed = refWalkSpeed;
			triggered = false;
		}

	}
}
