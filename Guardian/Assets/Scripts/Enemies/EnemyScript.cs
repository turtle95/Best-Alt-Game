using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public EnemySpawn sScript;
    public variableTracker varTrack;
    public GameObject fogObject;
	public float upScale = 0.005f;
	public float maxFogSize = 0.05f;
	PlayerGrowth gScript;
    public AudioSource audManager;
    public AudioClip spiritDeath;
	public SkinnedMeshRenderer spiritVisisbility;

	void Start(){
		gScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerGrowth> ();
		varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
		sScript = GameObject.Find ("Enemy Spawner").GetComponent<EnemySpawn>();
	}
	//kills the enemy when a rock hits it
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Rock")) {
			//Debug.Log ("Hit!");
			sScript.amountOfEnemies -= 1;
			gScript.testVar += 1;
			gScript.Grow ();
            audManager.PlayOneShot(spiritDeath);
			varTrack.EnemiesKilled += 1;
			gameObject.GetComponent<MeshCollider> ().enabled = false;
			spiritVisisbility.enabled = false;
			Destroy (fogObject);
			StartCoroutine (waitForSound ());
		}
	}

    void Update()
    {
		if(fogObject.transform.localScale.x < maxFogSize)
        	fogObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * upScale;
		//new ParticleSystem.MinMaxCurve (1 + 1* Time.deltaTime, 1.1f +1* Time.deltaTime);
		//fogObject.GetComponent<ParticleSystem> ().main.startSize = ;
    }


	IEnumerator waitForSound(){
		yield return new WaitForSeconds (3);
		Destroy(this.gameObject);
	}
}
