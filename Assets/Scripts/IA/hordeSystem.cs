using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hordeSystem : MonoBehaviour
{
    public List<GameObject> spawnerList = new List<GameObject>();
    public List<IASpawner> spawnerScripList = new List<IASpawner>();
    private bool waitForNewHorde = false;
    public int enemySum;
    public int hordeCount = 10;

    // Start is called before the first frame update
    void Start()
    {        
        for(int i = 0; i < 2; i++)
        {
            Debug.Log("EnemyAdded");
             IASpawner spawnerScript = spawnerList[i].GetComponent<IASpawner>();    
              if (spawnerScript != null) 
                {
                    spawnerScripList.Add(spawnerScript);
                    Debug.Log("EnemyAdded: " + spawnerList[i].name);
                }    
        }   
    }

    // Update is called once per frame
    void Update()
    {
        enemySum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Quantidade de inimigos: " + enemySum);
        if(enemySum >= hordeCount)
        {
            StopHorde();
        }
        if(enemySum == 0 && waitForNewHorde)
        {
            StartNewHorde();
        }

    }
    
    void StopHorde()
    {
        foreach(var spawner in spawnerScripList)
        {
            spawner.canSpawn = false;            
        }
        waitForNewHorde = true;
    }

    void StartNewHorde()
    {
        waitForNewHorde = false;
        hordeCount += 10;
        foreach(var spawner in spawnerScripList)
        {
            spawner.canSpawn = true;            
        }
        
    }
}
