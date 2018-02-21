using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

	public Color dispColor; //a color to make the spawnpoints

	void OnDrawGizmos(){ //draws a box around the spawnpoints when they are viewed through the editor
		Gizmos.color = dispColor;
		Gizmos.DrawCube (transform.position, new Vector3(1,1,1));
	}
}
