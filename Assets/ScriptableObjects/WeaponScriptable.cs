using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponScriptable : ScriptableObject
{
    [Header("Status Data")]
    public int Damage;
    public float Range;
    public float AttackSpeed;
    public float projectileSpeed;
    public float currentCooldown;
    
    [Header("GFX Data")]
    public GameObject proj;

    [Header("Type Data")]
    public WeaponType type;
    public WeaponKind kind;
}
