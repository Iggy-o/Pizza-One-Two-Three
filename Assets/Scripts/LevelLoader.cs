using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    int currentSceneIndex;
    public CheckOut cashier;
    public GameObject HintButton;


	void Start () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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

    public void LoadTutorialKitchen(){
        SceneManager.LoadScene("Tutorial Kitchen");
    }

    public void LoadUpSceneMainGame()
    {
        ToppingCounter.cheese = 0;
        ToppingCounter.olives = 0;
        ToppingCounter.tomato = 0;
        ToppingCounter.pesto = 0;

        SceneManager.LoadScene("Level 1_Kitchen");
        NextQuestion();


        //public static string randomTopping = "Tomato Sauce";
        RandomToppingDisplay.toppingtextvar = "Tomato Sauce";
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadUpScene()
    {
        ToppingCounter.cheese = 0;
        ToppingCounter.olives = 0;
        ToppingCounter.tomato = 0;
        ToppingCounter.pesto = 0;
        
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

    public void cutterCheck(){
        GameObject textFraction = GameObject.Find("Incorrect Fraction Text");
        bool correctFraction;
        correctFraction = cashier.CheckCorrectness();

        if (correctFraction){
            LoadNextScene();
            cashier.CheckOutMoney(GameManager.timeNum);
            ResetCursor();
        }
        else if (correctFraction == false){
            cashier.setWinConditions();
            HintButton.SetActive(true);
            if (cashier.playerCut > cashier.gameCut){
                textFraction.GetComponent<TMPro.TextMeshProUGUI>().text = "Incorrect Fraction! Try a smaller fraction!";
            }
            else if (cashier.playerCut < cashier.gameCut){
                textFraction.GetComponent<TMPro.TextMeshProUGUI>().text = "Incorrect Fraction! Try a larger fraction!";
            }

        }
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
