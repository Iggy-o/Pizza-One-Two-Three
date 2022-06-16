using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    float resMon;
	
	private int nuM0;
	private int nuM1;
	private int nuM2;
	public GameObject lose;
	public GameObject win;
	public AudioClip loseSound;
	public AudioClip winSound;

	public GameObject resultButtom;
	public GameObject nextButtom;

	public GameObject[] monUI;
	public Sprite[] spriteTextureMon;

  //  private void Start()
  //  {
		//audioSource = GetComponent<AudioSource>();
  //  }
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
	public void GetResult()
    {
		nextButtom.SetActive(true);
		
		resMon =GameManager.thisRoundMon;
		Debug.Log(resMon);
		ShowMoney(resMon);
		if (CheckOut.correctOrNot==false)
		{
			lose.SetActive(true);
			lose.GetComponent<AudioSource>().PlayOneShot(loseSound);
		}
		if (CheckOut.correctOrNot == true)
		{
			win.SetActive(true);
			win.GetComponent<AudioSource>().PlayOneShot(winSound);
		}
		resultButtom.SetActive(false);
		//GameManager.monNum = 0; //Reset money to 
	}

	
}
