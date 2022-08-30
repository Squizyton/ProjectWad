using System;
using System.Collections;
using System.Collections.Generic;
using Guns;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    [SerializeField] private BaseGun currentGun;

    private void Awake()
    {
        instance = this;
    }
    
    
    public BaseGun GetCurrentGun()
    {
        return currentGun;
    }
}
