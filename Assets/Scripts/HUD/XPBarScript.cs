using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class XPBarScript : MonoBehaviour
{

    public Slider XpBar;
    public float maxXP = 100;
    public float XP;
    public GameObject player;
    private playerExpirience XPScript;
    // Start is called before the first frame update
    void Start()
    {
        XPScript = player.GetComponent<playerExpirience>();
    }

    // Update is called once per frame
    void Update()
    {
        XP = XPScript.currentExpirience;
        if(XpBar.value != XP)
        {
            XpBar.value = XP;
            XpBar.maxValue = XPScript.NeededExpirience;
        }

        
            
        
    }
}
