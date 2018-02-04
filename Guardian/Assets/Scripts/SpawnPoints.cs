using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

	public Color dispColor;

	void OnDrawGizmos(){
		Gizmos.color = dispColor;
		Gizmos.DrawCube (transform.position, new Vector3(1,1,1));
	}
}
