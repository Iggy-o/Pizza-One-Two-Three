using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AccountData
{
    public string username;
    public string email;
    public int stage;
    public float score;
    public string ach;
    


    public AccountData (GameAccount account)
    {
        username = account.username;
        email = account.email;
        stage = account.stage;        
        score = account.score;
        ach = account.ach;

    }

}
