using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAimerSetPos : MonoBehaviour {

	public Transform playerTrans;

	// Update is called once per frame
	void Update () {
		transform.position = playerTrans.position;
	}
}
