using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI.Lobby
{
    public class Players : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public Player Player { get; private set; }
        public bool ready = false;
        
        public void SetPlayerInfo(Player player)
        {
            Player = player;
            _text.text = player.NickName;
        }
    }
}
