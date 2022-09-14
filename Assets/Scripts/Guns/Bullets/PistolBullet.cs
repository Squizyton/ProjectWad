using System;
using System.Collections;
using System.Collections.Generic;
using Crafting;
using Guns.Abilities;
using Guns.Abilities.Bullet_Abilities.OnTick;
using Guns.Abilities.Bullet_Abilities;
using Player;
using UnityEngine;

public class PistolBullet : BaseBullet
{
    public BulletCraftingRecipe recipe;
    
    
    private new void Start()
    {
        
        var test = recipe.bulletAbility.GetType();

        var test2 = (BaseBulletAbility) Activator.CreateInstance(test,transform,10f);
        
        InjectAbility(AbilityType.Type.OnMove,test2);
        InjectAbility(AbilityType.Type.OnTick,new BaseTickAbility(transform,2f,true));
        
    }


    private new void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Bullet Movement Changed!");
            InjectAbility(AbilityType.Type.OnMove,new SlowFast(transform, .05f));
        }
    }
}