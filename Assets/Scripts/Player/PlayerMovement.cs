using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Animator mAnimator;
    private Rigidbody rig;
    private Vector3 direction;
    private NavMeshAgent nav;

    private playerAim aim;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        aim = GetComponent<playerAim>();        
        mAnimator = GetComponentInChildren<Animator>();
        nav.updateRotation = false;
    }

    private void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 currentPos = this.transform.position;
        Vector3 _dir = new Vector3(hor,0,ver);
        direction = currentPos + _dir;

        if(hor != 0 || ver != 0)
        {
            mAnimator.SetBool("IsWalking", true);
            Debug.Log("Walk");
        }
        else
        {
            mAnimator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {        
        nav.SetDestination(direction);
        Vector3 LookAt = aim.hit.point - transform.position;
        transform.rotation = Quaternion.LookRotation(LookAt);
    }
}
