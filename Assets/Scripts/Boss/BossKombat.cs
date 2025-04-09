using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossKombat : MonoBehaviour
{

    [Header("MainData")]
    private EnemyScriptable brain;

    [Header("Attack Info")]
    //[SerializeField] private bool canAttack;
    [SerializeField] private float currentAttackCooldown;
    public WeaponScriptable Weapon;
    private float AttackTime = 0f;

    private NavMeshAgent nav;

    public void Init(EnemyScriptable pBrain)
    {
        brain = pBrain;
        nav = GetComponent<NavMeshAgent>();
    }

    public bool checkAndAttack(Transform target)
    {
        if (target == null) return false;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= brain.AttackRange && Time.time >= AttackTime + brain.AttackSpeed)
        {
            AttackTime = Time.time;
            Attack(target);
            return true;
        }

        return false;
        
        // float Cooldown = 1f;
        // if(Time.time >= Cooldown + AttackTime)
        // {
        //     AttackTime = Time.time;
        //     Attack(target);
        // }
        
        // return false;
    }

    void Attack(Transform target)
    {
        //canAttack = false;
        Instantiate(Weapon.proj,target.position,Quaternion.identity);
        Debug.Log("Atacando");
        //target.GetComponent<IDamagable>().TakeDamage(Random.Range(brain.AttackDamage[0],brain.AttackDamage[1]));        
    }
}
