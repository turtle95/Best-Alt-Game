﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Movement : MonoBehaviour {

	public Transform mover;
	public Transform planet;
	public float walkSpeed = 10;
	public float gravity = -10;

	public CameraController camScript;

	Vector3 movement;
	private Rigidbody rb;


	Collider enemCol;
	bool triggered = false;

	float ySensitivity = 0.5f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody

	}
		

	void Update () {
		
		if (triggered && !enemCol) {
			walkSpeed = 10;
			triggered = false;
		}

		//rotates the player based on its relation to the planet, applies gravity
		WorldGravity();
		
		//creates a Vector3 out of the input Axis's
		movement = new Vector3 ( Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));

		//moves the player without directly adjusting its velocity, allows gravity to keep working
		rb.MovePosition (rb.position + mover.TransformDirection(movement * walkSpeed * Time.deltaTime));


		//rotates the items parented to the main player container based on mouse movement
		mover.localRotation = Quaternion.Euler (camScript.mouseY * ySensitivity, camScript.mouseX, mover.localRotation.z);

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
}
