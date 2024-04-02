using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.Multi
{
    public class RoomItem : MonoBehaviour
    {
        [Header("Room Item Settings: ")] 
        [SerializeField] private Text roomName;
        [SerializeField] private Text howManyPeopleInRoom;

        public void SetRoomName(string getRoomName)
        {
            roomName.text = roomName.text;
        }
    }
}
