using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStatusManager : MonoBehaviour, IDamagable
{
    public Status status;
    public event Action OnTakeDamage;

    public GameObject XP;

    private void Start()
    {
        
    }

    public void InitStatus(Status pStatus)
    {
        status.Health = pStatus.Health;
        status.Armor = pStatus.Armor;
        status.MagicResist = pStatus.MagicResist;
    }

    private void Update()   
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(Random.Range(1,5));
        }
    }
    public void TakeDamage(int amount)
    {

        status.Health -= amount;

        Debug.Log("Dano Tomado: " + amount);

        OnTakeDamage?.Invoke();

        //Anima Dano
        //Sangue
        //Num Dnao

        if(status.Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(XP, transform.position, Quaternion.identity);     
        Destroy(this.gameObject);
    }
}
