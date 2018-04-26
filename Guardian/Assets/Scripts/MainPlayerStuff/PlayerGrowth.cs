using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrowth : MonoBehaviour {

	//public variableTracker varTrack;
	public PlayerMovement001 pScript;
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
	Vector3 startSize;
	public Vector3 shrinkSize =new Vector3(1,1,1);

	// Use this for initialization
	void Start () {
	//	varTrack = GameObject.Find ("variableTracker").GetComponent<variableTracker> ();
		walkTemp = pScript.walkSpeed;
		dashTemp = pScript.dashDistance;
		grndTemp = pScript.distToGrounded;
		fallTemp = pScript.distToFall;
		rockTemp = rScript.rockSize;
		launchSpTemp = rScript.launchSpeed;
		startSize = gameObject.transform.localScale;
	}

	void Update(){
		//if(Input.GetButtonDown("Jump")){
			//testVar += 1;
		//	Grow();
	//	}
	}

	// Update is called once per frame
	public void Grow () {
		gameObject.transform.localScale += startSize * testVar * upScale;
		camBox.transform.localScale += startSize * testVar * upScale;
		pScript.walkSpeed +=walkTemp * testVar * upScale;
		pScript.dashDistance +=dashTemp * testVar * upScale;
		pScript.distToGrounded +=grndTemp * testVar * upScale;
		pScript.distToFall +=fallTemp * testVar * upScale;
		rScript.rockSize +=rockTemp * testVar * upScale;
		rScript.launchSpeed += launchSpTemp * testVar * upScale;
		pScript.refWalkSpeed += walkTemp * testVar * upScale;
		float tempSize = 1/transform.localScale.x;
		shrinkSize = new Vector3(tempSize, tempSize, tempSize);
	}
}
