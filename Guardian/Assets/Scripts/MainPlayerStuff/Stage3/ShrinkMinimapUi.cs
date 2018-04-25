using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkMinimapUi : MonoBehaviour {


	public PGrowthStage3 gScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = gScript.shrinkSize;
	}
}
