using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    public List<Transform> MovePositions;
    public List<Vector3> MPositions;
    private Vector3 Position1 = new Vector3(4,2,5);
    private Vector3 Position2 = new Vector3(-5,2,5);
    private Vector3 Position3 = new Vector3(0,0,0);

    private float MoveTime = 2f;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();        
    }

    public void Init(EnemyScriptable brain)
    {
        nav.speed = brain.speed;
        MPositions.Add(Position1);
        MPositions.Add(Position2);
        MPositions.Add(Position3);
    }

    public bool BossMove(Transform target)
    {
        if(!target) return false;
        // if(Vector3.Distance(transform.position, target.position) > nav.stoppingDistance)
        // {
            //nav.SetDestination(MovePositions[Random.Range(0,1)].position);
            float Cooldown = 3f;            
            if(Time.time >= Cooldown + MoveTime)
            {
                MoveTime = Time.time;
                this.gameObject.transform.position = MPositions[Random.Range(0,2)];
                Debug.Log("Movendo");
            }
            
            return false;
        // }
        // else
        // {
        //     return false;
        // }
        
    }
    
}
