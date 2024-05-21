using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private UniversalHealth health; 

    private void Awake()
    {
        if(health.onDeath != null)
            health.onDeath.AddListener(RespawnPlayer);
    }

    public void RespawnPlayer()
    {
        PlayerRespawnManager.instance.ResetPlayer(this.gameObject);
    }
}
