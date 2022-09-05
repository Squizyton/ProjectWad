using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFast : BaseBulletAbility
{
    private float timer = 5f;

    private  int newSpeed = 13;

    public SlowFast(Transform transform, float speed)
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

        
        //TODO: Fix newly spawned bullets running at the same time
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            bullet.transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }else
        {
            bullet.transform.Translate(Vector3.up * (newSpeed * Time.deltaTime));
        }
    }
}
