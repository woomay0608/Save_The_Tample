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
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "Life 3 Cure 50D", 50, 0, false, "Life # Cure 50D", HPUP ,true));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "Time X2 50D", 50, 0, false, "Time X2", TimeScaleChange,true));
    }

    private void Info()
    {
        string s = "Diamond Shopping";
        UIManager.Instance.POPInstantiate(s, UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);

    }

    private void HPUP()
    {
        PlayerDataManager.Instance.PlayerInstance.Health = Mathf.Min(20, PlayerDataManager.Instance.PlayerInstance.Health + 3);

    }
    private void TimeScaleChange()
    {
        UIManager.Instance.POPInstantiate("Time X 2", UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);
        Time.timeScale = 2f;
    }
}
