using Photon.Pun;
using UnityEngine;

public class ButtonInteract : MonoBehaviourPun, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject _detail;
    private bool active = false;
    public float _areaRadius = 5f;

    public string InteractionPrompt => _prompt;
    
    private void Start()
    {
        GetComponent<SphereCollider>().radius = _areaRadius;
        _detail.SetActive(false);
    }

    public void Interaction(Interactor interactor)
    {
        active = !active;
        _detail.SetActive(active);
        Debug.Log("ButtonInteract Success");
    }
}

