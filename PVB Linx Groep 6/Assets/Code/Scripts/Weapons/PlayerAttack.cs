using Code.Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;
using Weapons;

public class PlayerAttack : MonoBehaviour
{
    
    [Header("Player Attack Settings: ")]
    public Weapon weapon;
    [SerializeField] private Animator playerAttackAnim;
    
    [Header("SpawnPoint Settings: ")]
    [SerializeField] private GameObject spawnPointBow;
    [SerializeField] private GameObject spawnPointBullet;
    
    [Header("Other Script Settings: ")]
    [SerializeField] private BasicMovement getVector;
    [SerializeField] private ClassManager playerClass;
    
    [Header("Value Changes Settings: ")]
    [SerializeField] private string attackAnimationName;
    [SerializeField] [Range(0,1)] private float maxAnimMaskLayer;

    private float _attackTimer;
    private bool _isHolding = true;

    private void Start()
    {
        weapon.SpawnWeapon(spawnPointBow.transform);
        playerAttackAnim.SetBool("IsAiming", true);
    }

    private void Update()
    {
        _attackTimer -= Time.deltaTime;
        
        switch (playerClass.playerClass)
        {
            case PlayerClass.Warrior:
            {
                if (Input.GetKey(KeyCode.Mouse0))
                    Attack();
                break;
            }
            case PlayerClass.Archer:
                HandleArcherInput();
                break;
        }
        
        if (playerAttackAnim.GetCurrentAnimatorStateInfo(0).IsName(attackAnimationName) &&
            playerAttackAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            playerAttackAnim.SetBool("IsAttacking", false);
            playerAttackAnim.SetLayerWeight(1, 0);
        }
    }

    private void HandleArcherInput()
    {
        switch (_isHolding)
        {
            case true:
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                    Attack();
                break;
            }
        }
    }

    private void Attack()
    {
        if (_attackTimer <= 0f)
        {
            playerAttackAnim.SetLayerWeight(1, getVector.GetDirection().magnitude > 0.01f ? maxAnimMaskLayer : 0f);
            playerAttackAnim.SetBool("IsAttacking", true);
            playerAttackAnim.SetBool("IsWalking", false);
            weapon.setAttackDirection(spawnPointBullet.transform.rotation, spawnPointBullet.transform.position);
            weapon.Attack();
            _attackTimer = weapon.attackDelay;
        }
    }
}
