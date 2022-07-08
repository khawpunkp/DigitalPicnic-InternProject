using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Connection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server . . .");
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 10;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        //restrict game version
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        //connecting to photon
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "asia";
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        print("Connected to server !");
        print(PhotonNetwork.LocalPlayer.NickName);
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server for reason: " + cause);
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby !");
    }

    public override void OnJoinedRoom()
    {
        print("Joined room !");
    }
}
