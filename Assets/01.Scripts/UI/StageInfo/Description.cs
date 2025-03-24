using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Description : MonoBehaviour
{

    private TextMeshProUGUI Name;
    private TextMeshProUGUI Des;

    private void Awake()
    {
        Name = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Des = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void SetName(string text)
    {
        Name.text = text;
    }
    public void SetDes(string text)
    {
        Des.text = text;
    }

}
