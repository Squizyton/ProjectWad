using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public static UIManager instance;
   
   [Title("EXP Elements")]
   [SerializeField] private Slider expSlider;

   [SerializeField] private TextMeshProUGUI levelText;

   private void Awake()
   {
      instance = this;
   }


   #region EXP
   public void SetExpSlider(float exp)
   {
      Debug.Log("SetExpSlider"); 
      expSlider.value = exp;
   }
   
   public void SetExpSliderMax(float exp)
   {
      ResetSlider();
      expSlider.maxValue = exp;
   }
   
   public void SetLevelText(int level)
   {
      levelText.text = level.ToString();
   }
   
   private void ResetSlider()
   {
      expSlider.value = 0;
   }
   #endregion
   
   #region Crafting
   
   
   #endregion
}
