using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public float[] spawnPointsX = {-2f, -1f, 0f, 1f, 2f};
    private float spawnInterval;
    public GameObject Parent;

    private float _enemySpawnNum = 2f; // ���͸� ������ �� �ִ� ���� ����
    private float minSpawnInterval = 1.0f; // ���� �ֱ��� �ּҰ�
    private float intervalReductionRate = 0.1f; // ���� �ֱ⸦ ���̴� �ӵ�
    private bool isSpawning = false; // �ڷ�ƾ �ߺ� ������ ���� �÷���

    private void Start()
    {
        StartEnemyRoutine();
    }

    private void StartEnemyRoutine()
    {
        StartCoroutine("EnemySpawnRoutine");
    }

    IEnumerator EnemySpawnRoutine()
    {
        yield return new WaitForSeconds(3f);

        int spawnCount = 0;
        int enemyIndex = 0;
        while (true)
        {
            foreach (float posX in spawnPointsX)
            {
                int index = Random.Range(0, enemyIndex);
                SpawnEnemy(posX, index);
            }
            spawnCount++;
            if (spawnCount % 10 == 0)
            {
                enemyIndex++;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }


    private void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if(Random.Range(0,5) == 0)
        {
            index += 1;
        }


        if(index >= EnemyPrefabs.Length)
        {
            index = EnemyPrefabs.Length - 1;
        }

        Instantiate(EnemyPrefabs[index], spawnPos, Quaternion.identity);
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
