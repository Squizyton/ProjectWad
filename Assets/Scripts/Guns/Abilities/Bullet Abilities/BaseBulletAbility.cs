using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class BaseBulletAbility 
{
    protected int maxBounces;
    protected float speed;
    protected int damage;


    public Transform bullet;

    public BaseBulletAbility()
    {
    }

    public BaseBulletAbility(Transform bullet)
    {
        this.bullet = bullet;
    }


    public abstract void OnHit(Collider hit);
    public abstract void OnHit();
    public abstract void OnTick();
    public abstract void OnMove();
}
