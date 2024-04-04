using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class PlayerAttack : MonoBehaviour
{
    private float attackTimer;

    public Weapon weapon;

    public GameObject spawnPoint;

    private void Start()
    {
        weapon.SpawnWeapon(spawnPoint.transform);
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (attackTimer <= 0f)
            {
                weapon.setAttackDirection(spawnPoint.transform.rotation, spawnPoint.transform.position);
                weapon.Attack();
                attackTimer = weapon.attackDelay;
            }
        }
        
    }
}
