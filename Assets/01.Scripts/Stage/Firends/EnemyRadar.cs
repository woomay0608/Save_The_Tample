using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRadar : MonoBehaviour
{

    private Friends friends;

    private void Start()
    {
        friends = GetComponentInParent<Friends>();
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            friends.Target = other.gameObject;
            friends.IsInRange = true;
        }
      
    }





}
