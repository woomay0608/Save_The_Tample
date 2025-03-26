using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContent : MonoBehaviour
{
    [SerializeField] private GameObject CommandSlotPrefab;
    [SerializeField] private GameObject EquipSlotPrefab;
    private List<GameObject> CommandSlot = new List<GameObject>();
    private List<GameObject> EquipSlot = new List<GameObject>();

    private bool IsCommandSetOk =false;
    private bool IsFriendsSetOk =false;

    private void Update()
    {
        if (IsCommandSetOk)
        {
            for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommandCount; i++)
            {
                CommandSlot[i].gameObject.GetComponent<Slot>().Set(StageInfoManager.Instance.GetBuild().DicCommand[StageInfoManager.Instance.GetBuild().type][i]);
            }
        }
        if(IsFriendsSetOk)
        {
            for (int i = 0; i < EquipmentManager.Instance.GetEquipList().Count; i++)
            {
                EquipSlot[i].gameObject.GetComponent<EquipSlot>().Set(EquipmentManager.Instance.GetEquip(i));
            }
        }
        
    }
    public void  Set()
    {

        foreach(GameObject slot in CommandSlot)
        {
            slot.SetActive(false);
        }

        foreach (GameObject slot in EquipSlot)
        {
            slot.SetActive(false);
        }


        if (StageInfoManager.Instance.GetBuild() != null)
        {
            IsFriendsSetOk = false;

            if (StageInfoManager.Instance.GetBuild().CommandCount > CommandSlot.Count)
            {
                for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommandCount; i++)
                {
                    CommandSlot.Add(Instantiate(CommandSlotPrefab, transform));
                }
                foreach (GameObject slot in CommandSlot)
                {
                    slot.SetActive(false);
                }
            }
            for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommandCount; i++)
            {
                CommandSlot[i].gameObject.SetActive(true);

            }
            IsCommandSetOk = true;
        }

        if(StageInfoManager.Instance.GetFriend() != null)
        {
            IsCommandSetOk = false;

            if(EquipmentManager.Instance.GetEquipList().Count > EquipSlot.Count  )
            {
                for (int i = 0; i < EquipmentManager.Instance.GetEquipList().Count; i++)
                {
                    EquipSlot.Add(Instantiate(EquipSlotPrefab, transform));
                }
                foreach (GameObject slot in EquipSlot)
                {
                    slot.SetActive(false);
                }
            }
            for (int i = 0; i < EquipmentManager.Instance.GetEquipList().Count; i++)
            {
                EquipSlot[i].gameObject.SetActive(true);

            }

            IsFriendsSetOk = true;
        }
 

    }

}
