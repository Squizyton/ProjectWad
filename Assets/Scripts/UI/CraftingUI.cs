using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
  [SerializeField]private CanvasGroup craftingUI;
  
  [SerializeField]private CraftableAbilityUI craftingAbilityPrefab;
  [SerializeField] private Transform[] currentPrefabs;
  
  [SerializeField]private Transform craftingAbilityParent;

  private void Start()
  {
    
    currentPrefabs = new Transform[3];

    CreateAbilities();

    craftingUI.alpha = 0;
  }

  private void CreateAbilities()
  {
    for(var x = 0; x < currentPrefabs.Length; x++)
    {
      var craftableAbilityUI = Instantiate(craftingAbilityPrefab, craftingAbilityParent);
        craftableAbilityUI.InjectInfo(AbilitiesManager.Instance.GetRandomRecipe());
    } 
  }

}
