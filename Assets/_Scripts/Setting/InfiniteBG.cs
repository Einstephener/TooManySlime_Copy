using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBG : MonoBehaviour
{
    private float _moveSpeed = 3f;
    private void Update()
    {
        transform.position += Vector3.down * _moveSpeed * Time.deltaTime;
        if(transform.position.y < -16f)
        {
            transform.position += new Vector3(0, 32f, 0);
        }
    }

}
