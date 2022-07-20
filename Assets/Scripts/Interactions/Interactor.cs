using Photon.Pun;
using UnityEngine;

public class Interactor : MonoBehaviourPun
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[10];
    [SerializeField] private int _objFound;

    private IInteractable interactable;
    [SerializeField] private InteractionUI interactionUI;

    private void Update()
    {
        if (!photonView.IsMine) return;
        _objFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius, _colliders,
            _interactableMask);

        if (_objFound > 0)
        {
            interactable = _colliders[0].GetComponent<IInteractable>();
            var tag = _colliders[0].tag;

            if (interactable == null) return;
            if (!interactionUI.isDisplayed)
                interactionUI.Show(true, interactable.InteractionPrompt);
            switch (tag)
            {
                case "ButtonInteractable" when Input.GetKeyDown(KeyCode.F):
                    interactable.Interaction(this);
                    break;
            }
        }
        else
        {
            if (interactable != null)
                interactable = null;
            if(interactionUI.isDisplayed)
                interactionUI.Show();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionRadius);
    }
}
