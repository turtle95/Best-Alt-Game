using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpeed : MonoBehaviour {

	public AudioSource musics;
	public int killToIncrease1;
	public int killToIncrease2;
	public float increaseAmount1;
	public float increaseAmount2;

	variableTracker varTrack;

	// Use this for initialization
	void Start () {
		varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
	}
	
	// Update is called once per frame
	void Update () {
		if (varTrack.EnemiesKilled > killToIncrease1 && varTrack.EnemiesKilled < killToIncrease2)
			musics.pitch = increaseAmount1;
		if (varTrack.EnemiesKilled > killToIncrease2)
			musics.pitch = increaseAmount2;
	}
}
