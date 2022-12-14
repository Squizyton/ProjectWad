using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AbilitiesManager : MonoBehaviour
{
   
   public static AbilitiesManager Instance;
   
   [Title("Crafting Abilities")]
   [SerializeField]private List<CraftingRecipe> craftingRecipes = new ();
   private List<CraftingRecipe> usedRecipes = new ();
   
   
   private void Awake()
   {
      Instance = this;
   }

   public CraftingRecipe GetRandomRecipe()
   {
      return craftingRecipes[0];
   }
   
   public void AddUsedRecipe(CraftingRecipe recipe)
   {
      usedRecipes.Add(recipe);
      craftingRecipes.Remove(recipe);
   }
}
