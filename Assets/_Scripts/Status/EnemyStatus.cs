using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum EnemyType
{
    Normal,
    Shield,
    Fire,
    Thunder,
}


public class EnemyStatus : BaseStatus
{
    #region Fields
    public EnemyType enemyType;
    private float moveSpeed = 5f;
    private float minY = -5f;
    public GameObject DamageTxt;

    private bool _isDead = false;
    private Animator animator;
    #endregion

    private void Start()
    {
        animator = GetComponent<Animator>();
        InitializeStatus(100f, 100f, 10f);
    }

    private void Update()
    {
        if (!GameManager.Instance.isFight)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if(transform.position.y < minY)
            {
                Die();
            }
        }
        if(Health <= 0)
        {
            Die();
        }
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        SetDamageTxt(DamageTxt, damage);
    }

    public void HitAnimation()
    {
        if (!_isDead)
        {
            animator.SetTrigger("IsHit");
        }
    }

    public override void Die()
    {
        base.Die();
        if (!_isDead)
        {
            _isDead = true;
            animator.SetBool("IsDie", true);
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject); 
    }


    private void SetDamageTxt(GameObject DamageTxtUI, float Damange)
    {
        GameObject UI = Instantiate(DamageTxtUI, gameObject.transform);
        TMP_Text getDamange = UI.GetComponentInChildren<TMP_Text>();
        getDamange.text = Damange.ToString();
        RectTransform rectTransform = DamageTxtUI.GetComponent<RectTransform>();
        rectTransform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up);
        StartCoroutine(DestroyAfterDamage(DamageTxtUI));
    }
    private IEnumerator DestroyAfterDamage(GameObject DamageTxtUI)
    {
        yield return new WaitForSecondsRealtime(1f);
        Destroy(DamageTxtUI);
    }
}
