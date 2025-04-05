using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseScript : MonoBehaviour
{
    public GameObject LevelSelectorHUD;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
                LevelSelectorHUD.SetActive(true);
        }         
    }

}
