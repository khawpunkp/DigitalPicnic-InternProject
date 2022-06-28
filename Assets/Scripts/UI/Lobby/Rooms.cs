using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI.Lobby
{
    public class Rooms : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetRoomInfo(RoomInfo roomInfo)
        {
            _text.text = roomInfo.Name;
        }
    }
}
