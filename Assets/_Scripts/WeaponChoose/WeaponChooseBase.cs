using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChooseBase : MonoBehaviour
{
    #region Fields
    public GameObject Parent_Left;
    public GameObject Parent_Right;

    public GameObject[] Choices;
    private float moveSpeed = 5f;
    private float minY = -5f;
    #endregion

    private void OnEnable()
    {
        int a = Random.Range(0, Choices.Length);
        int b = Random.Range(0, Choices.Length);
        while (a == b)
        {
            b = Random.Range(0, Choices.Length);
        }

        Instantiate(Choices[a], Parent_Left.transform);
        Instantiate(Choices[b], Parent_Right.transform);
    }

    private void Update()
    {
        if (!GameManager.Instance.isFight)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y < minY)
            {
                Destroy(gameObject);
            }
        }
    }
}
