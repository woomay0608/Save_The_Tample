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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != transform.tag)
        {

            NavMeshPath navMeshPath = new NavMeshPath();
            if(NavMesh.CalculatePath(friends.transform.position, other.transform.position, NavMesh.AllAreas, navMeshPath))
            {
                friends.Target = other.gameObject;
                friends.IsInRange = true;
            }
            else
            {
                friends.IsInRange = false;
            }
 
            
        }
        else
        {
            friends.IsInRange = false;
            
        }
    }

}
