using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
  [SerializeField]private CanvasGroup craftingUI;
  
  [SerializeField]private CraftableAbilityUI craftingAbilityPrefab;
  [SerializeField] private Transform[] currentRecipesPrefabs;
  
  [SerializeField]private Transform craftingAbilityParent;

  private void Start()
  {
    
    currentRecipesPrefabs = new Transform[3];

    CreateAbilities();

    craftingUI.alpha = 0;
  }

  private void CreateAbilities()
  {
    for(var x = 0; x < currentRecipesPrefabs.Length; x++)
    {
        var craftableAbilityUI = Instantiate(craftingAbilityPrefab, craftingAbilityParent);
        craftableAbilityUI.InjectInfo(AbilitiesManager.Instance.GetRandomRecipe());
        
    } 
  }


  public static void CraftRecipe(CraftingRecipe recipe)
  {
    try
    {
      foreach(var materials in recipe.ingredientsList)
      {
        if(PlayerInventory.instance.CheckMaterial(materials.material,materials.amount))
          PlayerInventory.instance.RemoveMaterial(materials.material,materials.amount);
        else break;
      }

      if (recipe.bullet)
      {
        PlayerInventory.instance.GetCurrentGun().AddAbility(recipe);
      }
    }
    catch (Exception e)
    {
      Debug.LogError("Not Enough Resources");
      throw;
    }
  }

}
