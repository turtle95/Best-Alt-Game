using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRocks : MonoBehaviour {

	public GameObject rock;
	 GameObject rockUsedHere;
	public Transform spawnPoint;
	//RockStuff rScript;
	Rigidbody rb;
	public float launchSpeed = 200;
	public float initialCharge = 100;
	public float chargeSpeed = 200;
	float chargedLaunch = 0;
	// Use this for initialization
	void Start () {
		chargedLaunch = initialCharge;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			rockUsedHere = Instantiate (rock, spawnPoint.position, spawnPoint.rotation);
			rb = rockUsedHere.GetComponent<Rigidbody> ();
			rb.velocity = spawnPoint.forward * launchSpeed;

		}
		if (Input.GetButtonDown ("Fire2")) {
			rockUsedHere = Instantiate (rock, spawnPoint.position, spawnPoint.rotation);
			rb = rockUsedHere.GetComponent<Rigidbody> ();
			rb.useGravity = false;
			chargedLaunch += chargeSpeed * Time.deltaTime;
		}
		if (Input.GetButton ("Fire2")) {
			chargedLaunch += chargeSpeed * Time.deltaTime;
			rockUsedHere.transform.localScale += new Vector3(1 * Time.deltaTime,1 * Time.deltaTime,1 * Time.deltaTime);
			rockUsedHere.transform.position = spawnPoint.position;
		}
		if (Input.GetButtonUp ("Fire2")) {
			rb.useGravity = true;
			rb.velocity = spawnPoint.forward * chargedLaunch;
			chargedLaunch = initialCharge;
		}
	}
}
