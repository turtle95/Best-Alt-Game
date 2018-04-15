using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement001 : MonoBehaviour {

	public float walkSpeed = 10;

	Vector3 movement;
	private Rigidbody rb;

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
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody
		transform.localRotation = Quaternion.Euler (camScript.mouseY * ySensitivity, camScript.mouseX, transform.localRotation.z);
	}
	

	//// Update is called once per frame
	void Update () {


		if (triggered && !enemCol) {
			walkSpeed = 10;
			triggered = false;
		}

        //creates a Vector3 out of the input Axis's
		movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));
		movement = Camera.main.transform.TransformDirection(movement);

		
		if(!(movement.x == 0) && !(movement.z == 0))
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (new Vector3(movement.x, 0, movement.z)), turnSpeed);



		if (Input.GetButtonDown ("Jump")) {
			movement *= dashDistance;
			dashParticles.Play ();
			dashParticles2.Play ();
		}
        
		//moves the player

		if (Grounded () && !flying)
			movement.y = 0;
		if (!Grounded () && !flying) {
			movement.y = -14f * Time.deltaTime;
			if(!NotFastFall())
				movement.y = -45f * Time.deltaTime;
		}
		//if(shoot downward)
		//	movement.y = 5;
		//rb.MovePosition (rb.position +(movement * walkSpeed * Time.deltaTime));
		rb.velocity = (movement * walkSpeed);
		//rb.AddForce (movement * walkSpeed);
	}

	bool NotFastFall(){
		return Physics.Raycast (transform.position, Vector3.down, distToFall);
	}

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

		if (col.CompareTag ("Rock")) {
			flying = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.CompareTag ("Fog")) {
			walkSpeed = 10;
			triggered = false;
		}
		if (col.CompareTag ("Rock")) {
			flying = false;
		}
	}
}
