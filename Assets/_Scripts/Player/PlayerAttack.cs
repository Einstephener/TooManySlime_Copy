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
        //������ �����ϴ� �޼���.
        EnemyStatus enemyStatus = Enemy.GetComponent<EnemyStatus>();
        //ItemScript nowWeapon = BasicSword.GetComponent<ItemScript>();
        StartCoroutine(AttackEnemy(enemyStatus)); // ������ �ֱ�.
    }


    IEnumerator AttackEnemy(EnemyStatus enemyStatus)
    {
        enemyStatus.Health -= _playerStatus.AttackPower;
        _playerStatus.Health -= enemyStatus.AttackPower;
        yield return new WaitForSecondsRealtime(_attackDelay);
    }
}
