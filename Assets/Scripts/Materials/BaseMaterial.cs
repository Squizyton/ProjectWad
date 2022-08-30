using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "New Material", fileName = "New Material")]
public class BaseMaterial : ScriptableObject
{
    [Title("Basic Variables")]
    public string materialName;
    public string materialDescription;
    public Sprite materialIcon;
    
    [Title("Material Amount")]
    [MinMaxSlider(0,10,true)]
    public Vector2 materialAmountPerStack;

    [Title("Weight")] [Range(0, 1f)] public float weight;
}
