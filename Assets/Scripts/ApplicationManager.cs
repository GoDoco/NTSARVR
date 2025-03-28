using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplictionManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform camTransform;
    public int EnemyNumber = 0;
    public float SpawnRange = 3f;
   
   
    void Start()
    {
        SpawnEnemy();
    }
    
    public void SpawnEnemy()
    {
        EnemyNumber += 1;
        for (int i = 1; i < EnemyNumber; i++)
        {
            float x = camTransform.position.x + Random.Range(-SpawnRange, SpawnRange);
            float y = 3; //bloquer l'aléatoire sur l'axe horizontal
            float z = camTransform.position.z + Random.Range(-SpawnRange, SpawnRange);
            Vector3 spawnPos = new Vector3(x, y, z);
            Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
        }
    }

   

    void Update()
    {
        
    }
}
