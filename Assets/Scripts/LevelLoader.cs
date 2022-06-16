﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;



	// Use this for initialization
	void Start () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
	}

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadUpScene()
    {
        if (DayCustomerCheck.custCount == DayCustomerCheck.dayCount){
            DayCustomerCheck.custCount = 0;
            DayCustomerCheck.dayCount++;
            SceneManager.LoadScene("End of Day");
            Debug.Log("custCount is " + DayCustomerCheck.custCount + "----------------------------------------------------------------------------------------------");
        }
        else if (DayCustomerCheck.custCount < DayCustomerCheck.dayCount){
            SceneManager.LoadScene("Level 1_Kitchen");
            NextQuestion();
            DayCustomerCheck.custCount++;
            Debug.Log("dayCount is " + DayCustomerCheck.dayCount + "----------------------------------------------------------------------------------------------");
        }
        else Debug.Log("Error: Load next scene not working");
    }


    public void NextQuestion()
    {
        GameManager.orderIndex++;
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); //change the cursor to default arrow
    }

    public void RestartGame(){
        GameManager.monNum = 0;
		GameManager.thisRoundMon = 0;
		DayCustomerCheck.dayCount = 0;
		DayCustomerCheck.custCount = 0; 
        SceneManager.LoadScene("Start Screen");
    }
	
    public void QuitGame()
    {
        Application.Quit();
    }

}
