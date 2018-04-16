using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrigger : MonoBehaviour {

	public GameObject dashUi;

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			dashUi.SetActive (true);
			Destroy (this.gameObject);
		}
	}
}
