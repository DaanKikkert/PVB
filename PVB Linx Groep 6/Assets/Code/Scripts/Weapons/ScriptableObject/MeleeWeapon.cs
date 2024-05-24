using System.Collections;
using Code.Scripts.Weapons;
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
        private DealDamageOnCollision _damageScript;

        public override void Attack()
        {
            if (WeaponMonoInstance.instance != null)
                WeaponMonoInstance.instance.StartCoroutine(ToggleHitbox());
        }

        private IEnumerator ToggleHitbox()
        {
            if(_hitbox != null)
                _hitbox.enabled = true;
            yield return new WaitForSeconds(hitBoxDuration);
            if(_hitbox != null)
                _hitbox.enabled = false;
        }

        public override void SpawnWeapon(Transform parent)
        {
            base.SpawnWeapon(parent);
            _damageScript = parent.AddComponent<DealDamageOnCollision>();
            _hitbox = parent.AddComponent<BoxCollider>();
            _damageScript.SetDamage(damage);
            _hitbox.size = hitboxScale;
            _hitbox.center = new Vector3( 0, 0, hitboxOffset);
            _hitbox.isTrigger = true;
            _hitbox.enabled = false;
        }

        public override void DespawnWeapon()
        {
            base.DespawnWeapon();
            Destroy(_hitbox);
            Destroy(_damageScript);
        }
    }
}
