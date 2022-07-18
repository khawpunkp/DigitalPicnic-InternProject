using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class MiniGameInteract : MonoBehaviour
{
    private float countDownTime = 0;
    public float startTime = 5.9f;
    [SerializeField] private TextMeshProUGUI time;

    private void Start()
    {
        countDownTime = startTime;
        time.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Debug.Log(countDownTime);
        // countDownTime -= 1 * Time.deltaTime;
        // time.text = countDownTime.ToString("0");
        // if (countDownTime <= 3)
        //     time.color = Color.red;
        // if (countDownTime <= 0)
        //     countDownTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        countDownTime = startTime;
        time.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(countDownTime);
        countDownTime -= 1 * Time.deltaTime;
        time.text = countDownTime.ToString("0");
        if (countDownTime <= 3)
            time.color = Color.red;
        if (countDownTime <= 0)
            PhotonNetwork.LoadLevel("MiniGame");
    }

    private void OnTriggerExit(Collider other)
    {
        countDownTime = startTime;
        time.gameObject.SetActive(false);
    }
}
