using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksGravity : MonoBehaviour {

	PlanetGravity pScript;
	public Transform downLooker;
	public float gravity = -10;

	void Start(){
		pScript = GameObject.FindGameObjectWithTag ("Planet").GetComponent<PlanetGravity>();
	}

	// Update is called once per frame
	void Update () {
		//uses the planet's gravity function to calculate the rock's gravity
		pScript.Attract (transform, downLooker);
	}

}
