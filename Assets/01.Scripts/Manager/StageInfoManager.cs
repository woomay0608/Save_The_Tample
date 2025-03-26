using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageInfoManager : MonoBehaviour
{

    private static StageInfoManager instance;
    public static StageInfoManager Instance { get { return instance; } set { instance = value; } }

   private ScrollContent scrollContent;


    private BuildSO buildSO;
    private Friends friendSo;

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

        scrollContent = FindAnyObjectByType<ScrollContent>();
    }

    public BuildSO GetBuild()
    {
        if(buildSO != null)
        return buildSO;
        return null;
    }

    public void SetBuild( BuildSO build)
    {
        if(friendSo != null)
        {
            friendSo = null;
        }
        buildSO = build;
        scrollContent.Set();
    }

    public Friends GetFriend()
    {
        if (friendSo != null)
            return friendSo;
        return null;
    }

    public void SetFriend(Friends friend)
    {
        if (buildSO != null)
        {
            buildSO = null;
        }
        friendSo = friend;
        scrollContent.Set();
    }





}
