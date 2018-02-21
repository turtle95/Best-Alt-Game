using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour {


	// Quits the game when you press escape
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit (); 
		}
	}
}
