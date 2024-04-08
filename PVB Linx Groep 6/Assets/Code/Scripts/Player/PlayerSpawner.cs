using System.Collections.Generic;
using UnityEngine;

namespace Code.Player
{
    public class PlayerSpawner : MonoBehaviour
    {

        [Header("Player Spawner Settings: ")] 
        [SerializeField] private GameObject playerPref;
        [SerializeField] private List<Transform> spawnPoints = new();

        private void Awake() => SpawnPlayer();
        
        public void SpawnPlayer()
        {
            var randomSpawn = Random.Range(0, spawnPoints.Count);
            Instantiate(playerPref, spawnPoints[randomSpawn].transform.position, Quaternion.identity);
        }
    }
}
