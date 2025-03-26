using UnityEngine;
using System.Collections.Generic;

public  class Building : MonoBehaviour
{
    [SerializeField]protected BuildSO buildSO;

    private void Awake()
    {
        SetDic();
    }

    private void OnMouseDown()
    {
        StageInfoManager.Instance.SetBuild(buildSO);
    }

    public virtual void SetDic()
    {
        buildSO.DicCommand[buildSO.type] = new List<Command>();
    }


}
