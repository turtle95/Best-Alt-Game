using System;
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
	public int enemiesToProgress = 70;
	float spawnTime = 4f;
	public variableTracker varTrack;
	public int[] lowerSpawnTime;
	public float [] growthRates;
	float growthRate = 0.002f;
	GameObject enemySpawnedNow;
	public int prevEnCap = 0;

	public Image killedUi;

	public int amountOfEnemies = 0;

	public bool spawn = true;
	void Start () //starts the spawn coroutine 
	{
		varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
		//StartCoroutine (SpawnStuffs (amountOfEnemies));
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
		//Debug.Log (amountOfEnemies);
		//increases the enemy spawn rate based on how many enemies have been killed
		if (varTrack.EnemiesKilled > lowerSpawnTime [0]) 
		{
			growthRate = growthRates[0];
			spawnTime = 2f;
			if (varTrack.EnemiesKilled > lowerSpawnTime [1]) 
			{
				growthRate = growthRates[1];
				spawnTime = 1f;
				if (varTrack.EnemiesKilled > lowerSpawnTime [2])
				{
					growthRate = growthRates[2];
					spawnTime = 0.3f;
				}
			}
		}

		float enemiesKilledUi = varTrack.EnemiesKilled - prevEnCap;
		killedUi.fillAmount = enemiesKilledUi / (enemiesToProgress - prevEnCap);  
		if (spawn) {
			spawn = false;
			StartCoroutine (SpawnStuffs (amountOfEnemies));
		}
	//	Debug.Log (enemiesKilledUi / (enemyCap - prevEnCap));
	}
	
	//waits a second, then chooses a random spawnpoint and spawns an enemy there, after that it calls itself again
	IEnumerator SpawnStuffs(int spawnedEnemies)
	{
		yield return new WaitForSeconds (spawnTime);

//		Debug.Log ("In Enumerator " + amountOfEnemies);


		if (spawnedEnemies < enemyCap) 
		{
			int j = UnityEngine.Random.Range (0, points.Length);
			if(Epoints[j] == -1){

				enemySpawnedNow = Instantiate(enemy, points[j].transform.position, points[j].transform.rotation);
				amountOfEnemies += 1;
				if(!(varTrack.CurrentStage == 3))
					enemySpawnedNow.GetComponent<EnemyScript> ().upScale = growthRate;
				else
					enemySpawnedNow.GetComponent<EnemyScriptStage3> ().upScale = growthRate;
                Epoints[j] = 1;
            }

		}
		spawn = true;
		
	}


}
