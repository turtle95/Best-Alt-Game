using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTopDown : MonoBehaviour {
	
	Quaternion localRotPlayer; //quaternion to assign the player's rotation
	Transform playerTrans; 
	public int invert = 1; //value to toggle inverse/normal camera movement
	public GameObject player;
	Rigidbody playerRB;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	float ySensitivity = 0.5f;

	private Vector3 velocity = Vector3.one;

	public Transform mainCamTrans;
	// Use this for initialization
	void Start () {
		//offset = transform.position - player.transform.position;
		playerTrans = player.GetComponent<Transform>();
		playerRB = player.GetComponent<Rigidbody> ();
	}



	// Update is called once per frame
	void FixedUpdate () {
		FollowPlayer ();

	}



	void FollowPlayer(){

		Vector3 desiredPos = playerTrans.position;

		Vector3 smoothedPos = Vector3.SmoothDamp (transform.position, desiredPos, ref velocity, smoothSpeed);
		transform.position = smoothedPos;

	}
}
