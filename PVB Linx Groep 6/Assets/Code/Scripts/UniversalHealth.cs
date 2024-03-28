using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    
    private bool _didDamage = false;
    public bool isFullHealth = true;
    private Transform _currentTransform;
    
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
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
        Destroy(gameObject);
    }
}