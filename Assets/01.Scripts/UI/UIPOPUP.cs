using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPOPUP : MonoBehaviour
{

    GameObject Front;

    TextMeshProUGUI text;

    Button YesButton;
    Button NoButton;
    Button XButton;

    private void Awake()
    {
        Front = transform.GetChild(1).gameObject;
        text = Front.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        YesButton = Front.transform.GetChild(1).gameObject.GetComponent<Button>();
        NoButton = Front.transform.GetChild(2).gameObject.GetComponent<Button>();
        XButton = Front.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<Button>();
    }


    public void SetUP(string Text, Action Yes, Action No = null)
    {
        MethodCut();

        XButton.onClick.AddListener(Down);
        if(No == null) 
        {
            NoButton.onClick.AddListener(Down);
        }
        else
        {
            NoButton.onClick.AddListener(() => { No(); });
        }

        YesButton.onClick.AddListener(() => { Yes(); });
        text.text = Text;

        transform.gameObject.SetActive(true);

    }

    public void Down()
    {
        transform.gameObject.SetActive(false);
    }

    private void MethodCut()
    {
        XButton.onClick.RemoveAllListeners();
        YesButton.onClick.RemoveAllListeners();
        NoButton.onClick.RemoveAllListeners();
    }
  
}
