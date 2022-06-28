using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI.Lobby
{
    public class CurrentRoomCanvas : MonoBehaviour
    {
        private RoomInfo _roomInfo;
    
        [SerializeField] private TextMeshProUGUI _roomID;
    
        private RoomCanvas _roomCanvas;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void FirstInitailize(RoomCanvas canvas)
        {
            _roomCanvas = canvas;
        }

        public void Show(bool active, string roomID)
        {
            gameObject.SetActive(active);
            if (active)
                _roomID.text = "Room ID: " + roomID;
        }
    }
}
