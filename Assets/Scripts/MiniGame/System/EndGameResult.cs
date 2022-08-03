using System.Security.Cryptography;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class EndGameResult : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private ShowScoreboard _showScoreboard;
    [SerializeField] private GameObject score;


    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Score: " + _playerHealth.finalScore;
        score.SetActive(false);
    }

    public void OnClick_SubmitScore()
    {
        photonView.RPC("AddScoreToList", RpcTarget.All, playerName.text, _playerHealth.finalScore);
        // ScoreBoardManager.Instance.AddScore(new PlayerScore(playerName.text, _playerHealth.finalScore));
        _showScoreboard.OnClick_ShowScoreboard();
        gameObject.SetActive(false);
    }

    [PunRPC]
    void AddScoreToList(string playerName, int playerScore)
    {
        ScoreBoardManager.Instance.AddScore(new PlayerScore(playerName, playerScore));
    }
}
