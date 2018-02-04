using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float sensitivity = 60f;
	public float rangeY = 30f;
	float mouseX =0;
	float mouseY = 0;
	Quaternion localRot;
	Quaternion localRotPlayer;
	public Transform playerTrans;
	public int invert = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		mouseX += Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
		mouseY += Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;
			
		mouseY = Mathf.Clamp (mouseY, -rangeY, rangeY);
		localRot = Quaternion.Euler (mouseY * invert, 0, 0);
		transform.localRotation = localRot;
		localRotPlayer = Quaternion.Euler (mouseY * invert, mouseX, 0);
		playerTrans.localRotation = localRotPlayer;
		if (Input.GetButtonDown ("Invert")) {
			invert = -1*invert;
		}
	}
}
