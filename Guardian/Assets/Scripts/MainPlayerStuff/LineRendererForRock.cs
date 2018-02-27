using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererForRock : MonoBehaviour {

	public LineRenderer lRend;

	public Vector3 start;
	public Vector3 startVel;
	public float timeStep = 0.5f;
	public float maxTime = 5;
	public FireRocks rScript;

	// Use this for initialization
	void Start () {
		startVel = rScript.spawnPoint.forward * rScript.launchSpeed;
		start = rScript.spawnPoint.position;
		PlotTrajectory ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 PlotTrajectoryAtTime (Vector3 start2, Vector3 startVel2, float time2){
		return start2 + startVel2 * time2 + Physics.gravity * time2 * time2 * 0.5f;
	}

	public void PlotTrajectory (){
		//Vector3 prev = start;
		for (int i = 1;; i++) {
			float t = timeStep * i;
			if (t > maxTime)
				break;

			Vector3 pos = PlotTrajectoryAtTime (start, startVel, t);
			lRend.positionCount += 1;
			lRend.SetPosition (i, pos);
		}
		lRend.positionCount -= 1;
	}
}
