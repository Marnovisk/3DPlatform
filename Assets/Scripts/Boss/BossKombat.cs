using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossKombat : MonoBehaviour
{

    [Header("MainData")]
    private EnemyScriptable brain;

    [Header("Attack Info")]
    [SerializeField] private bool canAttack;
    [SerializeField] private float currentAttackCooldown;
    public WeaponScriptable Weapon;

    private NavMeshAgent nav;

    public void Init(EnemyScriptable pBrain)
    {
        brain = pBrain;
        nav = GetComponent<NavMeshAgent>();
    }

    public bool checkAndAttack(Transform target)
    {
        if(Vector3.Distance(this.transform.position, target.transform.position) <= brain.AttackRange){
            
            if(canAttack)
            {
                Attack(target);
            }

            return true;

        } 

        return false;
    }

    void Attack(Transform target)
    {
        canAttack = false;
        Instantiate(Weapon.proj,target);
        //target.GetComponent<IDamagable>().TakeDamage(Random.Range(brain.AttackDamage[0],brain.AttackDamage[1]));        
    }
}
