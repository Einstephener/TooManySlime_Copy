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
    private float moveSpeed = 5f;
    private float minY = -5f;

    private void Update()
    {
        if (!GameManager.Instance.isFight)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if(transform.position.y < minY)
            {
                Die();
            }
        }
    }


    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
