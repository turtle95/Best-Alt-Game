using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2AnimController : MonoBehaviour {

	public Animator playerAnim;
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetAxis ("Horizontal") == 0) && (Input.GetAxis ("Vertical") == 0))
			playerAnim.SetBool ("Running", false);
		else
			playerAnim.SetBool ("Running", true);
	}
}
