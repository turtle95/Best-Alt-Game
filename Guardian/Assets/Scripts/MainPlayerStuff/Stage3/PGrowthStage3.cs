using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGrowthStage3 : MonoBehaviour {
	
	//public variableTracker varTrack;
	public Stage3Movement pScript;
	public FireRocks rScript;
	public float upScale = 0.05f;
	public int testVar =1;
	public Transform camBox;

	float walkTemp;
	float dashTemp;
	float grndTemp;
	float fallTemp;
	float rockTemp;
	float launchSpTemp;
	float grav;
	// Use this for initialization
	void Start () {
		//	varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
		walkTemp = pScript.walkSpeed;
		dashTemp = pScript.dashDistance;
		grndTemp = pScript.distToGrounded;
		fallTemp = pScript.distToFall;
		rockTemp = rScript.rockSize;
		launchSpTemp = rScript.launchSpeed;
		grav = pScript.gravity;
	}

	// Update is called once per frame
	public void Grow () {
		gameObject.transform.localScale += new Vector3 (1, 1, 1) * testVar * upScale;
		camBox.transform.localScale += new Vector3 (1, 1, 1) * testVar * upScale;
		pScript.walkSpeed +=walkTemp * testVar * upScale;
		pScript.dashDistance +=dashTemp * testVar * upScale;
		pScript.distToGrounded +=grndTemp * testVar * upScale;
		pScript.distToFall +=fallTemp * testVar * upScale;
		rScript.rockSize +=rockTemp * testVar * upScale;
		rScript.launchSpeed += launchSpTemp * testVar * upScale;
		pScript.gravity += grav * testVar * upScale/2;

	}
}
