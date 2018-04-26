using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineBorderTrigger : MonoBehaviour {

	public GameObject [] turnON;
	public GameObject [] turnOff;

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			for (int i = 0; i < turnON.Length; i++) {
				turnON [i].SetActive (true);
			}
			for (int j = 0; j < turnOff.Length; j++) {
				turnOff [j].SetActive (false);
			}
			Destroy (this.gameObject);
		}

	}
}
