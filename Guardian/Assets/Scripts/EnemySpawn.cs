using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public Transform [] points; //array of spawnpoints
	public GameObject enemy; //enemy prefab to spawn


	void Start () //starts the spawn coroutine 
	{
		StartCoroutine (SpawnStuffs ());

		//used to fill the map with enemies at the start but we probably don't want that to happen right away
		//for (int i = 0; i < points.Length; i++) {
		//	Instantiate (enemy, points [i].position, points [i].rotation);
		//}
	}
	
	//waits a second, then chooses a random spawnpoint and spawns an enemy there, after that it calls itself again
	IEnumerator SpawnStuffs(){
		yield return new WaitForSeconds (1f);
		int j = Random.Range (0, points.Length);
		Instantiate (enemy, points [j].position, points [j].rotation);
		StartCoroutine (SpawnStuffs ());
	}
}
