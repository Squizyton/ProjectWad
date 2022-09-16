using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFan : BaseBulletAbility
{
    public GameObject bulletPrefab;
    private int _bulletCount = 8;
    private float procChance = .2f;

    public BulletFan(Transform transform, float speed)
    {
        bulletPrefab = transform.gameObject;
        bullet = transform;
        this.speed = speed;
    }

    public override void OnHit(Collider2D hit)
    {
        //Check to see if proc chance is met
        var percentage = Random.Range(0f, 1f);
        Debug.Log(percentage);
        if(percentage > procChance) return;
        
       for(var i = 0; i < _bulletCount; i++)
       {
           var bulletSpawn = Object.Instantiate(bulletPrefab, hit.transform.position, Quaternion.identity);
           bulletSpawn.transform.Rotate(0, 0, i * 360f / _bulletCount);
           bulletSpawn.TryGetComponent(out BaseBullet _bullet);
           
           foreach(var ability in PlayerInventory.instance.GetCurrentGun().ReturnAbilities())
            _bullet.InjectAbility(ability.ReturnType(),ability.ReturnAbility());

           _bullet.SetCantCollideWith(hit);

       }
    }

    public override void OnHit()
    {
       
    }

    public override void OnTick()
    {
    
    }

    public override void OnMove()
    {
    
    }
}
