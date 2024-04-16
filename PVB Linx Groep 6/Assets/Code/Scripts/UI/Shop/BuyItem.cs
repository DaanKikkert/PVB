using Code.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;
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
        
        public void Purchase(GameObject weapon)
        {
            if (CanPurchaseWeapon(cManager.playerClass))
            {
                GameObject putAsChild = Instantiate(weapon, _getManager.currentBuyer.transform.position, _getManager.currentBuyer.transform.rotation);
                putAsChild.transform.parent = _getManager.currentBuyer.transform;
            }
        }

        private bool CanPurchaseWeapon(PlayerClass playerClass)
        {
            return playerClass == allowedClass; 
        }
    }
}
