using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Normal,
    Shield,
    Fire,
    Thunder,
}


public class EnemyStatus : BaseStatus
{
    public EnemyType enemyType;


    public override void Die()
    {
        base.Die();
        // ���� ����ϸ� �� óġ ���� ���� (��: ���� ����)
        Debug.Log("���� ����߽��ϴ�. �÷��̾ ����ġ�� ����ϴ�.");
    }
}
