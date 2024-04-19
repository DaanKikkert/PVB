using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.Serialization;
using Weapons;

namespace Code.Scripts.Structure
{
    public class StructureAttacks : MonoBehaviour
    {
        
        [Header("Is Searching: ")]
        [SerializeField] private float range;
        private bool _hasTargeted;
        private Transform _currentTarget;

        [Header("Is Attacking: ")] 
        [SerializeField] private Weapon getWeapon;
        
        private bool _waitForNextProjectile;

        private void Awake() => getWeapon.SpawnWeapon(transform);

        // Update is called once per frame
        private void Update()
        {
            if (_currentTarget == null || !IsTargetInRange(_currentTarget))
            {
                _hasTargeted = false;
                FindNewTarget();
            }

            if (_currentTarget != null && !_waitForNextProjectile)
                Attack();
        }

        private void FindNewTarget()
        {
            if (!_hasTargeted)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, range);
                foreach (Collider vCollider in colliders)
                {
                    // ReSharper disable once InvertIf
                    if (vCollider.CompareTag("Enemy"))
                    {
                        _currentTarget = vCollider.transform;
                        _hasTargeted = true;
                        break;
                    }
                }
            }
        }

        private bool IsTargetInRange(Transform target)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            return distance <= range;
        }

        private void Attack()
        {
            if (!_waitForNextProjectile)
            {
                _waitForNextProjectile = true;
                StartCoroutine(Wait(getWeapon.attackDelay));
                transform.LookAt(_currentTarget);
                getWeapon.setAttackDirection(transform.rotation, transform.position);
                getWeapon.Attack();
            }
        }

        private IEnumerator Wait(float wait)
        {
            yield return new WaitForSeconds(wait);
            _waitForNextProjectile = false;
        }
    }
}
