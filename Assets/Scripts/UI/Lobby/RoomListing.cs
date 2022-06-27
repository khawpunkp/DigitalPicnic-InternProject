using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace UI.Lobby
{
    internal class RoomListing : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content;
        [SerializeField] private RoomList _room;

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log("update list");
            foreach (RoomInfo info in roomList)
            {
                RoomList listing = Instantiate(_room, _content);
                Debug.Log("create list");
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                }
            }
        }
    }
}
