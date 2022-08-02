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
    private int score = 30;

    
    public void StartFireBullet(bool isActive)
    {
        gameObject.GetComponent<PlayerShooting>().enabled = isActive;
        if(!isActive) return;
        level = 1;
        FireBullet();
        timePass = 0;
    }

    private void Update()
    {
        ShowFunnel();
        timePass += Time.deltaTime;
        timePlayed = TimeManager.Instance.GetTime();
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
                if (level >= maxLevel)
                    ScoreManager.Instance.AddScore(score);
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
