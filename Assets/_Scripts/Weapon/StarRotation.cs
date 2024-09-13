using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> Stars = new List<GameObject>(); //생성된 위성들
    private void Awake()
    {

    }
    private void FixedUpdate()
    {
        RotateSatellites();
    }
    private void RotateSatellites()
    {
        transform.Rotate(new Vector3(0, 0, 1), 30f * Time.deltaTime);
    }
    public void MakeNewStar(WeaponData weaponData)
    {
        GameObject newSatellite = Instantiate(weaponData.Prefab, transform);
        Stars.Add(newSatellite);
        SetStarPosition();

    }
    private void SetStarPosition()
    {
        int childCnt = Stars.Count;
        if (childCnt <= 0)
        {
            Debug.Log("Child count is invalid.");
            return;
        }

        for (int i = 0; i < Stars.Count; ++i)
        {
            float angle = 360.0f / childCnt;
            float newX = Mathf.Sin(i * angle * Mathf.Deg2Rad);
            float newY = Mathf.Cos(i * angle * Mathf.Deg2Rad);
            newX = (newX * 1f) + this.transform.position.x; // 거리(distance) 부분은 필요에 따라 수정
            newY = (newY * 1f) + this.transform.position.y;

            Stars[i].transform.position = new Vector3(newX, newY, 0);
        }
    }
}
