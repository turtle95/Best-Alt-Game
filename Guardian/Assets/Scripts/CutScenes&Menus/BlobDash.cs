using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobDash : MonoBehaviour {


	public ParticleSystem dash1;
	public ParticleSystem dash2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			dash1.Play ();
			dash2.Play ();
		}
	}
}
