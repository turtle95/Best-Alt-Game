using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	GameObject [] points; //array of spawnpoints
	public GameObject enemy; //enemy prefab to spawn
	GameObject [] spawnedEnemys; //array to store where all the enemies in the scene are
    public List<int> Epoints = new List<int>();
	public int enemyCap = 10;
	public float spawnTime = 3f;

	void Start () //starts the spawn coroutine 
	{
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
	
	//waits a second, then chooses a random spawnpoint and spawns an enemy there, after that it calls itself again
	IEnumerator SpawnStuffs()
	{
		yield return new WaitForSeconds (spawnTime);
		spawnedEnemys = GameObject.FindGameObjectsWithTag ("Enemy");

		if (spawnedEnemys.Length < enemyCap) 
		{
			int j = Random.Range (0, points.Length);
            if(Epoints[j] == -1){

            //bool doAgain;
                //do
                //{
                //    doAgain = false;
                //    for (int i = 0; i < spawnedEnemys.Length; i++)
                //    {
                //        if (Vector3.Distance(points[j].transform.position, spawnedEnemys[i].transform.position) < 1)
                //        {
                            
                //            j = Random.Range(0, points.Length);

                //            doAgain = true;
                //            i = spawnedEnemys.Length;
                //        }
                //    }
                //} while (doAgain);

                Instantiate(enemy, points[j].transform.position, points[j].transform.rotation);
                Epoints[j] = 1;
            }
            StartCoroutine(SpawnStuffs());
		}

		
	}


}
