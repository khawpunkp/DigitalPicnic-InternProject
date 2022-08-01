using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameSetUp : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerShooting _playerBullet;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject score;
    [SerializeField] private TextMeshProUGUI time;
    private bool isActive = false;
    private float countDownTime = 0;
    public float startTime = 3.2f;

    private void Start()
    {
        countDownTime = startTime;
        time.gameObject.SetActive(true);
        GameplayActive(false);
    }

    private void Update()
    {
        Countdown(isActive);
        if (countDownTime < 0)
        {
            GameplayActive(true);
            Countdown(false);
            gameObject.GetComponent<MiniGameSetUp>().enabled = false;
        }
    }

    private void GameplayActive(bool active)
    {
        _enemySpawner.enabled = active;
        _playerController.enabled = active;
        _playerBullet.enabled = active;
        health.SetActive(active);
        score.SetActive(active);
    }

    private void Countdown(bool isCountdown)
    {
        time.gameObject.SetActive(isCountdown);
        if (isCountdown)
        {
            time.text = countDownTime.ToString("0");
            countDownTime -= 1 * Time.deltaTime;
        }
    }

    public void setActive(bool active)
    {
        isActive = active;
    }
}
