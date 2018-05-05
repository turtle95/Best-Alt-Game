using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DashGhost : MonoBehaviour {

	public NavMeshAgent navi;
	private int destination = 0;
	public Transform [] waypoints;

	int prevDest =0;
	int currDest = 0;



	public AudioSource audManager;
	public AudioClip dashSound;


	public float dashDistance = 10;
	public float walkSpeed = 3;
	public ParticleSystem dashParticles;
	public ParticleSystem dashParticles2;

	// Use this for initialization
	void Start () {
		audManager = gameObject.GetComponent<AudioSource> ();
		StartCoroutine (Dash ());
	}


	void SetDestinations()
	{
		if (waypoints.Length == 0)
			return;

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
		if (!navi.pathPending && navi.remainingDistance < 0.5f)
			SetDestinations ();

		//lets you dash, doesn't effect y movement value though
		if (Input.GetButtonDown ("Jump")) {
			
		}

	}

	IEnumerator Dash(){
		audManager.PlayOneShot(dashSound);
		navi.speed = dashDistance;
		dashParticles.Play ();
		dashParticles2.Play ();
		yield return new WaitForSeconds (0.50f);
		navi.speed = walkSpeed;
		float dashTime = Random.Range (0, 1f);
		yield return new WaitForSeconds (dashTime);
		StartCoroutine (Dash ());
	}
}
