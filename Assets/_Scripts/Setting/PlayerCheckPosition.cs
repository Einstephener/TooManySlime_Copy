using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCheckPosition : MonoBehaviour
{
    private GameObject _player;
    private Scrollbar _positionSlider;
    private float _mapLength = 50f;
    private float _startPosition;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _positionSlider = GetComponent<Scrollbar>();

        _startPosition = _player.transform.position.y;
    }

    private void FixedUpdate()
    {
        float playerPositionValue = Mathf.Clamp(_player.transform.position.y, _startPosition, _mapLength);
        float normalizedValue = (playerPositionValue - _startPosition) / (_mapLength - _startPosition);

        _positionSlider.size = normalizedValue;
    }

}
