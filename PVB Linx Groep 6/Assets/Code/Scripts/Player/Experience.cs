using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    [Header("Show Experience Settings: ")]
    [SerializeField] private Text showLevel;
    [SerializeField] private Text showExperience;
    [SerializeField] private Slider showSlider;
    [SerializeField] private float maxExperience;
    
    private float _currentExperience;
    private int _currentLevel = 1;
    
    private void Start()
    {
        showSlider.maxValue = maxExperience;
        showSlider.value = 0;

        showExperience.text = _currentExperience + "/" + maxExperience;
        showLevel.text = "Level: " + _currentLevel;
    }

    public void AddExperience(float experience)
    {
        _currentExperience += experience;
        showSlider.value = _currentExperience;

        showExperience.text = _currentExperience + "/" + maxExperience;
        showLevel.text = "Level: " + _currentLevel;

        if (_currentExperience >= maxExperience)
        {
            showSlider.value = 0;
            maxExperience += 30 + _currentLevel * 20;
            _currentExperience = 0;
            showSlider.maxValue = maxExperience;
            _currentLevel += 1;
            showExperience.text = _currentExperience + "/" + maxExperience;
            showLevel.text = "Level: " + _currentLevel;
        }
    }
}
