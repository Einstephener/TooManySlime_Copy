using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Field

    private float _attackDelay = 1f;

    private PlayerMove _playerMove;

    public GameObject BasicSword; 

    public GameObject[] Weapon;

    private PlayerStatus _playerStatus;
    #endregion

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerStatus = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        if (_playerMove.CheckEnemy() != null)
        {
            GameObject Enemy = _playerMove.CheckEnemy();
            AttackBySword(Enemy);
        }
    }

    private void AttackBySword(GameObject Enemy)
    {
        if(Enemy.TryGetComponent(out EnemyStatus enemyStatus))
        {
            Debug.Log("EnemyState");
        }

        StartCoroutine(AttackEnemy(enemyStatus)); // 데미지 주기.

        ////검으로 공격하는 메서드.
        //ItemScript nowWeapon = BasicSword.GetComponent<ItemScript>();
    }


    IEnumerator AttackEnemy(EnemyStatus enemyStatus)
    {
        yield return new WaitForSecondsRealtime(_attackDelay);

        enemyStatus.HitAnimation();

        enemyStatus.Health -= _playerStatus.AttackPower;
        _playerStatus.Health -= enemyStatus.AttackPower;
    }
}
