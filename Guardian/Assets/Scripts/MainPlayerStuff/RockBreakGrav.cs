using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreakGrav : MonoBehaviour {

	public GameObject [] rockRBs;


	void OnCollisionEnter(Collision col){
		if(col.gameObject.CompareTag("Destructible"))
		{
			for (int i = 0; i < rockRBs.Length; i++) {
				rockRBs [i].GetComponent<Rigidbody>().isKinematic = true;
				rockRBs [i].GetComponent<RocksGravity> ().enabled = true;
				rockRBs [i].GetComponent<Collider> ().enabled = true;
			}
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.GetComponent<Collider> ().enabled = false;
			gameObject.GetComponent<RocksGravity> ().enabled = false;
		}
	}
}
