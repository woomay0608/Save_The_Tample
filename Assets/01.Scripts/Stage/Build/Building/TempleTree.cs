using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleTree : Building
{

    public override void SetDic()
    {
        base.SetDic();
        //bool IsLock, string Locktext, float LockMoney, float CoolTime, string CoolTimeText, bool IsCoolTime, string MethodName, Action action)

        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0,false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "500G", 500, 10, true, "Summon", () => { FriendsManager.Instance.SetFriends(1); }));

    }

    private void Info()
    {
        string s = "This Game Defens Enemy that Come to our Temple";
        UIManager.Instance.POPInstantiate(s, UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            PlayerDataManager.Instance.PlayerInstance.Health -= 1;
            if (PlayerDataManager.Instance.PlayerInstance.Health <= 0)
            {
                GameManager.Instance.GameEnd();
            }
        }
    }







}
