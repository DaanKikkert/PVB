using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Weapon/Ranged/Ranged Weapon Data")]
    public class RangedWeapon : Weapon
    {
        [Header("Projectile settings")]
        [SerializeField] private GameObject projectile;

        public override void Attack()
        {
            Instantiate(projectile, p_attackSpawnPosition , p_attackDirection);
        }
    }
}

