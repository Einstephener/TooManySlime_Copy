using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot: MonoBehaviour
{
    private WeaponData _weapon; // 슬롯에 들어갈 아이템
    public Image Icon;
    public Image LockImg;

    // 아이템 추가
    public void AddItem(WeaponData newWeapon)
    {
        _weapon = newWeapon;

        //잠금 해제, 아이템 아이콘 활성화.
        Icon.enabled = true;
        LockImg.enabled = false;

        Icon.sprite = _weapon.InventoryIcon_Weapon;
    }

    // 슬롯을 비움
    public void ClearSlot()
    {
        //잠금, 아이템 아이콘 비 활성화.
        Icon.enabled = false;
        LockImg.enabled = true;

        _weapon = null;        
    }

    // 슬롯이 비어있는지 확인
    public bool HasItem()
    {
        return _weapon != null;
    }

    // 슬롯에 있는 아이템 반환
    public WeaponData GetItem()
    {
        return _weapon;
    }
}

