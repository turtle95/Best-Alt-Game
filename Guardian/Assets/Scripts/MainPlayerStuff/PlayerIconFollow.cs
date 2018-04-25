using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconFollow : MonoBehaviour {

	public Transform playerTrans;


	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3 (playerTrans.position.x, transform.position.y, playerTrans.position.z);
		transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, playerTrans.rotation.z);
	}
}
