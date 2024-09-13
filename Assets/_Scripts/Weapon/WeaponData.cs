using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WeaponType
{
    Sword,
    Bow,
    NinjaStar,
}
public enum Properties
{
    Normal,
    Fire,
    Water,
}


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/ItemData/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public WeaponType ThisWeapon;
    public Properties ThisProperties;
    public GameObject Prefab;
    public Sprite InventoryIcon_Weapon;

    public float WeaponAttackPower;

}
