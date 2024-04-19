using UnityEngine;
using Weapons;

public class EnemyAttack : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private EnemyReferences enemyReferences;
    
    private float _attackTimer;  

    private void Start()
    {
        weapon.SpawnWeapon(spawnPoint.transform);
    }

    private void Update()
    {
        _attackTimer -= Time.deltaTime;
        if (enemyReferences.movement.isInRange)
            Attack();
    }

    private void Attack()
    {
        if (_attackTimer <= 0f)
        {
            weapon.setAttackDirection(spawnPoint.transform.rotation, spawnPoint.transform.position);
            weapon.Attack();
            _attackTimer = weapon.attackDelay;
        }
    }
}