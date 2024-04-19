using UnityEngine;
using Weapons;

public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField] private Animator playerAttackAnim;
    [SerializeField] private GameObject spawnPoint;

    private float _attackTimer;

    private void Start()
    {
        weapon.SpawnWeapon(spawnPoint.transform);
    }

    private void Update()
    {
        _attackTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
            Attack();
        if (playerAttackAnim.GetCurrentAnimatorStateInfo(0).IsName("SwordSlash") && playerAttackAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            playerAttackAnim.SetBool("IsAttacking", false);
    }

    private void Attack()
    {
        if (_attackTimer <= 0f)
        {
            playerAttackAnim.SetBool("IsAttacking", true);
            playerAttackAnim.SetBool("IsRunning", false);
            playerAttackAnim.SetBool("IsWalking", false);
            playerAttackAnim.SetBool("IsBlocking", false);
            
            weapon.setAttackDirection(spawnPoint.transform.rotation, spawnPoint.transform.position);
            weapon.Attack();
            _attackTimer = weapon.attackDelay;
        }
    }
}
