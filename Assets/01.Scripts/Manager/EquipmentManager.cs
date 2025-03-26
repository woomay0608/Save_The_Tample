using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    public GameObject[] EquipItemList = new GameObject[3];

    private static EquipmentManager instance;
    public static EquipmentManager Instance { get { return instance; } set { instance = value; } }

    private List<Equip> equips = new List<Equip>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<Equip> GetEquipList()
    {
        return equips;
    }

    public void AddEquip(Equip equip)
    {
        equips.Add(equip);
    }

    public Equip GetEquip(int Index)
    {
        return equips[Index];
    }

}
