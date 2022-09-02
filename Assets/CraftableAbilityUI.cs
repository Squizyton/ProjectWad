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
      recipeName = recipe.recipeName;

      CreateMaterials();
   }
   void CreateMaterials()
   {
      foreach (var ingredient in recipe.ingredientsList)
      {
         var newMaterial = Instantiate(materialPrefab, neededMaterialsGroup);
         newMaterial.TryGetComponent(out TextMeshProUGUI amountText);
         amountText.SetText(ingredient.amount.ToString());
         newMaterial.TryGetComponent(out Image materialImage);
         materialImage.sprite = ingredient.material.materialIcon;
      }
   }
   
}
