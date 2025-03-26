using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FriendsStat : MonoBehaviour
{
    public float AllAttackCoolTime;
    public float AllSpeed;
    public float AllDamage;


    private float equipAttack;
    private float equipSpeed;
    private float EquipCool;

    private Friends friends;

    private void Awake()
    {
        friends = GetComponent<Friends>();
        
    }

    private void Update()
    {
        EquipSet();
    }



    public void EquipSet()
    {
        if (friends.equipList.Count > 0)
        {
            foreach (Equip equip in friends.equipList)
            {
                switch (equip.EquipSo.type)
                {
                    case EquipType.Damage:
                        equipAttack = equip.EquipSo.Value;
                        break;
                    case EquipType.Speed:
                        equipSpeed = equip.EquipSo.Value;
                        break;
                    case EquipType.CoolTime:
                        EquipCool =- equip.EquipSo.Value;
                        break;
                }
            }
        }


        AllAttackCoolTime = friends.Getfriends().AttackCoolTime - EquipCool;
        if(AllAttackCoolTime < 0)
        {
            AllAttackCoolTime = 1;
        }
        AllDamage = friends.Getfriends().Damage - equipAttack;
        AllSpeed = friends.Getfriends().Speed + equipSpeed;


    }





}
