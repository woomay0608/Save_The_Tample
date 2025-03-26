using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int Money;
    public int Diamond;
    public int Health;
}






public class PlayerDataManager : MonoBehaviour
{
    public PlayerData PlayerInstance;
    public const string Key = "PlayerData";

    private static PlayerDataManager instance;
    public static PlayerDataManager Instance { get { return instance; } set { instance = value; } }



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        DataSet();
    }


    private void DataSet()
    {
        if(PlayerPrefs.HasKey(Key))
        {
            string json = PlayerPrefs.GetString(Key);
            Debug.Log(json);
            PlayerInstance = JsonUtility.FromJson<PlayerData> (json);
            Debug.Log("LoadData");
  
        }
        else
        {

            PlayerInstance.Health = 20;
            PlayerInstance.Money = 0;
            PlayerInstance.Diamond = 0;
            Debug.Log("New Data");
            SaveData();
        }
    }

    public PlayerData DataLoad()
    {
        return PlayerInstance;
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(PlayerInstance);
        PlayerPrefs.SetString(Key, data);
        PlayerPrefs.Save();
    }



    
}
