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
  
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this); //So that variableTracker will always be able to track variables (stays inbetween scenes)
	}
	
	// Update is called once per frame
	void Update () {
     /*   if (SceneManager.GetActiveScene().buildIndex != 0)
        {
			
			killedUi = GameObject.Find("EnemyCounterFill").GetComponent<Image>();
			killedUi.fillAmount = EnemiesKilled / (enemyCap);       //Updates UI
        }*/
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			 if (SceneManager.GetActiveScene().buildIndex == 1)
			 {
			SceneManager.LoadScene(1);      //Loads Level 1
			CurrentStage = 1;
			 }
		}

		if (EnemiesKilled >= 10 || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transStart = true;
                if (transStart == false)
                {
                    SceneManager.LoadScene(2);      //Loads Level 2
                    CurrentStage = 2;
                }
            }
        }

		if (EnemiesKilled >= 30|| Input.GetKeyDown(KeyCode.Alpha3))
        {
           if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                transStart = true;
                if (transStart == false)
                {
                    SceneManager.LoadScene(3);      //Loads Level 2
                    CurrentStage = 3;
                }
            }
        }

		if (EnemiesKilled >= 70|| Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                transStart = true;
                if (transStart == false)
                {
                    SceneManager.LoadScene(4);      //Loads Level 2
                    CurrentStage = 4;
                }
            }
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
            EnemiesKilled = 70;
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
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

	//Resets all the variables for when the game restarts
	public void ResetVars(){
		CurrentStage = 1;
		EnemiesKilled = 0;
		ObjectsDestroyed = 0;
		PlayerHP = 100;
        resultText.text = "";
	}
}
