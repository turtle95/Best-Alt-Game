using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public variableTracker varTrack;
    public GameObject GameOverUI;
    //private bool paused = false;
	// Use this for initialization
	void Start () {
        GameOverUI.SetActive(false);
        varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
	}

    // Update is called once per frame
    void Update()
    {
        if (varTrack.PlayerHP <= 0)
        {
            //paused = !paused;
            GameOverUI.SetActive(true);
            //Time.timeScale = 0;


            if (Input.GetButtonDown("RestartMenu"))
            {
                GameOverUI.SetActive(false);
                //Time.timeScale = 1;
                varTrack.ResetToLvl1();

            }
            if (Input.GetButtonDown("Restart"))
            {
                GameOverUI.SetActive(false);
                //Time.timeScale = 1;
                varTrack.ResetVars();
            }

        }
    }
}
