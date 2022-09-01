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

    [SerializeField] private Dictionary<BaseMaterial, int> materials = new();
    private void Awake()
    {
        instance = this;
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
}
