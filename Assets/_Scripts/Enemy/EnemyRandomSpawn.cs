using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public Transform[] spawnPoints; // ���� ��ȯ�� ��ġ�� (�ִ� 5��)
    public GameObject Parent;

    private float _enemySpawnNum = 2f; // ���͸� ������ �� �ִ� ���� ����
    private float spawnInterval; // ���� �ֱ� �ʱⰪ
    private float minSpawnInterval = 1.0f; // ���� �ֱ��� �ּҰ�
    private float intervalReductionRate = 0.1f; // ���� �ֱ⸦ ���̴� �ӵ�
    private bool isSpawning = false; // �ڷ�ƾ �ߺ� ������ ���� �÷���

    private void Start()
    {
        // �ʱ� �ڷ�ƾ ����
        StartCoroutine(SpawnEnemies());
        spawnInterval = 5f;
    }

    private void Update()
    {
        _enemySpawnNum += Time.deltaTime;


        // ���� spawnInterval�� 0 ���ϰ� �Ǹ� �ٽ� ���� �ڷ�ƾ ����
        if (!isSpawning)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        isSpawning = true;

        // �� ���� ���� ���� ���ݸ�ŭ ���
        yield return new WaitForSeconds(spawnInterval);

        spawnInterval -= Time.deltaTime; // ���� �ֱ� �ʱⰪ
        if (spawnInterval < minSpawnInterval)
        {
            spawnInterval = minSpawnInterval;
        }

        // ���� ����Ʈ���� ���� ����
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
        // ���� ���� �����Ͽ� Ȯ���� ���� ���� ����
        float randomValue = Random.Range(0f, 100f); // 0 ~ 100 ������ ��

        if (randomValue <= 90f)  // 90% Ȯ���� ù ��° ��
        {
            return EnemyPrefabs[0];
        }
        else if (randomValue <= 98f)  // 8% Ȯ���� �� ��° ��
        {
            return EnemyPrefabs[1];
        }
        else  // 2% Ȯ���� �� ��° ��
        {
            return EnemyPrefabs[2];
        }
    }
}
