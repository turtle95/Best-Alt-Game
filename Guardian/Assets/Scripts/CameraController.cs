﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float sensitivity = 60f; //sensitivity of mouse when moving the camera
	public float rangeY = 30f; //movement range for y mouse look
	float mouseX =0;
	float mouseY = 0; //values for mouse input

	Quaternion localRotPlayer; //quaternion to assign the player's rotation
	public Transform playerTrans; 
	public int invert = 1; //value to toggle inverse/normal camera movement

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Takes input from the mouse and gives it a speed
		mouseX += Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
		mouseY += Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;
			

		//gives the y camera movement a maximum/minimum movement range
		mouseY = Mathf.Clamp (mouseY, -rangeY, rangeY);



		//also creates a rotation quaternion but sets the whole player's rotation equal to it, that way the player rotates left/right with the camera
		localRotPlayer = Quaternion.Euler (mouseY * invert, mouseX, 0);
		playerTrans.localRotation = localRotPlayer;

		// allows toggling between inverted/normal camera controls 
		if (Input.GetButtonDown ("Invert")) {
			invert = -1*invert;
		}
	}
}
