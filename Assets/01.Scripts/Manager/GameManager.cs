using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; }  set { instance = value; }  }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        GameStart();
    }

    public void GameStart()
    {
        FriendsManager.Instance.ChangeFriends(0);
        FriendsManager.Instance.SetFriends(4);
    }
    public void GameStop() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    public void GameEnd()
    {
        PlayerPrefs.DeleteAll();
    }





}
