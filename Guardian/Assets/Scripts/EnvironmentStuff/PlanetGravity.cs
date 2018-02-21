using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

	public float gravity = -10;

	public void Attract(Transform turdNugget)
	{
		Vector3 gravityUp = (turdNugget.position - transform.position).normalized;
		Vector3 turdsUp = turdNugget.up;

		turdNugget.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

		Quaternion targetRotation = Quaternion.FromToRotation (turdsUp, gravityUp) * turdNugget.rotation;
		turdNugget.rotation = Quaternion.Slerp (turdNugget.rotation, targetRotation, 50 * Time.deltaTime);
	}
}
