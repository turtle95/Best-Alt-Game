using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class variableTracker : MonoBehaviour {


    public int EnemiesKilled = 0;       //Some basic things we may want to track
    public int CurrentStage = 1;
    public int ObjectsDestroyed = 0;
    public int PlayerHP = 0;
    public Text KilledNumber;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this); //So that variableTracker will always be able to track variables (stays inbetween scenes)
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            KilledNumber = GameObject.Find("KilledNumber").GetComponent<Text>();
            KilledNumber.text = EnemiesKilled.ToString();       //Updates UI
        }
		if (EnemiesKilled >= 10)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(2);      //Loads Level 2
                CurrentStage = 2;
            }
        }

        if (EnemiesKilled >= 30)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(3);      //Loads Level 3
                CurrentStage = 3;
            }
        }

        if (EnemiesKilled >= 70)
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                //SceneManager.LoadScene(4);    //Loads credits/end
                CurrentStage = 4;
            }
        }
    }
}
