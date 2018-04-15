using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Movement : MonoBehaviour {

	public Transform mover;
	public Transform planet;
	public float walkSpeed = 10;
	public float gravity = -10;
	public float turnSpeed = 0.1f;
	public CameraController camScript;

	Vector3 movement;
	private Rigidbody rb;

	Vector3 gravityUp;
	Collider enemCol;
	bool triggered = false;

	float ySensitivity = 0.9f;

	public Transform camDown;

	public float dashDistance = 15f;
	public ParticleSystem dashParticles;
	public ParticleSystem dashParticles2;


	public float distToGrounded = 1f;
	public float distToFall = 5f;

	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody

	}
		

	void Update () {
		//rotates the player based on its relation to the planet, applies gravity
		WorldGravity();

		movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (!(movement.x == 0) || !(movement.z == 0)) {
			//mover.rotation = transform.right * movement.x;
			//mover.Rotate (transform.up * movement.z, Space.World);
		//	mover.rotation = (transform.up, movement.z, Space.World);
			mover.localEulerAngles = (new Vector3(0, (movement.x *90) / (movement.z * 180),0));
			//Vector3 newDir = Vector3.RotateTowards(mover.forward, transform.right, turnSpeed, 0.0f, Space.World);
			//mover.rotation = Quaternion.LookRotation (newDir);
		}
		//if(movement.x ==1)
			//mover.localRotation = (90, mover.rotation.y, mover.rotation.z);
		//	mover.rotation = Quaternion.Slerp (mover.rotation, 
               //                                Quaternion.Euler (movement.x*90, 0,movement.z*90 ) * 
             //                                  Camera.main.transform.rotation, turnSpeed);
			//mover.Rotate ( Camera.main.transform.forward * -movement.x * turnSpeed);
		movement = Camera.main.transform.TransformDirection(movement);
		//movement.y = 0f;

		if (triggered && !enemCol) {
			walkSpeed = 8;
			triggered = false;
		}

		if (Input.GetButtonDown ("Jump")) {
			rb.AddForce(movement *dashDistance, ForceMode.VelocityChange);
			dashParticles.Play ();
			dashParticles2.Play ();
		}


		//moves the player without directly adjusting its velocity, allows gravity to keep working
		rb.MovePosition (rb.position + movement * walkSpeed * Time.deltaTime);


		//rotates the items parented to the main player container based on mouse movement
		//mover.localRotation = Quaternion.Euler (camScript.mouseY * ySensitivity, camScript.mouseX, mover.localRotation.z);

	}




	//true when you are too close to use fast fall
	bool NotFastFall(){
		return Physics.Raycast (transform.position,-transform.up, distToFall);
	}

	//true when you are on the ground
	bool Grounded()
	{
		return Physics.Raycast (transform.position, -transform.up, distToGrounded);
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
			walkSpeed = 10;
			triggered = false;
		}
	}


	public void WorldGravity()
	{
		//gets the distance between player and planet, essentially this is the direction you want to be facing
		gravityUp = (transform.position - planet.position).normalized;
		//the up direction for the player
		Vector3 turdsUp = transform.up;

		//applies gravity based on the player's local down
		rb.AddForce(turdsUp * gravity);

		//creates a rotation between the gravityUp and the player's current up
		Quaternion targetRotation = Quaternion.FromToRotation(turdsUp, gravityUp) * transform.rotation;
	
		//smoothly rotates the player to the target rotation
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, 50 * Time.deltaTime);
	}
}
