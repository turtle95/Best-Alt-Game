using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {


	public Image healthBar;

	variableTracker varTrack;
	// Use this for initialization
	void Start () {
		
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();

	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = varTrack.PlayerHP / 100;

		if (varTrack.PlayerHP <= 0) {
			varTrack.ResetVars ();
			SceneManager.LoadScene (0);
		}
	}

	void OnTriggerStay(Collider col){
		if (col.CompareTag ("Fog")) {
			varTrack.PlayerHP -= 4f * Time.deltaTime;
			Debug.Log (varTrack.PlayerHP);
		}
	}
}
