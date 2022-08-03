using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerScore
{
    public string name;
    public int score;

    public PlayerScore(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
