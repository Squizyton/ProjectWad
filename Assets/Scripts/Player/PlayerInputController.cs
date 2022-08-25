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
                currentGun.Fire();

            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           currentGun.Fire();
        }
        
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
            currentGun.Reload();
        
        
        if(Input.GetKeyDown(KeyCode.R))
            currentGun.Reload();
    }

}
