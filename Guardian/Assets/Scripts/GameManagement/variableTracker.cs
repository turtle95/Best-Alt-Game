using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class variableTracker : MonoBehaviour {


    public int EnemiesKilled = 0;       //Some basic things we may want to track
    public int CurrentStage = 1;
    public int ObjectsDestroyed = 0;
    public float PlayerHP = 100;
    public Text resultText;
    public bool randomResult;
    public bool transStart;
	GameObject endFader;
	cameraTransition cTScript;
	public bool controller = false;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this); //So that variableTracker will always be able to track variables (stays inbetween scenes)
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Join")){
			controller = true;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			controller = false;
		}
     
		if (EnemiesKilled < 10)
		{
			if (!(CurrentStage == 1) && !(CurrentStage == 0))
				ChangeScenes (1);  //Loads Level 1
		}

		if (EnemiesKilled >= 10 && EnemiesKilled < 30)
        {
			if (!(CurrentStage == 2))
				ChangeScenes (2);     //Loads Level 2
        }

		if (EnemiesKilled >= 30 && EnemiesKilled < 68)
        {
			if (!(CurrentStage == 3))
				ChangeScenes (3);      //Loads Level 3
        }

		if (EnemiesKilled >= 68)
        {
			if (!(CurrentStage == 4)) 
				ChangeScenes (4);       //Loads Ending
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnemiesKilled = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnemiesKilled = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EnemiesKilled = 30;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EnemiesKilled = 68;
        }

		if (CurrentStage == 4)
        {
            resultText = GameObject.Find("resultnum").GetComponent<Text>();
            if (randomResult == false)
            {
                resultText.text = (ObjectsDestroyed * 10).ToString() + " Lives";
            }
            else
            {
                var randomNum = Random.Range(20, 100000);
                resultText.text = randomNum.ToString() + " Lives";
            }
        }
    }

    public void ResetToLvl1(){
        PlayerHP = 100;
        CurrentStage = 1;
        EnemiesKilled = 0;
        ObjectsDestroyed = 0;
        ChangeScenes(1);
    }

	//Resets all the variables for when the game restarts
	public void ResetVars(){
		//CurrentStage = 1;
		//EnemiesKilled = 0;
		//ObjectsDestroyed = 0;
		PlayerHP = 100;
        if (EnemiesKilled < 10)
        {
            if (CurrentStage == 1)
            {
                EnemiesKilled = 0;
                ChangeScenes(1);  //Loads Level 1
            }
        }

        if (EnemiesKilled >= 10 && EnemiesKilled < 30)
        {
            if (CurrentStage == 2)
            {
                EnemiesKilled = 10;
                ChangeScenes(2);     //Loads Level 2
            }
        }

        if (EnemiesKilled >= 30 && EnemiesKilled < 68)
        {
            { 
            EnemiesKilled = 30;
            if (CurrentStage == 3)
                ChangeScenes(3);      //Loads Level 3
            }
        }



        //resultText.text = "";
	}


	public void ChangeScenes(int goToLevel){

		cTScript = GameObject.Find ("CameraTransition").GetComponent<cameraTransition>();
		switch(goToLevel){
		case 1:
			StartCoroutine (cTScript.PlayTransition (1, 3f));
			CurrentStage = 1;
			break;
		case 2:
			StartCoroutine (cTScript.PlayTransition (2, 3f));
			CurrentStage = 2;
			break;
		case 3:
			StartCoroutine (cTScript.PlayTransition (3, 3f));
			CurrentStage = 3;
			break;
		case 4:
			StartCoroutine (cTScript.PlayTransition (4, 10f));
			CurrentStage = 4;
			break;
		default:
			break;
		}
	}
}
