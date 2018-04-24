using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3CamLook : MonoBehaviour {

	public float sensitivity = 0.125f; //sensitivity of mouse when moving the camera
	public float rangeY = 100f; //movement range for y mouse look
	public float mouseX =0;
	public float mouseY = 0; //values for mouse input


 
	public int invert = 0; //value to toggle inverse/normal camera movement

	public Transform camDown;
	public Transform mainCam;

	public bool lookingDown = false;

	void Start(){
		transform.rotation = camDown.rotation;

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		//Takes input from the mouse and gives it a speed

		mouseX += Input.GetAxis ("Mouse X") * sensitivity;// * camDown.rotation;
		mouseY += Input.GetAxis ("Mouse Y") * sensitivity;// * camDown.rotation;

//		Quaternion xQ = Quaternion.AngleAxis (mouseX, camDown.right);
//		Quaternion yQ = Quaternion.AngleAxis (mouseY, camDown.up);
//		Vector3 LookStuffs = new Vector3(mouseY, mouseX, 0);

		mouseY = Mathf.Clamp (mouseY, -rangeY, rangeY);
		//gives the y camera movement a maximum/minimum movement range



		//transform.rotation = Quaternion.Euler (LookStuffs);
		transform.rotation = camDown.rotation * Quaternion.Euler (-mouseY,mouseX,0);

		float angle = transform.localEulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;

		if (angle > 45f) {
			lookingDown = true;
		} else
			lookingDown = false;

	
		// allows toggling between inverted/normal camera controls 
		if (Input.GetButtonDown ("Invert")) {
			invert = -1*invert;
		}
	}
}
