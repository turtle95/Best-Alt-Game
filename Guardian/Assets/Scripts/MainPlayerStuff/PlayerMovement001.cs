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

		float fall;
		if (Grounded ())
			fall = 0;
		else
			fall = -0.5f;

        //creates a Vector3 out of the input Axis's
		movement = new Vector3 (Input.GetAxis ("Horizontal"), fall, Input.GetAxis("Vertical"));
		transform.localRotation = Quaternion.Euler (transform.localRotation.x, camScript.mouseX, transform.localRotation.z);
        //directly assigns the player a velocity based on the movement and speed
       rb.velocity = transform.TransformDirection(movement * walkSpeed) ; 
	}

	bool Grounded(){
		return Physics.Raycast (transform.position, Vector3.down, distToGrounded);
	}

    /*
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * walkSpeed);
    }

    */
}
