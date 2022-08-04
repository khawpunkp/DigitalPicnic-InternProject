using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Lobby.CurrentRoom
{
    public class PlayerListing : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content;
        [SerializeField] private Players _player;
        [SerializeField] private GameObject _readyButton;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private GameObject _masterReady;
        [SerializeField] private TextMeshProUGUI _readyText;
        [SerializeField] private TextMeshProUGUI _masterReadyText;
        private List<Players> players = new List<Players>();
        
        private RoomCanvas _roomCanvas;
        private bool _ready = false;

        public void FirstInitialize(RoomCanvas canvas)
        {
            _roomCanvas = canvas;
        }

        public void Update()
        {
            var isMaster = PhotonNetwork.IsMasterClient;
            _startButton.SetActive(isMaster);
            _masterReady.SetActive(isMaster);
            _readyButton.SetActive(!isMaster);
            if(isMaster)
                SetMasterReadyUp(CheckPlayerReady());
        }

        public override void OnEnable()
        {
            base.OnEnable();
            SetReadyUp(false);
            GetCurrentPlayer();
        }

        public override void OnDisable()
        {
            base.OnDisable();
            foreach (var x in players)
            {
                Destroy(x.gameObject);
            }
            players.Clear();
        }

        private void SetReadyUp(bool state)
        {
            _ready = state;
            if (_ready)
            {
                _readyButton.GetComponent<Image>().color = Color.green;
                _readyText.text = "Ready";
            }
            else
            {
                _readyButton.GetComponent<Image>().color = Color.red;
                _readyText.text = "Not Ready";
            }
        }

        private void SetMasterReadyUp(bool state)
        {
            if (state)
            {
                _masterReady.GetComponent<Image>().color = Color.green;
                _masterReadyText.text = "Ready";
            }
            else
            {
                _masterReady.GetComponent<Image>().color = Color.red;
                _masterReadyText.text = "NotReady";
            }
        }

        private void GetCurrentPlayer()
        {
            if(!PhotonNetwork.IsConnected)
                return;
            if(PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
                return;
            foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
            {
                AddPlayerList(playerInfo.Value);
            }
        }

        private void AddPlayerList(Player newPlayer)
        {
            var index = players.FindIndex(x => Equals(x.Player, newPlayer));
            if (index != -1)
                players[index].SetPlayerInfo(newPlayer);
            else
            {
                Debug.Log(newPlayer.NickName + " Joined !");
                var player = Instantiate(_player, _content);

                Debug.Log("Create " + newPlayer.NickName + " List");
                if (player == null) return;
                player.SetPlayerInfo(newPlayer);
                player.ready = false;
                players.Add(player);
            }
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            _roomCanvas.CurrentRoomCanvas.LeaveRoom.OnClick_LeaveRoom();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            AddPlayerList(newPlayer);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Debug.Log(otherPlayer.NickName + " Leave !");
            var index = players.FindIndex(x => Equals(x.Player, otherPlayer));
            if (index == -1) return;
            Destroy(players[index].gameObject);
            players.RemoveAt(index);
        }

        private bool CheckPlayerReady()
        {
            var allPlayerReady = true;
            foreach (var x in players)
            {
                if (!Equals(x.Player, PhotonNetwork.LocalPlayer)) 
                    allPlayerReady = allPlayerReady && x.ready;
            }
            return allPlayerReady;
        }
        
        public void OnClick_Start()
        {
            if (!PhotonNetwork.IsMasterClient) return;
            if (!CheckPlayerReady()) return;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            Cursor.visible = false;            
            Cursor.lockState = CursorLockMode.Locked;
            PhotonNetwork.LoadLevel("MainScene");            
        }

        public void OnClick_Ready()
        {
            if (PhotonNetwork.IsMasterClient) return;
            _ready = !_ready;
            SetReadyUp(_ready);
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, _ready);
        }

        [PunRPC]
        private void RPC_ChangeReadyState(Player player, bool ready)
        {
            var index = players.FindIndex(x => Equals(x.Player, player));
            if (index == -1) return;
            players[index].ready = ready;
        }
    }
}
