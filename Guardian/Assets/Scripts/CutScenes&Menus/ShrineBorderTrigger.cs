using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineBorderTrigger : MonoBehaviour {

	public GameObject [] turnON;
	public GameObject [] turnOff;

	public GameObject [] turnON2;
	public GameObject [] turnOff2;

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			for (int i = 0; i < turnON.Length; i++) {
				turnON [i].SetActive (true);
			}
			for (int j = 0; j < turnOff.Length; j++) {
				turnOff [j].SetActive (false);
			}
			StartCoroutine (ShowInfection ());
		}

	}

	IEnumerator ShowInfection(){
		yield return new WaitForSeconds (2);

			for (int i = 0; i < turnON2.Length; i++) {
				turnON2 [i].SetActive (true);
			}
			for (int j = 0; j < turnOff2.Length; j++) {
				turnOff2 [j].SetActive (false);
			}
		Destroy (this.gameObject);
	}
}
