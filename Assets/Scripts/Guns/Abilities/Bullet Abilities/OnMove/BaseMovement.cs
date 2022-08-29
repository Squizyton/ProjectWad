using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : BaseBulletAbility
{
    private Vector3 direction;

    public BaseMovement(Transform transform, float speed, Vector3 direction)
    {
        bullet = transform;    
        this.speed = speed;
      
    }

    public override void OnHit(Collider hit)
    {
        throw new System.NotImplementedException();
    }

    public override void OnHit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTick()
    {
        throw new System.NotImplementedException();
    }

    public override void OnMove()
    {

        //Move the bullet
        bullet.transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }
}
