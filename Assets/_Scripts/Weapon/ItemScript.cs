using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon
{
    Sword,
    Bow,
    NinjaStar,
}
public enum Properties
{
    Fire,
    Water,
}


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/ItemData/WeaponData", order = 1)]
public class ItemScript : ScriptableObject
{
    public Weapon ThisWeapon;
    public Properties ThisProperties;
    public GameObject Prefab;

    public float WeaponAttackPower;



}
