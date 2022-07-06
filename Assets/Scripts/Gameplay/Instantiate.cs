using Photon.Pun;
using UnityEngine;

public class Instantiate : MonoBehaviourPun
{
    [SerializeField] private GameObject Prefab;

    private void Awake()
    {
        Vector3 offset = Random.insideUnitCircle * 3f;
        var position = transform.position;
        Vector3 instantiatePosition = new Vector3(position.x + offset.x, position.y, position.z + offset.z);
        
        if (!photonView.IsMine) return;
        MasterManager.NetworkInstantiate(Prefab, instantiatePosition, Quaternion.identity);
    }
}
