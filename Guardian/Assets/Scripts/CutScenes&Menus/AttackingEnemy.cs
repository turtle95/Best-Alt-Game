using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemy : MonoBehaviour {

	public variableTracker varTrack;
	public GameObject fogObject;
	float upScale = 0.005f;
	public PlayerMovement001 pScript;
	public GameObject eSpawn;
	public GameObject cutSceneStuffs;
	//kills the enemy when a rock hits it
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Rock")) {
			varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
			varTrack.EnemiesKilled += 1;
			pScript.enabled = true;
			eSpawn.SetActive (true);
			Destroy (cutSceneStuffs);
		}
	}

	void Update()
	{
		fogObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * upScale;
	}
}
