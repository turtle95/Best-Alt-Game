using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIntro : MonoBehaviour {


	public GameObject [] turnON;
	public GameObject [] turnOff;
	public CameraController cScript;
	public PlayerMovement001 pScript;
	public FireRocks rScript;
	// Use this for initialization
	void Awake () {
		cScript.enabled = false;
		pScript.enabled = false;
		rScript.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump")) {
			for (int i = 0; i < turnON.Length; i++) {
				turnON [i].SetActive (true);
			}
			for (int j = 0; j < turnOff.Length; j++) {
				turnOff [j].SetActive (false);
			}
			cScript.enabled = true;
			cScript.useMouse = false;
			cScript.mouseX = -90;
			cScript.mouseY = 30;
			StartCoroutine (CameraZoomIn ());
			//rScript.enabled = true;
			//RenderSettings.fogDensity = 0.017f;
		}
	}

	IEnumerator CameraZoomIn(){
		yield return new WaitForSeconds (1.5f);
		cScript.useMouse = true;
		cScript.smoothSpeed = 0.125f;
		pScript.enabled = true;
		Destroy (this.gameObject);
	}
}
