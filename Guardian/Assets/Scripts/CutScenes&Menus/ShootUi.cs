using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootUi : MonoBehaviour {

	public GameObject[] turnOn;

	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1"))
		{
			for (int i =0; i < turnOn.Length; i++)
				turnOn [i].SetActive (true);
			Destroy (this.gameObject);
		}


	}
}
