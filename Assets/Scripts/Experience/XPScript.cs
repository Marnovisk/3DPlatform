using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPScript : MonoBehaviour
{
    public int XPAmount;

    private Transform player;

    bool isReady = false;

    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isReady = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isReady) return;
        if(player == null)
        {
            Destroy(this.gameObject);
            return;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){

            other.GetComponent<playerExpirience>().IncreaseXp(XPAmount);
            Destroy(parentObject);
        } 

        
    }
}
