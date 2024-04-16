using Code.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;
using Weapons;
using Class = Code.Scripts.Player.PlayerClass;

namespace Code.Scripts.UI.Shop
{

    public class BuyItem : MonoBehaviour
    {

        public ClassManager cManager;
        [SerializeField] private PlayerClass allowedClass;
        private InteractionShop _getManager;

        private void Start()
        {
            Button getButton = GetComponent<Button>();
            _getManager = GetComponentInParent<InteractionShop>();
            cManager = _getManager.currentBuyer.GetComponentInParent<ClassManager>();
            getButton.interactable = CanPurchaseWeapon(cManager.playerClass);
        }
        
        public void Purchase(Weapon purchaseWeapon)
        {
            if (CanPurchaseWeapon(cManager.playerClass))
            {
                Transform oldWeapon = _getManager.currentBuyer.GetComponentInChildren<PlayerAttack>().transform;
                oldWeapon.GetComponent<PlayerAttack>().weapon.DespawnWeapon();
                oldWeapon.GetComponent<PlayerAttack>().weapon = purchaseWeapon;
                oldWeapon.GetComponent<PlayerAttack>().weapon.SpawnWeapon(oldWeapon);
            }
        }

        private bool CanPurchaseWeapon(PlayerClass playerClass)
        {
            return playerClass == allowedClass; 
        }
    }
}
