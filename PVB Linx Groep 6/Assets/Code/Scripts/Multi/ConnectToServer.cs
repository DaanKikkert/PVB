using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Code.Scripts.Multi
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {

        [Header("Swap Canvas after connecting settings: ")] 
        [SerializeField] private GameObject[] loadInCanvas;

        private bool _connectionFailed;
        
        private void Awake() => PhotonNetwork.ConnectUsingSettings();

        public override void OnConnectedToMaster()
        {
            loadInCanvas[0].SetActive(false);
            loadInCanvas[1].SetActive(true);
        }

        
        
        public override void OnDisconnected(DisconnectCause cause)
        {
            if (_connectionFailed)
                return;

            // ReSharper disable once InvertIf
            if (cause != DisconnectCause.None)
            {
                Debug.LogWarning("Failed to connect to the server: " + cause);

                // Check if the client state is still in the process of connecting
                if (PhotonNetwork.NetworkClientState == ClientState.ConnectingToNameServer)
                {
                    Debug.LogWarning("Connection failed due to network restrictions. Please try again later or use a different network.");
                    loadInCanvas[0].SetActive(false);
                    loadInCanvas[2].SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Failed to connect to the server: " + cause);
                    loadInCanvas[0].SetActive(false);
                    loadInCanvas[2].SetActive(true);
                }
                
                if (cause == DisconnectCause.Exception)
                {
                    Debug.LogWarning("Connection failure. Please check your network connection and try again.");
                    loadInCanvas[0].SetActive(false);
                    loadInCanvas[2].SetActive(true);
                    _connectionFailed = true;
                }

                _connectionFailed = true; // Set flag for UI update
            }
        }
    }
}
