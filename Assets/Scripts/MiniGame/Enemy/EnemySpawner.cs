using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private AnimationCurve spawnRateCurve;
    [SerializeField] private GameObject[] enemyPrefab;
    private int randomEnemy;
    private Vector3 spawnPos;
    private float timePass = 0;
    private float timePlayed = 0;
    private float spawnRate;

    void Start()
    {
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
        spawnPos = new Vector3(Random.Range(520, 1280), transform.position.y);
        GameObject enemy = Instantiate(enemyPrefab[randomEnemy], transform);
        enemy.transform.position = spawnPos;
    }
}
