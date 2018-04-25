using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptStage3 : MonoBehaviour {

	public variableTracker varTrack;
	public GameObject fogObject;
	public float upScale = 0.005f;
	public float maxFogSize = 0.05f;
	PGrowthStage3 gScript;
    public AudioSource audManager;
    public AudioClip spiritDeath;

	void Start(){
		gScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PGrowthStage3> ();
		varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
	}
	//kills the enemy when a rock hits it
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Rock")) {
			//Debug.Log ("Hit!");
			gScript.testVar += 1;
			gScript.Grow ();
            audManager.PlayOneShot(spiritDeath);
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
