using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "New Crafting Recipe",fileName = "New Crafting Recipe")]
public class BulletCraftingRecipe : SerializedScriptableObject
{
    [Title("Base Variables")]
    public string recipeName;
    
    [Space]
    
    [Title("Recipe")]
    [BoxGroup("Material List")] public List<Ingredients> ingredientsList;

    
    [Title("End Results")]
    public BaseBulletAbility bulletAbility;
    
}

[Serializable]
public struct Ingredients
{
    public BaseMaterial material;
    public int amount;
}
