using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Field

    private float _attackDelay = 1f;

    private PlayerMove _playerMove;

    public GameObject Hand; 

    public GameObject[] Weapon;

    private PlayerStatus _playerStatus;

    private Animator _playerAnimator;
    #endregion

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerStatus = GetComponent<PlayerStatus>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_playerMove.CheckEnemy() != null)
        {
            GameObject Enemy = _playerMove.CheckEnemy();
            _playerAnimator.SetTrigger("Attack");
            AttackBySword(Enemy);
        }
    }

    private void AttackBySword(GameObject Enemy)
    {
        if(!Enemy.TryGetComponent(out EnemyStatus enemyStatus))
        {
            Debug.Log("EnemyState Null");
        }

        // ������ �ֱ�.
        StartCoroutine(AttackEnemy(enemyStatus)); 

        ////������ �����ϴ� �޼���.
        //ItemScript nowWeapon = BasicSword.GetComponent<ItemScript>();
    }


    IEnumerator AttackEnemy(EnemyStatus enemyStatus)
    {
        yield return new WaitForSecondsRealtime(_attackDelay);

        //���� �ִϸ��̼�.
        enemyStatus.HitAnimation();

        //������.
        enemyStatus.Health -= _playerStatus.AttackPower;
        _playerStatus.Health -= enemyStatus.AttackPower;
    }
}
