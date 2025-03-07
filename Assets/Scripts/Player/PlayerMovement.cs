using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rig;
    private Vector3 direction;
    private NavMeshAgent nav;

    private playerAim aim;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        aim = GetComponent<playerAim>();
        nav.updateRotation = false;
    }

    private void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 currentPos = this.transform.position;
        Vector3 _dir = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        direction = currentPos + _dir;
        

        if(Input.GetKeyUp(KeyCode.Space))
        {
            
        }
    }

    private void FixedUpdate()
    {        
        nav.SetDestination(direction);
        Vector3 LookAt = aim.hit.point - transform.position;
        transform.rotation = Quaternion.LookRotation(LookAt);
    }
}
