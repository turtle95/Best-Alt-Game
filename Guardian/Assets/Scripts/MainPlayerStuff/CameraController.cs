using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float sensitivity = 0.125f; //sensitivity of mouse when moving the camera
	public float rangeY = 90f; //movement range for y mouse look
	public float mouseX =0;
	public float mouseY = 0; //values for mouse input

	Quaternion localRotPlayer; //quaternion to assign the player's rotation
	Transform playerTrans; 
	public int invert = 1; //value to toggle inverse/normal camera movement
	public GameObject player;
//	Rigidbody playerRB;
	public float smoothSpeed = 0.125f;
    public Vector3 offset;
//	float ySensitivity = 0.5f;

	private Vector3 velocity = Vector3.one;

	public Transform mainCamTrans;
	public variableTracker varTrack;
	public bool lookingDown = false;
	public bool useMouse = true;
	// Use this for initialization
	void Start () {
        //offset = transform.position - player.transform.position;
		playerTrans = player.GetComponent<Transform>();
		varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
	}


	
	// Update is called once per frame
	void FixedUpdate () {

		if (varTrack.controller)
			sensitivity = 7;
		else
			sensitivity = 1;

		FollowPlayer ();

		if (useMouse) {
			//Takes input from the mouse and gives it a speed
			mouseX += Input.GetAxis ("Mouse X") * sensitivity; //* 0.02f;
			mouseY -= Input.GetAxis ("Mouse Y") * sensitivity; //* 0.02f;
			
			//gives the y camera movement a maximum/minimum movement range
			mouseY = Mathf.Clamp (mouseY, -rangeY, rangeY);

		}
		transform.rotation = Quaternion.Euler (mouseY,mouseX,0);
	
		// allows toggling between inverted/normal camera controls 
		if (Input.GetButtonDown ("Invert")) {
			invert = -1*invert;
		}

		//allows angle to be negative, which stops you from shooting yourself upwards when aiming up
		float angle = transform.localEulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;

		if (angle > 45f) {
			lookingDown = true;
		} else
			lookingDown = false;
	}



	void FollowPlayer(){

		Vector3 desiredPos = playerTrans.position;
	
		Vector3 smoothedPos = Vector3.SmoothDamp (transform.position, desiredPos, ref velocity, smoothSpeed);
		transform.position = smoothedPos;

	}
}
