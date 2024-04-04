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

        private BoxCollider hitbox;
        private WeaponMonoInstance monoInstance;

        public override void Attack()
        {
            WeaponMonoInstance.instance.StartCoroutine(EnableHitbox());
        }

        private IEnumerator EnableHitbox()
        {
            hitbox.enabled = true;
            yield return new WaitForSeconds(hitBoxDuration);
            hitbox.enabled = false;
            Debug.Log("We have attacked lads");
        }

        public override void SpawnWeapon(Transform parent)
        {
            base.SpawnWeapon(parent);
            monoInstance = parent.AddComponent<WeaponMonoInstance>();
            hitbox = parent.AddComponent<BoxCollider>();
            hitbox.size = hitboxScale;
            hitbox.center = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z + hitboxOffset);
            hitbox.isTrigger = true;
            hitbox.enabled = false;
        }

        public override void DespawnWeapon()
        {
            base.DespawnWeapon();
            Destroy(hitbox);
            Destroy(monoInstance);
        }
    }
}
