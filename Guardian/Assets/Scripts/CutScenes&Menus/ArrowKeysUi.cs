using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeysUi : MonoBehaviour {


	public GameObject[] turnOn;
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));


		if (!(movement.x == 0) || !(movement.z == 0)) {
			for (int i =0; i < turnOn.Length; i++)
				turnOn [i].SetActive (true);
			Destroy (this.gameObject);
		}
	}
}
