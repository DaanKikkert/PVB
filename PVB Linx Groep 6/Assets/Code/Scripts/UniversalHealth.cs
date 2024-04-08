using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts
{
    public class UniversalHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        [SerializeField] private UnityEvent onDeath;
        [SerializeField] private UnityEvent onHealthChange;

        private bool _didDamage = false;
        public bool isFullHealth = true;
        private Transform _currentTransform;

        public int GetMaxHealth()
        {
            return _maxHealth;
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }
        
        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            onHealthChange.Invoke();
            if (_currentHealth <= 0)
                Die();
        }

        public void HealHealth(int amount)
        {
            _currentHealth += amount;
            onHealthChange.Invoke();
            if (_currentHealth >= _maxHealth)
            {
                _currentHealth = _maxHealth;
                isFullHealth = true;
            }
            else
            {
                isFullHealth = false;
            }
        }

        private void Die()
        {
            onDeath.Invoke();
        }
    }
}