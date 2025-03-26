using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsManager : MonoBehaviour
{
    private static FriendsManager instance;
    public static FriendsManager Instance { get { return instance; } set { instance = value; } }

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
    }


    public GameObject FriendsPrefabs;
    public List<Friends> Friends;

    public void SetFriends(int Count)
    {
        Vector3[] vector3 = new Vector3[]
        {
            new Vector3(13f,0.6f,0f),
            new Vector3(-13f,0.6f,0f),
            new Vector3(0f,0.6f,13f),
            new Vector3(0f,0.6f,-13f),
        };

        for (int i = 0; i< Count; i++) 
        {
            GameObject Prefabs = Instantiate(FriendsManager.Instance.FriendsPrefabs);
            Prefabs.transform.position = vector3[Random.Range(0, vector3.Length)];
        }
    }

}
