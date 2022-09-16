using System;
using System.Collections;
using System.Collections.Generic;
using Guns.Abilities;
using Sirenix.OdinInspector;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    //Bounces
    [SerializeField, ReadOnly] protected int bounces = 0;
    [SerializeField] protected int maxBounces = 0;

    [SerializeField] protected int baseDamage = 0;
    [SerializeField] protected GameObject bulletPrefab;

    //Speed
    [SerializeField] private protected float speed = 10;

    //LayerMask
    [SerializeField] protected LayerMask layerMask;

    //Collision
    private protected int collideAmountMax = 1;
    private Collider2D _cantCollideWith;

    //Actions

    //Action that happens every update
    private Action TickAction;
    
    
    
    private Action<Collider2D> OnHit;
    
    private Action OnMove;

    [SerializeField]private bool cantDie;
    [SerializeField]private bool cantCollide;
    protected virtual void Start()
    {
        bounces = maxBounces;
    }

    public virtual void Update()
    {
        
        //The Tick Action is called every update
        TickAction?.Invoke();

        if (cantCollide) return;
        //Collision detection
        var hitColliders = new Collider2D[collideAmountMax];

        //Does not generate Garbage. Which is good
        var numColliders = Physics2D.OverlapCircleNonAlloc(transform.position, 0.1f, hitColliders, layerMask);

        for (var i = 0; i < collideAmountMax; i++)
        {
            if(_cantCollideWith == hitColliders[i]) continue;
            
            
            if (!hitColliders[i]) return;

            OnHit?.Invoke(hitColliders[i]);
            //
            if (bounces > 0)
            {
                bounces--;
                // Rotate the bullet to a random direction
                var randomRotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
            }
            else
            {
                if (cantDie) return;
                Destroy(gameObject);
            }
        }
    }

    public void SetCantCollideWith(Collider2D target)
    {
        _cantCollideWith = target;
    }
    
    public IEnumerator WaitToCollide(float time)
    {
        cantCollide = true;
        cantDie = true;
        yield return new WaitForSeconds(time);
        cantDie = false;
        cantCollide = false;
    }
    
    public void FixedUpdate()
    {
        OnMove?.Invoke();
    }


    public void InjectAbility(AbilityType.Type type, BaseBulletAbility ability)
    {
        var abilityType = ability.GetType();

        if(Activator.CreateInstance(abilityType,transform,10f) is not BaseBulletAbility newAbility) return;
        
        switch (type)
        {
            case AbilityType.Type.OnTick:
                TickAction += newAbility.OnTick;
                break;
            case AbilityType.Type.OnHit:
                void OnAction(Collider2D onCollider) => newAbility.OnHit(onCollider);
                OnHit += OnAction;
                break;
            case AbilityType.Type.OnMove:
                OnMove = newAbility.OnMove;
                break;
        }
    }
}