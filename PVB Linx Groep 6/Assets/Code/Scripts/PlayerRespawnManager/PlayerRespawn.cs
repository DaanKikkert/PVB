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
    [SerializeField] private Transform playerHolder;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject playerPrefab;
    public static PlayerRespawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //WILL BE EDITED WHEN SERVERS IS RUNNING. SERVER.PLAYERCOUNT WILL REPLACE 4.
        for (int i = 0; i < 1; i++)
        {
            SpawnAtRandomPoint();
        }
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
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(playerPrefab, spawnPoints[randomIndex].position, quaternion.identity , playerHolder);

    }

    public GameObject returnHostPlayer()
    {
        //WILL BE EDITED ONCE NETWORK IS DONE.
        return playerHolder.GetChild(0).gameObject;
    }

}
