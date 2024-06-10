using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts
{
    public class UniversalHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private UnityEvent onHealthChange;
        public UnityEvent onDeath;
        
        public bool isFullHealth = true;
        [SerializeField] private int _currentHealth;
        private bool _didDamage = false;
        private Transform _currentTransform;

        public int GetMaxHealth()
        {
            return _maxHealth;
        }
        public void SetMaxHealth(int maxHealth)
        {
            _maxHealth = maxHealth;
        }
        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public void SetCurrentHealt(int health)
        {
            _currentHealth = health;
            onHealthChange.Invoke();
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