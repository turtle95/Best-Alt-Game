using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement001 : MonoBehaviour {

	public float walkSpeed = 5;

	Vector3 movement;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical")); //creates a Vector3 out of the input Axis's
		rb.velocity = transform.TransformDirection(movement * walkSpeed) ; //directly assigns the player a velocity based on the movement and speed
	}
}
