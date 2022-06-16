using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    
    public static void SaveAccount(GameAccount account)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/account.info";
        //
        FileStream stream = new FileStream(path, FileMode.Create);

        AccountData acc = new AccountData(account);

        formatter.Serialize(stream, acc);
        stream.Close();
    }

   
    public static AccountData LoadAccount()
    {
        string path = Application.persistentDataPath + "/account.info";
        //;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AccountData data = formatter.Deserialize(stream) as AccountData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file no found in " + path);
            return null;
        }
    }
}
