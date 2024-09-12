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
            AttackBySword(_playerMove.CheckEnemy());
        }
    }

    private void AttackBySword(GameObject Enemy)
    {
        //검으로 공격하는 메서드.
        EnemyStatus enemyStatus = Enemy.GetComponent<EnemyStatus>();
        //ItemScript nowWeapon = BasicSword.GetComponent<ItemScript>();
        StartCoroutine(AttackEnemy(enemyStatus)); // 데미지 주기.
    }


    IEnumerator AttackEnemy(EnemyStatus enemyStatus)
    {
        enemyStatus.Health -= _playerStatus.AttackPower;
        _playerStatus.Health -= enemyStatus.AttackPower;
        yield return new WaitForSecondsRealtime(_attackDelay);
    }
}
