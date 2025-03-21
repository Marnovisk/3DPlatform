using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class upgradeScript : MonoBehaviour
{
    public Button up1BTN;
    public Button up2BTN;
    public Button up3BTN;
    public GameObject playerHUD;
    public GameObject player;

    private playerExpirience XPScript;
    
    // Start is called before the first frame update
    void Start()
    {
        XPScript = player.GetComponent<playerExpirience>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FirstUpgrade()
    {
        Debug.Log("UP1");
        playerHUD.SetActive(true);
        XPScript.LevelUped = false;
        this.gameObject.SetActive(false);
    }

    public void SecondUpgrade()
    {
        Debug.Log("UP2");
        playerHUD.SetActive(true);
        XPScript.LevelUped = false;
        this.gameObject.SetActive(false);
    }

    public void ThirdUpgrade()
    {
        Debug.Log("UP3");
        playerHUD.SetActive(true);
        XPScript.LevelUped = false;
        this.gameObject.SetActive(false);
    }
}
