using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silhum : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Buliding"))
        {
            Destroy(this.gameObject);
        }
    }
   

}
