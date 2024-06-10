using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar_p : MonoBehaviour
{
    [SerializeField] private UniversalHealth health;
    [SerializeField] private Slider _healthbar;
    [SerializeField] private Text showHealth;

    private int _fixedHealth;
    private void Awake()
    {
        _healthbar.value = health.GetMaxHealth();
        showHealth.text = health.GetMaxHealth() + "/" + health.GetMaxHealth();
    }

    public void ShowsHealth()
    {
        _fixedHealth = health.GetMaxHealth();
        _healthbar.value = health.GetCurrentHealth();
        showHealth.text = health.GetCurrentHealth() + "/" + 100 + " HP";
    }

    public void ChangeHealthValue()
    {
        _healthbar.value = health.GetCurrentHealth();
    }
}
