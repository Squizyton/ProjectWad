using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CraftingRecipe : SerializedScriptableObject
{
    [Title("Base Variables")]
    public string recipeName;
    
    [Space]
    
    [Title("Recipe")]
    [BoxGroup("Material List")] public List<Ingredients> ingredientsList;


}


[Serializable]
public struct Ingredients
{
    public BaseMaterial material;
    public int amount;
}