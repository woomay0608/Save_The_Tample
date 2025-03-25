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
}
