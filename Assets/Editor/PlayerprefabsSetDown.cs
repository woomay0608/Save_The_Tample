using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class PlayerprefabsSetDown : MonoBehaviour
{

    [MenuItem("Tool/������ �ʱ�ȭ")]
    private static void SetDonw()
    {
        PlayerPrefs.DeleteAll();
    }
    [MenuItem("Tool/��� �߰�")]
    private static void Gold()
    {
        PlayerDataManager.Instance.PlayerInstance.Money += 5000;
    }
}
