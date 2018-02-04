using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Rock"))
			Destroy (this.gameObject);
	}
}
