using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRocks : MonoBehaviour {

	public GameObject rock; //rock prefab to spawn
    GameObject rockUsedHere; //gameobject to hold the rock that is created
	public Transform spawnPoint; //spot that the rock is spawned from
	public float rockSize =1;
    //public float timer;
	GameObject lineDraw;
	Rigidbody rb; 
	public float launchSpeed = 100; //launch speed for normal rocks
	public float initialCharge = 100; //initial speed for charge-up rocks  
	public float chargeSpeed = 100; //speed that charge-up rocks gain speed
	float chargedLaunch = 0;
    public float rockDisappearTime = 10;
	// Use this for initialization
	void Start () {
		chargedLaunch = initialCharge;
		lineDraw = GameObject.FindGameObjectWithTag ("RockLine");
		lineDraw.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton ("Fire1"))
			lineDraw.SetActive (true);

        if (Input.GetButtonUp ("Fire1")) { //If someone presses Fire1 then spawn a rock at the spawn point and give it a launch speed
			rockUsedHere = Instantiate (rock, spawnPoint.position, spawnPoint.rotation);
			rockUsedHere.transform.localScale *= rockSize;
			rockUsedHere.GetComponent<RockBreakController> ().rockSize = rockSize;
			rb = rockUsedHere.GetComponent<Rigidbody> ();
		//	rb.mass = rockSize;
		//	rb.angularDrag *= rockSize;
			rb.velocity = spawnPoint.forward * launchSpeed;
			lineDraw.SetActive (false);
		} 
			




		//Stuff for Goku Rock, probably will delete at some point

		/*if (Input.GetButtonDown ("Fire2")) { //if someone presses fire2 then spawn a rock, disable its gravity, and start charging up speed
			rockUsedHere = Instantiate (rock, spawnPoint.position, spawnPoint.rotation);
			rb = rockUsedHere.GetComponent<Rigidbody> ();
			rb.useGravity = false;
			chargedLaunch += chargeSpeed * Time.deltaTime;
		}
		if (Input.GetButton ("Fire2")) { //while fire2 is held, charge up the speed and make the rock larger, also keep it attatched to the spawn point
			chargedLaunch += chargeSpeed * Time.deltaTime;
			rockUsedHere.transform.localScale += new Vector3(1 * Time.deltaTime,1 * Time.deltaTime,1 * Time.deltaTime);
			rockUsedHere.transform.position = spawnPoint.position;
		}
		if (Input.GetButtonUp ("Fire2")) { //when fire2 is released, turn on the rock's gravity, give it a launch speed, and reset the chargedLaunch variable
            //timer += 1.0F * Time.deltaTime;
            rb.useGravity = true;
			rb.velocity = spawnPoint.forward * chargedLaunch;
			chargedLaunch = initialCharge;


		}
        //timer += 1.0F * Time.deltaTime;

        if (Input.GetButtonUp("Fire2"))
        { //when fire2 is released, turn on the rock's gravity, give it a launch speed, and reset the chargedLaunch variable
            rb.useGravity = true;
            rb.velocity = spawnPoint.forward * chargedLaunch;
            chargedLaunch = initialCharge;
            //if (timer >= 3)
            //{
            //    Destroy(rb);
            //}

        }*/
        //remove the game obj after x sec
        Destroy(this.rockUsedHere, rockDisappearTime);


	}
}
