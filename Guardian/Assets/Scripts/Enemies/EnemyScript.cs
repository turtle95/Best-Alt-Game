using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public variableTracker varTrack;
    public GameObject fogObject;
	float upScale = 0.005f;
	public float maxFogSize = 0.05f;
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
		if(fogObject.transform.localScale.x < maxFogSize)
        	fogObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * upScale;
		//new ParticleSystem.MinMaxCurve (1 + 1* Time.deltaTime, 1.1f +1* Time.deltaTime);
		//fogObject.GetComponent<ParticleSystem> ().main.startSize = ;
    }
}
