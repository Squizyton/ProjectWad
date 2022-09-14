using System;
using System.Collections;
using System.Collections.Generic;
using Guns;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerInventory : SerializedMonoBehaviour
{
    public static PlayerInventory instance;

    [SerializeField] private BaseGun currentGun;
    [SerializeField] private int currentExp;
    [SerializeField] private int currentLevel;
    [SerializeField] private int neededExp;
    [SerializeField] private Dictionary<BaseMaterial, int> materials = new();
    private Action onExpGet;
    private void Awake()
    {
        instance = this;
        currentLevel = 1;
        UIManager.instance.SetLevelText(currentLevel);
        UIManager.instance.SetExpSliderMax(neededExp);
    }

    public BaseGun GetCurrentGun()
    {
        return currentGun;
    }

    public void AddMaterial(BaseMaterial material, int amount)
    {
        if(materials.ContainsKey(material))
        {
            materials[material] += amount;
        }
        else
        {
            materials.Add(material, amount);
        }
    }
    
    public void RemoveMaterial(BaseMaterial material, int amount)
    {
        if(materials.ContainsKey(material))
        {
            materials[material] -= amount;
        }
    }
    
    
    public bool CheckMaterial(BaseMaterial material, int amount)
    {
        if (!materials.ContainsKey(material)) return false;
        
        return materials[material] >= amount;
    }
    
    public void GetExperience(int amount)
    {
        currentExp += amount;
        if (currentExp >= neededExp)
        {
            currentLevel++;
            UIManager.instance.SetLevelText(currentLevel);
            neededExp = (int)(neededExp * 2.5f);
            currentExp = 0;
        }
        UIManager.instance.SetExpSlider(currentExp);
    }
}
