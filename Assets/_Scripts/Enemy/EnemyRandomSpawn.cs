using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour
{
    #region Field

    public GameObject[] EnemyPrefabs;
    public GameObject[] WeaponChoosePrefabs;
    public GameObject WeaponChoice;
    private float[] _spawnPointsX = { -2f, -1f, 0f, 1f, 2f };
    private float[] _coroutineInterval = { 0.5f, 1f, 1.5f, 2f, 3f };
    public GameObject Parent;

    private bool _alreadyChooseWeapon = false;
    //private float _enemySpawnNum = 2f; // ���͸� ������ �� �ִ� ���� ����
    //private float minSpawnInterval = 1.0f; // ���� �ֱ��� �ּҰ�
    //private float intervalReductionRate = 0.1f; // ���� �ֱ⸦ ���̴� �ӵ�
    //private bool isSpawning = false; // �ڷ�ƾ �ߺ� ������ ���� �÷���
    #endregion
    private void Start()
    {
        StartEnemyRoutine();
    }

    private void StartEnemyRoutine()
    {
        StartCoroutine(EnemySpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {

        yield return new WaitForSeconds(SetSpawnSpeed());

        int spawnCount = 0;
        int enemyIndex = 0;
                
        while (true)
        {
            if (!GameManager.Instance.isFight) //�������� ���� ���� ����.
            {
                if(!_alreadyChooseWeapon)
                {
                    SpawnWeaponChoose();
                    _alreadyChooseWeapon = true;
                }
                else
                {
                    int numSpawnPoints = GetRandomSpawnPointCount();

                    List<float> selectedSpawnPoints = GetRandomSpawnPoints(numSpawnPoints);

                    foreach (float posX in selectedSpawnPoints)
                    {
                        int index = Random.Range(0, enemyIndex);
                        SpawnEnemy(posX, index);
                    }
                    spawnCount++;

                    if (spawnCount % 10 == 0) //10�� ��ȯ���� ��ȯ�Ǵ� �� ���� ����
                    {
                        enemyIndex++;
                        _alreadyChooseWeapon = false;
                    }
                }
            }
            yield return new WaitForSeconds(SetSpawnSpeed());
        }
    }

    // ���� ���� ĭ ����.
    private void SpawnWeaponChoose()
    {
        Instantiate(WeaponChoice, transform.position, Quaternion.identity, Parent.transform);
    }


    //�� ����.
    private void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if (Random.Range(0, 5) == 0) // 20�ۼ�Ʈ
        {
            index += 1;
        }


        if (index >= EnemyPrefabs.Length)
        {
            index = EnemyPrefabs.Length - 1;
        }
        Instantiate(EnemyPrefabs[index], spawnPos, Quaternion.identity, Parent.transform);
        /*GameObject enemyObject = */
        //EnemyStatus enemy = enemyObject.GetComponent<EnemyStatus>();
    }

    private float SetSpawnSpeed()
    {
        int coroutineIndex = Random.Range(0, _coroutineInterval.Length);
        float SpawnSpeed = _coroutineInterval[coroutineIndex];
        return SpawnSpeed;
    }

    // ������ ���� ��ǥ ������ �����ϴ� �޼��� (1�� ~ 5��)
    private int GetRandomSpawnPointCount()
    {
        // Ȯ�� ���� ����: 1���� ���� Ȯ���� ���� ����, 5���� ���� Ȯ���� ���� ����
        int[] probabilities = { 5, 15, 25, 40, 60 }; // ���� 145, 5���� ���� Ȯ���� ���� ŭ
        int randomValue = Random.Range(0, 145);

        int cumulativeProbability = 0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            cumulativeProbability += probabilities[i];
            if (randomValue < cumulativeProbability)
            {
                return i + 1; // 1�� ~ 5��
            }
        }

        return 5; // �⺻������ 5���� ����
    }

    // ���õ� ������ŭ ������ ���� ��ǥ�� ��ȯ
    private List<float> GetRandomSpawnPoints(int numPoints)
    {
        List<float> spawnPointsList = new List<float>(_spawnPointsX);
        List<float> selectedPoints = new List<float>();

        for (int i = 0; i < numPoints; i++)
        {
            int randomIndex = Random.Range(0, spawnPointsList.Count);
            selectedPoints.Add(spawnPointsList[randomIndex]);
            spawnPointsList.RemoveAt(randomIndex); // �ߺ� ������ ���� ���õ� ��ǥ ����
        }

        return selectedPoints;
    }


    //private GameObject SelectRandomEnemy()
    //{
    //    // ���� ���� �����Ͽ� Ȯ���� ���� ���� ����
    //    float randomValue = Random.Range(0f, 100f); // 0 ~ 100 ������ ��

    //    if (randomValue <= 90f)  // 90% Ȯ���� ù ��° ��
    //    {
    //        return EnemyPrefabs[0];
    //    }
    //    else if (randomValue <= 98f)  // 8% Ȯ���� �� ��° ��
    //    {
    //        return EnemyPrefabs[1];
    //    }
    //    else  // 2% Ȯ���� �� ��° ��
    //    {
    //        return EnemyPrefabs[2];
    //    }
    //}
}
