using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement001 : MonoBehaviour {

	public float walkSpeed = 5;

	Vector3 movement;
	private Rigidbody rb;

	public float distToGrounded = 5f; //the distance from player's origin to the ground when grounded
	GameObject checkground;
	public CameraController camScript;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody
	}
	

	//// Update is called once per frame
	void Update () {


        //creates a Vector3 out of the input Axis's
		movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));
		//turns the player with the mouse
		transform.localRotation = Quaternion.Euler (transform.localRotation.x, camScript.mouseX, transform.localRotation.z);
        
		//moves the player
		rb.MovePosition (rb.position +transform.TransformDirection(movement * walkSpeed * Time.deltaTime));
	}
}
