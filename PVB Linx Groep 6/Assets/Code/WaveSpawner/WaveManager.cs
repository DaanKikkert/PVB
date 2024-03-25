using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _spawners = new List<EnemySpawner>(0);
    public int wave;
    public int totalZombies;

    
    //MOCKUP
    public int playerCount;
    
    
    private int _baseEnemyCount = 20;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewWave();
        }
    }

    public void NewWave()
    {
        wave++;
        foreach (var spawner in _spawners)
        {
            spawner.SpawnEnemies(CalculateEnemyCount());
        }
        totalZombies = CalculateEnemyCount() * 4;
    }

    private int CalculateEnemyCount()
    {
        var baseMultiplier = 1.3f;
       
        var zombieCount =  Mathf.RoundToInt(((baseMultiplier * wave * playerCount) + _baseEnemyCount)/_spawners.Count);  
        return zombieCount;
    }

}
