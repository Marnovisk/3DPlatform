using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAim : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;
    public Ray ray;

    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);            

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    //Debug.Log(hit.point);
                }
            }
        
    }
}
