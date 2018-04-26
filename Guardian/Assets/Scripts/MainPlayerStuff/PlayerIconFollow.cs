using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconFollow : MonoBehaviour {

	public Transform playerTrans;


	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, playerTrans.eulerAngles.y));
		 // new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, playerTrans.localEulerAngles.y);
	}
}
