using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapStage3 : MonoBehaviour {
	
	public Transform playerTrans;



	// Update is called once per frame
	void Update () {

		transform.localPosition = new Vector3 (playerTrans.localPosition.x, transform.localPosition.y, playerTrans.localPosition.z);
		transform.rotation = playerTrans.rotation;
	}
}
