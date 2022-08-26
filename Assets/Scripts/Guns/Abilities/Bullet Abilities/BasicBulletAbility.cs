using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBulletAbility
{
    protected private int maxBounces;
    protected private float speed;
    protected private int damage;


    public Transform bullet;
    
    
    public abstract void OnHit(Collider hit);
    public abstract void OnHit();
    public abstract void OnTick();
    public abstract void OnMove();
}
