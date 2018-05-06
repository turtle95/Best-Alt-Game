using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemy : MonoBehaviour {
	public Color fColor;
	public variableTracker varTrack;
	//public GameObject fogObject;
//	float upScale = 0.005f;
	//public PlayerMovement001 pScript;
	public GameObject eSpawn;
	public GameObject cutSceneStuffs;

	public GameObject creepySounds;
	public GameObject enemyDeath;
	public Animator uiAnim;
	public GameObject fogBlowAway;
	public GameObject uiStuffs;
	//public Animator shrineAnim;
	//kills the enemy when a rock hits it
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Rock")) {
			varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
			varTrack.EnemiesKilled += 1;
			uiStuffs.SetActive (true);
			uiAnim.Play ("GlowAnim");
			//pScript.enabled = true;
			RenderSettings.fogDensity = 0.02f;
			RenderSettings.fogColor = fColor;
			Camera.main.clearFlags = CameraClearFlags.Skybox;
			eSpawn.SetActive (true);
			enemyDeath.SetActive (true);
			fogBlowAway.SetActive (true);

			Destroy (creepySounds);
			Destroy (cutSceneStuffs);
		}
	}

	void Update()
	{
		//fogObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * upScale;
	}
}
