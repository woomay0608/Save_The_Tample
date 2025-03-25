using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleTree : Building
{
    public override void SetDic()
    {
        base.SetDic();

        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty,false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));
        buildSO.DicCommand[buildSO.type].Add(new Command(false, string.Empty, 0, 0, string.Empty, false, "Info", Info));

    }

    private void Info()
    {
        
        Debug.Log("on");

    }







}
