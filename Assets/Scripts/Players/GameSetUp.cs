using System;
using Photon.Pun;
using UnityEngine;

public class GameSetUp : MonoBehaviour
{
    private bool active = false;
    [SerializeField] private GameObject _exitCanvas;
    
    // Start is called before the first frame update
    private void Awake()
    {
        MasterManager.NetworkInstantiate("instantiate", Vector3.zero, Quaternion.identity);
        _exitCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _exitCanvas.gameObject.SetActive(active);
            active = !active;
        }
    }

    public void OnClick_LeaveGame()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
