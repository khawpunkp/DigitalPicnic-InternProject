using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UI.Lobby.CurrentRoom;
using UnityEngine;

namespace UI.Lobby
{
    public class CurrentRoomCanvas : MonoBehaviour
    {
        private RoomInfo _roomInfo;
    
        [SerializeField] private TextMeshProUGUI _roomID;

        [SerializeField] private PlayerListing _playerListing;
        [SerializeField] private LeaveRoom _leaveRoom;
        public LeaveRoom LeaveRoom
        {
            get { return _leaveRoom; }
        }
        
        private RoomCanvas _roomCanvas;

        private void Awake()
        {
            Debug.Log("current awake");
            gameObject.SetActive(false);
        }

        public void FirstInitialize(RoomCanvas canvas)
        {
            _roomCanvas = canvas;
            _leaveRoom.FirstInitialize(canvas);
            _playerListing.FirstInitialize(canvas);
        }

        public void Show(bool active, string roomID = "")
        {
            gameObject.SetActive(active);
            if (!active) return;
            if(PhotonNetwork.IsMasterClient)
                _roomID.text = "[MASTER] " + roomID;
            else
                _roomID.text = roomID;
        }
    }
}
