using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI.Lobby
{
    public class CreateRoom : MonoBehaviourPunCallbacks
    {
        private RoomCanvas _roomCanvas;
        [SerializeField] private TextMeshProUGUI _roomID;

        public void FirstInitialize(RoomCanvas canvas)
        {
            _roomCanvas = canvas;
        }
        
        public void OnClick_CreateRoom()
        {
            if(!PhotonNetwork.IsConnected)
                return;
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 8;
            PhotonNetwork.JoinOrCreateRoom(_roomID.text, roomOptions, TypedLobby.Default);
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Created room successfully.");
            _roomCanvas.CurrentRoomCanvas.Show(true, _roomID.text);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log("Create room failed for reason: " + message);
        }
    }
}
