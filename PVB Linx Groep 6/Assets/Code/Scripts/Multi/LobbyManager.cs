using System.Collections.Generic;
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

        [Header("Get Rooms Settings: ")]
        [SerializeField] private RoomItem roomItemPref;
        [SerializeField] private Transform contentObject;

        private List<RoomItem> _getItem = new List<RoomItem>();
    

        // Start is called before the first frame update
        private void Start() => PhotonNetwork.JoinLobby();
        

        public void OnClickCreate()
        {
            if (roomInputField.text.Length >= 1)
                PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){MaxPlayers = getNumber});
        }

        public override void OnJoinedRoom()
        {
            changingPanels[0].SetActive(false); 
            changingPanels[1].SetActive(true);
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomInfos) => UpdateRoomList(roomInfos);

        private void UpdateRoomList(List<RoomInfo> list)
        {
            // Destroy first all in list before spawning new and updated list
            foreach (RoomItem item in _getItem)
                Destroy(item.gameObject);
            _getItem.Clear();

            foreach (RoomInfo room in list)
            {
                RoomItem newRoom = Instantiate(roomItemPref, contentObject);
                newRoom.SetRoomName(room.Name);
                _getItem.Add(newRoom);
            }
        }
    }
}
