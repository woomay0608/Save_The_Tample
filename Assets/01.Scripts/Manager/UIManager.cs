using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } set { instance = value; } }

    public GameObject uIPOPUP;

    private void Awake()
    {
        if (instance == null)
        { instance = this; }
        else
        {
            Destroy(gameObject);
        }

    }


    public void POPInstantiate(string Text, Action Yes, Action No = null)
    {
        GameObject uIPOPup = Instantiate(uIPOPUP, GameObject.Find("Canvas").transform);
        uIPOPup.GetComponent<UIPOPUP>().SetUP(Text, Yes, No);   
    }




}
