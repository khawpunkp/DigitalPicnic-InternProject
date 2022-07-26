using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private AnimationCurve fireRateCurve;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private Transform[] bulletPosition;
    private float fireRate;
    private float timePass = 0;
    private float timePlayed = 0;
    private float level = 1;
    private float maxLevel = 4;
    [SerializeField] private GameObject[] funnel;

    // Update is called once per frame
    void Start()
    {
        FireBullet();
        timePass = 0;
        // InvokeRepeating("FireBullet", 1f, fireRate * 0.1f);
    }

    private void Update()
    {
        ShowFunnel();
        timePass += Time.deltaTime;
        timePlayed += Time.deltaTime;
        fireRate = fireRateCurve.Evaluate(timePlayed) * 0.1f;
        if (timePass > fireRate)
        {
            FireBullet();
            timePass = 0;
        }
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
        GameObject bullet = Instantiate(playerBullet, bulletParent);
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
                if (level > 1)
                    level -= 1;
                break;
        }
    }
}
