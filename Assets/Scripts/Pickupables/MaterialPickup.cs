using System.Collections;
using System.Collections.Generic;
using Pickupables;
using Sirenix.OdinInspector;
using UnityEngine;

public class MaterialPickup : Pickupable
{
   
   [Title("Material Variables")]
   [SerializeField] private Sprite materialSprite;
   
   [SerializeField] private BaseMaterial materialToPickup;


   private void Start()
   {
      materialSprite = materialToPickup.materialIcon;
   }

   public override void OnPickup()
   {
      PlayerInventory.instance.AddMaterial(materialToPickup,(int)Random.Range(materialToPickup.materialAmountPerStack.x,materialToPickup.materialAmountPerStack.y));
      Destroy(gameObject);
   }
}
