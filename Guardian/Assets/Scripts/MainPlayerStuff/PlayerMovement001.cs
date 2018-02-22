using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement001 : MonoBehaviour {

	public float walkSpeed = 10;

	Vector3 movement;
	private Rigidbody rb;

	Collider enemCol;
	bool triggered = false;

	GameObject checkground;
	public CameraController camScript;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody
	}
	

	//// Update is called once per frame
	void Update () {


		if (triggered && !enemCol) {
			walkSpeed = 10;
			triggered = false;
		}

        //creates a Vector3 out of the input Axis's
		movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));
		//turns the player with the mouse
		transform.localRotation = Quaternion.Euler (transform.localRotation.x, camScript.mouseX, transform.localRotation.z);
        
		//moves the player
		rb.MovePosition (rb.position +transform.TransformDirection(movement * walkSpeed * Time.deltaTime));
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
}
