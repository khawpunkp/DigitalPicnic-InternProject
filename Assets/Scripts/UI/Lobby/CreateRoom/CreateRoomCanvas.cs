using System.Collections;
using System.Collections.Generic;
using UI.Lobby;
using UnityEngine;

public class CreateRoomCanvas : MonoBehaviour
{
    [SerializeField] private CreateRoom _createRoom;
    private RoomCanvas _roomCanvas;

    public void FirstInitailize(RoomCanvas canvas)
    {
        _roomCanvas = canvas;
        _createRoom.FirstInitailize(canvas);
    }
}
