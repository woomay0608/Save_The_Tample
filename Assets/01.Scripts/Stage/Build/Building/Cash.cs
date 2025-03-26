using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : Building
{
    public override void SetDic()
    {
        base.SetDic();
        //bool IsLock, string Locktext, float LockMoney, float CoolTime, string CoolTimeText, bool IsCoolTime, string MethodName, Action action)

        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "Info", Info));




        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));

    }

    private void Info()
    {
        string s = "Diamond Shopping";
        UIManager.Instance.POPInstantiate(s, UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);

    }
}
