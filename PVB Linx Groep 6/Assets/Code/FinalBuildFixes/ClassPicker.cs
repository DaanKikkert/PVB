using System.Collections;
using System.Collections.Generic;
using Code.Player;
using UnityEngine;

public class ClassPicker : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    
    public void PickThisClass()
    {
        Debug.Log("Called");
        if (PlayerRespawnManager.instance != null)
        {
            Instantiate(player,PlayerRespawnManager.instance.GetPlayerHolder());
            PlayerRespawnManager.instance.SpawnAtRandomPoint();
            PlayerRespawnManager.instance.ResetPlayerWithinSpawnPoints();
        }

        if (WaveManager.instance != null)
            WaveManager.instance.NewWave();
        Destroy(camera);
        Destroy(transform.parent.gameObject);
    }
}
