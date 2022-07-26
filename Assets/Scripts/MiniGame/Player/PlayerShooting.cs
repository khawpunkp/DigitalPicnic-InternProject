using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform[] bulletPosition;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private float level = 1;
    private float maxLevel = 4;
    [SerializeField] private GameObject[] funnel;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("FireBullet", 1f, fireRate * 0.1f);
    }

    private void Update()
    {
        ShowFunnel();
    }

    private void ShowFunnel()
    {
        switch (level)
        {
            case < 3:
                funnel[0].SetActive(false);
                funnel[1].SetActive(false);
                break;
            case >= 3:
                funnel[0].SetActive(true);
                funnel[1].SetActive(true);
                break;
        }
    }

    private void InstantiateBullet(int i)
    {
        GameObject bullet = Instantiate(playerBullet, bulletPosition[i]);
        bullet.transform.position = bulletPosition[i].position;
    }

    private void FireBullet()
    {
        switch (level)
        {
            case 1:
                InstantiateBullet(0);
                break;
            case 2:
                InstantiateBullet(1);
                InstantiateBullet(2);
                break;
            case 3:
                InstantiateBullet(0);
                InstantiateBullet(3);
                InstantiateBullet(4);
                break;
            case 4:
                InstantiateBullet(1);
                InstantiateBullet(2);
                InstantiateBullet(3);
                InstantiateBullet(4);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        switch (col.tag)
        {
            case "PowerItem":
            {
                Debug.Log(level);
                Destroy(col.gameObject);
                if (level < maxLevel)
                    level += 1;
                break;
            }
            case "Enemy":
                Destroy(col.gameObject);
                level = 1;
                break;
        }
    }
}
