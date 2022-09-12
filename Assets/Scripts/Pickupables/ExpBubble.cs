using System.Collections;
using System.Collections.Generic;
using Pickupables;
using UnityEngine;

public class ExpBubble : Pickupable
{
    [SerializeField] private int expAmount;
    
    public override void OnPickup()
    {
        PlayerInventory.instance.GetExperience(expAmount);
        Destroy(gameObject);
    }
}
