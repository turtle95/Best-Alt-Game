using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public Transform [] points;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnStuffs ());
		for (int i = 0; i < points.Length; i++) {
			Instantiate (enemy, points [i].position, points [i].rotation);
		}
	}
	

	IEnumerator SpawnStuffs(){
		yield return new WaitForSeconds (1f);
		int j = Random.Range (0, points.Length);
		Instantiate (enemy, points [j].position, points [j].rotation);
		StartCoroutine (SpawnStuffs ());
	}
}
