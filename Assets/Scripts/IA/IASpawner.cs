using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IASpawner : MonoBehaviour
{
    public EnemyScriptable[] EnemiesBrains;
    public GameObject EnemyPrefab;
    public int enemyCount;

    public bool canSpawn = true;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1,5);
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if(canSpawn)
        {
            var enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemy.GetComponent<IAController>().Init(EnemiesBrains[Random.Range(0,EnemiesBrains.Length)]);
            enemyCount += 1;
        }
        
    }

    
}
