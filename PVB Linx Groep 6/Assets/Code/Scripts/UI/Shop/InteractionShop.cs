using System;
using UnityEngine;

namespace Code.Scripts.UI.Shop
{
    public class InteractionShop : MonoBehaviour
    {
        
        [SerializeField] private GameObject shopUI;
        public GameObject currentBuyer;
        private bool _inRange;

        private void Awake() => shopUI.SetActive(false);
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _inRange)
                shopUI.SetActive(true);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                currentBuyer = other.gameObject;
                _inRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _inRange = false;
            shopUI.SetActive(false);
            currentBuyer = null;
        }
    }
}
