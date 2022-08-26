using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : BasicBulletAbility
{

    public BasicMovement(Transform transform, float speed)
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
      bullet.transform.position += bullet.transform.forward * (speed * Time.deltaTime);
    }
}
