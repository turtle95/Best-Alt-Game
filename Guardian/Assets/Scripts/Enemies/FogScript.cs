﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FogScript : MonoBehaviour {

    //public variableTracker varTrack;
    // Use this for initialization
    public Scene scene;
	void Start () {
        //varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
        scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider collision)
    {
        if (scene.name == "Scene1")
        {
            if (collision.gameObject.tag == "Destructible")
            {
                collision.gameObject.GetComponent<DestructibleScript>().fogged = true;
                collision.gameObject.GetComponent<DestructibleScript>().ChangeColor();
            }
        }
    }
}
