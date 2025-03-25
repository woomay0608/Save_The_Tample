using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Silhum : MonoBehaviour
{

    public float Health = 100f;
    public GameObject Destination;
    public NavMeshAgent Agent;


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Agent.SetDestination(Destination.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Health -= 10f;
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
