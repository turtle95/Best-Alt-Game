using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineBorderTrigger : MonoBehaviour {

	public MeshRenderer sheild;

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			sheild.enabled = true;
			Destroy (this.gameObject);
		}

	}
}
