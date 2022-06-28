using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace UI.Lobby
{
    public class RoomListing : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content;
        [SerializeField] private Rooms _room;

        private List<Rooms> rooms = new List<Rooms>();

        private RoomCanvas _roomCanvas;

        public void FirstInitailize(RoomCanvas canvas)
        {
            _roomCanvas = canvas;
        }
        
        public override void OnJoinedRoom()
        {
            _roomCanvas.CurrentRoomCanvas.Show(true, PhotonNetwork.CurrentRoom.Name);
            _content.DestroyChildren();
        }
        
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log("Update room list");
            foreach (RoomInfo info in roomList)
            {
                if (info.RemovedFromList)
                {
                    var index = rooms.FindIndex(x => x.RoomInfo.Name == info.Name);
                    if (index == -1) continue;
                    Destroy(rooms[index].gameObject);
                    rooms.RemoveAt(index);
                }
                else
                {
                    Rooms room = Instantiate(_room, _content);
                    Debug.Log("Create list");
                    if (room == null) continue;
                    room.SetRoomInfo(info);
                    rooms.Add(room);
                }
            }
        }
    }
}
