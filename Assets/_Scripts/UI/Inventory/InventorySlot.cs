using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot: MonoBehaviour
{
    private WeaponData _weapon; // ���Կ� �� ������
    public Image Icon;
    public Image LockImg;

    // ������ �߰�
    public void AddItem(WeaponData newWeapon)
    {
        _weapon = newWeapon;

        //��� ����, ������ ������ Ȱ��ȭ.
        Icon.enabled = true;
        LockImg.enabled = false;

        Icon.sprite = _weapon.InventoryIcon_Weapon;
    }

    // ������ ���
    public void ClearSlot()
    {
        //���, ������ ������ �� Ȱ��ȭ.
        Icon.enabled = false;
        LockImg.enabled = true;

        _weapon = null;        
    }

    // ������ ����ִ��� Ȯ��
    public bool HasItem()
    {
        return _weapon != null;
    }

    // ���Կ� �ִ� ������ ��ȯ
    public WeaponData GetItem()
    {
        return _weapon;
    }
}

