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
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "Summon 500G", 500, 10, true, "Summon", () => { FriendsManager.Instance.SetFriends(1); }));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "SpawnTimeDonw", SpawnTimeDonw));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "SpawnTimeUp", SpawnTimeUp));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "SpawnCountUP", SpawnCountUP));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "SpawnCountDown", SpawnCountDown));
    }

    private void Info()
    {
        string s = "This Game Defens Enemy that Come to our Temple";
        UIManager.Instance.POPInstantiate(s, UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);
    }

    private void SpawnTimeDonw()
    {
        SpawnManager.Instance.SpawnCoolTime -= 1f;
        SpawnManager.Instance.SpawnCoolTime = Mathf.Max(1f, SpawnManager.Instance.SpawnCoolTime);
    }
    private void SpawnTimeUp()
    {
        SpawnManager.Instance.SpawnCoolTime += 1f;
        SpawnManager.Instance.SpawnCoolTime = Mathf.Min(10f, SpawnManager.Instance.SpawnCoolTime);
    }

    private void SpawnCountUP()
    {
        SpawnManager.Instance.SpawnCount += 1;
        SpawnManager.Instance.SpawnCount = Mathf.Min(20, SpawnManager.Instance.SpawnCount);
    }
    private void SpawnCountDown() 
    {
        SpawnManager.Instance.SpawnCount -= 1;
        SpawnManager.Instance.SpawnCount = Mathf.Min(1, SpawnManager.Instance.SpawnCount);
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
