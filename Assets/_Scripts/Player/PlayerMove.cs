using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    #region Field

    private GameObject _player;
    private float _speed = 2f;
    private float _rayLength = 0.5f;

    private bool _isEnd = false;
    private bool _isEnemy = false;
    private Rigidbody2D _rb;
    [SerializeField] private LayerMask enemyLayer;

    #endregion



    private void Awake()
    {
        _player = gameObject;
        _rb = GetComponent<Rigidbody2D>();
    }

    //private void FixedUpdate()
    //{
    //    if (!_isEnd)
    //    {
    //        if (!CheckEnemy())
    //        {
    //            transform.position += new Vector3(0, _speed * Time.deltaTime, 0);
    //        }
    //        else
    //        {
    //            transform.position += Vector3.zero;
    //        }
    //    }
    //}


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.6f, 2.6f);
        transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
    }


    private bool CheckEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, _rayLength, enemyLayer);

        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
            return true;
        }

        return false;
    }
}
