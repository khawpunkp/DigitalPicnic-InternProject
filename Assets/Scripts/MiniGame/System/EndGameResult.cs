using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class EndGameResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private GameObject ScoreBoardCanvas;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private ShowScoreboard _showScoreboard;
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

    public void OnClick_SubmitScore()
    {
        ScoreBoardManager.Instance.AddScore(new PlayerScore(playerName.text, _playerHealth.finalScore));
        _showScoreboard.OnClick_ShowScoreboard();
        gameObject.SetActive(false);
    }
}
