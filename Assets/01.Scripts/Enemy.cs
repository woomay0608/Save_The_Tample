using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private float Health = 100f;
    private GameObject Destination;
    private NavMeshAgent Agent;


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Destination = FindAnyObjectByType<TempleTree>().gameObject;

        Agent.SetDestination(Destination.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Health -= other.transform.GetComponentInParent<FriendsStat>().AllDamage;
            Death(other);
        }
    }
   

    public void Death(Collider other)
    {
        if (Health <= 0)
        {
            other.GetComponentInParent<Friends>().Target = null;
            Destroy(gameObject);
        }
    }



}
