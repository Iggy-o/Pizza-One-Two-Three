using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; 
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static float timeNum;
	public TextMeshProUGUI timeText;

	public static float monNum;
	public TextMeshProUGUI moneyText;
	public static int thisRoundMon;

	public bool timerStart = false;

	public GameObject[] orderUI;
	public int[] orderparentNum;
	public int[] orderchildNum;
	public static int[] answer= { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	public TextMeshProUGUI parentText;
	public TextMeshProUGUI childText;
	public Sprite[] spriteTextureOrder;
	public static int orderIndex;

	public GameObject win;
	public GameObject backButton;
	
	private const int WINMONEY = 900;
	private const int WINDAYS = 7;
	
	public void OrderAndProgress()
	{
		orderIndex=Random.Range(0,21);
		parentText.text = orderparentNum[orderIndex].ToString();
		childText.text = orderchildNum[orderIndex].ToString();
        if (orderparentNum[orderIndex] < 10 && orderparentNum[orderIndex] >= 0) //the answer figure (parent)
        {
            orderUI[0].SetActive(false); //parent fraction 10
            orderUI[1].GetComponent<Image>().sprite = spriteTextureOrder[orderparentNum[orderIndex] % 10]; //parent fraction <10
        }

        else if (orderparentNum[orderIndex] >= 10) //the answer figure (parent)
        {

            orderUI[0].GetComponent<Image>().sprite = spriteTextureOrder[1]; //parent fraction 10 (it will only be 1 here)
            orderUI[1].GetComponent<Image>().sprite = spriteTextureOrder[orderparentNum[orderIndex] % 10]; //parent fraction <10
        }


        if (orderchildNum[orderIndex] < 10 && orderchildNum[orderIndex] >= 0) //the answer figure (child)
        {

            orderUI[2].SetActive(false); //parent fraction 10
            orderUI[3].GetComponent<Image>().sprite = spriteTextureOrder[orderchildNum[orderIndex] % 10]; //parent fraction <10

        }

        else if (orderchildNum[orderIndex] >= 10) //the answer figure (child)
        {

            orderUI[2].GetComponent<Image>().sprite = spriteTextureOrder[1]; //child fraction 10 (it will only be 1 here)
            orderUI[3].GetComponent<Image>().sprite = spriteTextureOrder[orderchildNum[orderIndex] % 10]; //child fraction <10
        }


        for (int i = 0; i < orderparentNum.Length; i++)
		{
			answer[i] = (orderchildNum[i] * 360 / orderparentNum[i]); //the answer in degree
		}
	}

	public void ShowMoney(float monNums)
	{
		moneyText.text = monNums.ToString ();
	}
	
	void Start()
	{
		monNum += thisRoundMon; //update the money to the total that player wins so far
		ShowMoney(monNum);
		OrderAndProgress(); //show fraction question
		timeNum = 0; //reset timer
	}
	
	void Update()
	{
		WinCheck();
	}

	void WinCheck(){
		// Add time to the clock if the game is running
		if (monNum < WINMONEY && timerStart || DayCustomerCheck.playerHasFinished == true && timerStart) //if player has not won and the timer starts
		{
			timeNum = timeNum + Time.deltaTime;
			int timeInt = (int)timeNum;
			timeText.text = timeInt.ToString() + "s";
		}

		if (monNum >= WINMONEY && DayCustomerCheck.playerHasFinished == false || DayCustomerCheck.dayCount >= WINDAYS && monNum >= 900 && DayCustomerCheck.playerHasFinished == false)
		{ //reach win condition
			win.SetActive(true);
			DayCustomerCheck.playerHasFinished = true;
			SceneManager.LoadScene("Game Win Screen");
		}
		else if (DayCustomerCheck.dayCount >= WINDAYS && monNum <= 900 && DayCustomerCheck.playerHasFinished == false)
		{//unable to reach win condition
			win.SetActive(true);
			DayCustomerCheck.playerHasFinished = true;
			SceneManager.LoadScene("Game Lose Screen");
		}
	}

	public void TimerStart() //use button to trigger this function
	{
		timerStart = true;
	}
}

