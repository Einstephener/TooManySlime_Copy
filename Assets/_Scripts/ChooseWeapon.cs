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
            // 인벤토리에 아이템 추가
            bool wasPickedUp = InventoryManager.Instance.AddItem(ThisWeaponData);
            if (wasPickedUp)
            {
                Destroy(gameObject); // 아이템이 인벤토리에 추가되면 월드에서 삭제
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
