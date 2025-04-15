using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerAttacks : MonoBehaviour
{
    //private Rigidbody rb;s
    public GameObject PlayerWeapon;
    public Animator mAnimator;
    float areacurrentCooldown = 0;
    float tornadoCurrentCooldown = 0;
    float shootCurrentCooldown = 0;

    private Ray ray;
    private List<GameObject> enemyList;

    public LayerMask EnemyLayer;

    private GameObject enemy;

    public  List <WeaponScriptable> Weapons;
    private playerAim aim;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        enemyList = new List<GameObject>();        
        aim = GetComponent<playerAim>();
        mAnimator = GetComponentInChildren<Animator>();
        WeaponStarter();
    }

    public void WeaponStarter()
    {
        Debug.Log("Arma Iniciada");
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i] = Instantiate(Weapons[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            mAnimator.SetBool("AttackTrigger", true);            
        }

        if(mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 2.15f && mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            EnemyHit();
        }

        if(mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.10f && mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            enemyList.Clear();
            Debug.Log("Lista Limpa");
        }

        if(Input.GetMouseButtonDown(1))
        {
            UseshootWeapon();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            UseAreaWeapon();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            UseTornadoWeapon();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Weapons[0].Damage += 10;
            Debug.Log("Dano aumentado para: " +  Weapons[0].Damage);
        }
    }

    void EnemyHit()
    {
        //Debug.Log("Esta atacando");

        ray = new Ray(PlayerWeapon.transform.position, transform.forward);
        RaycastHit hit;

        

        if(Physics.Raycast(ray, out hit , 2.5f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                enemy = hit.transform.gameObject;
                bool isDamaged = enemyList.Contains(enemy);
                if(!isDamaged)
                {
                    enemy.GetComponent<IDamagable>().TakeDamage(15);  
                }                  

                enemyList.Add(enemy);
            }               
        }            
        Debug.DrawRay(ray.origin, ray.direction * 2.5f , Color.red);
        mAnimator.SetBool("AttackTrigger", false);

        // if(mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.10f && mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        // {
        //     mAnimator.SetBool("AttackTrigger", false);
        // }
        
    }

    public void UseshootWeapon()
    {
        float Cooldown = Weapons[0].AttackSpeed;
        if(Time.time >= Cooldown + shootCurrentCooldown)
        {
           shootCurrentCooldown = Time.time;
           var projectile = Instantiate(Weapons[0].proj, transform.position, Quaternion.LookRotation(this.transform.forward, this.transform.up));
           projectile.GetComponent<Projectile>().upgradeDamage(Weapons[0].Damage);
           Destroy(projectile, 10f);  
        }      
    }

    public void UseAreaWeapon()
    {
        float Cooldown = Weapons[1].AttackSpeed;
        if(Time.time >= Cooldown + areacurrentCooldown)
        {
            areacurrentCooldown = Time.time;
            var projectile = Instantiate(Weapons[1].proj, aim.hit.point, Quaternion.LookRotation(this.transform.forward, this.transform.up)); 
            projectile.GetComponent<Projectile>().upgradeDamage(Weapons[1].Damage);
            Destroy(projectile, 10f);
        }       
    }

    public void UseTornadoWeapon()
    {
        float Cooldown = Weapons[2].AttackSpeed;
        if(Time.time >= Cooldown + tornadoCurrentCooldown)
        {
            tornadoCurrentCooldown = Time.time;
            var projectile = Instantiate(Weapons[2].proj, transform.position, Quaternion.LookRotation(this.transform.forward, this.transform.up));
            projectile.GetComponent<Projectile>().upgradeDamage(Weapons[2].Damage);
            Destroy(projectile, 10f);   
        }     
    }

}
