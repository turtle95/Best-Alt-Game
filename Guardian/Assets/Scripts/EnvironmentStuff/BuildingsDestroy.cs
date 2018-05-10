using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsDestroy : MonoBehaviour {

	public variableTracker varTrack;
	public GameObject deathFloaty;
	public GameObject RopeDest;
	AudioSource audManager;
	public AudioClip destDeath;


	// Use this for initialization
	void Start () {
		varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
		audManager = GetComponent<AudioSource> ();
	}



	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Rock" && varTrack.EnemiesKilled > 20)
		{
			varTrack.ObjectsDestroyed += 1;
			Instantiate (deathFloaty, transform.position, transform.rotation);
			audManager.PlayOneShot(destDeath);

			GetComponent<MeshRenderer> ().enabled = false;
		//	BoxCollider boxCol = gameObject.GetComponent<BoxCollider> ();
		//	if (!(boxCol == null)) {
		//		boxCol.enabled = false;
		//	}

			GetComponent<MeshCollider> ().enabled = false;
			//if (!(boxCol == null)) {
				//meshCol.enabled = false;
		//	}
			if (RopeDest != null)
				Destroy (RopeDest);
			StartCoroutine (waitForSound ());
		}
	}

	IEnumerator waitForSound(){
		yield return new WaitForSeconds (3);
		Destroy(this.gameObject);
	}
}
