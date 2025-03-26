using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCommand : MonoBehaviour
{
    private ScrollContent scrollContent;
    void Start()
    {
        scrollContent = GetComponentInChildren<ScrollContent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
