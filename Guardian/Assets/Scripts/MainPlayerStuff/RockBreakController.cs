using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreakController : MonoBehaviour {

	public GameObject rockPieces;
	GameObject rockPiecesSized;
	public float rockSize = 1;
    public AudioSource audManager;
    public AudioClip rockCollision;
    public AudioClip rockExplode;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Destructible") || col.gameObject.CompareTag ("Enemy")) {
            audManager.PlayOneShot(rockExplode);
			rockPiecesSized = Instantiate (rockPieces, transform.position, transform.rotation);
			rockPiecesSized.transform.localScale *= rockSize;
			Destroy (this.gameObject);
		}
        else
        {
            audManager.PlayOneShot(rockCollision);
        }

	}
}
