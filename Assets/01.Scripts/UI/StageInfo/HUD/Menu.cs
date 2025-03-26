using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] private MenuObjcet menuObjcet;
    private Button menuButton;

    private void Awake()
    {
        menuButton =transform.GetChild(1).GetComponent<Button>();
    }
    private void Start()
    {
        menuButton.onClick.AddListener(SetMenuObject);
    }



    private void SetMenuObject()
    {
        menuObjcet.gameObject.SetActive(true);
    }




}
