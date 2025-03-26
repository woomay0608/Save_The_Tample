using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : Building
{

    public override void SetDic()
    {
        base.SetDic();
        //bool IsLock, string Locktext, float LockMoney, float CoolTime, string CoolTimeText, bool IsCoolTime, string MethodName, Action action)

        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "Damage 3000G", 3000, 300, true, "DamageUP", DamageUPSkill));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "Speed 3000G", 3000, 300, true, "SpeedUP", SpeedUPSkill));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "CoolTime 3000G", 3000, 300, true, "CoolTimeDown", CoolTimeDownSkill));


    }

    private void Info()
    {
        string s = "PlayerSkill";
        UIManager.Instance.POPInstantiate(s, UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);
    }


    private void DamageUPSkill()
    {
       StartCoroutine(DamageUP());
        
    }
    private IEnumerator DamageUP()
    {


        foreach (var FSo in FriendsManager.Instance.FriendsPrefabsList)
        {
            FSo.GetComponent<Friends>().Getfriends().Damage += 3;
        }
        yield return new WaitForSeconds(30f);
        foreach (var FSo in FriendsManager.Instance.FriendsPrefabsList)
        {
            FSo.GetComponent<Friends>().Getfriends().Damage -= 3;
        }
    }
    private void SpeedUPSkill()
    {
        StartCoroutine(SpeedUP());

    }
    private IEnumerator SpeedUP()
    {

        foreach (var FSo in FriendsManager.Instance.FriendsPrefabsList)
        {
            FSo.GetComponent<Friends>().Getfriends().Speed += 3;
        }
        yield return new WaitForSeconds(30f);
        foreach (var FSo in FriendsManager.Instance.FriendsPrefabsList)
        {
            FSo.GetComponent<Friends>().Getfriends().Speed -= 3;
        }
    }
        private void CoolTimeDownSkill()
    {
        StartCoroutine(CoolTimeDonw());

    }
    private IEnumerator CoolTimeDonw()
    {
        float[] Cooltime = new float[FriendsManager.Instance.FriendsPrefabsList.Count];
        int Index = 0;
        foreach (var FSo in FriendsManager.Instance.FriendsPrefabsList)
        {
            Cooltime[Index] = FSo.GetComponent<Friends>().Getfriends().AttackCoolTime;
            Index++;
        }
 
        foreach (var FSo in FriendsManager.Instance.FriendsPrefabsList)
        {
            FSo.GetComponent<Friends>().Getfriends().AttackCoolTime -= 1;
            FSo.GetComponent<Friends>().Getfriends().AttackCoolTime = Mathf.Max(1f, FSo.GetComponent<Friends>().Getfriends().AttackCoolTime);
        }
        yield return new WaitForSeconds(30f);
        Index = 0;
        foreach (var FSo in FriendsManager.Instance.FriendsPrefabsList)
        {
            FSo.GetComponent<Friends>().Getfriends().AttackCoolTime = Cooltime[Index];
            Index++;

        }
    }
}
