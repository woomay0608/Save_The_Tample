using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContent : MonoBehaviour
{
    [SerializeField] private GameObject SlotPrefab;
    private List<GameObject> slots = new List<GameObject>();

    private bool IsSetok =false;

    private void Update()
    {
        if (IsSetok)
        {
            for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommandCount; i++)
            {
                slots[i].gameObject.GetComponent<Slot>().Set(StageInfoManager.Instance.GetBuild().DicCommand[StageInfoManager.Instance.GetBuild().type][i]);
                Debug.Log("CantSet3");
            }
        }
        
    }
    public void  Set()
    {
        Debug.Log("CantSet");
        foreach(GameObject slot in slots)
        {
            slot.SetActive(false);
        }
        

        if (StageInfoManager.Instance.GetBuild() != null)
        {
            Debug.Log("CantSet");
            if (StageInfoManager.Instance.GetBuild().CommandCount > slots.Count)
            {

                for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommandCount; i++)
                {
                    slots.Add(Instantiate(SlotPrefab, transform));
                    Debug.Log("CantSet1");
                }
            }
            else
            {
                for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommandCount; i++)
                {
                    slots[i].gameObject.SetActive(true);
                    Debug.Log("CantSet2");
                }

            }
        }


        for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommandCount; i++)
        {
            slots[i].gameObject.GetComponent<Slot>().Set(StageInfoManager.Instance.GetBuild().DicCommand[StageInfoManager.Instance.GetBuild().type][i]);
            Debug.Log("CantSet3");
        }

        IsSetok = true;

    }

}
