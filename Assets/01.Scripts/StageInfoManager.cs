using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageInfoManager : MonoBehaviour
{

    private static StageInfoManager instance;
    public static StageInfoManager Instance { get { return instance; } set { instance = value; } }

    [SerializeField] private ScrollContent scrollContent;


    private BuildSO buildSO;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public BuildSO GetBuild()
    {
        if(buildSO != null)
        return buildSO;
        return null;
    }

    public void SetBuild( BuildSO build)
    {
        buildSO = build;
        scrollContent.Set();
    }



}
