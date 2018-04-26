using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {


	public Transform playerTrans;
	float speed = 30f;
	float turnSpeed = 300f;
	public GameObject expload;
	// Update is called once per frame
	void Update () {
		Quaternion neededRot = Quaternion.LookRotation (playerTrans.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, neededRot, Time.deltaTime * turnSpeed);

		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			expload.SetActive (true);
			Destroy (this.gameObject);
		}
	}
}
