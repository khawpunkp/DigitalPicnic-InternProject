using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private AnimationCurve spawnRateCurve;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Background bg;
    private int randomEnemy;
    private Vector3 spawnPos;
    private float timePass = 0;
    private float timePlayed = 0;
    private float spawnRate;

    // private float maxY;
    // private float minY;
    
    private void Start()
    {
        // var cvRect = canvas.GetComponent<RectTransform>().rect;
        // var cvScale = canvas.transform.localScale;
        // var offset = enemyPrefab[enemyPrefab.Length].GetComponent<RectTransform>().rect.width;
        //
        // maxY = (cvRect.height - offset) * cvScale.y;
        // minY = (0 + offset) * cvScale.y;
    }

    public void StartSpawnEnemy(bool isActive)
    {
        gameObject.GetComponent<EnemySpawner>().enabled = isActive;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        if(!isActive) return;
        SpawnEnemy();
        timePass = 0;
    }

    void Update()
    {
        timePass += Time.deltaTime;
        timePlayed = TimeManager.Instance.GetTime();
        // Debug.Log(timePlayed);
        spawnRate = spawnRateCurve.Evaluate(timePlayed) * 0.1f;
        if (timePass > spawnRate)
        {
            SpawnEnemy();
            timePass = 0;
        }
    }
    
    private void SpawnEnemy()
    {
        randomEnemy = Random.Range(0, enemyPrefab.Length);
        spawnPos = new Vector3(Random.Range(bg.minX, bg.maxX), transform.position.y);
        GameObject enemy = Instantiate(enemyPrefab[randomEnemy], transform);
        enemy.transform.position = spawnPos;
    }
}
