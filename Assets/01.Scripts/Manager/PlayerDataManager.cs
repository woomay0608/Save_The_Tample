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

public class PlayerDataInstance
{
    private PlayerData instance = new PlayerData();

    public int GetMoney()
    {
        return instance.Money;
    }
    public int GetDiamond()
    {
        return instance.Diamond;
    }
    public int GetHealth()
    {
        return instance.Health;
    }
    public void SetMoney(int money) 
    {
        instance.Money = money;
    }
    public void SetDiamond(int diamond) 
    {
        instance.Diamond = diamond;
    }
    public void SetHealth(int health)
    {
        instance.Health = health;

    }
}




public class PlayerDataManager : MonoBehaviour
{
    public PlayerDataInstance PlayerInstance;
    public const string Key = "PlayerData";

    private static PlayerDataManager instance;
    public static PlayerDataManager Instance { get { return instance; } set { instance = value; } }



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else;
        {
            Destroy(gameObject);
        }


        DataSet();
    }


    private void DataSet()
    {
        if(PlayerPrefs.HasKey(Key))
        {
            PlayerInstance = JsonUtility.FromJson<PlayerDataInstance>(PlayerPrefs.GetString(Key));
            Debug.Log("LoadData");
        }
        else
        {
            PlayerInstance = new PlayerDataInstance();
            PlayerInstance.SetHealth(20);
            PlayerInstance.SetDiamond(0);
            PlayerInstance.SetMoney(0);
            SaveData();
            Debug.Log("New Data");
            string data = JsonUtility.ToJson(PlayerInstance);
            PlayerPrefs.SetString(Key, data);
        }
    }

    public PlayerDataInstance DataLoad()
    {
        return PlayerInstance;
    }

    public void SaveData()
    {
        PlayerPrefs.Save();
    }



    
}
