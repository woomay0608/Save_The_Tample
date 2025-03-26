using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuObjcet : MonoBehaviour
{

    private GameObject Image;
    private List<Button> Buttons = new List<Button>();

    
    private void Awake()
    {
        Image = transform.GetChild(1).gameObject;
        for (int i = 0; i < Image.transform.childCount; i++)
        {
            Buttons.Add(Image.transform.GetChild(i).GetComponent<Button>());
        }

    }
    private void Start()
    {
        Buttons[0].onClick.AddListener(PlayerDataManager.Instance.SaveData);
        Buttons[1].onClick.AddListener(GameManager.Instance.GameStop);
        Buttons[2].onClick.AddListener(() => { transform.gameObject.SetActive(false); });
    }


    

}
