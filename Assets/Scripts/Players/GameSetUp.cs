using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MasterManager.NetworkInstantiate("instantiate", Vector3.zero, Quaternion.identity);
    }
}
