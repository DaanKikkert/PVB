using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class FakePlayerAttack : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField] private GameObject spawnPoint;

    private float _attackTimer;

    private void Start()
    {
        weapon.SpawnWeapon(spawnPoint.transform);
    }

    private void Update()
    {        
        _attackTimer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (_attackTimer <= 0f)
        {
            weapon.setAttackDirection(spawnPoint.transform.rotation, spawnPoint.transform.position);
            weapon.Attack();
            _attackTimer = weapon.attackDelay;
        }
    }
}
