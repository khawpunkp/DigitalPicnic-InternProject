using UnityEngine;

namespace UI.Lobby
{
    public class CreateRoomCanvas : MonoBehaviour
    {
        [SerializeField] private CreateRoom _createRoom;
        [SerializeField] private RoomListing _roomListing;
        private RoomCanvas _roomCanvas;

        public void Start()
        {
            gameObject.SetActive(true);
        }

        public void FirstInitialize(RoomCanvas canvas)
        {
            _roomCanvas = canvas;
            _createRoom.FirstInitialize(canvas);
            _roomListing.FirstInitialize(canvas);
        }
    }
}
