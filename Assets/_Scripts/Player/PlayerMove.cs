using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    #region Field

    private float _rayLength = 0.5f;

    [SerializeField] private LayerMask enemyLayer;

    #endregion


    private void FixedUpdate()
    {
        if(!GameManager.Instance.isPlayerMove)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float toX = Mathf.Clamp(mousePos.x, -2.6f, 2.6f);
            transform.position = new Vector3(toX, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position += new Vector3(0, 3* Time.deltaTime, 0);
        }

        if (CheckEnemy() != null)
        {
            GameManager.Instance.isFight = true;
        }
        else
        {
            GameManager.Instance.isFight = false;
        }
    }


    public GameObject CheckEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, _rayLength, enemyLayer);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }

        return null;

    }
}
