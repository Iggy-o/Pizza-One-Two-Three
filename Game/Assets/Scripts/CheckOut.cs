using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{
    public static bool correctOrNot;	
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckCorrectness()
    {
        if (Slice.cutChoicePortion * 30 == GameManager.answer[GameManager.orderIndex])
        {
            correctOrNot = true;
            return true;
        }
        else
        {
            correctOrNot = false;
            return false;
        }

    }

    public void CheckOutMoney(float timeSpent)
	{
		timeSpent = GameManager.timeNum;
		GameManager.thisRoundMon = 0;
        if (CheckCorrectness() == false)
        {
            GameManager.thisRoundMon += 1;
        }
        else if (CheckCorrectness() == true)
        {
            if (timeSpent > 15)
            {
                GameManager.thisRoundMon += 15;
            }
            else if (timeSpent > 10)
            {
                GameManager.thisRoundMon += 30;
            }
            else if (timeSpent > 5)
            {
                GameManager.thisRoundMon += 80;
            }
            else if (timeSpent > 0)
            {
                GameManager.thisRoundMon += 100;
            }
        }
        

		GameManager.timeNum = 0;


	}
}
