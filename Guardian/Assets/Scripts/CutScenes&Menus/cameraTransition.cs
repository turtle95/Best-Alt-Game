using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class cameraTransition : MonoBehaviour {

    public GameObject movingCam;
    public GameObject target;
    public GameObject end;
    public variableTracker varTrack;
    public Image loadImage;

    // Use this for initialization
    void Start () {
        varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            //play fade anim 2
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            movingCam.transform.position = Vector3.MoveTowards(movingCam.transform.position, target.transform.position, 1f);
        }
        //movingCam.transform.position = Vector3.RotateTowards(movingCam.transform.position, targetCam.transform.position, 1f, 1f);
        if (varTrack.transStart)
        {
            StartCoroutine(fadeTrans());
        }
	}

    IEnumerator fadeTrans()
    {
        movingCam.transform.position = Vector3.MoveTowards(movingCam.transform.position, end.transform.position, 1f);
        yield return new WaitForSeconds(2);
        //play fade anim
        varTrack.transStart = false;
        print("load next scene");
    }
}
