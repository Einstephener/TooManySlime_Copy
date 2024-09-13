using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStatus : BaseStatus
{
    [HideInInspector] public float shield;
    public Scrollbar HealthSlider;
    public TMP_Text HealthTxt;

    [SerializeField] private float _playerHealth = 300f;
    [SerializeField] private float _playerMaxHealth = 300f;

    private void Start()
    {
        InitializeStatus(_playerHealth, 100f, 100f);
        HealthSliderSet();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        HealthSliderSet();
    }

    private void HealthSliderSet()
    {
        float normalizedValue = (_playerHealth) / (_playerMaxHealth);

        HealthSlider.size = normalizedValue;

        HealthTxt.text = _playerHealth.ToString();

    }

    public override void Die()
    {
        base.Die();
        // 게임 종료
    }
}
