using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour {

	public GameObject results;
	public GameObject credits;

	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		if (Input.GetButtonDown ("Jump")) {
			credits.SetActive (true);
			results.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
		if(Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene (0);
	}

	IEnumerator DisplayCredits(){
		yield return new WaitForSeconds (5);

	}
}
