using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
   
    [SerializeField] private Transform zone;
    [SerializeField] private Transform enemyHolder;
    private Vector2 _zoneSize;
    
    

    private void Awake()
    {
        _zoneSize.x = zone.localScale.x;
        _zoneSize.y = zone.localScale.z;
        var enemyHolderPosX = (_zoneSize.x / 2) * -1;
        var enemyHolderPosZ = (_zoneSize.y / 2) * -1;
        enemyHolder.localPosition = new Vector3(enemyHolderPosX, 0, enemyHolderPosZ);
        
    }

    public void SpawnEnemies(int count, List<GameObject> enemyTypeList)
    {
        for (int i = 0; i < count; i++)
        {
            var enemyType = Random.Range(0, enemyTypeList.Count);
            var enemySpawnPositionX = Random.Range(0, _zoneSize.x);
            var enemySpawnPositionY = Random.Range(0, _zoneSize.y);
            var enemy = Instantiate(enemyTypeList[enemyType], enemyHolder);
            enemy.transform.localPosition = new Vector3(enemySpawnPositionX, 1, enemySpawnPositionY);
        }
    }

}
