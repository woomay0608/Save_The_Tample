using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SO", menuName = "Stage/Bulid")]
public class BuildSO : ScriptableObject
{
    public Sprite Face;
    public string Des;
    public string name;
    public int CommondCount;
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

