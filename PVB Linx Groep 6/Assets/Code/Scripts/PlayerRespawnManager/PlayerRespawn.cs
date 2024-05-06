using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerRespawnManager : MonoBehaviour
{
    [SerializeField] private Transform playerHolder;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CanvasGroup cg;
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
            //StartCoroutine(FadeEffect.FadeIn(cg, .5f));
            player.GetComponent<CharacterController>().enabled = false;
            playerHolder.GetChild(0).position = spawnPoints[randomIndex].position;
            var a = player.GetComponent<UniversalHealth>();
            a.SetCurrentHealt(100);
            a.onHealthChange.Invoke();
            player.GetComponent<CharacterController>().enabled = true;
            //StartCoroutine(FadeEffect.FadeOut(cg, .5f));
    }

    public void SpawnAtRandomPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject player = Instantiate(playerPrefab, spawnPoints[randomIndex].position, quaternion.identity , playerHolder);
        //UnityEditor.Events.UnityEventTools.AddPersistentListener(player.GetComponent<UniversalHealth>().onDeath, ResetPlayerWithinSpawnPoints);
        player.GetComponent<UniversalHealth>().onDeath.AddListener(ResetPlayerWithinSpawnPoints);
        
        // player.GetComponent<UniversalHealth>().onDeath.SetPersistentListenerState(0 ,ResetPlayerWithinSpawnPoints());
    }

    public GameObject returnHostPlayer()
    {
        //WILL BE EDITED ONCE NETWORK IS DONE.
        return playerHolder.GetChild(0).gameObject;
    }

}
