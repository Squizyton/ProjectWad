using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    //Bounces
    [SerializeField] protected int bounces = 0;
    [SerializeField] protected int maxBounces = 3;


    [SerializeField] protected GameObject bulletPrefab;
    
    //Speed
    private protected float speed = 10;
    
    
    //Collision
    private protected int collideAmountMax = 1;
    
    
    //Actions
    
    //Action that happens every update
   private protected Action TickAction;
   private protected Action<Collider> OnHit;
   private protected Action OnMove;


   protected virtual void Start()
   {
       bounces = maxBounces;
   }

   public virtual void Update()
    {
        //The Tick Action is called every update
        TickAction?.Invoke();
        //Collision detection
        var hitColliders = new Collider[collideAmountMax];

        //Does not generate Garbage. Which is good
        var numColliders = Physics.OverlapSphereNonAlloc(transform.position, 0.1f, hitColliders);
        
        for (var i = 0; i < collideAmountMax; i++)
        {
            OnHit?.Invoke(hitColliders[i]);
            bounces--;
        }
    }

    public void FixedUpdate()
    {
        OnMove?.Invoke();
    }
    
    
    public void 
}
