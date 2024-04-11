using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro waveCounterText;
    [SerializeField] private TMP_Asset enemyCounterText;
    
    public WaveManager waveManager;
    
    
    public void UpdateUI()
    {
        //waveCounterText = "Wave:" + waveManager.wave.ToString();
        //enemyCounterText.text = "Enemies remaining" + waveManager.GetEnemyCount().ToString();
    }
}
