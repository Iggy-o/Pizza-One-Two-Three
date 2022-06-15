using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static float timeNum;
	public GameObject[] timeUI;
	public TextMeshProUGUI timeText;
	public Sprite[] spriteTexture;

	public static float monNum;
	public GameObject[] monUI;
	public Sprite[] spriteTextureMon;
	public static int thisRoundMon;

	public GameObject[] orderUI;
	//public GameObject[] progressUI;
	public int[] orderparentNum;
	public int[] orderchildNum;
	public static int[] answer= { 0,0,0,0,0,0,0};
	public Sprite[] spriteTextureOrder;
	public static int orderIndex;

	//private int numOrder1;
	//private int numProgress0;
	//private int numProgress1;

	public GameObject win;
	public GameObject backButton;
	
	private const int WINMONEY = 200;

	private int nuM0;
	private int nuM1;
	private int nuM2;

	private int num0;
	private int num1;
	private int num2;

	
	public void OrderAndProgress()
	{
		if (orderIndex >= 6)
		{
			orderIndex = 0;
		}
		
		if (true) //orderNum[orderIndex] < 10 && orderNum[orderIndex] >= 0
		{
			orderUI[0].GetComponent<Image>().sprite = spriteTextureOrder[orderparentNum[orderIndex]]; //parent fraction
			orderUI[1].GetComponent<Image>().sprite = spriteTextureOrder[orderchildNum[orderIndex]]; //child fraction
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
		if (monNums < 10 && monNums >= 0)
		{
			monUI[0].GetComponent<Image>().sprite = spriteTextureMon[(int)monNums];
			monUI[1].SetActive(false);
			monUI[2].SetActive(false);
		}
		else if (monNums < 100 && monNums >= 10)
		{
			nuM0 = (int)(monNums / 10);
			nuM1 = (int)(monNums % 10);
			monUI[0].GetComponent<Image>().sprite = spriteTextureMon[nuM0];
			monUI[1].GetComponent<Image>().sprite = spriteTextureMon[nuM1];
			monUI[1].SetActive(true);
			monUI[2].SetActive(false);
		}
		else if (monNums < 1000 && monNums >= 100)
		{
			nuM0 = (int)(monNums / 100);
			nuM1 = (int)((monNums % 100) / 10);
			nuM2 = (int)((monNums % 100) % 10);
			monUI[0].GetComponent<Image>().sprite = spriteTextureMon[nuM0];
			monUI[1].GetComponent<Image>().sprite = spriteTextureMon[nuM1];
			monUI[2].GetComponent<Image>().sprite = spriteTextureMon[nuM2];
			monUI[0].SetActive(true);
			monUI[1].SetActive(true);
			monUI[2].SetActive(true);
		}
	}
	void Start()
	{
		monNum += thisRoundMon;
		ShowMoney(monNum);
		OrderAndProgress();
		timeNum = 0;
	}
	void Update()
    {

		// Add time to the clock if the game is running
		if (monNum < WINMONEY)
		{
			timeNum = timeNum + Time.deltaTime;
			int timeInt = (int)timeNum;
			timeText.text = timeInt.ToString() + "s";

			/*
			if (timeNum < 10 && timeNum >= 0)
			{
				timeUI[0].GetComponent<Image>().sprite = spriteTexture[(int)timeNum];
				timeUI[1].SetActive(false);
				timeUI[2].SetActive(false);
			}
			else if (timeNum < 100 && timeNum >= 10)
			{
				num0 = (int)(timeNum / 10);
				num1 = (int)(timeNum % 10);
				timeUI[0].GetComponent<Image>().sprite = spriteTexture[num0];
				timeUI[1].GetComponent<Image>().sprite = spriteTexture[num1];
				timeUI[1].SetActive(true);
				timeUI[2].SetActive(false);
			}
			else if (timeNum < 1000 && timeNum >= 100)
			{
				num0 = (int)(timeNum / 100);
				num1 = (int)((timeNum % 100) / 10);
				num2 = (int)((timeNum % 100) % 10);
				timeUI[0].GetComponent<Image>().sprite = spriteTexture[num0];
				timeUI[1].GetComponent<Image>().sprite = spriteTexture[num1];
				timeUI[2].GetComponent<Image>().sprite = spriteTexture[num2];
				timeUI[0].SetActive(true);
				timeUI[1].SetActive(true);
				timeUI[2].SetActive(true);
			}
			*/
		}
		else //you win
		{
			win.SetActive(true);
			backButton.SetActive(true);
			monNum = 0;
			thisRoundMon = 0;
		}
	}

}

