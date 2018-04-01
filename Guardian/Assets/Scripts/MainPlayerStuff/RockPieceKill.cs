using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPieceKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (KillThePieces());
	}
	
	IEnumerator KillThePieces(){
		yield return new WaitForSeconds (3);
		Destroy (this.gameObject);
	}
}
