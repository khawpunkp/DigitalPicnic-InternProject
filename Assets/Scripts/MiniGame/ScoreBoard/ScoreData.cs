using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData : MonoBehaviour
{
    public List<PlayerScore> PlayerScores;

    public ScoreData()
    {
        PlayerScores = new List<PlayerScore>();
    }
}
