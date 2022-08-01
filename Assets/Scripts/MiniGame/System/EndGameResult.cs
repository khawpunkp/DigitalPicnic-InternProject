using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private GameObject score;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Score: " + _playerHealth.finalScore;
        score.SetActive(false);
    }
}
