using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Building
{

    public int indexs = 0;
   
    public override void SetDic()
    {
        base.SetDic();
        //bool IsLock, string Locktext, float LockMoney, float CoolTime, string CoolTimeText, bool IsCoolTime, string MethodName, Action action)

        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "500G", 500, 0, false, "Shoes", InstantiateShoes));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "500G", 500, 0, false, "Glove", InstantiateGlove));
        buildSO.DicCommand[buildSO.type].Add(new Command(true, "500G", 500, 0, false, "Potion", InstantiatePotion));


        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        //buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));

    }

    private void Info()
    {
        string s = "Buy Item!";
        UIManager.Instance.POPInstantiate(s, UIManager.Instance.uIPOPUP.GetComponent<UIPOPUP>().Down);

    }

    private void InstantiateShoes()
    {
        GameObject game = Instantiate(EquipmentManager.Instance.EquipItemList[2], EquipmentManager.Instance.transform);
        game.GetComponent<Equip>().index = indexs;
        indexs++;
        EquipmentManager.Instance.AddEquip(game.GetComponent<Equip>());
    }
    private void InstantiateGlove()
    {
        GameObject game = Instantiate(EquipmentManager.Instance.EquipItemList[0], EquipmentManager.Instance.transform);
        game.GetComponent<Equip>().index = indexs;
        indexs++;
        EquipmentManager.Instance.AddEquip(game.GetComponent<Equip>());
    }
    private void InstantiatePotion()
    {
        GameObject game = Instantiate(EquipmentManager.Instance.EquipItemList[1], EquipmentManager.Instance.transform);
        game.GetComponent<Equip>().index = indexs;
        indexs++;
        EquipmentManager.Instance.AddEquip(game.GetComponent<Equip>());
    }


}
