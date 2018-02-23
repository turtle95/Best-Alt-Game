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
    // Use this for initialization
    void Start () {
        varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
        objectColor = currentColor = this.GetComponentInChildren<Renderer>().material.color;
        foggedColor = new Color32(0, 0, 0, 255);
        fogged = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!fogged)
        {
            if (this.GetComponentInChildren<Renderer>().material.color != objectColor)
            {
                Color32 currentColor = this.GetComponentInChildren<Renderer>().material.color;
                currentColor.b = currentColor.g = currentColor.r += 1;
                this.GetComponentInChildren<Renderer>().material.color = currentColor;
            }
        }

        if (fogged)
        {
            if (this.GetComponentInChildren<Renderer>().material.color != foggedColor)
            {
                Color32 currentColor = this.GetComponentInChildren<Renderer>().material.color;
                currentColor.b = currentColor.g = currentColor.r -= 1;
                this.GetComponentInChildren<Renderer>().material.color = currentColor;
            }
        }
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
