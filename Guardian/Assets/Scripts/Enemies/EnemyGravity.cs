using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGravity : MonoBehaviour {



	// Rotates the enemy to stand on the planet
	void Start ()
	{
		GameObject planet = GameObject.FindGameObjectWithTag ("Planet");

		Vector3 gravityUp = (transform.position - planet.transform.position).normalized;

		transform.rotation = Quaternion.FromToRotation (transform.up, gravityUp) * transform.rotation;
	}

}
