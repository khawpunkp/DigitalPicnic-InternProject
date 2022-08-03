using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LeaveRoom : MonoBehaviour
{

    private RoomCanvas _roomCanvas;

    public void FirstInitialize(RoomCanvas canvas)
    {
        _roomCanvas = canvas;
    }
    
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomCanvas.CurrentRoomCanvas.Show(false);
    }
}
