using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBulletAbility
{
    protected int maxBounces;
    protected float speed;
    protected int damage;


    public Transform bullet;
    
    
    public abstract void OnHit(Collider hit);
    public abstract void OnHit();
    public abstract void OnTick();
    public abstract void OnMove();
}
