using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3CamLook : MonoBehaviour {

	public float sensitivity = 0.125f; //sensitivity of mouse when moving the camera
	public float rangeY = 120f; //movement range for y mouse look
	public float mouseX =0;
	public float mouseY = 0; //values for mouse input


 
	public int invert = 1; //value to toggle inverse/normal camera movement

	public Transform camDown;
	public Transform mainCam;

	// Update is called once per frame
	void FixedUpdate () {
		
		//Takes input from the mouse and gives it a speed
		//mouseX += Input.GetAxis ("Mouse X") * sensitivity;
		//mouseY -= Input.GetAxis ("Mouse Y") * sensitivity;
		mouseX = Input.GetAxis ("Mouse X") * sensitivity;
		mouseY = Input.GetAxis ("Mouse Y") * sensitivity;

		Quaternion xQ = Quaternion.AngleAxis (mouseX, camDown.right);
		Quaternion yQ = Quaternion.AngleAxis (mouseY, camDown.up);
		Vector3 LookStuffs = new Vector3(mouseY, mouseX, 0);
		//mouseY = Mathf.Clamp (mouseY, -rangeY, rangeY);
		//LookStuffs = camDown.InverseTransformPoint (LookStuffs);
		//gives the y camera movement a maximum/minimum movement range



		transform.rotation = Quaternion.Euler (LookStuffs);

		//transform.localRotation = transform.localRotation * xQ * yQ;
		//transform.Rotate(Vector3.up, mouseX, Space.Self);
		//transform.Rotate(Vector3.right, mouseY, Space.Self);
		//mainCam.RotateAround (camDown.position, camDown.up, mouseX);
		//mainCam.RotateAround (camDown.position, camDown.right, mouseY);
		// allows toggling between inverted/normal camera controls 
		if (Input.GetButtonDown ("Invert")) {
			invert = -1*invert;
		}
	}
}
