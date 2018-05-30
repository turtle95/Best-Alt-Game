using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	public Transform planetTrans;
	public float speed = 120f;
	float turnSpeed = 300f;
	public GameObject expload;

	public int health = 10;
	public Animator damageAnim;

	public GameObject warning;
	public Animator worldAnim;


    PGrowthStage3 gScript;
    variableTracker varTrack;
    ParticleSystem growPart;

    void Start(){
		warning = GameObject.Find ("MeteorWarning");
		worldAnim = GameObject.Find ("PlanetShards").GetComponent<Animator>();
		planetTrans = GameObject.Find ("PlanetShards").GetComponent<Transform>();
        gScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PGrowthStage3>();
        varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
        growPart = GameObject.Find("GrowParticles").GetComponent<ParticleSystem>();
    }

	// Update is called once per frame
	void Update () {
		Quaternion neededRot = Quaternion.LookRotation (planetTrans.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, neededRot, Time.deltaTime * turnSpeed);

		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	
		if (health <= 0) {
            gScript.testVar += 1;
            gScript.Grow();
            varTrack.EnemiesKilled += 1;
            growPart.Play();
            Instantiate (expload, transform.position, transform.rotation);
			//expload.SetActive (true);
			//expload.transform.position = transform.position;
			if(warning = GameObject.Find ("MeteorWarning"))
				warning.SetActive (false);
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		//if (col.gameObject.CompareTag ("Player")) {
		//	damageAnim.SetTrigger ("TakeDamage");
		//	health = 0;

		//}

		if (col.gameObject.CompareTag ("Rock")) {
			damageAnim.SetTrigger ("TakeDamage");
			health--;
		}

		if (col.gameObject.CompareTag ("Destructible")) {
			Destroy (col.gameObject);
		}

		if(col.gameObject.CompareTag("World")){
			worldAnim.SetTrigger("TakeDamage");
		}
	}
}
