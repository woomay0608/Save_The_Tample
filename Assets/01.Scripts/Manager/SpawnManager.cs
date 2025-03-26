using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject SpawnPoint;
    public List<BoxCollider> SpawnPoints = new List<BoxCollider>();
    public GameObject Enemy;
    public float SpawnCoolTime = 10f;
    public int SpawnCount = 3;
    float time;

    private static SpawnManager instance;
    public static SpawnManager Instance { get { return instance; } set { instance = value; } }

  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            SpawnPoints.Add(SpawnPoint.transform.GetChild(i).GetComponent<BoxCollider>());
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > SpawnCoolTime)
        {
            time -= SpawnCoolTime;
            Spawn();
        }
    }

    public void Spawn()
    {


        for (int i = 0; i < SpawnCount; i++)
        {
            BoxCollider Spot = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
            Vector3 Pos = new Vector3(
        Random.Range(Spot.bounds.min.x, Spot.bounds.max.x),
        0.97f,
        Random.Range(Spot.bounds.min.z, Spot.bounds.max.z));

            GameObject Ene = Instantiate(Enemy, Pos, Quaternion.identity);
        }



    }


   
}
