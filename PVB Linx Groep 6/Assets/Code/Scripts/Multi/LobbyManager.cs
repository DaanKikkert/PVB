using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.Multi
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {

        [Header("Input Manager Settings: ")] 
        [SerializeField] private InputField roomInputField;
        [SerializeField] private GameObject[] changingPanels;
        [SerializeField] private Text roomName;
        [SerializeField] [Range(1, 40)] private int getNumber;
    

        // Start is called before the first frame update
        private void Start() => PhotonNetwork.JoinLobby();
        

        public void OnClickCreate()
        {
            if (roomInputField.text.Length >= 1)
                PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){MaxPlayers = getNumber});
        }

        public override void OnJoinedRoom()
        {
            
        }
    }
}
