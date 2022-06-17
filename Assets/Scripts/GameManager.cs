﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; 
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static float timeNum;
	public GameObject[] timeUI;
	public TextMeshProUGUI timeText;
	public Sprite[] spriteTexture;

	public static float monNum;
	public GameObject[] monUI;
	public TextMeshProUGUI moneyText;
	public Sprite[] spriteTextureMon;
	public static int thisRoundMon;

	public bool timerStart = false;

	public GameObject[] orderUI;
	//public GameObject[] progressUI;
	public int[] orderparentNum;
	public int[] orderchildNum;
	public static int[] answer= { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	public Sprite[] spriteTextureOrder;
	public static int orderIndex;

	//private int numOrder1;
	//private int numProgress0;
	//private int numProgress1;

	public GameObject win;
	public GameObject backButton;
	
	private const int WINMONEY = 900;
	private const int WINDAYS = 7;

	private int nuM0;
	private int nuM1;
	private int nuM2;

	private int num0;
	private int num1;
	private int num2;

	
	public void OrderAndProgress()
	{
		orderIndex=Random.Range(0,21);

		if (orderparentNum[orderIndex]<10 && orderparentNum[orderIndex] >= 0) //orderNum[orderIndex] < 10 && orderNum[orderIndex] >= 0
		{
			
			orderUI[0].SetActive(false); //parent fraction 10
			orderUI[1].GetComponent<Image>().sprite = spriteTextureOrder[orderparentNum[orderIndex] % 10]; //parent fraction <10

		}

		else if (orderparentNum[orderIndex] >= 10) //orderNum[orderIndex] < 10 && orderNum[orderIndex] >= 0
		{

			orderUI[0].GetComponent<Image>().sprite = spriteTextureOrder[1]; //parent fraction 10 (it will only be 1 here)
			orderUI[1].GetComponent<Image>().sprite = spriteTextureOrder[orderparentNum[orderIndex]%10]; //parent fraction <10
		}


		if (orderchildNum[orderIndex] < 10 && orderchildNum[orderIndex] >= 0) //orderNum[orderIndex] < 10 && orderNum[orderIndex] >= 0
		{

			orderUI[2].SetActive(false); //parent fraction 10
			orderUI[3].GetComponent<Image>().sprite = spriteTextureOrder[orderchildNum[orderIndex] % 10]; //parent fraction <10

		}

		else if (orderchildNum[orderIndex] >= 10) //orderNum[orderIndex] < 10 && orderNum[orderIndex] >= 0
		{

			orderUI[2].GetComponent<Image>().sprite = spriteTextureOrder[1]; //child fraction 10 (it will only be 1 here)
			orderUI[3].GetComponent<Image>().sprite = spriteTextureOrder[orderchildNum[orderIndex] % 10]; //child fraction <10
		}

		
		for (int i = 0; i < orderparentNum.Length; i++)
		{
			answer[i] = (orderchildNum[i] * 360 / orderparentNum[i]);
			Debug.Log(answer[i]);
			//answer.Add((orderchildNum[i] / orderparentNum[i]) * 360);
			//Debug.Log(answer);
		}
		
		//answer[orderIndex] = (orderchildNum[orderIndex] / orderparentNum[orderIndex]) * 360;
		//else if (orderNum[orderIndex] < 100 && orderNum[orderIndex] >= 10)
		//{
		//	orderUI[0].GetComponent<Image>().sprite = spriteTextureMon[numOrder0];
		//	orderUI[1].GetComponent<Image>().sprite = spriteTextureMon[numOrder1];
		//}
	}

	public void ShowMoney(float monNums)
	{
		moneyText.text = monNums.ToString ();
	}
	// 	if (monNums < 10 && monNums >= 0)
	// 	{
	// 		monUI[0].GetComponent<Image>().sprite = spriteTextureMon[(int)monNums];
	// 		monUI[1].SetActive(false);
	// 		monUI[2].SetActive(false);
	// 	}
	// 	else if (monNums < 100 && monNums >= 10)
	// 	{
	// 		nuM0 = (int)(monNums / 10);
	// 		nuM1 = (int)(monNums % 10);
	// 		monUI[0].GetComponent<Image>().sprite = spriteTextureMon[nuM0];
	// 		monUI[1].GetComponent<Image>().sprite = spriteTextureMon[nuM1];
	// 		monUI[1].SetActive(true);
	// 		monUI[2].SetActive(false);
	// 	}
	// 	else if (monNums < 1000 && monNums >= 100)
	// 	{
	// 		nuM0 = (int)(monNums / 100);
	// 		nuM1 = (int)((monNums % 100) / 10);
	// 		nuM2 = (int)((monNums % 100) % 10);
	// 		monUI[0].GetComponent<Image>().sprite = spriteTextureMon[nuM0];
	// 		monUI[1].GetComponent<Image>().sprite = spriteTextureMon[nuM1];
	// 		monUI[2].GetComponent<Image>().sprite = spriteTextureMon[nuM2];
	// 		monUI[0].SetActive(true);
	// 		monUI[1].SetActive(true);
	// 		monUI[2].SetActive(true);
	// 	}
	// }
	void Start()
	{
		monNum += thisRoundMon;
		ShowMoney(monNum);
		OrderAndProgress();
		timeNum = 0;
	}
	void Update(){
		WinCheck();
	}


	void WinCheck(){
		// Add time to the clock if the game is running
		if (monNum < WINMONEY && timerStart || DayCustomerCheck.playerHasFinished == true && timerStart)
		{
			timeNum = timeNum + Time.deltaTime;
			int timeInt = (int)timeNum;
			timeText.text = timeInt.ToString() + "s";
		}
			// {
			// 	timeUI[0].GetComponent<Image>().sprite = spriteTexture[(int)timeNum];
			// 	timeUI[1].SetActive(false);
			// 	timeUI[2].SetActive(false);
			// }
			// else if (timeNum < 100 && timeNum >= 10)
			// {
			// 	num0 = (int)(timeNum / 10);
			// 	num1 = (int)(timeNum % 10);
			// 	timeUI[0].GetComponent<Image>().sprite = spriteTexture[num0];
			// 	timeUI[1].GetComponent<Image>().sprite = spriteTexture[num1];
			// 	timeUI[1].SetActive(true);
			// 	timeUI[2].SetActive(false);
			// }
			// else if (timeNum < 1000 && timeNum >= 100)
			// {
			// 	num0 = (int)(timeNum / 100);
			// 	num1 = (int)((timeNum % 100) / 10);
			// 	num2 = (int)((timeNum % 100) % 10);
			// 	timeUI[0].GetComponent<Image>().sprite = spriteTexture[num0];
			// 	timeUI[1].GetComponent<Image>().sprite = spriteTexture[num1];
			// 	timeUI[2].GetComponent<Image>().sprite = spriteTexture[num2];
			// 	timeUI[0].SetActive(true);
			// 	timeUI[1].SetActive(true);
			// 	timeUI[2].SetActive(true);
			// }

		if (monNum >= WINMONEY && DayCustomerCheck.playerHasFinished == false || DayCustomerCheck.dayCount >= WINDAYS && monNum >= 900 && DayCustomerCheck.playerHasFinished == false){ //WINMONEY == 2200
			win.SetActive(true);
			DayCustomerCheck.playerHasFinished = true;
			SceneManager.LoadScene("Game Win Screen");
		}
		else if (DayCustomerCheck.dayCount >= WINDAYS && monNum <= 900 && DayCustomerCheck.playerHasFinished == false){
			win.SetActive(true);
			DayCustomerCheck.playerHasFinished = true;
			SceneManager.LoadScene("Game Lose Screen");
		}
	}


	public void TimerStart()
	{
		timerStart = true;
	}
}

