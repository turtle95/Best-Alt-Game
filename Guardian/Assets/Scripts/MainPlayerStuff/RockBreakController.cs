using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreakController : MonoBehaviour {

	public GameObject rockPieces;
	GameObject rockPiecesSized;
	public float rockSize = 1;
    public AudioSource audManager;
    public AudioClip rockCollision;

	void OnCollisionEnter(Collision col){
        audManager.PlayOneShot(rockCollision);
		if (col.gameObject.CompareTag ("Destructible") || col.gameObject.CompareTag ("Enemy")) {
			rockPiecesSized = Instantiate (rockPieces, transform.position, transform.rotation);
			rockPiecesSized.transform.localScale *= rockSize;
			Destroy (this.gameObject);
		}

	}
}
