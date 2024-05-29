using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : ScriptableObject
    {
        [Header("Weapon stats")]
        [SerializeField] protected int damage;
        [SerializeField] public float attackDelay;
        
        [Header("Visuals")]
        [SerializeField] protected GameObject weaponModel;
        
        public GameObject spawnPoint;

        protected Vector3 p_attackSpawnPosition;
        protected Quaternion p_attackDirection;

        protected GameObject p_model;
        
        public virtual void SpawnWeapon(Transform parent)
        {
            p_model = Instantiate(weaponModel);
            p_model.gameObject.transform.SetParent(parent);
            p_model.transform.position = parent.transform.position;
            p_model.transform.rotation = parent.transform.rotation;
        }

        public virtual void DespawnWeapon()
        {
            Destroy(p_model);
        }

        public abstract void Attack();

        public void setAttackDirection(Quaternion dir, Vector3 pos)
        {
            p_attackDirection = dir;
            p_attackSpawnPosition = pos;
        }
    }
}
