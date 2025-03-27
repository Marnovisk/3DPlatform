using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/UpgradeData", order = 2)]
public class Upgradecriptable : ScriptableObject
{
   [Header("Data")]
    public float value; 
    public UpgradeType upgradeType;
    public WeaponScriptable weapon;

    [Header("Info Data")]
    public string description;
    public UpgradeWeapon _upgradeWeapon;

    public enum UpgradeType
    {
        IncreaseDamage,
        IncreaseRange,
        IncreaseAttackSpeed
    }

    public enum UpgradeWeapon
    {
        Shoot,
        Tornado,
        Area
    }


    public void ApplyUpgrade(GameObject player)
    {
        var playerAttacks = player.GetComponent<playerAttacks>();        
        switch(_upgradeWeapon)
        {
            case UpgradeWeapon.Shoot:
                weapon = playerAttacks.Weapons[0];
                break;
            case UpgradeWeapon.Area:
                weapon = playerAttacks.Weapons[1];
                break;
            case UpgradeWeapon.Tornado:
                weapon = playerAttacks.Weapons[2];
                break;    
        }

        switch (upgradeType)
        {
            case UpgradeType.IncreaseDamage:
                weapon.Damage += (int)value;
                break;
            case UpgradeType.IncreaseRange:
                weapon.Range += value;
                break;
            case UpgradeType.IncreaseAttackSpeed:
                weapon.AttackSpeed -= value;
                break;
        }
    }
}
