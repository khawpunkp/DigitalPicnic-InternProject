using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public int health = 1;
    private void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.tag)
        {
            case "MinigamePlayer":
            {
                health -= 1;
                if(health == 0)
                    Destroy(gameObject);
                break;
            }
        }
    }
}
