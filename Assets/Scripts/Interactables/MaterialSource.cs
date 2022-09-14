using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class MaterialSource : MonoBehaviour,IInteractable
{
    [SerializeField] private MaterialPickup material;
    
    
    
    [SerializeField] private int spawnAmount;

    [Title("Spawn Settings")]
    [SerializeField] private float radius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool debugSpawn;
    public void OnInteract()
    {
        for (var i = 0; i < spawnAmount; i++)
        {
            var xPos = MathF.Cos(Mathf.Deg2Rad * Random.Range(0, 360)) * Random.Range(0, radius) + (transform.position.x + offset.x);
            var yPos = MathF.Sin(Mathf.Deg2Rad * Random.Range(0, 360)) * Random.Range(0, radius) + (transform.position.y + offset.y);
            
            var spawnPos = new Vector3(xPos, yPos,0);

            Instantiate(material.gameObject, spawnPos, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }


    private void OnDrawGizmos()
    {

        if (!debugSpawn) return; 
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, radius);
    }
}
