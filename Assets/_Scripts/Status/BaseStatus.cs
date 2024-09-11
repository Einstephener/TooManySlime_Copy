using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatus : MonoBehaviour
{
    public float Health;
    public float AttackPower;
    public float Defense;

    public virtual void InitializeStatus(float health, float attackPower, float defense)
    {
        this.Health = health;
        this.AttackPower = attackPower;
        this.Defense = defense;
    }

    public virtual void TakeDamage(float damage)
    {
        float finalDamage = Mathf.Max(0, damage - Defense);
        Health -= finalDamage;

        if (Health <= 0)
        {
            Die();
        }
    }

    // 사망 처리
    public virtual void Die()
    {
        // 사망 시 처리 (예: 오브젝트 비활성화 등)
    }
}
