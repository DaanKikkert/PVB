using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>(0);
    [SerializeField] private List<EnemySpawner> _spawners = new List<EnemySpawner>(0);
    public int wave;
    public int totalEnemies;
    public static WaveManager instance;

    private void Awake()
    {
        instance = this;
    }


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
    
    public void CheckForNewWave()
    {
        if (totalEnemies <= 0)
            NewWave();
    }
    

    public void NewWave()
    {
        wave++;
        foreach (EnemySpawner spawner in _spawners)
        {
            spawner.SpawnEnemies(CalculateEnemyCount(), enemyPrefabs);
        }
        totalEnemies = CalculateEnemyCount() * 4;
    }

    private int CalculateEnemyCount()
    {
        float baseMultiplier = 1.3f;
        int zombieCount =  Mathf.RoundToInt(((baseMultiplier * wave * playerCount) + _baseEnemyCount)/_spawners.Count);  
        return zombieCount;
    }

    private void clearWave(int goToWave)
    {
        foreach (EnemySpawner spawner in _spawners)
        {
            for (int i = 0; i < spawner.transform.childCount; i++)
            {
                Destroy(spawner.transform.GetChild(i));
            }
        }
        totalEnemies = 0;
        wave = goToWave - 1;
        NewWave();
    }

}
