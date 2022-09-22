using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletons;
public class CraftingUI : SingletonBehaviour<CraftingUI>
{

  [SerializeField]private CanvasGroup craftingUI;
  
  [SerializeField]private CraftableAbilityUI craftingAbilityPrefab;
  [SerializeField]private Transform[] currentRecipesPrefabs;
  
  [SerializeField]private Transform craftingAbilityParent;

  
  private void Start()
  {
    
    currentRecipesPrefabs = new Transform[3];

    CreateAbilities();
  }

  private void CreateAbilities()
  {
    for(var x = 0; x < currentRecipesPrefabs.Length; x++)
    {
        var craftableAbilityUI = Instantiate(craftingAbilityPrefab, craftingAbilityParent);
        craftableAbilityUI.InjectInfo(AbilitiesManager.Instance.GetRandomRecipe());
        currentRecipesPrefabs[x] = craftableAbilityUI.transform;
    } 
  }

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.Escape))
      UIManager.instance.CraftingPanel(false);
  }


  public void CraftRecipe(CraftingRecipe recipe)
  {
    try
    {
      foreach(var materials in recipe.ingredientsList)
      {
        if (PlayerInventory.instance.CheckMaterial(materials.material, materials.amount))
        {
          PlayerInventory.instance.RemoveMaterial(materials.material, materials.amount);
          AbilitiesManager.Instance.AddUsedRecipe(recipe);
        }
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


  public void DestroyAbilityRecipes()
  {
    foreach (var prefab in currentRecipesPrefabs)
    {
      Destroy(prefab.gameObject);
      
    }
  }
}
