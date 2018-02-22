using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

	public float gravity = -10;
	//calculates and applies planet based gravity, can be called and used by anything!
	public void Attract(Transform turdNugget, Transform downLooker)
	{
		Vector3 gravityUp = (turdNugget.position - transform.position).normalized;
		Vector3 turdsUp = downLooker.up;

		turdNugget.GetComponent<Rigidbody>().AddForce(turdsUp * gravity);

		Quaternion targetRotation = Quaternion.FromToRotation (turdsUp, gravityUp) * downLooker.rotation;
		downLooker.rotation = Quaternion.Slerp (downLooker.rotation, targetRotation, 50 * Time.deltaTime);
	}
}
