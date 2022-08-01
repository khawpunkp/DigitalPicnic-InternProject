using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private  RowUI rowUI;

    public void InstantiateScore()
    {
        var playerScores = ScoreBoardManager.Instance.GetHighScore().ToArray();
        for (int i = 0; i < playerScores.Length && i < 5; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = playerScores[i].name;
            row.score.text = playerScores[i].score.ToString();
        }
    }
}
