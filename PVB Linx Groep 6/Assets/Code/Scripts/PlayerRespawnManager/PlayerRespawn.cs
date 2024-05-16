using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerRespawnManager : MonoBehaviour
{
    [SerializeField] private int fakePlayersCount;
    [SerializeField] private Transform playerHolder;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject fakePlayerPrefab;
    public static PlayerRespawnManager instance;
    

    private void Awake()
    {
        instance = this;
    }

    public Transform GetPlayerHolder()
    {
        return playerHolder;
    }

    public void ResetPlayerWithinSpawnPoints()
    {
        for (int i = 0; i < playerHolder.childCount; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            playerHolder.GetChild(i).position = spawnPoints[randomIndex].position;
        }
    }

    public void SpawnAtRandomPoint()
    {
        for (int i = 0; i < fakePlayersCount; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(fakePlayerPrefab, spawnPoints[randomIndex].position, quaternion.identity , playerHolder);
        }
    }

    public GameObject returnHostPlayer()
    {
        return playerHolder.GetChild(0).gameObject;
    }

}
