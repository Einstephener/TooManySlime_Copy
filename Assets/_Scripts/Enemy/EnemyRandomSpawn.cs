using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public Transform[] spawnPoints; // 적이 소환될 위치들 (최대 5개)
    public GameObject Parent;

    private float _enemySpawnNum = 2f; // 몬스터를 스폰할 수 있는 숫자 증가
    private float spawnInterval; // 스폰 주기 초기값
    private float minSpawnInterval = 1.0f; // 스폰 주기의 최소값
    private float intervalReductionRate = 0.1f; // 스폰 주기를 줄이는 속도
    private bool isSpawning = false; // 코루틴 중복 방지를 위한 플래그

    private void Start()
    {
        // 초기 코루틴 시작
        StartCoroutine(SpawnEnemies());
        spawnInterval = 5f;
    }

    private void Update()
    {
        _enemySpawnNum += Time.deltaTime;


        // 만약 spawnInterval이 0 이하가 되면 다시 스폰 코루틴 실행
        if (!isSpawning)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        isSpawning = true;

        // 적 스폰 전에 스폰 간격만큼 대기
        yield return new WaitForSeconds(spawnInterval);

        spawnInterval -= Time.deltaTime; // 스폰 주기 초기값
        if (spawnInterval < minSpawnInterval)
        {
            spawnInterval = minSpawnInterval;
        }

        // 스폰 포인트마다 적을 생성
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            float randomValue = Random.Range(0, _enemySpawnNum);
            if (randomValue >= 1)
            {
                Instantiate(SelectRandomEnemy(), spawnPoints[i].position, spawnPoints[i].rotation, Parent.transform);
            }
        }

        isSpawning = false;
    }

    private GameObject SelectRandomEnemy()
    {
        // 랜덤 값을 생성하여 확률에 따라 적을 선택
        float randomValue = Random.Range(0f, 100f); // 0 ~ 100 사이의 값

        if (randomValue <= 90f)  // 90% 확률로 첫 번째 적
        {
            return EnemyPrefabs[0];
        }
        else if (randomValue <= 98f)  // 8% 확률로 두 번째 적
        {
            return EnemyPrefabs[1];
        }
        else  // 2% 확률로 세 번째 적
        {
            return EnemyPrefabs[2];
        }
    }
}
