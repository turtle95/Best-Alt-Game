using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkMinimapUi : MonoBehaviour {

	public variableTracker varTrack;
	public PlayerGrowth pScript;
	public PGrowthStage3 gScript;
	public float scaleDiv = 2f;
	// Use this for initialization
	void Start () {
		varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(varTrack.CurrentStage == 3)
			transform.localScale = gScript.shrinkSize;
		else
			transform.localScale = pScript.shrinkSize/scaleDiv;
	}
}
