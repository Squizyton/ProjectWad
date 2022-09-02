using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]private LayerMask interactionMask;
    private Collider2D _previousColliders;
    
    private IInteractable _currentInteractable;
    
    //TODO: Should this be a normal OnTriggerEnter2D or OverlapCircle??
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer != interactionMask.value) return;
        
        if(other.TryGetComponent(out IInteractable interactable))
            _currentInteractable = interactable;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer != interactionMask.value) return;

        if (!other.TryGetComponent(out IInteractable interactable)) return;
        
        if (interactable == _currentInteractable)
            _currentInteractable = null;
    }
}
