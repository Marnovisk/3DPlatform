using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hordeSystem : MonoBehaviour
{
    public List<GameObject> spawnerList = new List<GameObject>();
    public List<IASpawner> spawnerScripList = new List<IASpawner>();
    public Transform BossSpawn;
    public GameObject Zeus;
    public EnemyScriptable ZeusBrains;
    private bool waitForNewHorde = false;
    public int enemySum;
    public int hordeCount = 10;
    public int CurrentHorde = 1;
    public int totalHorde = 3;
    private bool isSpawning = true;
    private bool BossOnScene = false;

    // Start is called before the first frame update
    void Start()
    {        
        for(int i = 0; i < 2; i++)
        {
             IASpawner spawnerScript = spawnerList[i].GetComponent<IASpawner>();    
              if (spawnerScript != null) 
                {
                    spawnerScripList.Add(spawnerScript);
                }    
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySum >= hordeCount)
        {
            StopHorde();
        }
        if(enemySum == 0 && waitForNewHorde)
        {
            StartNewHorde();
        }

        if(isSpawning)
        {
            enemySum = spawnerScripList[0].enemyCount * spawnerScripList.Count;
        }else
        {
            enemySum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
            

    }
    
    void StopHorde()
    {    
        isSpawning = false;
        foreach(var spawner in spawnerScripList)
        {
            spawner.canSpawn = false;                        
        }
        waitForNewHorde = true;
    }

    void StartNewHorde()
    {        
        if(CurrentHorde < totalHorde)
        {
            CurrentHorde += 1;
            waitForNewHorde = false;
            hordeCount += 10;
            foreach(var spawner in spawnerScripList)
            {
                spawner.enemyCount = 0; 
                spawner.canSpawn = true;  
            }
            isSpawning = true;   
        }else
        {
            SpawnBoss();
        }             
    }

    void SpawnBoss()
    {
        if(!BossOnScene)
        {
            var Boss = Instantiate(Zeus, BossSpawn.position, Quaternion.identity);
            Boss.GetComponent<BossController>().Init(ZeusBrains);
            BossOnScene = true;
        }
        
    }
}
