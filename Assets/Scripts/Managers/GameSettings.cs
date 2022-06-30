using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Managers/GameSettings")]
public class GameSettings : ScriptableObject
{

    [SerializeField] private string _gameVersion = "0.0.0";
    public string GameVersion
    {
        get { return _gameVersion; }
    }

    [SerializeField] private string _nickName = "Player";

    public string NickName
    {
        get
        {
            int id = Random.Range(0, 9999);
            return _nickName + "_" + id;
        }
    }
}
