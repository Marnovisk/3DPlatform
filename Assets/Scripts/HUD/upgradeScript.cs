using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class upgradeScript : MonoBehaviour
{
    public List<Button> BTNList;
    public GameObject playerHUD;
    public GameObject player;

    private playerExpirience XPScript;
    public List<Upgradecriptable> Upgrades;

    public WeaponKind _upgradeWeapon;

    
    
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

    public void SetUpgrades()
    {        
        foreach(Button BTN in BTNList)
        {
            var upgradePick = Random.Range(0,Upgrades.Count);
            BTN.GetComponentInChildren<TMP_Text>().text = Upgrades[upgradePick].description;
            BTN.onClick.AddListener(() => FirstUpgrade(upgradePick));
        }
    }

    public void FirstUpgrade(int index)
    {
        Debug.Log("UP Apllied");

        if (index < Upgrades.Count)
        {
            Upgrades[index].ApplyUpgrade(player);
            Debug.Log($"Upgrade aplicado: {Upgrades[index].description}");
        }

        playerHUD.SetActive(true);
        XPScript.LevelUped = false;
        this.gameObject.SetActive(false);
    }
}
