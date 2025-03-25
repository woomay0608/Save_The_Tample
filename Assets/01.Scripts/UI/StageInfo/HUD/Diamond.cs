using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Diamond : HUD
{

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    protected override void Set()
    {
        text.text = PlayerDataManager.Instance.PlayerInstance.Diamond.ToString();
    }
}
