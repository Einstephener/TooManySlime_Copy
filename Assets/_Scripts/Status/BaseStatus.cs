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

    // ��� ó��
    public virtual void Die()
    {
        // ��� �� ó�� (��: ������Ʈ ��Ȱ��ȭ ��)
    }
}
