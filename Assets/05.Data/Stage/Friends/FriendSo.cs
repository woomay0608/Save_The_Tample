using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
