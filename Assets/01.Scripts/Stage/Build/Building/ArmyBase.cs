using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyBase : Building
{
    public override void SetDic()
    {
        base.SetDic();
        //bool IsLock, string Locktext, float LockMoney, float CoolTime, string CoolTimeText, bool IsCoolTime, string MethodName, Action action)

        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "Melee", MeleeFriend));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "Range Friend 3000G", 3000, 0, false, "Range", RangeFriend));





    }

    private void Info()
    {
        string s = "Upgrade Friend";
        UIManager.Instance.POPInstantiate(s, UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);

    }

    private void MeleeFriend()
    {
        FriendsManager.Instance.ChangeFriends(0);
        UIManager.Instance.POPInstantiate("Melee Friend Help Us\n Summon The Tree", UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);
    }
    private void RangeFriend()
    {
        FriendsManager.Instance.ChangeFriends(1);
        UIManager.Instance.POPInstantiate("Range Friend Help Us\n Summon The Tree", UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);
    }
}
