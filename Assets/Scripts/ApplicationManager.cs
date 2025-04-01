using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ApplictionManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform camTransform;
    public int EnemyCap = 5;
    public int EnemyNumber = 1;
    public float SpawnRange = 3f;
    
   
   
    void Start()
    {
        SpawnEnemy();
    }
    
    public void SpawnEnemy()
    {
        if (EnemyNumber<EnemyCap)
        {
            while (EnemyNumber<EnemyCap)
            {
                EnemyNumber += 1;

                float x = camTransform.position.x + Random.Range(-SpawnRange, SpawnRange);
                float y = 3; //bloquer l'aléatoire sur l'axe horizontal
                float z = camTransform.position.z + Random.Range(-SpawnRange, SpawnRange);
                Vector3 spawnPos = new Vector3(x, y, z);
                Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
            }
        }
        else
        {
            
        }
    }

   

    void Update()
    {
        
    }
}
