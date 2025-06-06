using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : HUD
{
    Slider slider;
    TextMeshProUGUI Text;
    
    private void Awake()
    {
        slider = GetComponent<Slider>();
        Text = GetComponentInChildren<TextMeshProUGUI>();
    }

    protected override void Set()
    {
        slider.value = PlayerDataManager.Instance.PlayerInstance.Health / 20f;
        Text.text = $"{PlayerDataManager.Instance.PlayerInstance.Health}/20";
    }

   
}
