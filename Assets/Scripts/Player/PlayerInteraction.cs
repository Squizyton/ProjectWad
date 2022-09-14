using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]private LayerMask interactionMask;
    private Collider2D _previousColliders;
    
    private IInteractable _currentInteractable;
    [SerializeField]private CanvasGroup _canvasGroup;

    [Title("Pick Up Variable")]
    [SerializeField,ReadOnly]private float pickUpRange;
    [SerializeField]private float basePickUpRange;
    [SerializeField]private LayerMask pickUpMask;
    private const int MaxColliders = 99;


    private void Start()
    {
        pickUpRange = basePickUpRange;
        
    }

    private void Update()
    {
        
        //Pickup-----
        var colliders = new Collider2D[MaxColliders];
        var colliderCount = Physics2D.OverlapCircleNonAlloc(transform.position, pickUpRange, colliders, pickUpMask);
        
        
        for(var i = 0; i < colliderCount; i++)
        {
            var obj = colliders[i];
            //TryGetComponent is better than GetComponent. Due to memory allocation
            obj.TryGetComponent<IPickupable>(out var pickup);
            pickup?.Pickup(transform);
        }
        
        
        
        //Interact----------    
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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }
}
