using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject _detailCanvas;
    private bool active = false;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        active = !active;
        _detailCanvas.SetActive(active);
        Debug.Log("ButtonInteract Success");
        return true;
    }
}

