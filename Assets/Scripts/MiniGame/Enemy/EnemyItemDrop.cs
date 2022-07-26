using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour
{
    [SerializeField] private AnimationCurve spawnRateCurve;
    [SerializeField] private GameObject[] itemPrefab;
    private float timePlayed = 0;
    private int spawnRate;
    private int isSpawn = 10;
    private int dropRate = 150;
    public int health = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime;
        Debug.Log(timePlayed);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.tag)
        {
            case "MinigamePlayer":
            {
                health -= 1;
                if (health == 0)
                {
                    Destroy(gameObject);
                    spawnRate = Mathf.RoundToInt(spawnRateCurve.Evaluate(timePlayed));
                    isSpawn = Random.Range(0, 100);
                    // Debug.Log("spawn rate: " + spawnRate + "  is spawn: " + isSpawn);
                    // Debug.Log(isSpawn <= spawnRate);
                    if (isSpawn <= spawnRate || dropRate <= spawnRate)
                    {
                        SpawnItem();
                        dropRate = 150;
                    }
                    else
                    {
                        dropRate -= 10;
                    }
                }
                break;
            }
        }
    }

    private void SpawnItem()
    {
        GameObject enemy = Instantiate(itemPrefab[Random.Range(0, 2)], transform.parent);
        enemy.transform.position = transform.position;
    }
}
