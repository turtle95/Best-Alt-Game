using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleGrav : MonoBehaviour {

	public float gravity = -10;
	public Transform downLooker;
	PlanetGravity pScript;

	public float distToGrounded = 0.5f; //the distance from player's origin to the ground when grounded

	void Start(){
		GameObject planet = GameObject.FindGameObjectWithTag ("Planet");
		pScript = planet.GetComponent<PlanetGravity> ();
		Vector3 gravityUp = (transform.position - planet.transform.position).normalized;

		transform.rotation = Quaternion.FromToRotation (transform.up, gravityUp) * transform.rotation;
	}

	void Update(){
		if (!Grounded ())
			pScript.Attract (transform, downLooker);
	}

	bool Grounded(){
		return Physics.Raycast (transform.position, Vector3.down, distToGrounded);
	}
}
