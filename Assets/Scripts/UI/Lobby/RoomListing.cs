using System;
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

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log("Update room list");
            foreach (RoomInfo info in roomList)
            {
                Rooms listing = Instantiate(_room, _content);
                Debug.Log("Create list");
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                }
            }
        }
    }
}
