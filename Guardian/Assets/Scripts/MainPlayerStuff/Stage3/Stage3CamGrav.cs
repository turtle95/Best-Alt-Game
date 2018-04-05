using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3CamGrav : MonoBehaviour {

	public float gravity = -10;
	public Transform downLooker;
	GameObject planet;



	Quaternion localRotPlayer; //quaternion to assign the player's rotation
	Transform playerTrans; 
	public int invert = 1; //value to toggle inverse/normal camera movement
	public GameObject player;
	Rigidbody playerRB;
	public float smoothSpeed = 0.125f;


	private Vector3 velocity = Vector3.one;

	//public Transform mainCamTrans;
	//PlanetGravity pScript;

	//public float distToGrounded = 0.5f; //the distance from player's origin to the ground when grounded

	void Start(){
		planet = GameObject.FindGameObjectWithTag ("Planet");
		//pScript = planet.GetComponent<PlanetGravity> ();
		Vector3 gravityUp = (transform.position - planet.transform.position).normalized;

		transform.rotation = Quaternion.FromToRotation (transform.up, gravityUp) * transform.rotation;
		playerTrans = player.GetComponent<Transform>();
		playerRB = player.GetComponent<Rigidbody> ();
	}

	void Update(){
			//pScript.Attract (transform, downLooker);
		Vector3 gravityUp = (transform.position - planet.transform.position).normalized;
		Vector3 turdsUp = downLooker.up;
		Quaternion targetRotation = Quaternion.FromToRotation (turdsUp, gravityUp) * downLooker.rotation;
		downLooker.rotation = Quaternion.Slerp (downLooker.rotation, targetRotation, 50 * Time.deltaTime);
		transform.rotation = Quaternion.FromToRotation (transform.up, gravityUp) * transform.rotation;
	}





	// Update is called once per frame
	void FixedUpdate () {
		FollowPlayer ();
		//Takes input from the mouse and gives it a speed
	/*	mouseX += Input.GetAxis ("Mouse X") * sensitivity * 0.02f;
		mouseY -= Input.GetAxis ("Mouse Y") * sensitivity * 0.02f;

		//gives the y camera movement a maximum/minimum movement range
		mouseY = Mathf.Clamp (mouseY, -rangeY, rangeY);


		mainCamTrans.rotation = Quaternion.Euler (mouseY,mouseX,playerTrans.rotation.z);

		// allows toggling between inverted/normal camera controls 
		if (Input.GetButtonDown ("Invert")) {
			invert = -1*invert;
		}*/


	}



	void FollowPlayer(){

		Vector3 desiredPos = playerTrans.position;

		Vector3 smoothedPos = Vector3.SmoothDamp (transform.position, desiredPos, ref velocity, smoothSpeed);
		transform.position = smoothedPos;

	}

}
