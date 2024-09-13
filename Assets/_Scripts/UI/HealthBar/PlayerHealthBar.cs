using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        rectTransform.position = Camera.main.WorldToScreenPoint(player.transform.position + offset);
    }

}
