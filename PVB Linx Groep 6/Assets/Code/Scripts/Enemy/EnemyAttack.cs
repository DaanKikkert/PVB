using UnityEngine;
using Weapons;

public class EnemyAttack : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField] private GameObject spawnPoint;

    private EnemyReferences _references;
    
    private float _attackTimer;  

    private void Start()
    {
        _references = GetComponentInParent<EnemyReferences>();
        weapon.hitboxHolder = spawnPoint;
        weapon.SpawnWeapon(spawnPoint.transform);
    }

    private void Update()
    {
        _attackTimer -= Time.deltaTime;
        if (_references.movement.isInRange)
            Attack();
    }

    private void Attack()
    {
        if (_attackTimer <= 0f)
        {
            _references.animator.ResetTrigger("Attack");
            weapon.setAttackDirection(spawnPoint.transform.rotation, spawnPoint.transform.position);
            weapon.Attack();
            _attackTimer = weapon.attackDelay;
            _references.animator.SetTrigger("Attack");
        }
    }
}