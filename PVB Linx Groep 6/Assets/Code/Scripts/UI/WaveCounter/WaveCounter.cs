using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveCounterText;
    [SerializeField] private TextMeshProUGUI enemyCounterText;
    
    public WaveManager waveManager;
    
    
    public void UpdateUI()
    {
        waveCounterText.text = "Wave: " + waveManager.wave.ToString();
        enemyCounterText.text = "Enemies: " + waveManager.GetEnemyCount().ToString();
    }
}
