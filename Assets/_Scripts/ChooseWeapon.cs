using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    public WeaponData ThisWeaponData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ThisWeaponData != null && collision.CompareTag("Player"))
        {
            PlayerAttack player = collision.GetComponent<PlayerAttack>();
            CheckAndSpawnWeapon(ThisWeaponData, player);
            // �κ��丮�� ������ �߰�
            bool wasPickedUp = InventoryManager.Instance.AddItem(ThisWeaponData);
            if (wasPickedUp)
            {
                Destroy(gameObject); // �������� �κ��丮�� �߰��Ǹ� ���忡�� ����
            }
        }
    }

    private void CheckAndSpawnWeapon(WeaponData weaponData, PlayerAttack player)
    {
        if (weaponData.ThisWeapon == WeaponType.NinjaStar)
        {
            player.SpawnStar(weaponData);
        }
    }
}
