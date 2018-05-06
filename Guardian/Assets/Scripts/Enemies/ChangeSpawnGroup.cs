using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpawnGroup : MonoBehaviour {
    public GameObject group1;
    public GameObject group2;
    public variableTracker varTrack;


	// Use this for initialization
	void Start () {
        varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();

		
	}
	
	// Update is called once per frame
	void Update () {
        if (varTrack.EnemiesKilled == 15)
        {
            group1.SetActive(false);
            group2.SetActive(true);
        }
	}
}
