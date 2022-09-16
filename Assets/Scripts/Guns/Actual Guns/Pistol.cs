using System;
using System.Collections;
using System.Collections.Generic;
using Guns;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = System.Object;

public class Pistol : BaseGun
{
    [Title("Pistol Attributes")] public CraftingRecipe baseMovement;

    public CraftingRecipe onHitTest;
    //The pistol is a basic gun that has a single bullet per shot.
    private void Start()
    { 
        AddAbility(baseMovement);
        currentMagazine = magazineSize;
    }
    
    
}
