using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.tag)
        {
            case "Enemy":
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
