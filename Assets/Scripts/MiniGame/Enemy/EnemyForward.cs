using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
