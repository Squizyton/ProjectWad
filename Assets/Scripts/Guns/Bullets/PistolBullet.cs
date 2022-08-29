using System.Collections;
using System.Collections.Generic;
using Guns.Abilities;
using Guns.Abilities.Bullet_Abilities.OnTick;
using Player;
using UnityEngine;

public class PistolBullet : BaseBullet
{
    private new void Start()
    {
      
        InjectAbility(AbilityType.Type.OnMove,new BaseMovement(transform, speed, transform.position - GunRotation.GetMousePosition() ));
        InjectAbility(AbilityType.Type.OnTick,new BaseTickAbility(transform,2f,true));
    }
}