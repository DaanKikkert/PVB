using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>(0);
    [SerializeField] private List<EnemySpawner> spawners = new List<EnemySpawner>(0);
    public int wave;
    public int totalEnemies;
    public static WaveManager instance;
    [SerializeField]private int baseEnemyCount = 20;
    [SerializeField]private float baseMultiplier = 1.3f;
    //MOCKUP
    public int playerCount;
    private void Awake()
    {
        instance = this;
        NewWave();
    }
    public void CheckForNewWave()
    {
        if (totalEnemies <= 0)
            NewWave();
    }

    public void NewWave()
    {
        wave++;
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.SpawnEnemies(CalculateEnemyCount(), enemyPrefabs);
        }
        totalEnemies = CalculateEnemyCount() * 4;
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
                Destroy(spawner.enemyHolder.transform.GetChild(i).gameObject);
            }
        }
        totalEnemies = 0;
        wave = goToWave - 1;
        NewWave();
    }

}
