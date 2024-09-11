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
        // 적이 사망하면 적 처치 로직 실행 (예: 보상 지급)
        Debug.Log("적이 사망했습니다. 플레이어가 경험치를 얻습니다.");
    }
}
