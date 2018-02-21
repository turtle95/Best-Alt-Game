using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Movement : MonoBehaviour {

	public Transform mover;
	public Transform planet;
	public float walkSpeed = 10;
	public float gravity = -10;
	//public float distToGrounded = 5f; //the distance from player's origin to the ground when grounded
	//GameObject checkground;
	Transform player;
	public CameraController camScript;

	Vector3 movement;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody
		player = transform;
	}
		

	void Update () {
		
		/* Commented out the check ground stuff becuase we might need it later, don't need it for anything right now though
		bool fall;
		if (Grounded ())
			fall = false;
		else
			fall = true;
		*/


		//rotates the player based on its relation to the planet, applies gravity
		WorldGravity();
		
		//creates a Vector3 out of the input Axis's
		movement = new Vector3 ( Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));

		//moves the player without directly adjusting its velocity, allows gravity to keep working
		rb.MovePosition (rb.position + mover.TransformDirection(movement * walkSpeed * Time.deltaTime));


		//rotates the items parented to the main player container based on mouse movement
		mover.localRotation = Quaternion.Euler (mover.localRotation.x, camScript.mouseX, mover.localRotation.z);

	}


	public void WorldGravity()
	{
		//gets the distance between player and planet, essentially this is the direction you want to be facing
		Vector3 gravityUp = (transform.position - planet.position).normalized;
		//the up direction for the player
		Vector3 turdsUp = transform.up;

		//applies gravity based on the player's local down
		rb.AddForce(turdsUp * gravity);

		//creates a rotation between the gravityUp and the player's current up
		Quaternion targetRotation = Quaternion.FromToRotation (turdsUp, gravityUp) * transform.rotation;
	
		//smoothly rotates the player to the target rotation
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, 50 * Time.deltaTime);
	}

	/*
	bool Grounded(){
		return Physics.Raycast (transform.position, -transform.up, distToGrounded);
	}*/


}
