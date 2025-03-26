using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class PlayerprefabsSetDown : MonoBehaviour
{

    [MenuItem("Tool/데이터 초기화")]
    private static void SetDonw()
    {
        PlayerPrefs.DeleteAll();
    }
    [MenuItem("Tool/골드 추가")]
    private static void Gold()
    {
        PlayerDataManager.Instance.PlayerInstance.Money += 50000;
    }
    [MenuItem("Tool/다이아")]
    private static void Dia()
    {
        PlayerDataManager.Instance.PlayerInstance.Diamond += 5000;
    }
}
