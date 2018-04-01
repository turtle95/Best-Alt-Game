using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float sensitivity = 30f; //sensitivity of mouse when moving the camera
	public float rangeY = 30f; //movement range for y mouse look
	public float mouseX =0;
	public float mouseY = 0; //values for mouse input

	Quaternion localRotPlayer; //quaternion to assign the player's rotation
	public Transform playerTrans; 
	public int invert = 1; //value to toggle inverse/normal camera movement

    public GameObject player;
    private Vector3 offset;


	// Use this for initialization
	void Start () {
        //offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//Takes input from the mouse and gives it a speed
		mouseX += Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
		mouseY += Input.GetAxis ("Mouse Y") * -sensitivity * Time.deltaTime;
			

		//gives the y camera movement a maximum/minimum movement range
		//mouseY = Mathf.Clamp (mouseY, -rangeY, rangeY);



		//also creates a rotation quaternion but sets the whole player's rotation
        //equal to it, that way the player rotates left/right with the camera
		//localRotPlayer = Quaternion.Euler (mouseY * invert, mouseX, 0);
		//playerTrans.localRotation = localRotPlayer;

        //transform.position = player.transform.position + offset;

		// allows toggling between inverted/normal camera controls 
		if (Input.GetButtonDown ("Invert")) {
			invert = -1*invert;
		}
	}
}
