using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result : MonoBehaviour
{
    	float resMon;
	
	public GameObject lose;
	public GameObject win;
	public AudioClip loseSound;
	public AudioClip winSound;

	public TextMeshProUGUI moneyText;
	public GameObject resultButtom;
	public GameObject nextButtom;

    	public void ShowMoney(float monNums)
	{
		moneyText.text = monNums.ToString();
	}
	public void GetResult()
    {
		nextButtom.SetActive(true);
		
		resMon =GameManager.thisRoundMon;
		Debug.Log(resMon);
		ShowMoney(resMon);
		if (CheckOut.correctTopping == false)
		{
			lose.SetActive(true);
			BGmusic.playSoundEffect(loseSound);
		}
		if (CheckOut.correctTopping == true)
		{
			win.SetActive(true);
			BGmusic.playSoundEffect(winSound);
		}
		resultButtom.SetActive(false);
	}	
}
