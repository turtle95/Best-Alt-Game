﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUi : MonoBehaviour {

	public GameObject[] turnOn;
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Jump"))
		 {
			for (int i =0; i < turnOn.Length; i++)
				turnOn [i].SetActive (true);
			Destroy (this.gameObject);
		}
		

	}
}
