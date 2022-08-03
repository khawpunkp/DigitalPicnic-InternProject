using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed * Background.Instance.cvScale.x);
    }
}
