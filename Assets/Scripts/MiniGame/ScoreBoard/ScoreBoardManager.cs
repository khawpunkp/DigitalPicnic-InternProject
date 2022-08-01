using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Realtime;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    public static ScoreBoardManager Instance;

    private ScoreData SD;
    
    public void Awake()
    {
        SD = new ScoreData();
        
        if (Instance != null)
        {  
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public IEnumerable<PlayerScore> GetHighScore()
    {
        return SD.PlayerScores.OrderByDescending(x => x.score);
    }

    public void AddScore(PlayerScore playerScore)
    {
        SD.PlayerScores.Add(playerScore);
    }
}
