using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGameInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public float _areaRadius = 7;
    public bool isActive = false;
    private GameObject[] players;
    private GameObject localPlayer;
    [SerializeField] private GameObject MiniGame;
    [SerializeField] private GameObject StartGameCanvas;
    [SerializeField] private GameObject EndGameCanvas;
    [SerializeField] private MiniGameSetUp MiniGameSetUp;
    
    public string InteractionPrompt => _prompt;

    private void Start()
    {
        GetComponent<CapsuleCollider>().radius = _areaRadius;
        MiniGame.SetActive(false);
        MiniGameSetUp.setActive(false);
    }

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var p in players)
        {
            if (p.GetPhotonView().IsMine)
                localPlayer = p;
        }
    }

    public void Interaction(Interactor interactor)
    {
        MiniGame.SetActive(true);
        StartGameCanvas.SetActive(true);
        MiniGameSetUp.gameObject.SetActive(true);
        EndGameCanvas.SetActive(false);
        PlayerDisplay(false);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    // countDownTime = startTime;
    // time.gameObject.SetActive(true);
    // }
    //
    // private void OnTriggerStay(Collider other)
    // {
    //     isActive = true;
    //     MiniGame.SetActive(true);
    //     TimeManager.Instance.StartTimer();
    //     ScoreManager.Instance.StartScore();
    //     time.text = countDownTime.ToString("0");
    //     countDownTime -= 1 * Time.deltaTime; 
    //     if (countDownTime <= 3)
    //         time.color = Color.red;
    //     if (countDownTime <= 0)
    //         time.gameObject.SetActive(false);
    //     PlayerDisplay(false);
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    // isActive = false;
    // countDownTime = startTime;
    // time.gameObject.SetActive(false);
    // MiniGame.SetActive(false);
    // localPlayer.SetActive(true);
    // }

    private void PlayerDisplay(bool active)
    {
        localPlayer.GetComponent<ThirdPersonController>().enabled = active;
        localPlayer.transform.GetChild(0).gameObject.SetActive(active);
    }
    
    public void OnClick_ExitMiniGame()
    {
        PlayerDisplay(true);
        MiniGame.SetActive(false);
        localPlayer.SetActive(true);
    }

    public void OnClick_StartMiniGame()
    {
        MiniGameSetUp.setActive(true);
        StartGameCanvas.SetActive(false);
        TimeManager.Instance.StartTimer();
        ScoreManager.Instance.StartScore();
    }
}
