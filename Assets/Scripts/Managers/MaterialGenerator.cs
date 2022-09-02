using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;
public class MaterialGenerator : MonoBehaviour
{
    public static MaterialGenerator instance;

    [Title("Current Materials")]
    [SerializeField] private int spawnAmount;
    private int currentlySpawned;
    
    
    [Title("Bounds")]
    [SerializeField]private BoxCollider2D bounds;

    [Title("Materials")] public List<BaseMaterial> materials;
    
    [Title("Container")]
    [SerializeField] private Transform container;
    
    //Generation will change
    [Title("Testing Variables")] public GameObject testPrefab;
    private void Start()
    {
        instance = this;
        SpawnMaterials();
    }



    private void SpawnMaterials()
    {
        //TODO: Change Generation to something more interesting
        for(var i = 0; i < spawnAmount; i++)
        {

            var randomPosition = new Vector3(Random.Range(bounds.bounds.min.x, bounds.bounds.max.x),
                Random.Range(bounds.bounds.min.y, bounds.bounds.max.y),0);
            var go = Instantiate(testPrefab, randomPosition,
                Quaternion.identity, container);
        }
    }

    private void DestroyAllMaterials()
    {
        
    }

    [ContextMenu("Regenerate")]
    public void Regenerate()
    {
        DestroyAllMaterials();
        SpawnMaterials();
    }
}

