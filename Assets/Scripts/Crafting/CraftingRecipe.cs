using System;
using System.Collections;
using System.Collections.Generic;
using Guns.Abilities;
using Sirenix.OdinInspector;
using UnityEngine;

public class CraftingRecipe: SerializedScriptableObject
{
    [Title("Base Variables")]
    public string recipeName;
    
    [Space]
    
    [Title("Recipe")]
    [BoxGroup("Material List")] public List<Ingredients> ingredientsList;

    [Title("Crafting Recipe For")] public bool gun;
    public bool bullet;
    public bool player;

    [ShowIf("@gun||bullet||player")] public AbilityType.Type type;
}


[Serializable]
public struct Ingredients
{
    public BaseMaterial material;
    public int amount;
}