using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    public List<Transform> MovePositions;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();        
    }

    public void Init(EnemyScriptable brain)
    {
        nav.speed = brain.speed;
    }

    public bool BossMove(Transform target)
    {
        if(!target) return false;
        if(Vector3.Distance(transform.position, target.position) > nav.stoppingDistance)
        {
            nav.SetDestination(MovePositions[Random.Range(0,1)].position);
            return true;
        }
        else
        {
            return false;
        }
        
    }
    
}
