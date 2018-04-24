using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour {

	GameObject [] points; //array of spawnpoints
	public GameObject enemy; //enemy prefab to spawn
	// GameObject [] spawnedEnemys; //array to store where all the enemies in the scene are
    public List<int> Epoints = new List<int>();
	public int enemyCap = 10;
	float spawnTime = 4f;
	public variableTracker varTrack;
	public int[] lowerSpawnTime;
	float growthRate = 0.002f;
	GameObject enemySpawnedNow;
	public int prevEnCap = 0;

	public Image killedUi;


	void Start () //starts the spawn coroutine 
	{
		varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
		StartCoroutine (SpawnStuffs ());
		points = GameObject.FindGameObjectsWithTag ("EnemySpawner");

        for (int n = 0; n < points.Length; n++){
            Epoints.Add(-1);
        }
		//used to fill the map with enemies at the start but we probably don't want that to happen right away
		//for (int i = 0; i < points.Length; i++) {
		//	Instantiate (enemy, points [i].position, points [i].rotation);
		//}
	}

	void Update(){

		//increases the enemy spawn rate based on how many enemies have been killed
		if (varTrack.EnemiesKilled > lowerSpawnTime [0]) 
		{
			growthRate = 0.004f;
			spawnTime = 2f;
			if (varTrack.EnemiesKilled > lowerSpawnTime [1]) 
			{
				growthRate = 0.007f;
				spawnTime = 1f;
				if (varTrack.EnemiesKilled > lowerSpawnTime [2])
				{
					growthRate = 0.012f;
					spawnTime = 0.5f;
				}
			}
		}

		float enemiesKilledUi = varTrack.EnemiesKilled - prevEnCap;
		killedUi.fillAmount = enemiesKilledUi / (enemyCap - prevEnCap);  
	//	Debug.Log (enemiesKilledUi / (enemyCap - prevEnCap));
	}
	
	//waits a second, then chooses a random spawnpoint and spawns an enemy there, after that it calls itself again
	IEnumerator SpawnStuffs()
	{
		yield return new WaitForSeconds (spawnTime);

		GameObject [] spawnedEnemys = GameObject.FindGameObjectsWithTag ("Enemy");

		if (spawnedEnemys.Length < enemyCap) 
		{
			int j = Random.Range (0, points.Length);
			if(Epoints[j] == -1){

				enemySpawnedNow = Instantiate(enemy, points[j].transform.position, points[j].transform.rotation);
				if(!(varTrack.CurrentStage == 3))
					enemySpawnedNow.GetComponent<EnemyScript> ().upScale = growthRate;
				else
					enemySpawnedNow.GetComponent<EnemyScriptStage3> ().upScale = growthRate;
                Epoints[j] = 1;
            }
            StartCoroutine(SpawnStuffs());
		}

		
	}


}
