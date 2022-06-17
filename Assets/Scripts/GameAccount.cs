using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAccount
{
    public string username;
    public string email;
    public int stage;    
    public float score;
    public string ach;

    public GameAccount(string un, string em)
    {
        username = un;
        email = em;
        stage = 0;
        score = 0;
        ach = "NA";
    }
    public void Set_score(float result)
    {
        score = result;

    }
    public void Set_ach()
    {
        if (score < 15)
        {
            ach = "Bad";
        }
        else if (score < 30)
        {
            ach = "Good";
        }
        else if (score < 80)
        {
            ach = "Great";
        }
        else if (score < 100)
        {
            ach = "Excellent";
        }
        else
        {
            ach = "Mastered";
        }

    }
   

    public void SaveGameAccount()
    {
        SaveSystem.SaveAccount(this);
    }

    public void LoadGameAccount()
    {
        AccountData data = SaveSystem.LoadAccount();

        username = data.username;
        email = data.email;
        stage = data.stage;
        score = data.score;
        ach = data.ach;
    }

}
