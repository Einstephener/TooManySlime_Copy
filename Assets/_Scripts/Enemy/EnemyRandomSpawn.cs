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

    private float _enemySpawnNum = 2f; // 몬스터를 스폰할 수 있는 숫자 증가
    private float minSpawnInterval = 1.0f; // 스폰 주기의 최소값
    private float intervalReductionRate = 0.1f; // 스폰 주기를 줄이는 속도
    private bool isSpawning = false; // 코루틴 중복 방지를 위한 플래그

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
