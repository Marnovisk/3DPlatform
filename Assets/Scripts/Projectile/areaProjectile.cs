using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaProjectile : Projectile, ITargetWeapon
{
    public Transform target;

    // Start is called before the first frame update
    public override void Init(Transform ptarget)
    {
        base.Init();
        //target = ptarget;
        isReady = true;
        

        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;

        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<IDamagable>().TakeDamage(DamageValue);
        }
        
    }
}
