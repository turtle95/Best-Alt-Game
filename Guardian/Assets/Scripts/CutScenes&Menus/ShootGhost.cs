using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootGhost : MonoBehaviour {

	public NavMeshAgent navi;
	private int destination = 0;
	public Transform [] waypoints;

	int prevDest =0;
	int currDest = 0;



	public AudioSource audManager;
	public AudioClip dashSound;


	public GameObject bullet;
	GameObject rockUsedHere;

	Rigidbody rb; 
	public float launchSpeed = 100; 


	// Use this for initialization
	void Start () {
		audManager = gameObject.GetComponent<AudioSource> ();
		//StartCoroutine (Dash ());
	}


	void SetDestinations()
	{
		if (waypoints.Length == 0)
			return;
		Shoot ();
		navi.destination = waypoints [destination].position;

		destination = Random.Range (0, waypoints.Length);
		while (destination == prevDest || destination == currDest) {
			destination = Random.Range (0, waypoints.Length);
		}

		prevDest = currDest;
		currDest = destination;
	}


	// Update is called once per frame
	void Update () {
		if (!navi.pathPending && navi.remainingDistance < 7f)
			SetDestinations ();



	}

	void Shoot(){
		audManager.PlayOneShot(dashSound);
		rockUsedHere = Instantiate (bullet, transform.position, transform.rotation);
		rb = rockUsedHere.GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * launchSpeed;
	}
}
