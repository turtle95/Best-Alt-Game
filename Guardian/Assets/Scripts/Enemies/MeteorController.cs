using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

	variableTracker varTrack;

	public GameObject [] meteors;
	public GameObject warning;
	public CameraShake shakeScript;


	bool m1 = false;
	bool m2 = false;
	bool m3 = false;
	bool m4 = false;
	bool m5 = false;
	bool m6 = false;
	bool m7 = false;
	// Use this for initialization
	void Start () {
		varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
	}
	
	// Update is called once per frame
	void Update () {
		if (varTrack.EnemiesKilled == 42 && !(m1)) {
			SendMeteor (0);
			m1 = true;
		}
		if (varTrack.EnemiesKilled == 48 && !(m2)) {
			SendMeteor (1);
			m2 = true;
		}
		if (varTrack.EnemiesKilled == 53 && !(m3)) {
			SendMeteor (2);
			m3 = true;
		}
		if (varTrack.EnemiesKilled == 54 && !(m4)) {
			SendMeteor (3);
			m4 = true;
		}
		if (varTrack.EnemiesKilled == 58 && !(m5)) {
			SendMeteor (4);
			m5 = true;
		}
		if (varTrack.EnemiesKilled == 60 && !(m6)) {
			SendMeteor (5);
			m6 = true;
		}
		if (varTrack.EnemiesKilled == 65 && !(m7)) {
			SendMeteor (6);
			m7 = true;
		}
	}

	void SendMeteor(int meteorToSend){
		meteors [meteorToSend].SetActive (true);
		warning.SetActive (true);
		StartCoroutine (shakeScript.Shake (2,0.2f));
	}
}
