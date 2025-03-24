using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]private BuildSO buildSO;


    private void OnMouseDown()
    {
        StageInfoManager.Instance.SetBuild(buildSO);
    }
}
