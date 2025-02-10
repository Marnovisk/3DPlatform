using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttacks : MonoBehaviour
{
    private Rigidbody rb;
    private Ray ray;

    public LayerMask EnemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            ray = new Ray(rb.position, transform.forward);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit , 5.0f))
            {
                Debug.Log(hit.point);                
            }            
            Debug.DrawRay(ray.origin, ray.direction * 5.0f , Color.red);
        }
    }
}
