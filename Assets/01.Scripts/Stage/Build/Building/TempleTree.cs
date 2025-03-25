using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleTree : Building
{
    [SerializeField] private GameObject Friends;
    public override void SetDic()
    {
        base.SetDic();
        //bool IsLock, string Locktext, float LockMoney, float CoolTime, string CoolTimeText, bool IsCoolTime, string MethodName, Action action)

        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty,false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "500G", 500, 30, "5", true, "Summon", FriendsInstantiate));


        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));

    }

    private void Info()
    {
        string s = "This Game Defens Enemy that Come to our Temple";
        UIManager.Instance.POPInstantiate(s, UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);

    }

    private void FriendsInstantiate()
    {
        Vector3[] vector3 = new Vector3[]
        {
            new Vector3(13f,0.6f,0f),
            new Vector3(-13f,0.6f,0f),
            new Vector3(0f,0.6f,13f),
            new Vector3(0f,0.6f,-13f),
        };

        GameObject Prefabs = Instantiate(Friends);
        Prefabs.transform.position = vector3[Random.Range(0,vector3.Length)];
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }







}
