using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreakController : MonoBehaviour {

	public GameObject rockPieces;


	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Destructible") || col.gameObject.CompareTag ("Enemy")) {
			Instantiate (rockPieces, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}

	}
}
