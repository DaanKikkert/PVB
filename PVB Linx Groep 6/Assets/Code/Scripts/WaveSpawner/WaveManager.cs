using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>(0);
    [SerializeField] private List<EnemySpawner> spawners = new List<EnemySpawner>(0);
    [SerializeField] private int baseEnemyCount = 20;
    [SerializeField] private float baseMultiplier = 1.3f;
    [SerializeField] private UnityEvent updateUI;
    
    public int wave;
    public static WaveManager instance;
    
    private int _totalEnemies;
    
    //MOCKUP
    public int playerCount;
    
    private void Awake()
    {
        instance = this;
        NewWave();
    }

    private void Start()
    {
        CheckForNewWave();
        updateUI.Invoke();
    }
    public void CheckForNewWave()
    {
        _totalEnemies--;
        if (_totalEnemies <= 0)
            NewWave();
        updateUI.Invoke();
    }

    public void NewWave()
    {
        wave++;
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.SpawnEnemies(CalculateEnemyCount(), enemyPrefabs);
        }
        _totalEnemies = CalculateEnemyCount() * 4;
        updateUI.Invoke();
    }

    private int CalculateEnemyCount()
    {
        int enemyCount =  Mathf.RoundToInt(((baseMultiplier * wave * playerCount) + baseEnemyCount)/spawners.Count);  
        return enemyCount;
    }

    public void ClearWave(int goToWave)
    {
        foreach (EnemySpawner spawner in spawners)
        {
            for (int i = 0; i < spawner.enemyHolder.transform.childCount; i++)
            {
                Destroy(spawner.enemyHolder.transform.GetChild(i));
            }
        }
        _totalEnemies = 0;
        wave = goToWave - 1;
        NewWave();
    }

    public int GetEnemyCount()
    {
        return _totalEnemies;
    }

}
