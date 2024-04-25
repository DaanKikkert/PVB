using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Unity.Mathematics;
using UnityEditor.Events;
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
            int randomIndex = Random.Range(0, spawnPoints.Length);
            GameObject player = playerHolder.GetChild(0).gameObject;
            player.GetComponent<CharacterController>().enabled = false;
            playerHolder.GetChild(0).position = spawnPoints[randomIndex].position;
            player.GetComponent<CharacterController>().enabled = true;
    }

    public void SpawnAtRandomPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject player = Instantiate(playerPrefab, spawnPoints[randomIndex].position, quaternion.identity , playerHolder);
        UnityEventTools.AddPersistentListener(player.GetComponent<UniversalHealth>().onDeath, ResetPlayerWithinSpawnPoints);
    }

    public GameObject returnHostPlayer()
    {
        //WILL BE EDITED ONCE NETWORK IS DONE.
        return playerHolder.GetChild(0).gameObject;
    }

}
