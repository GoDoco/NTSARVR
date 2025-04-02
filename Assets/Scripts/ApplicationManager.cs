using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ApplictionManager : MonoBehaviour
{
    public GameObject VegetablePrefab;
    public GameObject BombPrefab;
    public GameObject SilverPrefab;
    public GameObject GoldPrefab;
    public Transform camTransform;
    public int EnemyCap = 5;
    public int EnemyNumber = 1;
    public float SpawnRange = 3f;
    private System.Random Rand;
    public int Difficulty;
   
   
    void Start()
    {
        Rand = new System.Random();
        SpawnEnemy();
        EnemyCap*=Difficulty;
    }
    
    public void SpawnEnemy()
    {
        if (EnemyNumber<EnemyCap)
        {
            while (EnemyNumber<EnemyCap)
            {
                

                float x = camTransform.position.x + Random.Range(-SpawnRange, SpawnRange);
                float y = 3; //bloquer l'aléatoire sur l'axe horizontal
                float z = camTransform.position.z + Random.Range(-SpawnRange, SpawnRange);
                Vector3 spawnPos = new Vector3(x, y, z);
                EnemyNumber += 1;
                int rand = Rand.Next(10);
                if (rand <= 2)
                {
                    Instantiate(BombPrefab, spawnPos, Quaternion.identity);
                }
                else if (rand <= 4)
                {
                    Instantiate(SilverPrefab, spawnPos, Quaternion.identity);
                }
                else if (rand == 5)
                {
                    Instantiate(GoldPrefab, spawnPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(VegetablePrefab, spawnPos, Quaternion.identity);
                }
                
                
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
