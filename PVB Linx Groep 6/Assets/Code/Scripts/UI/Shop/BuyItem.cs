using Code.Scripts.Player;
using Code.Scripts.Weapons;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Weapons;
using Class = Code.Scripts.Player.PlayerClass;

namespace Code.Scripts.UI.Shop
{

    public class BuyItem : MonoBehaviour
    {

        public ClassManager cManager;
        [SerializeField] private PlayerClass allowedClass;
        [SerializeField] private Transform weaponHolder;

        private void Start()
        {
            Button getButton = GetComponent<Button>();
            getButton.interactable = CanPurchaseWeapon(cManager.playerClass);
        }
        
        public void Purchase(Weapon purchaseWeapon)
        {
            if (CanPurchaseWeapon(cManager.playerClass))
            {
                weaponHolder.GetComponent<PlayerAttack>().weapon.DespawnWeapon();
                weaponHolder.GetComponent<PlayerAttack>().weapon = purchaseWeapon;
                weaponHolder.GetComponent<PlayerAttack>().weapon.SpawnWeapon(weaponHolder);
            }
        }

        private bool CanPurchaseWeapon(PlayerClass playerClass)
        {
            return playerClass == allowedClass; 
        }
    }
}
