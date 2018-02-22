using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutSpawnersOnGrnd : MonoBehaviour {


	public float distToGrounded = 5f; //the distance from player's origin to the ground when grounded

	void Update () 
	{
		if (!Grounded ())
			transform.Translate (new Vector3(0,-1, 0));
	}

	bool Grounded(){
		return Physics.Raycast (transform.position, Vector3.down, distToGrounded);
	}
}
