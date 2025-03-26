using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    [SerializeField] GameObject Lock;
    private Button LockButton;
    private TextMeshProUGUI Locktext;



    [SerializeField] GameObject CoolTime;
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



        CoolTime = transform.GetChild(1).gameObject;
        CooltimeText = CoolTime.GetComponentInChildren<TextMeshProUGUI>();
        CooltimeImage = CoolTime.transform.GetChild(1).GetComponent<Image>();

        Lock = transform.GetChild(2).gameObject;
        LockButton = Lock.GetComponentInChildren<Button>();
        Locktext = Lock.GetComponentInChildren<TextMeshProUGUI>();



    }
    public void Set(Command command)
    {

        LockButton.onClick.RemoveAllListeners();
        ActiveButton.onClick.RemoveAllListeners();
        Lock.gameObject.SetActive(command.IsLock);

        if (command.IsDiamond)
        {
            Locktext.text = command.LockText;
            Locktext.color = new Color(30f / 255f, 150f / 255f, 1f);
        }
        else
        {
            Locktext.color = new Color(1f, 240f / 255f, 0f);
            Locktext.text = command.LockText;
        }

        LockButton.onClick.AddListener(() => LockOpen(command));


        if (command.IsCoolTime && !command.IsLock)
            Cooltiome(command);

        Active.gameObject.SetActive(true);
        Activetext.text = command.MethodName;
        ActiveButton.onClick.AddListener(() => { command.action(); if (command.IsCoolTime) { command.IsCoolTimePassed = true; } });

    }



    public void LockOpen(Command command)
    {
        if (command.IsDiamond)
        {
            if (PlayerDataManager.Instance.PlayerInstance.Diamond > command.LockMoney)
            {
                PlayerDataManager.Instance.PlayerInstance.Diamond -= (int)command.LockMoney;
                command.IsLock = false;
                Lock.gameObject.SetActive(command.IsLock);
            }
        }
        else
        {

            if (PlayerDataManager.Instance.PlayerInstance.Money > command.LockMoney)
            {
                PlayerDataManager.Instance.PlayerInstance.Money -= (int)command.LockMoney;
                command.IsLock = false;
                Lock.gameObject.SetActive(command.IsLock);
            }
        }

    }

    public void Cooltiome(Command command)
    {
        if (command.IsCoolTimePassed)
        {
            command.CurCooltime += Time.deltaTime;
            if (command.Cooltime < command.CurCooltime)
            {
                CoolTime.gameObject.SetActive(!command.IsCoolTimePassed);
                command.CurCooltime -= command.Cooltime;
                command.IsCoolTimePassed = false;

            }
            else
            {
                CoolTime.gameObject.SetActive(command.IsCoolTimePassed);
                CooltimeText.text = Math.Round((command.Cooltime - command.CurCooltime), 2).ToString();
                CooltimeImage.fillAmount = (command.Cooltime - command.CurCooltime) / command.Cooltime;
            }
        }
        else
        {
            CoolTime.gameObject.SetActive(command.IsCoolTimePassed);
        }

    }







}
