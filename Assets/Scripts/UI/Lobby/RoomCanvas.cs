using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomCanvas : MonoBehaviour
{
    [SerializeField] private CreateRoomCanvas _createRoomCanvas;
    public CreateRoomCanvas CreateRoomCanvas
    {
        get { return _createRoomCanvas; }
    }
    
    [SerializeField] private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas
    {
        get { return _currentRoomCanvas; }
    }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CreateRoomCanvas.FirstInitailize(this);
        CurrentRoomCanvas.FirstInitailize(this);
    }
}
