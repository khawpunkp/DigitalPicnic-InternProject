using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject[] heart;

    private int health = 3;

    private int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        switch (col.tag)
        {
            case "HealthItem":
                Destroy(col.gameObject);
                if (health < maxHealth)
                    health += 1;
                Debug.Log(health);
                heart[health - 1].SetActive(true);
                break;
            case "Enemy":
                Destroy(col.gameObject);
                heart[health - 1].SetActive(false);
                health -= 1;
                break;
        }
    }
}
