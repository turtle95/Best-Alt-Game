using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleScript : MonoBehaviour {

    public variableTracker varTrack;
    public Color32 objectColor;
    public Color32 currentColor;
    public Color32 foggedColor;
    public bool fogged;
	public GameObject deathFloaty;
	public Transform floatySpawner;
	public Material [] mainColorMat;
	public GameObject objWMats;
	public Material [] foggedColorMat;
    // Use this for initialization
    void Start () {
        varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();

			//objectColor = currentColor = mainColorMat[i].color;
		mainColorMat = objWMats.GetComponent<Renderer>().materials;
        foggedColor = new Color32(0, 0, 0, 255);
        fogged = false;
    }



	// Update is called once per frame
	/*void FixedUpdate () {
        if (!fogged)
        {
            if (this.GetComponentInChildren<Renderer>().material.color != objectColor)
            {
				
				Color32 currentColor = mainColorMat.color;
                currentColor.b = currentColor.g = currentColor.r += 1;
				mainColorMat.color = currentColor;
            }
			
			
        }

        if (fogged)
        {
            if (this.GetComponentInChildren<Renderer>().material.color != foggedColor)
            {
				Color32 currentColor = mainColorMat.color;
                currentColor.b = currentColor.g = currentColor.r -= 1;
				mainColorMat.color = currentColor;
            }
		
        }
        fogged = false;
	}*/

	public void ChangeColor(){
		//for (int i = 0; i < mainColorMat.Length; i++) {
			if (fogged)
			objWMats.GetComponent<Renderer>().materials = foggedColorMat;
			else
			objWMats.GetComponent<Renderer>().materials = mainColorMat;
		//}
		fogged = false;
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Rock")
        {
            varTrack.ObjectsDestroyed += 1;
			Instantiate (deathFloaty, floatySpawner.position, floatySpawner.rotation); 
            Destroy(this.gameObject);
        }
    }
}
