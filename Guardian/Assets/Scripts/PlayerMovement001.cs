using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement001 : MonoBehaviour {

	public float walkSpeed = 5;

	Vector3 movement;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody
	}
	

	//// Update is called once per frame
	void Update () {
        //creates a Vector3 out of the input Axis's
		movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, 
                                Input.GetAxis("Vertical"));
        //directly assigns the player a velocity based on the movement and speed
       rb.velocity = transform.TransformDirection(movement * walkSpeed) ; 
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
