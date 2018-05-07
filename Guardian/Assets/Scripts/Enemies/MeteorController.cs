using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

	variableTracker varTrack;

	public Transform [] spawnPoints;
	public GameObject warning;
	public CameraShake shakeScript;

	public GameObject meteor;

	// Use this for initialization
	void Start () {
		varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
		StartCoroutine (SpawnMeteor ());
	}
	


	IEnumerator SpawnMeteor(){
		float timeTillSpawn = Random.Range (10, 30);
		yield return new WaitForSeconds (timeTillSpawn);
		SendMeteor ();

	}

	void SendMeteor(){
		int chosenSpot = Random.Range(0, spawnPoints.Length);
		GameObject currentMeteor = Instantiate (meteor, spawnPoints [chosenSpot].position, spawnPoints [chosenSpot].rotation);
		int sizeScale = Random.Range (10, 100);
		if (varTrack.EnemiesKilled > 64)
			sizeScale = 300;
		currentMeteor.transform.localScale = new Vector3 (sizeScale, sizeScale, sizeScale);
		currentMeteor.GetComponent<Meteor> ().health = sizeScale / 20;
		warning.SetActive (true);
		StartCoroutine (shakeScript.Shake (2,0.2f));
		StartCoroutine (SpawnMeteor ());
	}
}
