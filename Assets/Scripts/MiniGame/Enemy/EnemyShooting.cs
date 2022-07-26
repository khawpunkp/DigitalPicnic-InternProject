using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform[] bulletPosition;
    [SerializeField] private float fireRate = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBullet", 1f, fireRate * 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FireBullet()
    {
        foreach (var pos in bulletPosition)
        {
            GameObject bullet = Instantiate(enemyBullet, pos);
            bullet.transform.position = pos.position;
        }
    }
}
