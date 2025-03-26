using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInfo : MonoBehaviour
{

    private Description description;
    private Image Face;


    private void Awake()
    {
        description = GetComponentInChildren<Description>();
        Face = transform.GetChild(3).GetComponent<Image>();
    }

    private void Update()
    {
        Set();
    }

    public void Set()
    {
        if(StageInfoManager.Instance.GetBuild() != null)
        {
            description.SetName(StageInfoManager.Instance.GetBuild().BuildName);
            description.SetDes(StageInfoManager.Instance.GetBuild().Des);
            Face.sprite = StageInfoManager.Instance.GetBuild().Face;
        }else
        {
            description.SetName(string.Empty);
            description.SetDes(string.Empty);
            Face.sprite = null;
        }
    }

   

}
