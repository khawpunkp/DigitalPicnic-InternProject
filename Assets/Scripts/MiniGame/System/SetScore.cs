using TMPro;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.Instance.GetScore().ToString("0");
    }
}
