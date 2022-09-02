using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Crafting
{
    [CreateAssetMenu(menuName = "New Crafting Recipe",fileName = "New Crafting Recipe")]
    public class BulletCraftingRecipe : CraftingRecipe
    {
        [Title("End Results")]
        public BaseBulletAbility bulletAbility;
    }

 
}