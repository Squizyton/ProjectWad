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


    //Collision
    private protected int collideAmountMax = 1;


    //Actions

    //Action that happens every update
    private Action TickAction;
    private Action<Collider> OnHit;
    private Action OnMove;


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
            if (!hitColliders[i]) return;

            Debug.Log(hitColliders[i]);

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
                Destroy(gameObject);
            }
        }
    }


    public void FixedUpdate()
    {
        OnMove?.Invoke();
    }


    public void InjectAbility(AbilityType.Type type, BaseBulletAbility ability)
    {
        switch (type)
        {
            case AbilityType.Type.OnTick:
                TickAction += ability.OnTick;
                break;
            case AbilityType.Type.OnHit:
                void OnAction(Collider onCollider) => ability.OnHit(new BoxCollider());
                OnHit += OnAction;
                break;
            case AbilityType.Type.OnMove:
                OnMove = ability.OnMove;
                break;
            case AbilityType.Type.Passive:

                break;
        }
    }
}