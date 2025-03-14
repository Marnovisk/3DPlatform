using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerAttacks : MonoBehaviour
{
    //private Rigidbody rb;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            EnemyHit();
        }

        if(Input.GetMouseButtonDown(0))
        {
            enemyList.Clear();
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
    }

    void EnemyHit()
    {
        ray = new Ray(this.transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit , 5.0f))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    enemy = hit.transform.gameObject;
                    bool isDamaged = enemyList.Contains(enemy);
                    if(!isDamaged)
                    {
                        enemy.GetComponent<IDamagable>().TakeDamage(15);                                            
                        Debug.Log("Enemy Hit");
                    }                  

                    enemyList.Add(enemy);
                }               
            }            
            Debug.DrawRay(ray.origin, ray.direction * 5.0f , Color.red);
    }

    public void UseshootWeapon()
    {
        float Cooldown = Weapons[0].AttackSpeed;
        if(Time.time >= Cooldown + shootCurrentCooldown)
        {
            Debug.Log(Time.time);
           shootCurrentCooldown = Time.time;
            var projectile = Instantiate(Weapons[0].proj, transform.position, Quaternion.LookRotation(this.transform.forward, this.transform.up));
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
            Destroy(projectile, 10f);   
        }     
    }

}
