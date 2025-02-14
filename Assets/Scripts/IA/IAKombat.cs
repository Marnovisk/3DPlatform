using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class IAKombat : MonoBehaviour
{
    [Header("MainData")]
    private EnemyScriptable brain;

    [Header("Attack Info")]
    [SerializeField] private bool canAttack;
    [SerializeField] private float currentAttackCooldown;

    private NavMeshAgent nav;

    public void Init(EnemyScriptable pBrain)
    {
        brain = pBrain;
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = brain.AttackRange;
        Debug.Log("At init");
    }
   public bool checkAndAttack(Transform target)
    {
        Debug.Log("Attack");
        CooldownRecovery();
        if(Vector3.Distance(this.transform.position, target.transform.position) <= brain.AttackRange){
            
             if(canAttack)
            {
                Attack(target);
                Debug.Log("Attack s");
            }

            return true;

        } 

        return false;

    }

    public void CooldownRecovery()
    {
        currentAttackCooldown -= Time.deltaTime;
                if (currentAttackCooldown <= 0)
                {
                    canAttack = true;
                    currentAttackCooldown = brain.AttackSpeed;
                }
    }

    void Attack(Transform target)
    {
        canAttack = false;
        target.GetComponent<IDamagable>().TakeDamage(Random.Range(brain.AttackDamage[0],brain.AttackDamage[1]));        
    }
}
