using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFast : BaseBulletAbility
{
    private float timer = 5f;

    private  int _newSpeed = 13;
    private float _slowSpeed = .25f;
    public SlowFast(Transform transform, float speed)
    {
        bullet = transform;
        this.speed = speed;
    }

    public override void OnHit(Collider2D hit)
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
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            bullet.transform.Translate(Vector3.up * (_slowSpeed * Time.deltaTime));
        }else
        {
            bullet.transform.Translate(Vector3.up * (_newSpeed * Time.deltaTime));
        }
    }
}
