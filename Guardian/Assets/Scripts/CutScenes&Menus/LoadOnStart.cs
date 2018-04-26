using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnStart : MonoBehaviour {
	public variableTracker vScript;
	public Text textss;
    public Text credits;

	// Use this for initialization
	void Start (){
		StartCoroutine (SplashScreen());
	}
	
	IEnumerator SplashScreen(){
		yield return new WaitForSeconds (2);
        credits.text = "Josh - Project Lead, Programming\nJake - 3D Modelling\nAndrew - Terrain, Audio\nMarissa - Programming, Audio\nTanner - 3D Modelling\nSharon - Programming";
		//textss.text = "You Should be Doing Something.";
		yield return new WaitForSeconds (3);
		vScript.CurrentStage = 1;
		SceneManager.LoadScene(1);
	}
}
