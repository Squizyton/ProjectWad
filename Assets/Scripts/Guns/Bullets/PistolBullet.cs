using System.Collections;
using System.Collections.Generic;
using Guns.Abilities;
using Player;
using UnityEngine;

public class PistolBullet : BaseBullet
{
    private new void Start()
    {
      
        InjectAbility(AbilityType.Type.OnMove,new BasicMovement(transform, speed, transform.position - GunRotation.GetMousePosition() ));
    }
}