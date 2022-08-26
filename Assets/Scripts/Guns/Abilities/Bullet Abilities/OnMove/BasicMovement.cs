using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : BasicBulletAbility
{
    
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
       Debug.Log("Moving with Basic Movement");
    }
}
