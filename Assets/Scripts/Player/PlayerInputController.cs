using System;
using System.Collections;
using System.Collections.Generic;
using Guns;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField] private BaseGun currentGun;


 

    private void Update()
    {
        
        if (currentGun.autoFire)
        {
            if (Input.GetMouseButton(0))
            {
                PlayerInventory.instance.GetCurrentGun().Fire();

            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerInventory.instance.GetCurrentGun().Fire();
        }
        
        if(Input.GetKeyDown(KeyCode.R))
            PlayerInventory.instance.GetCurrentGun().Reload();
    }

}
