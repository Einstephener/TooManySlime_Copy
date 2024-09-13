using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            PlayerAttack player = gameObject.GetComponentInParent<PlayerAttack>();
            PlayerStatus playerStatus = gameObject.GetComponentInParent<PlayerStatus>();
            EnemyStatus enemyStatus = collision.GetComponent<EnemyStatus>();

            enemyStatus.TakeDamage(playerStatus.AttackPower);
        }
    }
}
