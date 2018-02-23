using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public variableTracker varTrack;
    public GameObject fogObject;

	//kills the enemy when a rock hits it
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Rock")) {
			varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
			varTrack.EnemiesKilled += 1;
			Destroy (this.gameObject);
		}
	}

    void Update()
    {
        fogObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime;
		//new ParticleSystem.MinMaxCurve (1 + 1* Time.deltaTime, 1.1f +1* Time.deltaTime);
		//fogObject.GetComponent<ParticleSystem> ().main.startSize = ;
    }
}
