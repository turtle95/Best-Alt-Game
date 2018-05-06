using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFog : MonoBehaviour {

	public GameObject fogStuff;
	public GameObject fogPoof;

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Rock")) 
			{
			fogStuff.SetActive(false);
			fogPoof.SetActive (true);
			StartCoroutine (ReSpawn ());
			}
	}

	IEnumerator ReSpawn()
	{
		yield return new WaitForSeconds (1);
		fogPoof.SetActive (false);
		fogStuff.SetActive (true);
	}
}
