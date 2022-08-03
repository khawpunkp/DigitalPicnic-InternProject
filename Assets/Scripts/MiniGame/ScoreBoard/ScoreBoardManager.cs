using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Realtime;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    public static ScoreBoardManager Instance;

    private List<PlayerScore> PS;
    
    public void Awake()
    {
        PS = new List<PlayerScore>();
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    public IEnumerable<PlayerScore> GetHighScore()
    {
        return PS.OrderByDescending(x => x.score);
    }

    public void AddScore(PlayerScore playerScore)
    {
        PS.Add(playerScore);
    }

    
}
