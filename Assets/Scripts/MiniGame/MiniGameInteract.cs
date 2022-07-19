using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class MiniGameInteract : MonoBehaviour
{
    private float countDownTime = 0;
    public float startTime = 5.2f;
    public bool isActive = false;
    private GameObject[] players;
    private GameObject localPlayer;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private GameObject MiniGame;

    private void Start()
    {
        countDownTime = startTime;
        time.gameObject.SetActive(false);
        MiniGame.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        countDownTime = startTime;
        time.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        isActive = true;
        MiniGame.SetActive(true);
        time.text = countDownTime.ToString("0");
        countDownTime -= 1 * Time.deltaTime; 
        if (countDownTime <= 3)
            time.color = Color.red;
        if (countDownTime <= 0)
            time.gameObject.SetActive(false);
        localPlayer.GetComponent<ThirdPersonController>().enabled = false;
        localPlayer.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
        countDownTime = startTime;
        time.gameObject.SetActive(false);
        MiniGame.SetActive(false);
        localPlayer.SetActive(true);
    }
}
