using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContent : MonoBehaviour
{
    [SerializeField] private GameObject SlotPrefab;
    private List<GameObject> slots = new List<GameObject>();
    public void Set()
    {
        foreach(GameObject slot in slots)
        {
            slot.SetActive(false);
        }
        

        if (StageInfoManager.Instance.GetBuild() != null)
        {
            if (StageInfoManager.Instance.GetBuild().CommondCount > slots.Count)
            {

                for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommondCount; i++)
                {
                    slots.Add(Instantiate(SlotPrefab, transform));
                }
            }
            else
            {
                for (int i = 0; i < StageInfoManager.Instance.GetBuild().CommondCount; i++)
                {
                    slots[i].gameObject.SetActive(true);
                }

            }
        }
    }

}
