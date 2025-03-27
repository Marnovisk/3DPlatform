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
    public List<Upgradecriptable> Upgrades;

    public UpgradeWeapon _upgradeWeapon;

    public enum UpgradeWeapon
    {
        Shoot,
        Tornado,
        Area
    }
    
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

    public void FirstUpgrade(int index)
    {
        Debug.Log("UP1");
        player.GetComponent<playerAttacks>().WeaponStarter();
        var arma = player.GetComponent<playerAttacks>().Weapons[0];

        if (index < Upgrades.Count)
        {
            Upgrades[index].ApplyUpgrade(player);
            Debug.Log($"Upgrade aplicado: {Upgrades[index].description}");
        }

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
