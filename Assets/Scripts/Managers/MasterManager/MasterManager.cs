using System.IO;
using Photon.Pun;
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : ScriptableObjectSingleton<MasterManager>
{
    [SerializeField] private GameSettings _gameSettings;
    public static GameSettings GameSettings
    {
        get { return Instance._gameSettings; }
    }

    public static GameObject NetworkInstantiate(string prefab,Vector3 position, Quaternion rotation)
    {
        GameObject result = PhotonNetwork.Instantiate(Path.Combine(prefab), position, rotation);
        return result;
    }
}