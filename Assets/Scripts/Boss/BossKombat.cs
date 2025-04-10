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
    }

    void Attack(Transform target)
    {
        //canAttack = false;
        var projectile = Instantiate(Weapon.proj,target.position,Quaternion.identity);
        projectile.GetComponent<Projectile>().upgradeDamage(Weapon.Damage);
        Debug.Log("Atacando");
        Destroy(projectile, 2f);      
    }
}
