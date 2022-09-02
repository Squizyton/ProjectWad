using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class AbilitiesManager : MonoBehaviour
{
   
   public static AbilitiesManager Instance;
   
   
   
   [Title("Crafting Abilities")]
   [SerializeField]private List<CraftingRecipe> craftingRecipes = new ();
   private List<CraftingRecipe> usedRecipes = new ();


   private void Start()
   {
      Instance = this;
   }

   public CraftingRecipe GetRandomRecipe()
   {
      return craftingRecipes[Random.Range(0, craftingRecipes.Count)];
   }
}
