using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Player,
    Castle,
    Enemy
}
public class UniversalHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    private bool _isRegenerating = false;
    private bool _didDamage = false;
    private Transform _currentTransform;
    public ObjectType _objectType;
    private int _onePercentOfCastleHPInt;
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
        float onePercentOfCastleHP = _maxHealth * 0.005f;
        _onePercentOfCastleHPInt = Mathf.RoundToInt(onePercentOfCastleHP);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
            Die();
    }

    public void HealHealth(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
    }

    public void PassiveRegenHealth(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
    }

    private IEnumerator PassiveRegenDelay(int delayAmount, int amountOfHealth)
    {
        if (!_isRegenerating)
        {
            yield return new WaitForSeconds(delayAmount);
            PassiveRegenHealth(amountOfHealth);
            _isRegenerating = false;
            
            if (_currentHealth >= _maxHealth - 1)
            {
                _isRegenerating = false;
                StopCoroutine(PassiveRegenDelay(6, 1));
            }
        }
    }

    private IEnumerator DealingDamageDelay(int delayAmount)
    {
        if (!_didDamage)
        {
            _didDamage = true;
            yield return new WaitForSeconds(delayAmount);
            _didDamage = false;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_currentHealth <= _maxHealth - 1)
        {
            switch (_objectType)
            {
                case ObjectType.Player: 
                    StartCoroutine(PassiveRegenDelay(6, 1));
                    break;
                case ObjectType.Castle:
                    StartCoroutine(PassiveRegenDelay(6, _onePercentOfCastleHPInt));
                    break;
                case ObjectType.Enemy:
                    StartCoroutine(PassiveRegenDelay(6, 1));
                    break;
                
            }
            _isRegenerating = true;
        }

        if (_didDamage)
        {
            StartCoroutine(DealingDamageDelay(2));
        }
        
        Debug.Log(_currentHealth);
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        var otherHealth = collision.gameObject.GetComponent<UniversalHealth>();
        if (otherHealth != null)
        {
            switch (_objectType)
            {
                case ObjectType.Player:
                    if (otherHealth._objectType == ObjectType.Enemy)
                        TakeDamage(20); // Example: Player damages enemy
                    break;
                case ObjectType.Castle:
                    if (otherHealth._objectType == ObjectType.Enemy)
                        TakeDamage(25); // Example: Castle takes damage from enemy
                    break;
                case ObjectType.Enemy:
                    if (otherHealth._objectType == ObjectType.Player)
                        TakeDamage(20); // Example: Enemy damages player
                    break;
            }
        }
    }
}