using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class cameraTransition : MonoBehaviour {


    public GameObject target;
	public GameObject fader;
	public bool shaking = false;
	public CameraShake shakeScript;
    public variableTracker varTrack;

	void Awake(){
		shaking = false;
	}

	void Update(){
		if(shaking)
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 5f * Time.deltaTime);
	}

	// Update is called once per frame
	public IEnumerator PlayTransition (int sceneToLoad, float duration) 
	{
		
		fader.SetActive (true);
		if (!(sceneToLoad == 4)) {
			shaking = true;
			StartCoroutine (shakeScript.Shake (duration + 3, 0.1f));
		}
		yield return new WaitForSeconds (duration);
		shaking = false;
		SceneManager.LoadScene (sceneToLoad);
        varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
        varTrack.PlayerHP = 100;


	}
		
}
