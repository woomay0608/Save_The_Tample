using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(Die());
    }


    private IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject );
    }

}
