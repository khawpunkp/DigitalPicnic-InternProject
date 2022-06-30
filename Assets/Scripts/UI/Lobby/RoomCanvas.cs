using UI.Lobby;
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

    private void Start()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CreateRoomCanvas.FirstInitialize(this);
        CurrentRoomCanvas.FirstInitialize(this);
    }
}
