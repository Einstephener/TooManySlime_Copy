using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : BaseStatus
{
    [HideInInspector] public float shield;
    
    private void Start()
    {
        InitializeStatus(100f, 100f, 100f);
        
    }


    public override void Die()
    {
        base.Die();
        // 게임 종료
    }
}
