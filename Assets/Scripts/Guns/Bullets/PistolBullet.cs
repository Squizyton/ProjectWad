using System.Collections;
using System.Collections.Generic;
using Guns.Abilities;
using UnityEngine;

public class PistolBullet : BaseBullet
{
    new void Start()
    {
        InjectAbility(AbilityType.Type.OnMove,new BasicMovement());
    }
}