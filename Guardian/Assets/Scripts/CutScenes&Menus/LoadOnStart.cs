using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnStart : MonoBehaviour {

	public Text textss;

	// Use this for initialization
	void Start () {
		StartCoroutine (SplashScreen());
	}
	
	IEnumerator SplashScreen(){
		yield return new WaitForSeconds (2);
		textss.text = "You Should be Doing Something.";
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene(1);
	}
}
