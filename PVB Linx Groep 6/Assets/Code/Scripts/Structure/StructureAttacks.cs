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
        [SerializeField] private bool hasTargeted;
        [SerializeField] private Transform currentTarget;

        [Header("Is Attacking: ")] 
        [SerializeField] private Weapon getWeapon;
        
        private bool _waitForNextProjectile;

        // Update is called once per frame
        private void Update()
        {
            if (currentTarget == null || !IsTargetInRange(currentTarget))
            {
                hasTargeted = false;
                FindNewTarget();
            }

            if (currentTarget != null && !_waitForNextProjectile)
                Attack();
        }

        private void FindNewTarget()
        {
            if (!hasTargeted)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, range);
                foreach (Collider vCollider in colliders)
                {
                    // ReSharper disable once InvertIf
                    if (vCollider.CompareTag("Enemy"))
                    {
                        currentTarget = vCollider.transform;
                        hasTargeted = true;
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
                getWeapon.SpawnWeapon(transform);
                transform.LookAt(currentTarget);
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
