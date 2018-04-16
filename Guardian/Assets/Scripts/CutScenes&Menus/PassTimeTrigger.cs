using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTimeTrigger : MonoBehaviour {

	public GameObject fader;
	public GameObject[] turnOn;
	public GameObject[] turnOff;
	public GameObject[] turnOn2;
	public GameObject[] turnOff2;
	public PlayerMovement001 pScript;
	public FireRocks rScript;
	public BoxCollider myCol;

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			myCol.enabled = false;
			StartCoroutine (WaitForFade());
		}
	}

	IEnumerator WaitForFade()
	{
		fader.SetActive (true);
		yield return new WaitForSeconds (2);
		for (int i = 0; i < turnOn.Length; i++) {
			turnOn [i].SetActive (true);
		}
		for (int j = 0; j < turnOff.Length; j++) {
			turnOff [j].SetActive (false);
		}
		pScript.rb.velocity = Vector3.zero;
		pScript.enabled = false;

		yield return new WaitForSeconds (2);
		for (int i = 0; i < turnOn2.Length; i++) {
			turnOn2 [i].SetActive (true);
		}
		for (int j = 0; j < turnOff2.Length; j++) {
			turnOff2 [j].SetActive (false);
		}
		rScript.enabled = true;
	}

}
