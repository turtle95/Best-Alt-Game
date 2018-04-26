using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpPlanets : MonoBehaviour {


	public variableTracker varTrack;
	public GameObject expload;



	public int health = 10;
	public Animator damageAnim;

	// Use this for initialization
	void Start () {
		varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
	}

	void Update(){
		if (health <= 0) {
			varTrack.ObjectsDestroyed += 1;
			Instantiate (expload, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Rock")
		{
			damageAnim.SetTrigger ("TakeDamage");
			health--;
		}
	}
}
