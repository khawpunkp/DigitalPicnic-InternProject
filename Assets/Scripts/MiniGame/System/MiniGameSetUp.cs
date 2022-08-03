using System;
using TMPro;
using UnityEngine;

public class MiniGameSetUp : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerShooting _playerBullet;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject score;
    [SerializeField] private TextMeshProUGUI time;
    private bool isActive = false;
    private float countDownTime = 0;
    public float startTime = 3.2f;
    private Vector3 spawnPos;

    private void Start()
    {
        GameplayActive(false);
        spawnPos = _player.transform.position;
    }

    public void StartCountDown(bool active)
    {
        isActive = active;
        if(!isActive) return;
        countDownTime = startTime;
        _player.transform.position = spawnPos;
        time.gameObject.SetActive(true);
        GameplayActive(false);
        gameObject.GetComponent<MiniGameSetUp>().enabled = true;
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
        _enemySpawner.StartSpawnEnemy(active);
        _player.GetComponent<PlayerController>().enabled = active;
        _playerBullet.StartFireBullet(active);
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
}
