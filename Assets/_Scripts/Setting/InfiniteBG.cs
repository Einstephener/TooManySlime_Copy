using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfiniteBG : MonoBehaviour
{
    private float _moveSpeed = 3f;
    private bool _isMoving = true;
    private void FixedUpdate()
    {
        if (!GameManager.Instance.isFight && _isMoving)
        {
            transform.position += Vector3.down * _moveSpeed * Time.deltaTime;
            if(transform.position.y < -16f)
            {
                transform.position += new Vector3(0, 32f, 0);
            }
        }

        if (GameManager.Instance.isEnd)
        {
            StartCoroutine(StopMove());
        }
    }

    IEnumerator StopMove()
    {
        yield return new WaitForSecondsRealtime(4f);
        _isMoving = false;
    }

}
