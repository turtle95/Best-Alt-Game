using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillTest : MonoBehaviour {


	PlayerGrowth gScript;

	void Start(){
		gScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerGrowth> ();
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Rock")) {
				//Destroy (this.gameObject);
				Debug.Log ("Hit!");
				//gScript.testVar += 1;
				//gScript.Grow ();
			Destroy (this.gameObject);
		}
	}
}
