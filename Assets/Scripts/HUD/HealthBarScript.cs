using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public Slider HealthBar;
    public float maxHealth = 100;
    public float Health;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health = player.GetComponent<CharacterStatusManager>().status.Health;
        if(HealthBar.value != Health)
        {
            HealthBar.value = Health;
        }
    }
}
