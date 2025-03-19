using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HordeCounterScript : MonoBehaviour
{
    public TMP_Text HordaTotal;
    public TMP_Text HordaAtual;
    public GameObject hordasController;
    private hordeSystem HordaScript;

    // Start is called before the first frame update
    void Start()
    {
        HordaScript = hordasController.GetComponent<hordeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HordaTotal.text != HordaScript.hordeCount.ToString())
        {
            HordaTotal.SetText(HordaScript.hordeCount.ToString());
        }
        
        HordaAtual.SetText(HordaScript.enemySum.ToString());
    }
}
