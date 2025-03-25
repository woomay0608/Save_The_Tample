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

[CreateAssetMenu(fileName = "friends", menuName = "Stage/Friends")]
public class FriendSo : ScriptableObject
{
    public float AttackRange;
    public float AttackCoolTime;
    public float Speed;
    public float RunSpeed;
    public float Damage;
    public float Health;
}


[Serializable]
public class Command
{
    [Header("Lock")]
    public bool IsLock;
    public string LockText;
    public float LockMoney;
    [Header("CoolTime")]
    public float Cooltime;
    public float CurCooltime;
    public bool IsCoolTime;
    public bool IsCoolTimePassed;

    public string MethodName;
    public Action action;


    public Command(bool IsLock, string Locktext, float LockMoney , float CoolTime, bool IsCoolTime, string MethodName , Action action)
    {
        this.IsLock = IsLock;
        this.LockText = Locktext;
        this.LockMoney = LockMoney;
        Cooltime = CoolTime;
        CurCooltime = 0f;
        IsCoolTimePassed = false;
        this.IsCoolTime = IsCoolTime;
        this.MethodName = MethodName;
        this.action = action;
    }


}


