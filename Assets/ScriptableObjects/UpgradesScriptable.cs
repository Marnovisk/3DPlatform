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

    public enum UpgradeType
    {
        IncreaseDamage,
        IncreaseRange,
        IncreaseAttackSpeed
    }

    public void ApplyUpgrade(WeaponScriptable weapon)
    {
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
