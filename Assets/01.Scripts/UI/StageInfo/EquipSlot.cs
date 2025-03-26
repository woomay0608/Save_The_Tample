using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{

    [SerializeField] GameObject Active;
    private TextMeshProUGUI Activetext;
    private Button ActiveButton;

    private GameObject Equip;
    private GameObject OtherEquip;

    private void Awake()
    {
        Active = transform.GetChild(0).gameObject;
        Activetext = Active.GetComponentInChildren<TextMeshProUGUI>();
        ActiveButton = Active.GetComponentInChildren<Button>();

        Equip = transform.GetChild(1).gameObject;
        OtherEquip = transform.GetChild(2).gameObject;

    }

    public void Set(Equip equip)
    {
        ActiveButton.onClick.RemoveAllListeners();

        Activetext.text = equip.EquipSo.Name;


        if(equip.IsEquip)
        {
            bool IsFound = false;
            foreach(Equip eq in StageInfoManager.Instance.GetFriend().equipList.ToList())
            {
                if (eq.index == equip.index)
                {
                    IsFound = true;
                    break;
                }
            }

            if(IsFound)
            {
                OtherEquip.SetActive(false);
                Equip.SetActive(true);
            }
            else
            {
                OtherEquip.SetActive(true);
                Equip.SetActive(false);
            }
        }
        else
        {
            OtherEquip.SetActive(false);
            Equip.SetActive(false);
      
        }

        ActiveButton.onClick.AddListener(() => { EquipItem(equip); });



    }

    private void EquipItem(Equip equip)
    {
        if(equip.IsEquip) 
        {
            foreach (Equip eq in StageInfoManager.Instance.GetFriend().equipList.ToList())
            {
                if(eq.index == equip.index)
                {
                    eq.IsEquip = false;
                    StageInfoManager.Instance.GetFriend().equipList.Remove(eq);
                }
            }
        }
        else
        {
            equip.IsEquip = true;
            StageInfoManager.Instance.GetFriend().equipList.Add(equip);
        }


        //foreach (Equip eq in StageInfoManager.Instance.GetFriend().equipList)
        //{
        //    if (eq == equip)
        //    {
        //        if(eq.IsEquip) 
        //        {
        //            eq.IsEquip = false;
        //            StageInfoManager.Instance.GetFriend().equipList.Remove(eq);
        //        }
        //    }
        //}
    }



}
