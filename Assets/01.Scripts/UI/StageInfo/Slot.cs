using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    [SerializeField]GameObject Lock;
    private Button LockButton;
    private float LockMoney;
    private TextMeshProUGUI Locktext;



    [SerializeField] GameObject CoolTime;
    private float Cooltime;
    private TextMeshProUGUI CooltimeText;
    private Image CooltimeImage;

    [SerializeField] GameObject Active;
    private TextMeshProUGUI Activetext;
    private Button ActiveButton;




    private void Awake()
    {
        Active = transform.GetChild(0).gameObject;
        Activetext = Active.GetComponentInChildren<TextMeshProUGUI>();
        ActiveButton = Active.GetComponentInChildren<Button>();


        Lock = transform.GetChild(1).gameObject;
        LockButton = Lock.GetComponentInChildren<Button>();
        Locktext = Lock.GetComponentInChildren<TextMeshProUGUI>();
   


        CoolTime = transform.GetChild(2).gameObject;
        CooltimeText = CoolTime.GetComponentInChildren<TextMeshProUGUI>();
        CooltimeImage = CoolTime.transform.GetChild(1).GetComponent<Image>();
    }

    public void Set(Command command)
    {
        Lock.gameObject.SetActive(command.IsLock);
        Locktext.text = command.LockText;
        LockMoney = command.LockMoney;
        LockButton.onClick.AddListener(() => LockOpen(command));

        if(command.IsCoolTime && Cooltime > 0)
        {
            Cooltime -= Time.deltaTime;
            CoolTime.gameObject.SetActive(true);
            CooltimeText.text = command.CoolTimeText;
            CooltimeImage.fillAmount = Cooltime;
        }


        Active.gameObject.SetActive(true);
        Activetext.text = command.MethodName;
        ActiveButton.onClick.AddListener(() => { command.action(); });

    }


    public void LockOpen(Command command)
    {
        if(500f > LockMoney) 
        {
            command.IsLock = false;
            Lock.gameObject.SetActive(command.IsLock);
        }
    }







}
