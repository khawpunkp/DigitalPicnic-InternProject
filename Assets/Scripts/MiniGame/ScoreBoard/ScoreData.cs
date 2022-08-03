using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public List<PlayerScore> PlayerScores;

    public ScoreData()
    {
        PlayerScores = new List<PlayerScore>();
    }
}
