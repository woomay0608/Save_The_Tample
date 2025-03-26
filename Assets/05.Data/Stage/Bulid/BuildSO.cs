using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public enum BuildingType
{
    Tree,
    Shop,
    PlayerSkill,
    CashShop,
    ArmyBase
}

public enum EquipType
{
    Damage,
    Speed,
    CoolTime
}




[CreateAssetMenu(fileName = "SO", menuName = "Stage/Bulid")]
public class BuildSO : ScriptableObject
{
    public Sprite Face;
    public string Des;
    public string BuildName;
    public int CommandCount;
    public BuildingType type;
    public Dictionary<BuildingType, List<Command>> DicCommand = new Dictionary<BuildingType, List<Command>>();

}





[Serializable]
public class Command
{
    [Header("Lock")]
    public bool IsLock;
    public string LockText;
    public float LockMoney;
    public bool IsDiamond;
    [Header("CoolTime")]
    public float Cooltime;
    public float CurCooltime;
    public bool IsCoolTime;
    public bool IsCoolTimePassed;

    public string MethodName;
    public Action action;



    public Command(bool IsLock, string Locktext, float LockMoney, float CoolTime, bool IsCoolTime, string MethodName, Action action, bool Isdia = false)
    {
        this.IsLock = IsLock;
        this.LockText = Locktext;
        this.LockMoney = LockMoney;
        IsDiamond = Isdia;
        Cooltime = CoolTime;
        CurCooltime = 0f;
        IsCoolTimePassed = false;
        this.IsCoolTime = IsCoolTime;
        this.MethodName = MethodName;
        this.action = action;
    }
}




