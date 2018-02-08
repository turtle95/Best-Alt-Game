using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public variableTracker varTrack;

	//kills the enemy when a rock hits it
	void OnCollisionEnter(Collision col){
        if (col.gameObject.CompareTag("Rock"))
            varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
            varTrack.EnemiesKilled += 1;
			Destroy (this.gameObject);
	}
}
