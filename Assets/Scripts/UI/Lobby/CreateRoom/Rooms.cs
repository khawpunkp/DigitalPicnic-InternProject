using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI.Lobby
{
    public class Rooms : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TextMeshProUGUI _text;

        public RoomInfo RoomInfo { get; private set; }
        
       
        
        public void SetRoomInfo(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
            _text.text = roomInfo.Name;
        }

        public void OnClick_JoinRoom()
        {
            PhotonNetwork.JoinRoom(RoomInfo.Name); 
        }
    }
}
