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

        public void FirstInitailize(RoomCanvas canvas)
        {
            _roomCanvas = canvas;
            _createRoom.FirstInitailize(canvas);
            _roomListing.FirstInitailize(canvas);
        }
    }
}
