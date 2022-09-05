using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftableAbilityUI : MonoBehaviour
{
   [SerializeField] private CraftingRecipe recipe;

   
   [SerializeField] private Transform neededMaterialsGroup;
   [SerializeField] private GameObject materialPrefab;
   
   [SerializeField]private string recipeName;
   //TODO Implement this later on
   [SerializeField]private string recipeDescription;

   [SerializeField]private TextMeshProUGUI recipeNameText;


   public void InjectInfo(CraftingRecipe newRecipe)
   {
      recipe = newRecipe;
      recipeNameText.SetText(recipe.recipeName);
      CreateMaterials();
   }
   void CreateMaterials()
   {
      foreach (var ingredient in recipe.ingredientsList)
      {
         var newMaterial = Instantiate(materialPrefab, neededMaterialsGroup);
        var amountText= newMaterial.GetComponentInChildren<TextMeshProUGUI>();
        
         amountText.SetText(ingredient.amount.ToString());
         var materialImage = newMaterial.GetComponentInChildren<Image>();
         materialImage.sprite = ingredient.material.materialIcon;
      }
   }
   
}
