using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStuff : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	public void ShootOff(float force){
		rb.AddForce (transform.forward * force);
	}
}
