using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace UI.Lobby.CurrentRoom
{
    public class PlayerListing : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content;
        [SerializeField] private Players _player;

        private List<Players> players = new List<Players>();

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log(newPlayer.NickName + "Joined !");
            Players player = Instantiate(_player, _content);
            Debug.Log("Create list");
            if (player == null) return;
            player.SetPlayerInfo(newPlayer);
            players.Add(player);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Debug.Log(otherPlayer.NickName + "Leave !");
            var index = players.FindIndex(x => Equals(x.Player, otherPlayer));
            if (index == -1) return;
            Destroy(players[index].gameObject);
            players.RemoveAt(index);
        }
    }
}
