using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRanged : MonoBehaviour
{
    [SerializeField] private float attackDelay = 1f;

    [SerializeField] private GameObject projectile;
    
    private float _attackTimer;

    private void Update()
    {
        _attackTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (_attackTimer <= 0f)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            _attackTimer = attackDelay;
        }
    }
}
