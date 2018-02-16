using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Movement : MonoBehaviour {

	public Transform world;

	public float walkSpeed = 10;

	public float distToGrounded = 5f; //the distance from player's origin to the ground when grounded
	GameObject checkground;
	public Transform mover;
	public CameraController camScript;

	Vector3 movement;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //assigns rb to the player's rigidbody
	}
		

	void Update () {

		float fall;
		if (Grounded ())
			fall = 0;
		else
			fall = -0.5f;
		
		//creates a Vector3 out of the input Axis's
		movement = new Vector3 (Input.GetAxis("Vertical"),0, -Input.GetAxis ("Horizontal"));

		Vector3 fallControl = new Vector3(0,fall,0);

		//directly assigns the player a velocity based on the movement and speed
		rb.velocity = transform.TransformDirection(fallControl * walkSpeed) ; 
		//float mY = transform.eulerAngles.y;
	//	groundLooker.LookAt( world.position);
		transform.localRotation = Quaternion.Euler (transform.localRotation.x, camScript.mouseX, transform.localRotation.z);
		mover.RotateAround(world.position, movement, Time.deltaTime*walkSpeed);
		//transform.eulerAngles = new Vector3(transform.eulerAngles.x +90, mY, transform.eulerAngles.y );

		//transform.localRotation = Quaternion.Euler (groundLooker.localRotation.x, 0, groundLooker.localRotation.z);
		//groundLooker.localRotation = Quaternion.Euler (0,0,0);
		//groundLooker.rotation = Quaternion.E
		//transform.rotation = Quaternion (groundLooker.localRotation.z, transform.rotation.y, groundLooker.localRotation.z);
	}



	bool Grounded(){
		return Physics.Raycast (transform.position, -transform.up, distToGrounded);
	}





	/*
	//// Failed attempt to make the player rotate instead of the player
	void Update () {
		//creates a Vector3 out of the input Axis's
		movement = new Vector3 (-Input.GetAxis ("Vertical"), 0, Input.GetAxis("Horizontal") );
		//directly assigns the player a velocity based on the movement and speed
		//rb.velocity = transform.TransformDirection(movement * walkSpeed) ; 
		if (movement != Vector3.zero)
			world.localEulerAngles += movement * Time.deltaTime * walkSpeed;


		if (world.localEulerAngles.x > 90)
			new Vector3 (0, world.localEulerAngles.y, world.localEulerAngles.z);
		if (world.localEulerAngles.y > 90)
			new Vector3 (world.localEulerAngles.x, 0, world.localEulerAngles.z);
		if (world.localEulerAngles.z> 90)
			new Vector3 (world.localEulerAngles.x, world.localEulerAngles.y, 0);
				//new Vector3(world.eulerAngles.x +movement.x, world.eulerAngles.x +movement.x, world.eulerAngles.x +movement.x) *Time.deltaTime;
	}
	*/


}
