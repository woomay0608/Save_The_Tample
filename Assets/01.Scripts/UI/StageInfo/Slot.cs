using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
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
    private double TimeCoolTime;
    private TextMeshProUGUI CooltimeText;
    private Image CooltimeImage;

    [SerializeField] GameObject Active;
    private TextMeshProUGUI Activetext;
    private Button ActiveButton;


    bool IsCoolTimePassed = false;
    bool IsFrist = true;

    private float disableTime = 0f; // 비활성화된 시간 기록
    private bool isDisabled = false; // 비활성화 상태 체크



    private void Awake()
    {
        Active = transform.GetChild(0).gameObject;
        Activetext = Active.GetComponentInChildren<TextMeshProUGUI>();
        ActiveButton = Active.GetComponentInChildren<Button>();



        CoolTime = transform.GetChild(1).gameObject;
        CooltimeText = CoolTime.GetComponentInChildren<TextMeshProUGUI>();
        CooltimeImage = CoolTime.transform.GetChild(1).GetComponent<Image>();

        Lock = transform.GetChild(2).gameObject;
        LockButton = Lock.GetComponentInChildren<Button>();
        Locktext = Lock.GetComponentInChildren<TextMeshProUGUI>();
   


    }

    private void Update()
    {
        if(!IsFrist && IsCoolTimePassed) 
        {
            TimeCoolTime += Time.deltaTime;

        }
    }

    private void OnDisable()
    {
        disableTime = Time.time;
        isDisabled = true;
    }


    private void OnEnable()
    {

        if (isDisabled)
        {
            // 비활성화된 동안의 시간 계산
            float elapsedTime = Time.time - disableTime;
            Debug.Log("비활성화된 동안 경과된 시간: " + elapsedTime + "초");

            TimeCoolTime += elapsedTime;

            isDisabled = false;
        }
    }


    public void Set(Command command)
    {

        LockButton.onClick.RemoveAllListeners();
        ActiveButton.onClick.RemoveAllListeners();
        



        Lock.gameObject.SetActive(command.IsLock);
        Locktext.text = command.LockText;
        LockMoney = command.LockMoney;
        LockButton.onClick.AddListener(() => LockOpen(command));

        if(command.IsCoolTime && !command.IsLock)
        Cooltiome(command);

        Active.gameObject.SetActive(true);
        Activetext.text = command.MethodName;
        ActiveButton.onClick.AddListener(() => { command.action(); if (command.IsCoolTime) { IsCoolTimePassed = true; IsFrist = false; } });

    }


    
    public void LockOpen(Command command)
    {
        if(PlayerDataManager.Instance.PlayerInstance.Money > command.LockMoney) 
        {
            PlayerDataManager.Instance.PlayerInstance.Money -= (int)command.LockMoney;
            command.IsLock = false;
            Lock.gameObject.SetActive(command.IsLock);
        }
    }

    public void Cooltiome(Command command )
    {
        if (!IsFrist)
        {

            if (IsCoolTimePassed)
            {
                if (command.Cooltime < TimeCoolTime)
                {
                    CoolTime.gameObject.SetActive(!IsCoolTimePassed);
                    TimeCoolTime -= command.Cooltime;
                    IsCoolTimePassed = false;

                }
                else
                {
                    CoolTime.gameObject.SetActive(IsCoolTimePassed);
                    CooltimeText.text = Math.Round((command.Cooltime - TimeCoolTime), 2).ToString();
                    CooltimeImage.fillAmount = (command.Cooltime - (float)TimeCoolTime) / command.Cooltime;
                }
            }
        }

    }







}
