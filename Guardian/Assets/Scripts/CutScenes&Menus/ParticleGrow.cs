using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGrow : MonoBehaviour {

	public float upScale = 0.005f;
	
	// Update is called once per frame
	void Update () {
		
			transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * upScale;
	}
}
