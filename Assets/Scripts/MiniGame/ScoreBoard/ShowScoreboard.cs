using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScoreboard : MonoBehaviour
{
    [SerializeField] private ScoreUI _scoreUI;
    
    public void OnClick_ShowScoreboard()
    {
        _scoreUI.ResetScoreUI();
        _scoreUI.InstantiateScore();
        gameObject.SetActive(true);
    }
}
