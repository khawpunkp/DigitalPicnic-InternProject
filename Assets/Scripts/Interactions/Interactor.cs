using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor.UIElements;
using UnityEngine;

public class Interactor : MonoBehaviourPun
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[10];
    [SerializeField] private int _objFound;

    private void Update()
    {
        if (!photonView.IsMine) return;
        _objFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius, _colliders,
            _interactableMask);

        if (_objFound <= 0) return;
        var interactable = _colliders[0].GetComponent<IInteractable>();
        var tag = _colliders[0].tag;
        
        if(interactable == null) return;
        switch (tag)
        {
            case "ButtonInteractable" when Input.GetKeyDown(KeyCode.F):
                interactable.Interaction(this);
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionRadius);
    }
}
