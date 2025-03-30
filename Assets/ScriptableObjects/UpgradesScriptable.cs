using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/UpgradeData", order = 2)]
public class Upgradecriptable : ScriptableObject
{
   [Header("Data")]
    public float value; 
    public UpgradeType upgradeType;
    private WeaponScriptable weapon;

    [Header("Info Data")]
    public string description;
    public WeaponKind _upgradeWeapon;
    public void ApplyUpgrade(GameObject player)
    {
        var playerAttacks = player.GetComponent<playerAttacks>();        
        switch(_upgradeWeapon)
        {
            case WeaponKind.Shoot:
                weapon = playerAttacks.Weapons[0];
                break;
            case WeaponKind.Area:
                weapon = playerAttacks.Weapons[1];
                break;
            case WeaponKind.Tornado:
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
