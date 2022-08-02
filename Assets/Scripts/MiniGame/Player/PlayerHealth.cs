using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    
    [SerializeField] public GameObject player;

    [SerializeField] private EnemySpawner _enemySpawner;

    private int health = 3;

    private int maxHealth = 3;

    private int score = 30;

    public int finalScore = 0;

    [SerializeField] private GameObject EndGameCanvas;

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            player.SetActive(false);
            finalScore = ScoreManager.Instance.GetScore();
            EndGameCanvas.SetActive(true);
            _enemySpawner.StartSpawnEnemy(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        switch (col.tag)
        {
            case "HealthItem":
                Destroy(col.gameObject);
                if (health >= maxHealth)
                    ScoreManager.Instance.AddScore(score);
                if (health < maxHealth)
                    health += 1;
                Debug.Log(health);
                hearts[health - 1].SetActive(true);
                break;
            case "Enemy":
                Destroy(col.gameObject);
                if (health > 0)
                {
                    hearts[health - 1].SetActive(false);
                    health -= 1;
                }
                break;
        }
    }

    public void SetPlayerMaxHealth()
    {
        health = maxHealth;
        foreach (var heart in hearts)
        {
            heart.SetActive(true);
        }
    }
}
