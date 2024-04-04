using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Weapon/Melee/Melee Weapon Data")]
    public class MeleeWeapon : Weapon
    {
        [Header("Hitbox Settings")]
        [Tooltip("The amount of time the hitbox should be active")]
        [SerializeField] private float hitBoxDuration = 0.1f;
        [Tooltip("How far the hitbox should be placed in front of the player")]
        [SerializeField] private float hitboxOffset = 1;

        [SerializeField] private Vector3 hitboxScale = new Vector3(1, 1, 1);

        private BoxCollider _hitbox;
        private WeaponMonoInstance _monoInstance;

        public override void Attack()
        {
            WeaponMonoInstance.instance.StartCoroutine(ToggleHitbox());
        }

        private IEnumerator ToggleHitbox()
        {
            _hitbox.enabled = true;
            yield return new WaitForSeconds(hitBoxDuration);
            _hitbox.enabled = false;
        }

        public override void SpawnWeapon(Transform parent)
        {
            base.SpawnWeapon(parent);
            _monoInstance = parent.AddComponent<WeaponMonoInstance>();
            _hitbox = parent.AddComponent<BoxCollider>();
            _hitbox.size = hitboxScale;
            _hitbox.center = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z + hitboxOffset);
            _hitbox.isTrigger = true;
            _hitbox.enabled = false;
        }

        public override void DespawnWeapon()
        {
            base.DespawnWeapon();
            Destroy(_hitbox);
            Destroy(_monoInstance);
        }
    }
}
