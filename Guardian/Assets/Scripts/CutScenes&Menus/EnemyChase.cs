using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyChase : MonoBehaviour {

	public NavMeshAgent nav;
	public Transform player;
	// Use this for initialization
	void Start () {
		nav = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

		nav.SetDestination(player.position);
	}
}
