using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : Projectile, ITargetWeapon
{
    public Transform target;

    // Start is called before the first frame update
    public override void Init(Transform ptarget)
    {
        base.Init();
        //target = ptarget;
        isReady = true;
        

        Destroy(this.gameObject, 2f);
    }

    public override void Update()
    {
        base.Update();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<IDamagable>().TakeDamage(DamageValue);
        }
        
    }
}
