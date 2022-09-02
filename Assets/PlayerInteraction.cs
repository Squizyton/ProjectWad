using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]private LayerMask interactionMask;
    private Collider2D _previousColliders;
    
    private IInteractable _currentInteractable;
    [SerializeField]private CanvasGroup _canvasGroup;

    private void Update()
    {
      
        if (_currentInteractable != null)
        {
            _canvasGroup.alpha = 1;
        }else if(_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= Time.deltaTime;
        }
        
        if(_currentInteractable != null)
            if(Input.GetKeyDown(KeyCode.F))
                _currentInteractable.OnInteract();
    }

    //TODO: Should this be a normal OnTriggerEnter2D or OverlapCircle??
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        
        if(!other.gameObject.layer.Equals(7)) return;
        
        if(other.TryGetComponent(out IInteractable interactable))
            _currentInteractable = interactable;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       

        if (!other.TryGetComponent(out IInteractable interactable)) return;
        
        if (interactable == _currentInteractable)
            _currentInteractable = null;
    }
}
